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
    public partial class TodayFrm : Form
    {
        private decimal todayXiaoFei_ = new decimal(0);
        private decimal todayShouRu_ = new decimal(0);

        private MoneyNetDS.RiChang_JiaoYiRow row_ = null;

        public TodayFrm()
        {
            InitializeComponent();
        }

        public TodayFrm(MoneyNetDS.RiChang_JiaoYiRow row)
        {
            row_ = row;

            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
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

            if (cboMingCheng.Text.Trim().Length == 0)
            {
                lblMingCheng.ForeColor = Color.Red;
                return;
            }
            else
            {
                lblMingCheng.ForeColor = Color.Black;
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

            LstItem fangShiItem = lvwFangShi.SelectedItems[0].Tag as LstItem;
            LstItem fenLeiItem = lvwFenLei.SelectedItems[0].Tag as LstItem;

            MoneyNetDS.RiChang_JiaoYiRow row = row_;

            if (row == null)
            {
                row = Program.MoneyNetDS.RiChang_JiaoYi.NewRiChang_JiaoYiRow();
            }
            else
            {
                Program.UpdateHistory(row, ChangeModeEnum.±à¼­);

                row.BeginEdit();
            }

            row.MingCheng = cboMingCheng.Text;

            if (!cboMingCheng.Items.Contains(cboMingCheng.Text))
                cboMingCheng.Items.Add(cboMingCheng.Text);

            row.JiaoYi_FangXiang = rdoXiaoFei.Checked;
            row.JiaoYi_Time = dtpDate.Value;
            row.Jin_E = decimal.Parse(txtJinE.Text);
            row.MiaoShu = txtMiaoShu.Text;
            row.JiaoYi_FangShiRow = Program.MoneyNetDS.JiaoYi_FangShi.FindByID(fangShiItem.ID);
            row.JiaoYi_FenLeiRow = Program.MoneyNetDS.JiaoYi_FenLei.FindByID(fenLeiItem.ID);

            if (row_ == null)
            {
                Program.MoneyNetDS.RiChang_JiaoYi.Rows.Add(row);

                txtJinE.Text = "0.0";
                txtMiaoShu.Text = "";
            }
            else
            {
                row.EndEdit();
            }

            txtJinE.Focus();
            txtJinE.SelectAll();

            SummarySelectedDay();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DayDetailFrm frm = new DayDetailFrm();
            frm.SelectedDate = dtpDate.Value;

            frm.ShowDialog(this);

            SummarySelectedDay();
        }

        private void TodayFrm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Alt && !e.Control && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        btnOK_Click(sender, new EventArgs());
                        break;
                    case Keys.N:
                        btnNew_Click(sender, new EventArgs());
                        break;
                    case Keys.D:
                        btnDetail_Click(sender, new EventArgs());
                        break;
                }
            }
        }

        private void TodayFrm_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpDate.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpDate.Value = new DateTime(Program.GetDefaultYear(), 
                DateTime.Now.Month, DateTime.Now.Day);

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

            rdoXiaoFei.Checked = true;

            FillMingChengCombo(-1);

            SummarySelectedDay();

            if (row_ != null)
            {
                dtpDate.Value = row_.JiaoYi_Time;
                txtJinE.Text = row_.Jin_E.ToString();
                txtMiaoShu.Text = row_.MiaoShu;
                rdoShouRu.Checked = !row_.JiaoYi_FangXiang;
                rdoXiaoFei.Checked = row_.JiaoYi_FangXiang;

                foreach (ListViewItem item in lvwFenLei.Items)
                {
                    LstItem lstItem = item.Tag as LstItem;

                    if (lstItem.ID == row_.JiaoYi_FenLei_ID)
                    {
                        item.Selected = true;

                        break;
                    }
                }

                foreach (ListViewItem item in lvwFangShi.Items)
                {
                    LstItem lstItem = item.Tag as LstItem;

                    if (lstItem.ID == row_.JiaoYi_FangShi_ID)
                    {
                        item.Selected = true;

                        break;
                    }
                }

                cboMingCheng.Text = row_.MingCheng;

                btnNew.Text = "±£´æ";
                btnDetail.Visible = false;
            }
        }

        private void SummarySelectedDay()
        {
            todayShouRu_ = 0;
            todayXiaoFei_ = 0;

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if ((row.JiaoYi_Time.Year == dtpDate.Value.Year) &&
                    (row.JiaoYi_Time.Month == dtpDate.Value.Month) &&
                    (row.JiaoYi_Time.Date == dtpDate.Value.Date))
                {
                    if (row.JiaoYi_FangXiang)
                    {
                        todayXiaoFei_ += row.Jin_E;
                    }
                    else
                    {
                        todayShouRu_ += row.Jin_E;
                    }
                }
            }

            txtTodayXiaoFei.Text = todayXiaoFei_.ToString();
            txtTodayShouRu.Text = todayShouRu_.ToString();
        }

        private void FillMingChengCombo(int fenleiID)
        {
            cboMingCheng.Items.Clear();

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (fenleiID == -1 || row.JiaoYi_FenLei_ID == fenleiID)
                {
                    string name = row.MingCheng;

                    if (!cboMingCheng.Items.Contains(name))
                    {
                        cboMingCheng.Items.Add(name);
                    }
                }
            }

            if (cboMingCheng.Items.Count > 0)
                cboMingCheng.SelectedIndex = 0;
            else
                cboMingCheng.Text = "";

            cboMingCheng.Focus();
            cboMingCheng.SelectAll();
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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (row_ == null)
            {
                rdoXiaoFei.Checked = true;
                rdoShouRu.Checked = false;

                cboMingCheng.Text = "";

                txtJinE.Text = "0.0";

                txtMiaoShu.Text = "";
            }

            SummarySelectedDay();
        }

        private void lvwFenLei_Validating(object sender, CancelEventArgs e)
        {
            if (lvwFenLei.SelectedItems.Count != 1)
            {
                lblFenLei.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                lblFenLei.ForeColor = Color.Black;
            }

        }

        private void lvwFangShi_Validating(object sender, CancelEventArgs e)
        {
            if (lvwFangShi.SelectedItems.Count != 1)
            {
                lblFangShi.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                lblFangShi.ForeColor = Color.Black;
            }

        }

        private void cboMingCheng_Validating(object sender, CancelEventArgs e)
        {
            if (cboMingCheng.Text.Trim().Length == 0)
            {
                lblMingCheng.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                lblMingCheng.ForeColor = Color.Black;
            }

        }

        private void lvwFenLei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwFenLei.SelectedItems.Count <= 0)
                return;

            LstItem fenLeiItem = lvwFenLei.SelectedItems[0].Tag as LstItem;

            FillMingChengCombo(fenLeiItem.ID);
        }
    }
}