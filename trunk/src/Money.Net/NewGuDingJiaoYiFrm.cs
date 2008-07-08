using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Money.Net.DB;

namespace Money.Net
{
    public partial class NewGuDingJiaoYiFrm : Form
    {
        private MoneyNetDS.GuDing_JiaoYiRow row_ = null;

        private ZhouQi zhouqi_ = null;

        public NewGuDingJiaoYiFrm()
        {
            InitializeComponent();
        }

        public NewGuDingJiaoYiFrm(MoneyNetDS.GuDing_JiaoYiRow row)
        {
            row_ = row;

            zhouqi_ = ZhouQi.FromXmlString(row_.ZhouQi);

            InitializeComponent();
        }

        private void chkEndTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndTime.Enabled = chkEndTime.Checked;
        }

        private void GuDingJiaoYiFrm_Load(object sender, EventArgs e)
        {
            foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                Program.MoneyNetDS.JiaoYi_FangShi.Rows)
            {
                ListViewItem item = new ListViewItem(row.Name);
                item.Tag = new LstItem(row.ID, row.Name);

                lvwFangShi.Items.Add(item);
            }

            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                Program.MoneyNetDS.JiaoYi_FenLei.Rows)
            {
                ListViewItem item = new ListViewItem(row.Name);
                item.Tag = new LstItem(row.ID, row.Name);

                lvwFenLei.Items.Add(item);
            }

            if (row_ == null)
                return;

            txtName.Text = row_.MingCheng;
            txtJinE.Text = row_.Jin_E.ToString();
            txtMiaoShu.Text = row_.MiaoShu;

            if (!row_.IsZhouQiNull())
            {
                zhouqi_ = ZhouQi.FromXmlString(row_.ZhouQi);

                txtZhouQi.Text = zhouqi_.ToString();
            }
            else
            {
                txtZhouQi.Text = "";
            }

            if (!row_.IsStart_TimeNull())
                dtpStartTime.Value = row_.Start_Time;

            chkEndTime.Checked = row_.HasEndDate;

            if (!row_.IsStop_TimeNull())
            {
                dtpEndTime.Value = row_.Stop_Time;
            }

            foreach (ListViewItem item in lvwFenLei.Items)
            {
                LstItem lstItem = item.Tag as LstItem;

                if (lstItem.ID == row_.JiaoYi_FenLei_ID)
                {
                    item.Selected = true;
                }
            }

            foreach (ListViewItem item in lvwFangShi.Items)
            {
                LstItem lstItem = item.Tag as LstItem;

                if (lstItem.ID == row_.JiaoYi_FangShi_ID)
                {
                    item.Selected = true;
                }
            }

            rdoShouRu.Checked = !row_.JiaoYi_FangXiang;
            rdoXiaoFei.Checked = row_.JiaoYi_FangXiang;
        }

        private void btnZhouQi_Click(object sender, EventArgs e)
        {
            if (zhouqi_ == null)
                zhouqi_ = new ZhouQi();

            JiaoYiZhouQiFrm frm = new JiaoYiZhouQiFrm(zhouqi_);

            if (DialogResult.OK == frm.ShowDialog(this))
            {
                zhouqi_ = frm.ZhouQi;

                txtZhouQi.Text = zhouqi_.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvwFenLei.SelectedItems.Count != 1)
            {
                lblFenLei.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblFenLei.ForeColor = Color.Black;
            }

            if (lvwFangShi.SelectedItems.Count != 1)
            {
                lblFangShi.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblFangShi.ForeColor = Color.Black;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                lblMingCheng.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblMingCheng.ForeColor = Color.Black;
            }

            if (zhouqi_ == null)
            {
                lblZhouQi.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblZhouQi.ForeColor = Color.Black;
            }

            if (txtJinE.Text.Length == 0)
            {
                lblJinE.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblJinE.ForeColor = Color.Black;
            }

            try
            {
                double.Parse(txtJinE.Text);
                lblJinE.ForeColor = Color.Black;
            }
            catch
            {
                txtJinE.SelectAll();
                lblJinE.ForeColor = Color.Red;
                return;
            }

            DialogResult = DialogResult.OK;

            bool bEdit = false;
            if (row_ == null)
            {
                row_ = Program.MoneyNetDS.GuDing_JiaoYi.NewGuDing_JiaoYiRow();
            }
            else
            {
                bEdit = true;
                Program.UpdateHistory(row_, ChangeModeEnum.±à¼­);
                row_.BeginEdit();
            }

            LstItem fangShiItem = lvwFangShi.SelectedItems[0].Tag as LstItem;
            LstItem fenLeiItem = lvwFenLei.SelectedItems[0].Tag as LstItem;

            row_.MingCheng = txtName.Text;

            row_.JiaoYi_FangXiang = rdoXiaoFei.Checked;
            row_.Start_Time = new DateTime(dtpStartTime.Value.Year,
                dtpStartTime.Value.Month,
                dtpStartTime.Value.Day,
                0,
                0,
                1);
            row_.Stop_Time = new DateTime(dtpEndTime.Value.Year,
                dtpEndTime.Value.Month,
                dtpEndTime.Value.Day,
                23,
                59,
                59);
            row_.HasEndDate = chkEndTime.Checked;
            row_.Jin_E = decimal.Parse(txtJinE.Text);
            row_.MiaoShu = txtMiaoShu.Text;
            row_.JiaoYi_FangShiRow = Program.MoneyNetDS.JiaoYi_FangShi.FindByID(fangShiItem.ID);
            row_.JiaoYi_FenLeiRow = Program.MoneyNetDS.JiaoYi_FenLei.FindByID(fenLeiItem.ID);
            row_.ZhouQi = ZhouQi.ToXmlString(zhouqi_);

            if (row_.IsLast_Execute_TimeNull())
            {
                row_.Last_Execute_Time = row_.Start_Time.AddDays(-1);
            }

            if (bEdit)
            {
                row_.EndEdit();
            }
            else
            {
                Program.MoneyNetDS.GuDing_JiaoYi.Rows.Add(row_);
            }
        }

        private void lvwFenLei_Validating(object sender, CancelEventArgs e)
        {

        }

        private void lvwFangShi_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtJinE_Validating(object sender, CancelEventArgs e)
        {
            string value = txtJinE.Text.Trim();

            try
            {
                double.Parse(value);

                e.Cancel = false;

                lblJinE.ForeColor = Color.Black;
            }
            catch
            {
                txtJinE.SelectAll();
                e.Cancel = true;

                lblJinE.ForeColor = Color.Red;
            }
        }
    }
}