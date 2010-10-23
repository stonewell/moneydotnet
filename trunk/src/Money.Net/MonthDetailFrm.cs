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
    public partial class MonthDetailFrm : Form
    {
        public MonthDetailFrm()
        {
            InitializeComponent();
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


        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDetail.Rows.Clear();
            dgvDetail.Columns.Clear();

            Hashtable rows = new Hashtable();

            decimal[] total =
                new decimal[DateTime.DaysInMonth(Program.GetDefaultYear(),
                    cboMonth.SelectedIndex + 1)];

            for (int i = 0; i < total.Length; i++)
            {
                total[i] = new decimal(0.0);
            }

            if (rdoFenLei.Checked)
            {
                foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                    Program.MoneyNetDS._JiaoYi_FenLei.Rows)
                {
                    decimal[] values =
                        new decimal[DateTime.DaysInMonth(Program.GetDefaultYear(),
                            cboMonth.SelectedIndex + 1)];

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = new decimal(0.0);
                    }

                    rows[row.Name] = values;

                }
            }
            else
            {
                foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                    Program.MoneyNetDS._JiaoYi_FangShi.Rows)
                {
                    decimal[] values =
                        new decimal[DateTime.DaysInMonth(Program.GetDefaultYear(),
                            cboMonth.SelectedIndex + 1)];

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = new decimal(0.0);
                    }

                    rows[row.Name] = values;

                }
            }

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
               Program.MoneyNetDS._RiChang_JiaoYi.Rows)
            {
                if (row.JiaoYi_Time.Year == Program.GetDefaultYear() &&
                    row.JiaoYi_Time.Month == (cboMonth.SelectedIndex + 1))
                {
                    string key = row.JiaoYi_FenLeiRow.Name;

                    if (rdoFangShi.Checked)
                    {
                        key = row.JiaoYi_FangShiRow.Name;
                    }

                    if (row.JiaoYi_FangXiang)
                    {
                        (rows[key] as decimal[])[row.JiaoYi_Time.Day - 1] -=
                            row.Jin_E;

                        total[row.JiaoYi_Time.Day - 1] -=
                            row.Jin_E;
                    }
                    else
                    {
                        (rows[key] as decimal[])[row.JiaoYi_Time.Day - 1] +=
                            row.Jin_E;

                        total[row.JiaoYi_Time.Day - 1] +=
                            row.Jin_E;
                    }
                }
            }

            if (rdoFenLei.Checked)
            {
                dgvDetail.Columns.Add("分类", "分类");
            }
            else
            {
                dgvDetail.Columns.Add("交易方式", "交易方式");
            }

            for (int i = 0; i < DateTime.DaysInMonth(Program.GetDefaultYear(),
                            cboMonth.SelectedIndex + 1); i++)
            {
                dgvDetail.Columns.Add((i + 1).ToString(), (i + 1).ToString());
            }

            dgvDetail.Columns[0].Frozen = true;

            foreach (string key in rows.Keys)
            {
                decimal[] values = rows[key] as decimal[];

                int rowIndex = dgvDetail.Rows.Add();
                dgvDetail[0, rowIndex].Value = key;

                for (int i = 0; i < values.Length; i++)
                {
                    dgvDetail[i + 1, rowIndex].Value = values[i];
                }
            }

            int shouruIndex = dgvDetail.Rows.Add();
            dgvDetail[0, shouruIndex].Value = "合计";

            for (int i = 0; i < total.Length; i++)
            {
                dgvDetail[i + 1, shouruIndex].Value = total[i];

                if (total[i] < 0)
                {
                    dgvDetail[i + 1, shouruIndex].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvDetail[i + 1, shouruIndex].Style.ForeColor = Color.Blue;
                }
            }

            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail[DateTime.Now.Day, 0].Selected = true;
            }
        }

        private void MonthDetailFrm_Load(object sender, EventArgs e)
        {
            lblYear.Text = Program.GetDefaultYear().ToString();
        }

        private void rdoFenLei_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void rdoFangShi_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDayDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count == 0)
                return;

            if (cboMonth.SelectedIndex < 0)
                return;

            if (dgvDetail.SelectedCells[0].ColumnIndex < 1)
                return;

            int column = dgvDetail.SelectedCells[0].ColumnIndex;
            int row = dgvDetail.SelectedCells[0].RowIndex;

            DayDetailFrm frm = new DayDetailFrm();
            frm.SelectedDate = new DateTime(Program.GetDefaultYear(),
                cboMonth.SelectedIndex + 1,
                dgvDetail.SelectedCells[0].ColumnIndex);

            frm.ShowDialog(this);

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