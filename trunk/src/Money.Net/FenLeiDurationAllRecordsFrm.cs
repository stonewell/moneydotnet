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
    public partial class FenLeiDurationAllRecordsFrm : Form
    {
        private DateTime startDateTime_ = DateTime.Now;
        private DateTime endDateTime_ = DateTime.Now;
        private int fenLeiID_ = -1;
        private decimal shouru_ = 0;
        private decimal xiaofei_ = 0;

        public FenLeiDurationAllRecordsFrm()
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
            try
            {
                shouru_ = 0;
                xiaofei_ = 0;

                if (cboFenLei.SelectedItem == null)
                    return;

                LstItem item = cboFenLei.SelectedItem as LstItem;

                dgvDetail.SuspendLayout();

                dgvDetail.Rows.Clear();

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
                        int rowIndex = dgvDetail.Rows.Add();
                        dgvDetail[0, rowIndex].Value = row.JiaoYi_Time;
                        dgvDetail[1, rowIndex].Value = row.MingCheng;
                        dgvDetail[2, rowIndex].Value = row.JiaoYi_FangShiRow.Name;
                        dgvDetail[3, rowIndex].Value =
                            row.JiaoYi_FangXiang ? row.Jin_E * -1 : row.Jin_E;
                        dgvDetail[4, rowIndex].Value = row.MiaoShu;

                        if (row.JiaoYi_FangXiang)
                        {
                            dgvDetail[3, rowIndex].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgvDetail[3, rowIndex].Style.ForeColor = Color.Blue;
                        }

                        dgvDetail.Rows[rowIndex].Tag = row;

                        if (!row.JiaoYi_FangXiang)
                        {
                            shouru_ += row.Jin_E;
                        }
                        else
                        {
                            xiaofei_ += row.Jin_E;
                        }
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
            RefreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                MoneyNetDS.RiChang_JiaoYiRow dataRow =
                    dgvDetail.SelectedCells[0].OwningRow.Tag as MoneyNetDS.RiChang_JiaoYiRow;

                TodayFrm frm = new TodayFrm(dataRow);

                frm.ShowDialog(this);

                int column = dgvDetail.SelectedCells[0].ColumnIndex;
                int row = dgvDetail.SelectedCells[0].RowIndex;

                RefreshGrid();

                if (column >= dgvDetail.Columns.Count)
                {
                    column = dgvDetail.Columns.Count - 1;
                }

                if (row >= dgvDetail.Rows.Count)
                {
                    row = dgvDetail.Rows.Count - 1;
                }

                if (column >= 0 && row >= 0)
                    dgvDetail[column, row].Selected = true;
            }
        }
    }
}