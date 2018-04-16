using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nicholas.Smart.Materials.Business
{
    public class XmlHelper
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read(path, "/Node", "")
         * XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public static string Read(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch { }
            return value;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "Element", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public static void Insert(string path, string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mNode"></param>
        public static void Insert(string path,MaterialsNode mNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.SelectSingleNode(mNode.RNode);//查找根节点
                XmlElement xe = doc.CreateElement(mNode.PNode);//创建一个父节点
                xe.SetAttribute(mNode.PNodeAttr, mNode.PNodeValue); //为父节点添加属性
                if (mNode.CNode.Length > 0)
                {
                    for (int i = 0; i < mNode.CNode.Length; i++)
                    {
                        XmlElement xesub1 = doc.CreateElement(mNode.CNode[i]);
                        xesub1.InnerText = mNode.CNodeValue[i];//设置文本节点   
                        xe.AppendChild(xesub1);//添加到<book>节点中   
                    }
                }
                root.AppendChild(xe);
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(string path, SystemRegInfo info)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                XmlNodeList nodeList = doc.SelectSingleNode("Software").ChildNodes;
                foreach (XmlNode node in nodeList)
                {
                    XmlElement xe = (XmlElement)node;
                    switch (xe.Name)
                    {
                        case "IsAuthorized":
                            xe.InnerText = info.IsAuthorized;
                            break;
                        case "RegKey":
                            xe.InnerText = info.RegKey;
                            break;
                        case "StartDate":
                            xe.InnerText = info.StartDate;
                            break;
                        case "EndDate":
                            xe.InnerText = info.EndDate;
                            break;
                    }
                }
                reader.Close();
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(string path,MaterialsNode mNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                XmlNodeList nodeList = doc.SelectSingleNode(mNode.RNode).ChildNodes;
                foreach (XmlNode node in nodeList)
                {
                    XmlElement xe = (XmlElement) node;
                    if (xe.GetAttribute(mNode.PNodeAttr) == mNode.PNodeValue)
                    {
                        xe.SetAttribute(mNode.PNodeAttr, mNode.PNodeNewValue);

                        XmlNodeList nls = xe.ChildNodes;
                        foreach (XmlNode n in nls)
                        {
                            XmlElement xl = (XmlElement) n;
                            for (int i = 0; i < mNode.CNode.Length; i++)
                            {
                                if (xl.Name == mNode.CNode[i])
                                {
                                    xl.InnerText = mNode.CNodeValue[i];
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                reader.Close();
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(string path, MaterialsNode mNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                //doc.Load(path);
                XmlNodeList nodeList = doc.SelectSingleNode(mNode.RNode).ChildNodes;
                foreach (XmlNode node in nodeList)
                {
                    XmlElement xe = (XmlElement)node;
                    if (xe.GetAttribute(mNode.PNodeAttr) == mNode.PNodeValue)
                    {
                        xe.RemoveAttribute(mNode.PNodeAttr);//删除genre属性   
                    }
                    else if (xe.GetAttribute(mNode.PNodeAttr) == mNode.PNodeNewValue)
                    {
                        //xe.RemoveAll();//删除该节点的全部内容 
                        node.ParentNode.RemoveChild(node);
                    }   
                }
                reader.Close();
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static List<MaterialsData> GetXmlData(string path, MaterialsNode mNode)
        {

            List<MaterialsData> list = new List<MaterialsData>();
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);

                XmlNodeList xnl = doc.SelectSingleNode(mNode.RNode).ChildNodes;
                foreach (XmlNode node in xnl)
                {
                    MaterialsData data = new MaterialsData();
                    XmlElement xe = (XmlElement)node; 
                    XmlNodeList xnf1 = xe.ChildNodes;
                    foreach (XmlNode xn2 in xnf1)
                    {
                        XmlElement x = (XmlElement)xn2;
                        if (x.Name == "Value")
                        {
                            data.Area = x.InnerText;
                        }
                        if (x.Name == "Path")
                        {
                            data.Path = x.InnerText;
                        }
                        if (x.Name == "Type")
                        {
                            data.Type = x.InnerText;
                        }
                        if (x.Name == "Depth")
                        {
                            data.Depth = x.InnerText;
                        }
                        //Console.WriteLine(xn2.InnerText);//显示子节点点文本   
                    }  
                    list.Add(data);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static SystemRegInfo GetSystemRegInfo(string path, string root)
        {
            SystemRegInfo data = new SystemRegInfo();
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                if (doc.SelectSingleNode(root) == null) 
                    return null;

                XmlNodeList xnl = doc.SelectSingleNode(root).ChildNodes;
                foreach (XmlNode node in xnl)
                {
                    XmlElement x = (XmlElement)node;
                    switch (x.Name)
                    {
                        case "IsAuthorized":
                            data.IsAuthorized = x.InnerText;
                            break;
                        case "RegKey":
                            data.RegKey = x.InnerText;
                            break;
                        case "StartDate":
                            data.StartDate = x.InnerText;
                            break;
                        case "EndDate":
                            data.EndDate = x.InnerText;
                            break;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }



        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Attribute", "Value")
         ************************************************/
        public static void Update(string path, string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete(path, "/Node", "")
         * XmlHelper.Delete(path, "/Node", "Attribute")
         ************************************************/
        public static void Delete(string path, string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch { }
        }

        public static void CreateImageXml(string filename)
        {
            //创建XmlDocument对象
            XmlDocument xmlDoc = new XmlDocument();
            //XML的声明<?xml version="1.0" encoding="gb2312"?> 
            XmlDeclaration xmlSM = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //追加xmldecl位置
            xmlDoc.AppendChild(xmlSM);
            //添加一个名为Gen的根节点
            XmlElement xml = xmlDoc.CreateElement("", "Materials", "");
            //追加Gen的根节点位置
            xmlDoc.AppendChild(xml);
            //保存好创建的XML文档
            xmlDoc.Save(filename);   
        }

        public static void CreateRegInfoXml(string filename, SystemRegInfo info)
        {
            //创建XmlDocument对象
            XmlDocument xmlDoc = new XmlDocument();
            //XML的声明<?xml version="1.0" encoding="gb2312"?> 
            XmlDeclaration xmlSM = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
             //追加xmldecl位置
            xmlDoc.AppendChild(xmlSM);
             //添加一个名为Gen的根节点
            XmlElement xml = xmlDoc.CreateElement("", "Software", "");
            //追加Gen的根节点位置
            xmlDoc.AppendChild(xml);
            //添加另一个节点,与Gen所匹配，查找<Gen>
            XmlNode gen = xmlDoc.SelectSingleNode("Software");
            //添加一个名为<Zi>的节点   
            XmlElement zi = xmlDoc.CreateElement("IsAuthorized");
            //为<Zi>节点的属性
            zi.InnerText = info.IsAuthorized;
            gen.AppendChild(zi);//添加到<Gen>节点中   
            
            zi = xmlDoc.CreateElement("RegKey");
            //为<Zi>节点的属性
            zi.InnerText = info.RegKey;
            gen.AppendChild(zi);//添加到<Gen>节点中   

            zi = xmlDoc.CreateElement("StartDate");
            //为<Zi>节点的属性
            zi.InnerText = info.StartDate;
            gen.AppendChild(zi);//添加到<Gen>节点中   

            zi = xmlDoc.CreateElement("EndDate");
            //为<Zi>节点的属性
            zi.InnerText = info.EndDate;
            gen.AppendChild(zi);//添加到<Gen>节点中   

            //保存好创建的XML文档
            xmlDoc.Save(filename);   
        }

    }
}
