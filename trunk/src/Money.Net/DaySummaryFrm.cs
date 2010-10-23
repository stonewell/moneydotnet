using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Money.Net.DB;

namespace Money.Net
{
    public partial class DaySummaryFrm : Form
    {
        public DaySummaryFrm()
        {
            InitializeComponent();
        }

        public DateTime SelectedDate
        {
            get
            {
                return dtpDate.Value;
            }

            set
            {
                dtpDate.Value = value;

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            Hashtable rows = new Hashtable();

            decimal shouru = new decimal(0.0);
            decimal xiaofei = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS._RiChang_JiaoYi.Rows)
            {
                if ((row.JiaoYi_Time.Year == dtpDate.Value.Year) &&
                    (row.JiaoYi_Time.Month == dtpDate.Value.Month) &&
                    (row.JiaoYi_Time.Date == dtpDate.Value.Date))
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
                dgvDetail.Rows.Add(key, rows[key]);
            }

            lblShouRu.Text = shouru.ToString();
            lblXiaoFei.Text = xiaofei.ToString();

            dgvDetail.ClearSelection();
        }

        private void DaySummaryFrm_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpDate.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DayDetailFrm frm = new DayDetailFrm();
            frm.SelectedDate = dtpDate.Value;

            frm.ShowDialog(this);

            RefreshGrid();
        }
    }
}