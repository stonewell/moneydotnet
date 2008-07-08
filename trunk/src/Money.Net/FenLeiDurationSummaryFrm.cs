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
    public partial class FenLeiDurationSummaryFrm : Form
    {
        private DateTime startDateTime_ = DateTime.Now;
        private DateTime endDateTime_ = DateTime.Now;
        private int fenLeiID_ = -1;
        private decimal shouru_ = 0;
        private decimal xiaofei_ = 0;

        public FenLeiDurationSummaryFrm()
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

            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                Program.MoneyNetDS.JiaoYi_FenLei.Rows)
            {
                int index = cboFenLei.Items.Add(new LstItem(row.ID, row.Name));

                if (row.ID == fenLeiID_)
                    selectIndex = index;
            }

            if (selectIndex > 0)
                cboFenLei.SelectedIndex = selectIndex;
            else if (cboFenLei.Items.Count > 0)
                cboFenLei.SelectedIndex = 0;

            RefreshGrid();
        }

        public int FenLeiID
        {
            get
            {
                return fenLeiID_;
            }

            set
            {
                fenLeiID_ = value;
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
                if (cboFenLei.SelectedItem == null)
                    return;

                LstItem item = cboFenLei.SelectedItem as LstItem;

                dgvDetail.SuspendLayout();

                dgvDetail.Rows.Clear();

                Hashtable rows = new Hashtable();

                foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                   Program.MoneyNetDS.RiChang_JiaoYi.Rows)
                {
                    if (row.JiaoYi_Time.Year == dtpStart.Value.Year &&
                        (row.JiaoYi_Time.Month > dtpStart.Value.Month ||
                        row.JiaoYi_Time.Month == dtpStart.Value.Month &&
                        row.JiaoYi_Time.Day >= dtpStart.Value.Day) &&
                        row.JiaoYi_Time.Year == dtpEnd.Value.Year &&
                        (row.JiaoYi_Time.Month < dtpEnd.Value.Month ||
                        row.JiaoYi_Time.Month == dtpEnd.Value.Month &&
                        row.JiaoYi_Time.Day <= dtpEnd.Value.Day) &&
                        row.JiaoYi_FenLei_ID == item.ID)
                    {
                        string key = row.MingCheng;

                        decimal value = 0.0M;

                        if (rows.ContainsKey(key))
                            value = (decimal)rows[key];

                        if (!row.JiaoYi_FangXiang)
                        {
                            value +=
                                row.Jin_E;

                            shouru_ += row.Jin_E;
                        }
                        else
                        {
                            value -=
                                row.Jin_E;

                            xiaofei_ += row.Jin_E;
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
            if (cboFenLei.SelectedIndex >= 0)
            {
                LstItem item = cboFenLei.SelectedItem as LstItem;

                fenLeiID_ = item.ID;
            }
            else
            {
                fenLeiID_ = -1;
            }

            RefreshGrid();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FenLeiDurationDetailFrm frm = new FenLeiDurationDetailFrm();

            frm.StartDateTime = dtpStart.Value;
            frm.EndDateTime = dtpEnd.Value;
            frm.FenLeiID = fenLeiID_;

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
            FenLeiDurationAllRecordsFrm frm = new FenLeiDurationAllRecordsFrm();

            frm.StartDateTime = dtpStart.Value;
            frm.EndDateTime = dtpEnd.Value;
            frm.FenLeiID = fenLeiID_;

            frm.ShowDialog(this);

            RefreshGrid();
        }
    }
}