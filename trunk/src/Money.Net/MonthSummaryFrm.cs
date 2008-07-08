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
    public partial class MonthSummaryFrm : Form
    {
        public MonthSummaryFrm()
        {
            InitializeComponent();
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

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            MonthDetailFrm frm = new MonthDetailFrm();
            frm.SelectedMonth = SelectedMonth;

            frm.ShowDialog(this);

            RefreshGrid();
        }

        public int SelectedMonth
        {
            get
            {
                return cboMonth.SelectedIndex + 1;
            }

            set
            {
                if (value < 1 || value > 12)
                {
                    return;
                }

                cboMonth.SelectedIndex = value - 1;

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            Hashtable rows = new Hashtable();

            decimal shouru = new decimal(0.0);
            decimal xiaofei = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (row.JiaoYi_Time.Year == Program.GetDefaultYear() &&
                    row.JiaoYi_Time.Month == (cboMonth.SelectedIndex + 1))
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

        private void MonthSummaryFrm_Load(object sender, EventArgs e)
        {
            lblYear.Text = Program.GetDefaultYear().ToString();
        }

     }
}