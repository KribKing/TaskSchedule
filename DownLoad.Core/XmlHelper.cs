using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DownLoad.Core.Schema;

namespace DownLoad.Core
{
    public class XmlHelper
    {
        public static string GetNodeAttributeValue(string xPath, string attr, XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            string nameSpace = root.NamespaceURI;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", nameSpace);
            xPath = xPath.Replace("/", "/ns:");
            XmlNode node = root.SelectSingleNode(xPath, nsmgr);
            if (node == null)
            {
                return null;
            }
            return node.Attributes[attr].Value;
        }
        public static string GetNodeTextValue(string xPath, XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            string nameSpace = root.NamespaceURI;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", nameSpace);
            xPath = xPath.Replace("/", "/ns:");
            XmlNode node = root.SelectSingleNode(xPath, nsmgr);
            if (node == null)
            {
                return null;
            }
            return node.InnerText;
        }
        public static XmlNode GetNode(string xPath, XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            string nameSpace = root.NamespaceURI;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", nameSpace);
            xPath = xPath.Replace("/", "/ns:");
            XmlNode node = root.SelectSingleNode(xPath, nsmgr);
            return node;
        }
        public static DataTable XmlToDataTable(string config, XmlNode node)
        {
            try
            {
                if (node==null||!node.HasChildNodes)
                    return null;
                DataTable dt = new DataTable();
                SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(config);
                foreach (TableSchema item in info.TableSchema)
                {
                    DataColumn dc = new DataColumn(item.column);
                    dt.Columns.Add(dc);
                }            
                foreach  (XmlNode xn in node.ChildNodes)
                {
                    if (xn.NodeType ==XmlNodeType.Comment)
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
                        
                    }
                    dt.Rows.Add(dr);
                }            
                return dt;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message);
                return null;
            }
        }

    }
}
