using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Money.Net.DB;
using System.Collections;

namespace Money.Net
{
    public partial class FangShiDurationSummaryFrm : Form
    {
        private DateTime startDateTime_ = DateTime.Now;
        private DateTime endDateTime_ = DateTime.Now;
        private int fangShiID_ = -1;
        private decimal shouru_ = 0;
        private decimal xiaofei_ = 0;

        public FangShiDurationSummaryFrm()
        {
            InitializeComponent();

            endDateTime_ = new DateTime(Program.GetDefaultYear(),
                DateTime.Now.Month, DateTime.Now.Day);

            DateTime s = new DateTime(endDateTime_.Ticks);
            s = s.AddMonths(-1);

            if (s.Year != Program.GetDefaultYear())
                s = new DateTime(Program.GetDefaultYear(), 1, 1);

            startDateTime_ = s;
        }

        private void FenLeiDurationDetailFrm_Load(object sender, EventArgs e)
        {
            dtpStart.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpStart.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpEnd.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.Value = endDateTime_;

            dtpStart.Value = startDateTime_;

            int selectIndex = -1;

            foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                Program.MoneyNetDS._JiaoYi_FangShi.Rows)
            {
                int index = cboFangShi.Items.Add(new LstItem(row.ID, row.Name));

                if (row.ID == fangShiID_)
                    selectIndex = index;
            }

            if (selectIndex > 0)
                cboFangShi.SelectedIndex = selectIndex;
            else if (cboFangShi.Items.Count > 0)
                cboFangShi.SelectedIndex = 0;

            RefreshGrid();
        }

        public int FangShiID
        {
            get
            {
                return fangShiID_;
            }

            set
            {
                fangShiID_ = value;
            }
        }

        public DateTime StartDateTime
        {
            set
            {
                startDateTime_ = value;
            }
        }

        public DateTime EndDateTime
        {
            set
            {
                endDateTime_ = value;
            }
        }

        private void RefreshGrid()
        {
            shouru_ = 0;
            xiaofei_ = 0;

            try
            {
                if (cboFangShi.SelectedItem == null)
                    return;

                LstItem item = cboFangShi.SelectedItem as LstItem;

                dgvDetail.SuspendLayout();

                dgvDetail.Rows.Clear();

                Hashtable rows = new Hashtable();

                foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                   Program.MoneyNetDS._RiChang_JiaoYi.Rows)
                {
                    if (row.JiaoYi_Time.Year == dtpStart.Value.Year &&
                        (row.JiaoYi_Time.Month > dtpStart.Value.Month ||
                        row.JiaoYi_Time.Month == dtpStart.Value.Month &&
                        row.JiaoYi_Time.Day >= dtpStart.Value.Day) &&
                        row.JiaoYi_Time.Year == dtpEnd.Value.Year &&
                        (row.JiaoYi_Time.Month < dtpEnd.Value.Month ||
                        row.JiaoYi_Time.Month == dtpEnd.Value.Month &&
                        row.JiaoYi_Time.Day <= dtpEnd.Value.Day) &&
                        row.JiaoYi_FangShi_ID == item.ID)
                    {
                        string key = row.MingCheng;

                        decimal value = 0.0M;

                        if (rows.ContainsKey(key))
                            value = (decimal)rows[key];

                        if (row.JiaoYi_FangXiang)
                        {
                            value -=
                                row.Jin_E;

                            xiaofei_ += row.Jin_E;
                        }
                        else
                        {
                            value +=
                                row.Jin_E;

                            shouru_ += row.Jin_E;
                        }

                        rows[key] = value;
                    }
                }

                foreach (string key in rows.Keys)
                {
                    decimal value = (decimal)rows[key];

                    int rowIndex = dgvDetail.Rows.Add();
                    dgvDetail[0, rowIndex].Value = key;
                    dgvDetail[1, rowIndex].Value = value;

                    if (value < 0)
                    {
                        dgvDetail[1, rowIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvDetail[1, rowIndex].Style.ForeColor = Color.Blue;
                    }
                }

                dgvDetail.ResumeLayout();
            }
            finally
            {
                lblShouRu.Text = shouru_.ToString();
                lblXiaoFei.Text = xiaofei_.ToString();
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cboFenLei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFangShi.SelectedIndex >= 0)
            {
                LstItem item = cboFangShi.SelectedItem as LstItem;

                fangShiID_ = item.ID;
            }
            else
            {
                fangShiID_ = -1;
            }

            RefreshGrid();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FangShiDurationDetailFrm frm = new FangShiDurationDetailFrm();

            frm.StartDateTime = dtpStart.Value;
            frm.EndDateTime = dtpEnd.Value;
            frm.FangShiID = fangShiID_;

            if (dgvDetail.SelectedCells.Count > 0)
            {
                int row = dgvDetail.SelectedCells[0].RowIndex;

                frm.MingCheng = dgvDetail[0,row].Value.ToString();
            }

            frm.ShowDialog(this);

            RefreshGrid();
        }

        private void btnAllRecords_Click(object sender, EventArgs e)
        {
            FangShiDurationAllRecordsFrm frm = new FangShiDurationAllRecordsFrm();

            frm.StartDateTime = dtpStart.Value;
            frm.EndDateTime = dtpEnd.Value;
            frm.FangShiID = fangShiID_;

            frm.ShowDialog(this);

            RefreshGrid();
        }
    }
}