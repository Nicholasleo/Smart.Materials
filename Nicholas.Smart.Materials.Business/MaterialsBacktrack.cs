using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.Business
{
    public class MaterialsBacktrack
    {
        private static List<string> _hasKey = new List<string>();
        private static int _index = 1;

        /// <summary>
        /// 上限值
        /// </summary>
        private static int _maxNum;
        /// <summary>
        /// 下限值
        /// </summary>
        public static int MinNum;

        private static int GetMaxNum()
        {
            SystemConfigXml systemConfigXml = new SystemConfigXml();
            int area = 0;
            string width = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Width", "");
            if (!string.IsNullOrEmpty(width))
            {
                int.TryParse(width, out area);
            }
            return area;
        }

        public static List<Ent2> CountList(List<Ent1> list)
        {
            List<Ent2> resultList = new List<Ent2>();
            _index = 1; 
            _maxNum = GetMaxNum();
            try
            {
                List<Ent2> newList = GetNewList(list);
                newList = newList.OrderByDescending(s=>s.MyEnt.Depth).ThenByDescending(s => s.MyEnt.Length).ThenByDescending(s => s.MyEnt.Area).ToList();
                int total = 0;
                //剔除单个类型的型材可以满足一张板的型材
                foreach (var item in newList)
                {
                    total = item.MyEnt.Area*item.MyEnt.Qty;
                    if (total <= _maxNum && total >= _maxNum - 10)
                    {
                        Ent2 tEnt2 = new Ent2();
                        tEnt2.Key = "BC" + _index++;
                        tEnt2.MyEnt = item.MyEnt;
                        tEnt2.Area = total;
                        resultList.Add(tEnt2);
                        _hasKey.Add(item.Key);
                    }
                }

            START: RemoveItem(ref newList, _hasKey);
                total = 0;
                _hasKey.Clear();
                if (newList.Count <= 0)
                    return resultList;
                int listIndex = 1;
                int listCount = newList.Count;
                string depth = string.Empty;
                foreach (var item in newList)
                {
                    if (string.IsNullOrEmpty(depth))
                        depth = item.MyEnt.Depth;
                    if(_hasKey.Contains(item.Key))
                        continue;
                    if(item.MyEnt.Qty <= 0)
                        continue;
                    if(depth != item.MyEnt.Depth)
                        continue;
                    int tempQty = item.MyEnt.Qty;
                    for (int i = 1; i <= tempQty; i++)
                    {
                        total += item.MyEnt.Area;
                        if (total <= _maxNum && total >= _maxNum - 10)
                        {
                            Ent1 tEnt = new Ent1();
                            tEnt.Length = item.MyEnt.Length;
                            tEnt.Area = item.MyEnt.Area;
                            tEnt.Depth = item.MyEnt.Depth;
                            tEnt.Path = item.MyEnt.Path;
                            tEnt.Qty = i;

                            Ent2 tEnt2 = new Ent2();
                            tEnt2.Key = "BC" + _index;
                            tEnt2.MyEnt = tEnt;
                            tEnt2.Area = total;
                            resultList.Add(tEnt2);
                            if(i == tempQty)
                                _hasKey.Add(item.Key);
                            _index++;
                            item.MyEnt.Qty -= i;
                            goto START;
                        }
                        else if (total <= _maxNum && i == tempQty)
                        {
                            Ent1 tEnt = new Ent1();
                            tEnt.Length = item.MyEnt.Length;
                            tEnt.Area = item.MyEnt.Area;
                            tEnt.Qty = item.MyEnt.Qty;
                            tEnt.Depth = item.MyEnt.Depth;
                            tEnt.Path = item.MyEnt.Path;

                            Ent2 tEnt2 = new Ent2();
                            tEnt2.Key = "BC" + _index;
                            tEnt2.MyEnt = tEnt;
                            tEnt2.Area = total;
                            resultList.Add(tEnt2);
                            _hasKey.Add(item.Key);
                        }
                        else if (total == _maxNum && i < tempQty)
                        {
                            Ent1 tEnt = new Ent1();
                            tEnt.Length = item.MyEnt.Length;
                            tEnt.Area = item.MyEnt.Area;
                            tEnt.Qty = i;
                            tEnt.Depth = item.MyEnt.Depth;
                            tEnt.Path = item.MyEnt.Path;

                            Ent2 tEnt2 = new Ent2();
                            tEnt2.Key = "BC" + _index;
                            tEnt2.MyEnt = tEnt;
                            tEnt2.Area = total;
                            resultList.Add(tEnt2);
                            item.MyEnt.Qty -= i;
                            _index++;
                            goto START;
                        }
                        else if (total > _maxNum && i != tempQty)
                        {
                            total -= item.MyEnt.Area;
                            if (total < _maxNum)
                            {
                                Ent1 tEnt = new Ent1();
                                tEnt.Length = item.MyEnt.Length;
                                tEnt.Area = item.MyEnt.Area;
                                tEnt.Depth = item.MyEnt.Depth;
                                tEnt.Path = item.MyEnt.Path;
                                tEnt.Qty = (i - 1);

                                Ent2 tEnt2 = new Ent2();
                                tEnt2.Key = "BC" + _index;
                                tEnt2.MyEnt = tEnt;
                                tEnt2.Area = total;
                                resultList.Add(tEnt2);
                                item.MyEnt.Qty -= (i - 1);
                            }
                            break;
                        }
                        else if (total > _maxNum && i == tempQty)
                        {
                            if (tempQty > 1)
                            {
                                Ent1 tEnt = new Ent1();
                                tEnt.Length = item.MyEnt.Length;
                                tEnt.Area = item.MyEnt.Area;
                                tEnt.Depth = item.MyEnt.Depth;
                                tEnt.Path = item.MyEnt.Path;
                                tEnt.Qty = (i - 1);

                                Ent2 tEnt2 = new Ent2();
                                tEnt2.Key = "BC" + _index;
                                tEnt2.MyEnt = tEnt;
                                tEnt2.Area = total - item.MyEnt.Area * (i - 1);
                                resultList.Add(tEnt2);
                                item.MyEnt.Qty -= (i - 1);
                                if (listIndex == listCount)
                                {
                                    _index++;
                                    goto START;
                                }
                            }
                            total -= item.MyEnt.Area;
                        }
                    }
                    listIndex++;
                }
                if (newList.Count > 0)
                {
                    _index++;
                    goto START;
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return resultList;
        }

        private static void RemoveItem(ref List<Ent2> list, List<string> key)
        {
            key = key.Distinct().ToList();
            List<Ent2> newList = new List<Ent2>();
            foreach (var item in list)
            {
                if (!key.Contains(item.Key))
                    newList.Add(item);
            }
            list = newList;
        }

        /// <summary>
        /// 获取新的列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<Ent2> GetNewList(List<Ent1> list)
        {
            list = list.OrderByDescending(s => s.Length).ThenByDescending(s=>s.Area).ToList();
            List<Ent2> newList = new List<Ent2>();
            int keyCount = 1000;
            foreach (var ent in list)
            {
                Ent2 ent2 = new Ent2();
                ent2 = new Ent2();
                ent2.MyEnt = ent;
                ent2.Key = "MyKey" + keyCount++;
                newList.Add(ent2);
            }
            return newList;
        }

        //private List<Ent2> DCountList(ref List<Ent2> list3, ref List<string> hasKey, int maxNum, int minNum, ref int index)
        
    }
}
