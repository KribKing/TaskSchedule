using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DownLoad.Core.Schema;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace DownLoad.Core
{
    public class XmlHelper
    {
        public static string GetNodeAttributeValue(string xPath, string attr, XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode(xPath);
            if (node == null)
            {
                return null;
            }
            return node.Attributes[attr].Value;
        }
        public static string GetNodeAttributeValue(string xPath, string attr, XmlNode node)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(node.OuterXml);
            return GetNodeAttributeValue(xPath, attr, doc);
        }
        public static string GetNodeTextValue(string xPath, XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode(xPath);
            if (node == null)
            {
                return null;
            }
            return node.InnerText;
        }
        public static string GetNodeTextValue(string xPath, XmlNode node)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(node.OuterXml);
            return GetNodeTextValue(xPath, doc);
        }
        public static XmlNode GetNode(string xPath, XmlNode doc)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode(xPath);
                return node;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message,ex);
                return null;
            }

        }
        public static XmlNodeList GetNodes(string xPath, XmlNode doc)
        {
            try
            {
                XmlNodeList node = doc.SelectNodes(xPath);
                return node;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message,ex);
                return null;
            }

        }
        public static DataTable XmlToDataTable(string config, XmlNode node)
        {
            try
            {
                if (node == null || !node.HasChildNodes)
                    return null;
                DataTable dt = new DataTable();
                SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(config);
                foreach (TableSchema item in info.TableSchema)
                {
                    DataColumn dc = new DataColumn(item.column);
                    dt.Columns.Add(dc);
                }
                foreach (XmlNode xn in node.ChildNodes)
                {
                    if (xn.NodeType == XmlNodeType.Comment)
                        continue;
                    DataRow dr = dt.NewRow();
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(xn.OuterXml);
                    foreach (TableSchema item in info.TableSchema)
                    {
                        if (item.maptype == "文本值")
                        {
                            dr[item.column] = XmlHelper.GetNodeTextValue(item.map, xml);
                        }
                        else if (item.maptype == "属性值")
                        {
                            dr[item.column] = XmlHelper.GetNodeAttributeValue(item.map, item.attr, xml);
                        }
                        else if (item.maptype == "关联文本值")
                        {

                            XmlNode glnode = XmlHelper.GetNode(item.relemap, xml);
                            if (glnode != null)
                            {
                                XmlDocument parentxml = new XmlDocument();
                                parentxml.LoadXml(node.ParentNode.OuterXml);
                                dr[item.column] = XmlHelper.GetNodeTextValue(item.map, parentxml);
                            }

                        }
                        else if (item.maptype == "关联属性值")
                        {
                            XmlNode glnode = XmlHelper.GetNode(item.relemap, xml);
                            if (glnode != null)
                            {
                                XmlDocument parentxml = new XmlDocument();
                                parentxml.LoadXml(node.ParentNode.OuterXml);
                                dr[item.column] = XmlHelper.GetNodeAttributeValue(item.map, item.attr, parentxml);
                            }
                        }
                        dt.Rows.Add(dr);
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message,ex);
                return null;
            }
        }
        public static DataTable XmlToDataTable(string parentnode, SchemaInfo info, XmlNode node)
        {
            try
            {

                if (node == null || !node.HasChildNodes)
                    return null;
                DataTable dt = info.ToDt();
                string[] pnodes = parentnode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                ForeachToTable(0, pnodes, node, dt, info);
                Tools.RemoveEmpty(dt);
                return dt;

            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message,ex);
                return null;
            }
        }

        private static void ForeachToTable(int pindex, string[] pnodes, XmlNode node, DataTable dt, SchemaInfo info)
        {
            if (pindex == pnodes.Length)
            {
                foreach (XmlNode xn in node.ChildNodes)
                {
                    if (xn.NodeType == XmlNodeType.Comment)
                        continue;
                    DataRow dr = dt.NewRow();

                    foreach (TableSchema ts in info.TableSchema)
                    {
                        if (ts.maptype == "文本值")
                        {
                            dr[ts.column] = XmlHelper.GetNodeTextValue(ts.map, xn);
                        }
                        else if (ts.maptype == "属性值")
                        {
                            dr[ts.column] = XmlHelper.GetNodeAttributeValue(ts.map, ts.attr, xn);
                        }
                        else if (ts.maptype == "关联文本值")
                        {

                            XmlNode glnode = XmlHelper.GetNode(ts.relemap, xn);
                            if (glnode != null)
                            {
                                XmlDocument parentxml = new XmlDocument();
                                parentxml.LoadXml(node.ParentNode.OuterXml);
                                dr[ts.column] = XmlHelper.GetNodeTextValue(ts.map, parentxml);
                            }

                        }
                        else if (ts.maptype == "关联属性值")
                        {
                            XmlNode glnode = XmlHelper.GetNode(ts.relemap, xn);
                            if (glnode != null)
                            {
                                XmlDocument parentxml = new XmlDocument();
                                parentxml.LoadXml(node.ParentNode.OuterXml);
                                dr[ts.column] = XmlHelper.GetNodeAttributeValue(ts.map, ts.attr, parentxml);
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                string pnode = pnodes[pindex];
                XmlNodeList x = GetNodes(pnode, node);
                foreach (XmlNode item in x)
                {
                    if (item == null || !item.HasChildNodes)
                        continue;
                    ForeachToTable(pindex + 1, pnodes, item, dt, info);
                }
            }
        }


        public static XmlDocument RemoveNameSpace(string xml, string ns = "xmlns|xsi")
        {
            try
            {
                //去掉注释 和命名空间
                string[] strns = ns.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (strns.Length > 0)
                {
                    foreach (var item in strns)
                    {
                        string r = "(" + item + @":?[^=]*=[""][^""]*[""])";
                        xml = System.Text.RegularExpressions.Regex.Replace(
                          xml,
                          r, "",
                          System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                          System.Text.RegularExpressions.RegexOptions.Multiline);
                    }

                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return doc;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("RemoveNameSpace发生异常：" + ex.Message);
                return null;
            }
        }

        public static XmlDocument RemoveNameSpaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDocumentWithoutNs.ToString());
            return doc;
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }
}
