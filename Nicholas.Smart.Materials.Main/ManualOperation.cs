using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Enity;
using System.ComponentModel;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmMain
    {
        private SystemConfigXml systemConfigXml = new SystemConfigXml();

        private int _deviation1 = 100;
        private int _deviation2 = 100;
        private int _deviation3 = 100;
        private int _area = 1000;
        private int _MinArea = 600;

        private Thread thread;
        #region MyRegion

        //private BackgroundWorker bkWorker = new BackgroundWorker();
        //private FrmWaitting frmWait = new FrmWaitting();

        //private void InitC()
        //{
        //    bkWorker.WorkerReportsProgress = true;
        //    bkWorker.WorkerSupportsCancellation = true;
        //    bkWorker.DoWork += new DoWorkEventHandler(DoWork);
        //    bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
        //    bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        //}

        //public void DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // 事件处理，指定处理函数  
        //    result = CountList(entList);
        //    e.Result = ProcessProgress(bkWorker, e);
        //}

        //public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    // bkWorker.ReportProgress 会调用到这里，此处可以进行自定义报告方式  
        //    frmWait.SetNotifyInfo(e.ProgressPercentage, "处理进度:" + Convert.ToString(e.ProgressPercentage) + "%");
        //}

        //public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    frmWait.Close();
        //    MessageBox.Show(@"处理完毕!");
        //}

        //private int ProcessProgress(object sender, DoWorkEventArgs e)
        //{
        //    for (int i = 0; i <= 1000; i++)
        //    {
        //        if (bkWorker.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            return -1;
        //        }
        //        else
        //        {
        //            // 状态报告  
        //            bkWorker.ReportProgress(i / 10);

        //            // 等待，用于UI刷新界面，很重要  
        //            System.Threading.Thread.Sleep(1);
        //        }
        //    }

        //    return -1;
        //}
        ///// <summary>  
        ///// 步进值  
        ///// </summary>  
        //private int percentValue = 0; 
        #endregion

        private void CheckReg()
        {
            bool _isReg = true;
            string _errorInfo;
            int _infoType;
            bool isTrial = false;
            CheckRegInfo.CheckReg(ref _isReg, out _errorInfo, out _infoType,out isTrial);
            if (isTrial)
            {
                MessageBox.Show(string.Format(@"当前版本为试用版，可免费试用{0}次！", 6 - CheckRegInfo.GetLoginTimes()), @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!_isReg)
            {
                MessageBox.Show(_errorInfo, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new FrmRegister();
                DialogResult loginDiaSul = frm.ShowDialog();
                if (loginDiaSul == DialogResult.OK)
                {
                    _isReg = frm.RegSuccess;
                    frm.Dispose();
                    if (_isReg)
                    {
                        return;
                    }
                }
            }
        }

        private void tsbOk_Click(object sender, EventArgs e)
        {
            #if !DEBUG
            CheckReg();
	        #endif

            //percentValue = 10;
            //this.progressBar1.Maximum = 1000;
            //frmWait.StartPosition = FormStartPosition.CenterParent;

            try
            {

                GetConfig();
                entList = new List<Ent1>();
                dgvSource.EndEdit();
                int n = dgvSource.RowCount - 1;
                for (int i = 0; i < n; i++)
                {
                    Ent1 ent1 = new Ent1();
                    int length = 0;
                    int qty = 0;
                    int area = 0;
                    int.TryParse(dgvSource.Rows[i].Cells["Length"].Value == null ? "0" : dgvSource.Rows[i].Cells["Length"].Value.ToString(), out length);
                    int.TryParse(dgvSource.Rows[i].Cells["Qty"].Value == null ? "0" : dgvSource.Rows[i].Cells["Qty"].Value.ToString(), out qty);
                    int.TryParse(dgvSource.Rows[i].Cells["Area"].Value == null ? "0" : dgvSource.Rows[i].Cells["Area"].Value.ToString(), out area);
                    ent1.Length = length;
                    ent1.Area = area;
                    ent1.Qty = qty;
                    if (length + area + qty == 0)
                        continue;
                    entList.Add(ent1);
                }
                if (entList == null || entList.Count <= 0)
                {
                    MessageBox.Show(@"数据有误！");
                    return;
                }

                //bkWorker.RunWorkerAsync();
                //frmWait.ShowDialog();
                LoadDataAysnc();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable("Tree1");
            //dt.Columns.Add("Key", Type.GetType("System.String"));
            //dt.Columns.Add("Length", Type.GetType("System.Int32"));
            //dt.Columns.Add("Qty", Type.GetType("System.Int32"));
            //dt.Columns.Add("Area", Type.GetType("System.Int32"));
            //dt.Columns.Add("AreaSum", Type.GetType("System.Int32"));
            //dt.Columns.Add("Key1", Type.GetType("System.String"));
            //if (result == null || result.Count <= 0)
            //    return;
            //foreach (var ent2 in result)
            //{
            //    if (ent2.MyEnt.Qty <= 0)
            //        continue;
            //    DataRow newRow = dt.NewRow();
            //    newRow["Key"] = ent2.Key;
            //    newRow["Key1"] = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" + ent2.MyEnt.Area + ".png";
            //    if (ent2.Area == 0)
            //        ent2.Area = ent2.MyEnt.Area * ent2.MyEnt.Qty;
            //    newRow["AreaSum"] = ent2.Area;
            //    newRow["Length"] = ent2.MyEnt.Length;
            //    newRow["Qty"] = ent2.MyEnt.Qty;
            //    newRow["Area"] = ent2.MyEnt.Area;
            //    dt.Rows.Add(newRow);
            //    //lbView.Items.Add(ent2.MainKey + ":" + ent2.MyEnt.Length + "_" + ent2.MyEnt.Qty + "条" + "_" + ent2.MyEnt.Area);
            //}
            var frm = new FrmResult(ResultTable);
            frm.ShowDialog();
            frm.Dispose();
        }

        private delegate void LoadData(List<Ent1> list);

        public DataTable ResultTable = new DataTable();

        private List<Ent2> result;
        /// <summary>
        /// 计算
        /// </summary>
        private void LoadDataAysnc()
        {
#if DEBUG
#endif

            //result = CountList(entList);
            result = MaterialsBacktrack.CountList(entList);
            if (result.Count < 0)
                return;
            ResultTable.Clear();
            //lbView.Items.Clear();
            foreach (var ent2 in result)
            {
                if (ent2.MyEnt.Qty <= 0)
                    continue;
                DataRow newRow = ResultTable.NewRow();
                newRow["Key"] = ent2.Key;
                newRow["Key1"] = ent2.Key;
                if (ent2.Area == 0)
                    ent2.Area = ent2.MyEnt.Area * ent2.MyEnt.Qty;
                newRow["AreaSum"] = ent2.Area;
                newRow["Length"] = ent2.MyEnt.Length;
                newRow["Qty"] = ent2.MyEnt.Qty;
                newRow["Area"] = ent2.MyEnt.Area;
                ResultTable.Rows.Add(newRow);
                //lbView.Items.Add(ent2.MainKey + ":" + ent2.MyEnt.Length + "_" + ent2.MyEnt.Qty + "条" + "_" + ent2.MyEnt.Area);
            }
            dgvResult.DataSource = ResultTable;
            if (dgvResult.Columns.Contains("Key1"))
            {
                dgvResult.Columns["Key1"].Visible = false;
            }
            dgvResult.AutoGenerateColumns = true;
            dgvResult.SummaryColumns = new string[] { "Qty" };
            dgvResult.SummaryRowVisible = true;
        }

        private void GetConfig()
        {
            string deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation1", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out _deviation1);
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation2", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out _deviation2);
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation3", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out _deviation3);
            }
            string width = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Width", "");
            if (!string.IsNullOrEmpty(width))
            {
                int.TryParse(width, out _area);
            }
        }
        private List<Ent2> CountList(List<Ent1> list)
        {
            //list = list.OrderBy(s => s.Length).ToList();
            list = list.OrderByDescending(s => s.Length).ToList();
            List<Ent2> list3 = new List<Ent2>();
            int keyCount = 1000;
            foreach (var ent in list)
            {
                Ent2 ent2 = new Ent2();
                ent2 = new Ent2();
                ent2.MyEnt = ent;
                ent2.Key = "MyKey" + keyCount++;
                list3.Add(ent2);
            }

            //Backtrack back = new Backtrack(list3, _area, 800);
            //back.GetMainKey();


            List<Ent2> resultList = new List<Ent2>();

            List<string> hasKey = new List<string>();
            hasKey.Clear();

            
#if DEBUG
            DateTime beforDT = System.DateTime.Now;
#endif
            thread = new Thread(() =>
            {
                int index = 1;
                //有问题耗时过大
                list3 = list3.OrderByDescending(s => s.MyEnt.Length).ThenByDescending(s => s.MyEnt.Area).ToList();
                resultList = resultList.Concat(DCountList(ref list3, ref hasKey, _area, _area - 70, ref index)).ToList();

#if DEBUG
                DateTime afterDT = System.DateTime.Now;
                TimeSpan ts = afterDT.Subtract(beforDT);
                Console.WriteLine(@"计算930以上的整料总共花费{0}s.", ts.TotalSeconds);
                beforDT = System.DateTime.Now;
#endif

                list3 = list3.OrderByDescending(s => s.MyEnt.Length).ThenByDescending(s => s.MyEnt.Area).ToList();
                resultList = resultList.Concat(DCountList(ref list3, ref hasKey, _area, _area - 150, ref index)).ToList();

#if DEBUG
                afterDT = System.DateTime.Now;
                ts = afterDT.Subtract(beforDT);
                Console.WriteLine(@"计算850以上的整料总共花费{0}s.", ts.TotalSeconds);
                beforDT = System.DateTime.Now;
#endif
                //计算剩余的材料
                list3 = list3.OrderByDescending(s => s.MyEnt.Length).ThenByDescending(s => s.MyEnt.Area).ToList();
                resultList = resultList.Concat(CountShengyu(ref list3, ref hasKey, _area, _area - 250, ref index)).ToList();
                
                foreach (var item in list3)
                {
                    Ent2 ent = new Ent2();
                    ent.Key = "XC" + index++;
                    ent.MyEnt = item.MyEnt;
                    resultList.Add(ent);
                }

#if DEBUG
                afterDT = System.DateTime.Now;
                ts = afterDT.Subtract(beforDT);
                Console.WriteLine(@"计算剩余散料总共花费{0}s.", ts.TotalSeconds);
#endif
            });
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            return resultList;
        }


        //回溯法统计结果

        private List<Ent2> CountShengyu(ref List<Ent2> list3, ref List<string> hasKey, int maxNum, int minNum, ref int index)
        {
            List<Ent2> resultList = new List<Ent2>();
            int total = 0;
            List<string> xHasKey = new List<string>();
        START1://RemoveItem(ref list3,hasKey);
            //hasKey.Clear();
            foreach (var ent2 in list3)
            {
                if (hasKey.Contains(ent2.Key))
                    continue;
                if (ent2.MyEnt.Qty == 0)
                    continue;
                total = ent2.MyEnt.Qty * ent2.MyEnt.Area;
                xHasKey.Add(ent2.Key);
                if (total <= maxNum && total >= minNum)
                {
                    Ent2 ent = new Ent2();
                    ent.MyEnt = ent2.MyEnt;
                    ent.Area = total;
                    ent.Key = "XC" + index++;
                    resultList.Add(ent);
                    continue;
                }
                foreach (var ent21 in list3)
                {
                    if (xHasKey.Contains(ent21.Key) || hasKey.Contains(ent21.Key))
                        continue;
                    if (Math.Abs(ent2.MyEnt.Length - ent21.MyEnt.Length) > GetDeviation(ent2.MyEnt.Length))
                        continue;
                    if (ent21.MyEnt.Qty == 0)
                        continue;
                    for (int i = 1; i <= ent21.MyEnt.Qty; i++)
                    {
                        total += ent21.MyEnt.Area;
                        if (total <= maxNum && total >= minNum)
                        {
                            Ent1 ent1 = new Ent1();
                            ent1.Length = ent21.MyEnt.Length;
                            ent1.Area = ent21.MyEnt.Area;
                            ent1.Qty = i;

                            if (i == ent21.MyEnt.Qty)
                            {
                                hasKey.Add(ent21.Key);
                                xHasKey.Add(ent21.Key);
                            }


                            Ent2 ent = new Ent2();
                            ent.MyEnt = ent2.MyEnt;
                            ent.Area = total;
                            ent.Key = "XC" + index;
                            resultList.Add(ent);
                            hasKey.Add(ent2.Key);

                            ent = new Ent2();
                            ent.MyEnt = ent1;
                            ent.Area = total;
                            ent.Key = "XC" + index++;
                            resultList.Add(ent);
                            ent21.MyEnt.Qty -= i;
                            goto START1;
                        }
                    }
                    if (total < maxNum)
                    {
                        Ent2 ent4 = new Ent2();
                        if (!hasKey.Contains(ent2.Key))
                        {
                            ent4.MyEnt = ent2.MyEnt;
                            ent4.Area = total;
                            ent4.Key = "XC" + index;
                            resultList.Add(ent4);
                            hasKey.Add(ent2.Key);
                        }

                        ent4 = new Ent2();
                        ent4.MyEnt = ent21.MyEnt;
                        ent4.Area = total;
                        ent4.Key = "XC" + index;
                        resultList.Add(ent4);
                        hasKey.Add(ent21.Key);
                        xHasKey.Add(ent21.Key);
                    }
                    else
                    {
                        index++;
                        goto START1;
                    }
                }
            }
            hasKey = hasKey.Distinct().ToList();
            List<Ent2> list4 = new List<Ent2>();
            foreach (var item in list3)
            {
                if (!hasKey.Contains(item.Key) && item.MyEnt.Qty > 0)
                    list4.Add(item);
            }
            list3 = list4;
            return resultList;
        }


        private int GetDeviation(int length)
        {
            //if (length < 2000)
            //{
            //    return _deviation1;
            //}
            //else if (length >= 2000 && length < 3000)
            //{
            //    return _deviation2;
            //}
            //else if (length >= 3000)
            //{
            //    return _deviation3;
            //}
            return _area;
        }

        private List<Ent2> DCountList(ref List<Ent2> list3, ref List<string> hasKey, int maxNum, int minNum, ref int index)
        {
            List<Ent2> resultList = new List<Ent2>();
        START: RemoveItem(ref list3, hasKey);
            hasKey.Clear();
            if (list3.Count <= 0)
                return resultList;
            list3 = list3.OrderByDescending(s => s.MyEnt.Length).ThenByDescending(s => s.MyEnt.Area).ToList();
            foreach (var item in list3)
            {
                int xTotal = 0;
                #region 一张板本身满足条件
                xTotal = item.MyEnt.Area * item.MyEnt.Qty;
                if (xTotal <= maxNum && xTotal >= minNum)
                {
                    Ent1 tEnt = new Ent1();
                    tEnt.Length = item.MyEnt.Length;
                    tEnt.Area = item.MyEnt.Area;
                    tEnt.Qty = item.MyEnt.Qty;

                    Ent2 tEnt2 = new Ent2();
                    tEnt2.Key = "XC" + index++;
                    tEnt2.MyEnt = tEnt;
                    tEnt2.Area = xTotal;
                    resultList.Add(tEnt2);
                    hasKey.Add(item.Key);
                    goto START;
                }
                #endregion
            }


            List<string> tHasKey = new List<string>();
            foreach (var ent in list3)
            {
                if (hasKey.Contains(ent.Key))
                    continue;

                if (ent.MyEnt.Qty == 0)
                {
                    continue;
                }

                int xTotal = 0;

                #region 计算单条记录
                for (int i = 1; i <= ent.MyEnt.Qty; i++)
                {
                    xTotal += ent.MyEnt.Area;
                    //单个满条件
                    if (xTotal <= maxNum && xTotal >= minNum)
                    {
                        Ent1 tEnt = new Ent1();
                        tEnt.Length = ent.MyEnt.Length;
                        tEnt.Area = ent.MyEnt.Area;
                        tEnt.Qty = i;

                        Ent2 tEnt2 = new Ent2();
                        tEnt2.Key = "BC" + index++;
                        tEnt2.MyEnt = tEnt;
                        tEnt2.Area = xTotal;
                        resultList.Add(tEnt2);
                        if (i == ent.MyEnt.Qty)
                        {
                            hasKey.Add(ent.Key);
                        }
                        ent.MyEnt.Qty -= i;
                        goto START;
                    }
                }
                tHasKey.Add(ent.Key);


                #endregion

                List<string> xHasKey = new List<string>();

                foreach (var ent1 in list3)
                {
                    #region 2条记录满条件
                    if (tHasKey.Contains(ent1.Key) || hasKey.Contains(ent1.Key))
                        continue;
                    if (Math.Abs(ent.MyEnt.Length - ent1.MyEnt.Length) > GetDeviation(ent1.MyEnt.Length))
                        continue;
                    //int yTotal = ent1.MyEnt.Qty * ent1.MyEnt.Area;
                    int yTotal = 0;
                    if (ent1.MyEnt.Qty == 0)
                    {
                        continue;
                    }

                    for (int i = 1; i <= ent1.MyEnt.Qty; i++)
                    {
                        yTotal += ent1.MyEnt.Area;
                        if (xTotal + yTotal <= maxNum && xTotal + yTotal >= minNum)
                        {
                            Ent1 tEnt = new Ent1();
                            tEnt.Length = ent1.MyEnt.Length;
                            tEnt.Area = ent1.MyEnt.Area;
                            tEnt.Qty = i;
                            Ent2 tEnt2 = new Ent2();
                            tEnt2.Key = "BC" + index;
                            tEnt2.MyEnt = tEnt;
                            tEnt2.Area = xTotal + yTotal;
                            resultList.Add(tEnt2);

                            tEnt2 = new Ent2();
                            tEnt2.Key = "BC" + index++;
                            tEnt2.MyEnt = ent.MyEnt;
                            tEnt2.Area = xTotal + yTotal;
                            resultList.Add(tEnt2);
                            hasKey.Add(ent.Key);
                            if (i == ent1.MyEnt.Qty)
                            {
                                hasKey.Add(ent1.Key);
                            }
                            ent1.MyEnt.Qty -= i;
                            goto START;
                        }
                    }
                    xHasKey.Add(ent1.Key);
                    #endregion

                    #region 3条记录满足条件
                    List<string> pHasKey = new List<string>();
                    foreach (var ent2 in list3)
                    {
                        if (tHasKey.Contains(ent2.Key) || hasKey.Contains(ent2.Key) || xHasKey.Contains(ent2.Key))
                            continue;
                        if (Math.Abs(ent1.MyEnt.Length - ent2.MyEnt.Length) > GetDeviation(ent2.MyEnt.Length) && Math.Abs(ent.MyEnt.Length - ent2.MyEnt.Length) > GetDeviation(ent2.MyEnt.Length))
                            continue;
                        int kTotal = 0;
                        if (ent2.MyEnt.Qty == 0)
                            continue;
                        for (int i = 1; i <= ent2.MyEnt.Qty; i++)
                        {
                            kTotal += ent2.MyEnt.Area;
                            if (xTotal + yTotal + kTotal <= maxNum && xTotal + yTotal + kTotal >= minNum)
                            {
                                hasKey.Add(ent.Key);
                                hasKey.Add(ent1.Key);

                                Ent2 tEnt2 = new Ent2();
                                tEnt2.MyEnt = ent.MyEnt;
                                tEnt2.Key = "BC" + index;
                                tEnt2.Area = xTotal + yTotal + kTotal;
                                resultList.Add(tEnt2);

                                tEnt2 = new Ent2();
                                tEnt2.MyEnt = ent1.MyEnt;
                                tEnt2.Key = "BC" + index;
                                tEnt2.Area = xTotal + yTotal + kTotal;
                                resultList.Add(tEnt2);

                                Ent1 tEnt = new Ent1();
                                tEnt.Length = ent2.MyEnt.Length;
                                tEnt.Area = ent2.MyEnt.Area;
                                tEnt.Qty = i;

                                tEnt2 = new Ent2();
                                tEnt2.MyEnt = tEnt;
                                tEnt2.Key = "BC" + index++;
                                tEnt2.Area = xTotal + yTotal + kTotal;
                                resultList.Add(tEnt2);

                                if (i == ent2.MyEnt.Qty)
                                {
                                    hasKey.Add(ent2.Key);
                                }
                                ent2.MyEnt.Qty -= i;
                                goto START;
                            }
                        }
                        pHasKey.Add(ent2.Key);
                    #endregion

                        #region 4条记录满足条件
                        //4根组合 
                        List<string> qHasKey = new List<string>();
                        foreach (var item in list3)
                        {
                            if (tHasKey.Contains(item.Key) || hasKey.Contains(item.Key) || xHasKey.Contains(item.Key) || pHasKey.Contains(item.Key))
                                continue;
                            if (Math.Abs(ent2.MyEnt.Length - item.MyEnt.Length) > GetDeviation(item.MyEnt.Length) && Math.Abs(ent1.MyEnt.Length - item.MyEnt.Length) > GetDeviation(item.MyEnt.Length))
                                continue;
                            int tTotal = 0;
                            if (item.MyEnt.Qty == 0)
                            {
                                continue;
                            }
                            for (int i = 1; i <= item.MyEnt.Qty; i++)
                            {
                                tTotal += item.MyEnt.Area;
                                if (xTotal + yTotal + kTotal + tTotal <= maxNum && xTotal + yTotal + kTotal + tTotal >= minNum)
                                {
                                    hasKey.Add(ent.Key);
                                    hasKey.Add(ent1.Key);
                                    hasKey.Add(ent2.Key);

                                    Ent2 tEnt2 = new Ent2();
                                    tEnt2.MyEnt = ent.MyEnt;
                                    tEnt2.Key = "BC" + index;
                                    tEnt2.Area = xTotal + yTotal + kTotal + tTotal;
                                    resultList.Add(tEnt2);

                                    tEnt2 = new Ent2();
                                    tEnt2.MyEnt = ent1.MyEnt;
                                    tEnt2.Key = "BC" + index;
                                    tEnt2.Area = xTotal + yTotal + kTotal + tTotal;
                                    resultList.Add(tEnt2);

                                    tEnt2 = new Ent2();
                                    tEnt2.MyEnt = ent2.MyEnt;
                                    tEnt2.Key = "BC" + index;
                                    tEnt2.Area = xTotal + yTotal + kTotal + tTotal;
                                    resultList.Add(tEnt2);

                                    Ent1 tEnt = new Ent1();
                                    tEnt.Length = item.MyEnt.Length;
                                    tEnt.Area = item.MyEnt.Area;
                                    tEnt.Qty = i;

                                    tEnt2 = new Ent2();
                                    tEnt2.MyEnt = tEnt;
                                    tEnt2.Key = "BC" + index++;
                                    tEnt2.Area = xTotal + yTotal + kTotal + tTotal;
                                    resultList.Add(tEnt2);

                                    if (i == item.MyEnt.Qty)
                                    {
                                        hasKey.Add(item.Key);
                                    }

                                    item.MyEnt.Qty -= i;
                                    goto START;
                                }
                            }
                            qHasKey.Add(item.Key);
                            List<string> oHasKey = new List<string>();
                            foreach (var item1 in list3)
                            {
                                if (tHasKey.Contains(item1.Key) || hasKey.Contains(item1.Key) || xHasKey.Contains(item1.Key) || pHasKey.Contains(item1.Key) || qHasKey.Contains(item1.Key))
                                    continue;
                                if (Math.Abs(item.MyEnt.Length - item1.MyEnt.Length) > GetDeviation(item1.MyEnt.Length) && Math.Abs(item.MyEnt.Length - item1.MyEnt.Length) > GetDeviation(item1.MyEnt.Length))
                                    continue;
                                int qTotal = 0;
                                if (item1.MyEnt.Qty == 0)
                                {
                                    continue;
                                }
                                for (int i = 1; i <= item1.MyEnt.Qty; i++)
                                {
                                    qTotal += item1.MyEnt.Area;
                                    if (xTotal + yTotal + kTotal + tTotal + qTotal <= maxNum && xTotal + yTotal + kTotal + tTotal + qTotal >= minNum)
                                    {
                                        hasKey.Add(ent.Key);
                                        hasKey.Add(ent1.Key);
                                        hasKey.Add(ent2.Key);
                                        hasKey.Add(item.Key);

                                        Ent2 tEnt2 = new Ent2();
                                        tEnt2.MyEnt = ent.MyEnt;
                                        tEnt2.Key = "BC" + index;
                                        tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal;
                                        resultList.Add(tEnt2);

                                        tEnt2 = new Ent2();
                                        tEnt2.MyEnt = ent1.MyEnt;
                                        tEnt2.Key = "BC" + index;
                                        tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal;
                                        resultList.Add(tEnt2);

                                        tEnt2 = new Ent2();
                                        tEnt2.MyEnt = ent2.MyEnt;
                                        tEnt2.Key = "BC" + index;
                                        tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal;
                                        resultList.Add(tEnt2);

                                        tEnt2 = new Ent2();
                                        tEnt2.MyEnt = item.MyEnt;
                                        tEnt2.Key = "BC" + index;
                                        tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal;
                                        resultList.Add(tEnt2);

                                        Ent1 tEnt = new Ent1();
                                        tEnt.Length = item1.MyEnt.Length;
                                        tEnt.Area = item1.MyEnt.Area;
                                        tEnt.Qty = i;

                                        tEnt2 = new Ent2();
                                        tEnt2.MyEnt = tEnt;
                                        tEnt2.Key = "BC" + index++;
                                        tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal;
                                        resultList.Add(tEnt2);

                                        if (i == item1.MyEnt.Qty)
                                        {
                                            hasKey.Add(item1.Key);
                                        }
                                        item1.MyEnt.Qty -= i;
                                        goto START;
                                    }
                                }
                                oHasKey.Add(item1.Key);


                                #region
                                List<string> mHasKey = new List<string>();
                                foreach (var item2 in list3)
                                {
                                    if (tHasKey.Contains(item2.Key) || hasKey.Contains(item2.Key) || xHasKey.Contains(item2.Key) || pHasKey.Contains(item2.Key) || qHasKey.Contains(item2.Key) || oHasKey.Contains(item2.Key))
                                        continue;
                                    if (Math.Abs(item1.MyEnt.Length - item2.MyEnt.Length) > GetDeviation(item2.MyEnt.Length) && Math.Abs(item1.MyEnt.Length - item2.MyEnt.Length) > GetDeviation(item2.MyEnt.Length))
                                        continue;
                                    int oTotal = 0;
                                    if (item2.MyEnt.Qty == 0)
                                    {
                                        continue;
                                    }
                                    for (int i = 1; i <= item2.MyEnt.Qty; i++)
                                    {
                                        oTotal += item2.MyEnt.Area;
                                        if (xTotal + yTotal + kTotal + tTotal + qTotal + oTotal <= maxNum && xTotal + yTotal + kTotal + tTotal + qTotal + oTotal >= minNum)
                                        {
                                            hasKey.Add(ent.Key);
                                            hasKey.Add(ent1.Key);
                                            hasKey.Add(ent2.Key);
                                            hasKey.Add(item.Key);
                                            hasKey.Add(item1.Key);

                                            Ent2 tEnt2 = new Ent2();
                                            tEnt2.MyEnt = ent.MyEnt;
                                            tEnt2.Key = "BC" + index;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            tEnt2 = new Ent2();
                                            tEnt2.MyEnt = ent1.MyEnt;
                                            tEnt2.Key = "BC" + index;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            tEnt2 = new Ent2();
                                            tEnt2.MyEnt = ent2.MyEnt;
                                            tEnt2.Key = "BC" + index;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            tEnt2 = new Ent2();
                                            tEnt2.MyEnt = item.MyEnt;
                                            tEnt2.Key = "BC" + index;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            tEnt2 = new Ent2();
                                            tEnt2.MyEnt = item1.MyEnt;
                                            tEnt2.Key = "BC" + index;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            Ent1 tEnt = new Ent1();
                                            tEnt.Length = item2.MyEnt.Length;
                                            tEnt.Area = item2.MyEnt.Area;
                                            tEnt.Qty = i;

                                            tEnt2 = new Ent2();
                                            tEnt2.MyEnt = tEnt;
                                            tEnt2.Key = "BC" + index++;
                                            tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal;
                                            resultList.Add(tEnt2);

                                            if (i == item2.MyEnt.Qty)
                                            {
                                                hasKey.Add(item2.Key);
                                            }
                                            item2.MyEnt.Qty -= i;
                                            goto START;
                                        }
                                    }
                                    mHasKey.Add(item2.Key);
                                    List<string> nHasKey = new List<string>();
                                    foreach (var item3 in list3)
                                    {
                                        if (mHasKey.Contains(item3.Key) || tHasKey.Contains(item3.Key) || hasKey.Contains(item3.Key) || xHasKey.Contains(item3.Key) || pHasKey.Contains(item3.Key) || qHasKey.Contains(item3.Key) || oHasKey.Contains(item3.Key))
                                            continue;
                                        if (Math.Abs(item2.MyEnt.Length - item3.MyEnt.Length) > GetDeviation(item3.MyEnt.Length) && Math.Abs(item2.MyEnt.Length - item3.MyEnt.Length) > GetDeviation(item3.MyEnt.Length))
                                            continue;
                                        int mTotal = 0;
                                        if (item3.MyEnt.Qty == 0)
                                        {
                                            continue;
                                        }
                                        for (int i = 1; i <= item3.MyEnt.Qty; i++)
                                        {
                                            mTotal += item3.MyEnt.Area;
                                            if (xTotal + yTotal + kTotal + tTotal + qTotal + mTotal + oTotal <= maxNum && xTotal + yTotal + mTotal + kTotal + tTotal + qTotal + oTotal >= minNum)
                                            {
                                                hasKey.Add(ent.Key);
                                                hasKey.Add(ent1.Key);
                                                hasKey.Add(ent2.Key);
                                                hasKey.Add(item.Key);
                                                hasKey.Add(item1.Key);
                                                hasKey.Add(item2.Key);

                                                Ent2 tEnt2 = new Ent2();
                                                tEnt2.MyEnt = ent.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = ent1.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = ent2.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = item.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = item1.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = item2.MyEnt;
                                                tEnt2.Key = "BC" + index;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                Ent1 tEnt = new Ent1();
                                                tEnt.Length = item3.MyEnt.Length;
                                                tEnt.Area = item3.MyEnt.Area;
                                                tEnt.Qty = i;

                                                tEnt2 = new Ent2();
                                                tEnt2.MyEnt = tEnt;
                                                tEnt2.Key = "BC" + index++;
                                                tEnt2.Area = xTotal + yTotal + kTotal + tTotal + qTotal + oTotal + mTotal;
                                                resultList.Add(tEnt2);

                                                if (i == item3.MyEnt.Qty)
                                                {
                                                    hasKey.Add(item3.Key);
                                                }
                                                item3.MyEnt.Qty -= i;
                                                goto START;
                                            }
                                        }
                                        nHasKey.Add(item3.Key);
                                    }
                                }
                                #endregion
                            }
                        #endregion
                        }
                    }
                }
            }
            RemoveItem(ref list3, hasKey);
            return resultList;
        }

        private void RemoveItem(ref List<Ent2> list, List<string> key)
        {
            key = key.Distinct().ToList();
            List<Ent2> list4 = new List<Ent2>();
            foreach (var item in list)
            {
                if (!key.Contains(item.Key))
                    list4.Add(item);
            }
            list = list4;
        }




        private void tsbSetting_Click(object sender, EventArgs e)
        {
            var frm = new FrmSetting();
            frm.ShowDialog();
            _deviation1 = frm.Deviation1;
            _deviation2 = frm.Deviation2;
            _deviation3 = frm.Deviation3;
            _area = frm.Area;
            this.lbSettingInfo.Text = @"当前系统计算的板宽为：【" + _area + @"mm】";
        }
    }
}
