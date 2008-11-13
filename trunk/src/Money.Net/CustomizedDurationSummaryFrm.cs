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
    public partial class CustomizedDurationSummaryFrm : Form
    {
        public CustomizedDurationSummaryFrm()
        {
            InitializeComponent();
        }

        private void CustomizedDurationSummaryFrm_Load(object sender, EventArgs e)
        {
            dtpStart.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpStart.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpEnd.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.Value = new DateTime(Program.GetDefaultYear(),
                DateTime.Now.Month, DateTime.Now.Day);

            DateTime s = new DateTime(dtpEnd.Value.Ticks);
            s = s.AddMonths(-1);

            if (s.Year != Program.GetDefaultYear())
                s = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpStart.Value = s;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            Hashtable rows = new Hashtable();

            decimal shouru = new decimal(0.0);
            decimal xiaofei = new decimal(0.0);

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
                    row.JiaoYi_Time.Day <= dtpEnd.Value.Day))
                {
                    string key = row.JiaoYi_FenLeiRow.Name;

                    if (rdoFangShi.Checked)
                    {
                        key = row.JiaoYi_FangShiRow.Name;
                    }

                    if (rows.ContainsKey(key))
                    {
                        decimal value = (decimal)rows[key];

                        if (row.JiaoYi_FangXiang)
                        {
                            value = value - row.Jin_E;
                        }
                        else
                        {
                            value = value + row.Jin_E;
                        }

                        rows[key] = value;
                    }
                    else
                    {
                        if (row.JiaoYi_FangXiang)
                        {
                            rows[key] = row.Jin_E * -1;
                        }
                        else
                        {
                            rows[key] = row.Jin_E;
                        }
                    }

                    if (row.JiaoYi_FangXiang)
                    {
                        xiaofei += row.Jin_E;
                    }
                    else
                    {
                        shouru += row.Jin_E;
                    }
                }
            }

            dgvDetail.Rows.Clear();

            foreach (string key in rows.Keys)
            {
                int rowIndex = dgvDetail.Rows.Add(key, rows[key]);
            }

            lblShouRu.Text = shouru.ToString();
            lblXiaoFei.Text = xiaofei.ToString();
        }

        private void rdoFenLei_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetail.Columns[0].HeaderText = "分类";

            RefreshGrid();
        }

        private void rdoFangShi_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetail.Columns[0].HeaderText = "交易方式";

            RefreshGrid();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            CustomizedDurationDetailFrm frm = new CustomizedDurationDetailFrm();

            frm.StartDateTime = dtpStart.Value;
            frm.EndDateTime = dtpEnd.Value;

            frm.ShowDialog(this);

            RefreshGrid();
        }
    }
}