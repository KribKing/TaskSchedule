﻿using DevExpress.XtraTreeList.Nodes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DownLoad.Business;
using DownLoad.Core;
using DownLoad.Core.Schema;
using DownLoad.UI.Properties;
using System.Xml;
using DevExpress.XtraEditors;
using ICSharpCode.TextEditor.Document;

namespace DownLoad.UI
{
    public partial class ConfigFrm : FrmBase
    {
        private JobInfo Cur_JobInfo;
        private TreeListNode Cur_JobNode;
        private IQuickExcuteInterface ParentFrm;
        private PopupContainerEdit Cur_popc;
        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(JobInfo info, TreeListNode node, IQuickExcuteInterface Pat)
        {
            InitializeComponent();
            this.Cur_JobInfo = info;
            this.Cur_JobNode = node;
            this.ParentFrm = Pat;
            this.txttmp.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rtsscript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rttscript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rtbxml.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
        }     
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.teid.Text.Trim()))
                {
                    MessageBox.Show("作业编码不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tename.Text.Trim()))
                {
                    MessageBox.Show("作业名称不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tesystem.Text.Trim()))
                {
                    MessageBox.Show("大类编码不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tesysname.Text.Trim()))
                {
                    MessageBox.Show("大类名称不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                //if (string.IsNullOrEmpty(this.txtexp.Text.Trim()))
                //{
                //    MessageBox.Show("作业表达式不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                //    return;
                //}
                if (this.Cur_JobInfo == null)
                {
                    this.Cur_JobInfo = new JobInfo();
                }

                this.Cur_JobInfo.id = this.teid.Text.Trim();
                this.Cur_JobInfo.name = this.tename.Text.Trim();
                this.Cur_JobInfo.system = this.tesystem.Text.Trim();
                this.Cur_JobInfo.sysname = this.tesysname.Text.Trim();
                this.Cur_JobInfo.expression = this.txtexp.Text.Trim();
                this.Cur_JobInfo.jlzt = this.cejlzt.SelectedIndex.ToString();
                this.Cur_JobInfo.targetdbtype = this.cbetdbtype.SelectedIndex;
                this.Cur_JobInfo.isbulkop = this.cbtop.SelectedIndex == 0 ? true : false;
                this.Cur_JobInfo.istargetdbencode = this.cetjm.Checked;
                this.Cur_JobInfo.targetdbstring = this.cetjm.Checked ? EncodeAndDecode.Decode(this.txttstr.Text.Trim()) : this.txttstr.Text.Trim();
                this.Cur_JobInfo.tmpname = this.txttmpname.Text.Trim();
                this.Cur_JobInfo.createtmp = this.txttmp.Text.Trim();
                this.Cur_JobInfo.targetsql = this.rttscript.Text.Trim();
                this.Cur_JobInfo.sourcetype = this.rbsweb.Checked ? 0 : 1;
                this.Cur_JobInfo.servertype = this.cbstype.SelectedIndex;
                this.Cur_JobInfo.servermethod = this.txtMethod.Text.Trim();
                this.Cur_JobInfo.weburl = this.txturl.Text.Trim();
                this.Cur_JobInfo.nodelx = this.cbejxlx.SelectedIndex;
                this.Cur_JobInfo.node = this.tenode.Text.Trim();
                this.Cur_JobInfo.xmlconfig = this.rtbxml.Text.Trim();
                this.Cur_JobInfo.sourcedbtype = this.cbesdbtype.SelectedIndex;
                this.Cur_JobInfo.issourcedbencode = this.cesjm.Checked;
                this.Cur_JobInfo.sourcedbstring = this.cesjm.Checked ? EncodeAndDecode.Decode(this.txtsstr.Text.Trim()) : this.txtsstr.Text.Trim();
                this.Cur_JobInfo.sourcesql = this.rtsscript.Text.Trim();
                this.teid.Enabled = false;
                this.tesystem.Enabled = false;
                this.tesysname.Enabled = false;
                if (this.Cur_JobNode != null)
                {
                    this.Cur_JobNode.SetValue(0, this.Cur_JobInfo.name);
                    this.Cur_JobNode.StateImageIndex = this.Cur_JobInfo.jlzt == "0" ? 1 : 0;
                }
                GlobalInstanceManager<JobInfoManager>.Intance.AddJobInfo(Cur_JobInfo);
                MessageBox.Show("保存成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，异常原因：" + ex.Message, "操作提示", MessageBoxButtons.OK);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtexp_DoubleClick(object sender, EventArgs e)
        {
            using (ExecJob frm = new ExecJob(Cur_JobInfo))
            {
                frm.ShowDialog();
            }
        }


        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Cur_JobInfo = null;
            this.teid.Enabled = this.tesystem.Enabled = this.tesysname.Enabled = this.rbsweb.Checked = true;
            this.teid.Text = this.tename.Text = this.tesystem.Text = this.tesysname.Text = this.txtexp.Text = this.txturl.Text = this.txttmpname.Text = this.txttmp.Text = this.rttscript.Text = this.rtsscript.Text = this.tenode.Text = this.txtMethod.Text = "";
            this.cejlzt.SelectedIndex = 0;
        }

        private void rbsweb_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPageIndex = this.rbsweb.Checked ? 0 : 1;
            this.xtraTabPage2.PageVisible = !this.rbsweb.Checked;
            this.xtraTabPage1.PageVisible = this.rbsweb.Checked;
        }

        private void cbtop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gsource.Enabled = this.cbtop.SelectedIndex == 0;
            this.xtraTabControl2.SelectedTabPageIndex = this.cbtop.SelectedIndex;
        }

        private void btnquick_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo != null)
            {
                string strrequest = GlobalInstanceManager<JobInfoManager>.Intance.GetExcuteCondition(this.Cur_JobInfo);
                this.ParentFrm.QuickExcute(this.Cur_JobInfo, strrequest);
            }
        }

        private void cetjm_CheckedChanged(object sender, EventArgs e)
        {
            this.txttstr.Text = this.cetjm.Checked ? EncodeAndDecode.Encode(this.txttstr.Text.Trim()) : EncodeAndDecode.Decode(this.txttstr.Text.Trim());
        }

        private void cesjm_CheckedChanged(object sender, EventArgs e)
        {
            this.txtsstr.Text = this.cesjm.Checked ? EncodeAndDecode.Encode(this.txtsstr.Text.Trim()) : EncodeAndDecode.Decode(this.txtsstr.Text.Trim());
        }

        private void cbejxlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pxml.Visible = this.cbejxlx.SelectedIndex == 0 ? false : true;
        }

        private void btnxml_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "json文件|*.json|所有文件(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                this.rtbxml.Text = File.ReadAllText(fName);
            }
        }

        private void btnCreateTemp_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null || string.IsNullOrEmpty(this.Cur_JobInfo.id))
            {
                MessageBox.Show("当前作业内容无效，请检查", "操作提示", MessageBoxButtons.OK);
                return;
            }

            try
            {
                DataTable dt = new DataTable();
                if (this.Cur_JobInfo.sourcetype == 0)
                {
                    if (this.Cur_JobInfo.nodelx == 0)
                    {
                        string request = GlobalInstanceManager<JobInfoManager>.Intance.GetExcuteCondition(this.Cur_JobInfo);
                        request = new RequestMessage() { Request = new Request() { Head = new Head() { TranCode = this.Cur_JobInfo.id, TranName = this.Cur_JobInfo.name, TranSys = this.Cur_JobInfo.system, TranSysName = this.Cur_JobInfo.sysname, AckMessage = "请求访问" }, Body = request } }.ToString();
                        string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(request);
                        ResponseMessage Response = JsonConvert.DeserializeObject<ResponseMessage>(strret);
                        if (string.IsNullOrEmpty(strret))
                        {
                            MessageBox.Show("无执行记录，请检查", "操作提示", MessageBoxButtons.OK);
                            return;
                        }
                        string json = Tools.GetJsonNodeValue(Response.Response.Body, this.Cur_JobInfo.sourcetype == 1 ? "[]" : this.Cur_JobInfo.node, "[]").ToString();
                        dt = Tools.JsonToDataTable(json);
                    }
                    else if (this.Cur_JobInfo.nodelx == 1)
                    {
                        SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(this.Cur_JobInfo.xmlconfig);
                        if (info == null)
                            return;
                        dt = info.ToDt();
                    }
                }
                else if (this.Cur_JobInfo.sourcetype == 1)
                {
                    dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_JobInfo.sourcedbtype, this.Cur_JobInfo.sourcedbstring, this.Cur_JobInfo.sourcesql);
                }
                if (dt != null)
                {
                    string strtmp = "create table " + this.Cur_JobInfo.tmpname + Environment.NewLine + "(" + Environment.NewLine;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        strtmp += "   " + dc.ColumnName + "   varchar(256) null," + Environment.NewLine;
                    }
                    strtmp = strtmp.Remove(strtmp.LastIndexOf(','), 1);
                    strtmp += ")";
                    this.txttmp.Text = strtmp;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("导出发生异常：" + ex.Message);
            }
        }

        private void txtsstr_DoubleClick(object sender, EventArgs e)
        {
            using (DataConfigFrm frm = new DataConfigFrm(this.cbesdbtype.SelectedIndex, this.txtsstr.Text.Trim(), this.cesjm.Checked))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.txtsstr.Text = !this.cesjm.Checked ? EncodeAndDecode.Decode(frm.ConnectString) : frm.ConnectString;
                }
            }
        }

        private void txttstr_DoubleClick(object sender, EventArgs e)
        {
            using (DataConfigFrm frm = new DataConfigFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.txttstr.Text = !this.cetjm.Checked ? EncodeAndDecode.Decode(frm.ConnectString) : frm.ConnectString;
                }
            }
        }

        private void ConfigFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Cur_JobNode != null)
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.RemoveWinHandle(this.Cur_JobInfo.id);
            }
        }

        private void btngeneratexml_Click(object sender, EventArgs e)
        {
            using (MapXmlFrm frm = new MapXmlFrm(this.rtbxml.Text.Trim(), this.tename.Text.Trim()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.rtbxml.Text = frm.MapJson;
                }
            }
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            TestFrm frm = new TestFrm(this.Cur_JobInfo);
            frm.Show();
        }

        private void popctarget_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.Cur_popc = sender as PopupContainerEdit;
            this.Cur_popc.Properties.PopupControl = this.pop_ctrl_combox;
            this.LoadPopCtrl();
        }

        private void LoadPopCtrl()
        {
            List<JobInfo> list = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.ToList();
            this.gcjob.DataSource = list;
            this.gcjob.RefreshDataSource();
            foreach (JobInfo item in list.Where(a => a.system == this.tesystem.Text.Trim()))
            {
                int rowhanlde = this.gvjob.GetRowHandle(list.IndexOf(item));
                this.gvjob.SelectRow(rowhanlde);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> list = this.gvjob.GetSelectedRows().Where(a => a >= 0).ToList();
                if (this.Cur_popc == null || list == null || list.Count <= 0) return;
                foreach (int rowhanlde in list)
                {
                    JobInfo info = this.gvjob.GetRow(rowhanlde) as JobInfo;
                    if (this.Cur_popc == this.popctarget)
                    {
                        info.targetdbtype = this.cbetdbtype.SelectedIndex;
                        info.targetdbstring = this.txttstr.Text.Trim();
                        info.istargetdbencode = this.cetjm.Checked;
                    }
                    else
                    {
                        info.sourcedbtype = this.cbesdbtype.SelectedIndex;
                        info.sourcedbstring = this.txtsstr.Text.Trim();
                        info.issourcedbencode = this.cesjm.Checked;
                    }
                }
                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                MessageBox.Show("配置传递成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("配置传递失败", ex);
            }          
        }

        private void btnclosepop_Click(object sender, EventArgs e)
        {
            if (this.Cur_popc == null) return;
            this.Cur_popc.ClosePopup();
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            this.splitctrl.PanelVisibility = btn == this.btnright ? SplitPanelVisibility.Panel1 :
                                            btn == this.btnleft ? SplitPanelVisibility.Panel2 : SplitPanelVisibility.Both;
        }

        private void ConfigFrm_Shown(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo != null)
            {
                this.Text = string.Format("作业【{0}】的属性", this.Cur_JobInfo.name);
                this.teid.Text = this.Cur_JobInfo.id;
                this.tename.Text = this.Cur_JobInfo.name;
                this.tesystem.Text = this.Cur_JobInfo.system;
                this.tesysname.Text = this.Cur_JobInfo.sysname;
                this.txtexp.Text = this.Cur_JobInfo.expression;
                this.cejlzt.SelectedIndex = int.Parse(this.Cur_JobInfo.jlzt);
                this.cbtop.SelectedIndex = this.Cur_JobInfo.isbulkop ? 0 : 1;
                this.gsource.Enabled = this.Cur_JobInfo.isbulkop;
                this.cbetdbtype.SelectedIndex = this.Cur_JobInfo.targetdbtype;
                this.cetjm.Checked = this.Cur_JobInfo.istargetdbencode;
                this.txttstr.Text = this.cetjm.Checked ? EncodeAndDecode.Encode(this.Cur_JobInfo.targetdbstring) : this.Cur_JobInfo.targetdbstring;
                this.txttmpname.Text = this.Cur_JobInfo.tmpname;
                this.txttmp.Text = this.Cur_JobInfo.createtmp;
                this.rttscript.Text = this.Cur_JobInfo.targetsql;
                this.rbsweb.Checked = this.Cur_JobInfo.sourcetype == 0;
                this.rbsdb.Checked = this.Cur_JobInfo.sourcetype == 1;
                this.cbstype.SelectedIndex = this.Cur_JobInfo.servertype;
                this.txtMethod.Text = this.Cur_JobInfo.servermethod;
                this.txturl.Text = this.Cur_JobInfo.weburl;
                this.cbejxlx.SelectedIndex = this.Cur_JobInfo.nodelx;
                this.tenode.Text = this.Cur_JobInfo.node;
                this.rtbxml.Text = this.Cur_JobInfo.xmlconfig;
                this.cbesdbtype.SelectedIndex = this.Cur_JobInfo.sourcedbtype;
                this.cesjm.Checked = this.Cur_JobInfo.issourcedbencode;
                this.txtsstr.Text = this.cesjm.Checked ? EncodeAndDecode.Encode(this.Cur_JobInfo.sourcedbstring) : this.Cur_JobInfo.sourcedbstring;
                this.rtsscript.Text = this.Cur_JobInfo.sourcesql;
                this.teid.Properties.ReadOnly = this.Cur_JobNode == null ? false : true;
                this.tesystem.Properties.ReadOnly = this.Cur_JobNode == null ? false : true;
                this.tesysname.Properties.ReadOnly = this.Cur_JobNode == null ? false : true;
                this.btnnew.Visible = this.Cur_JobNode == null ? true : false;
            }
            if (this.Cur_JobNode == null)
            {
                this.teid.Focus();
            }
        }
    }
}
