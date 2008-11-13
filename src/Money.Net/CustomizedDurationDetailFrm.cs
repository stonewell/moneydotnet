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
    public partial class CustomizedDurationDetailFrm : Form
    {
        private DateTime startDateTime_ = DateTime.Now;
        private DateTime endDateTime_ = DateTime.Now;

        public CustomizedDurationDetailFrm()
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

        private void CustomizedDurationDetailFrm_Load(object sender, EventArgs e)
        {
            dtpStart.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpStart.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpEnd.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.Value = endDateTime_;

            dtpStart.Value = startDateTime_;

            RefreshGrid();
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
            dgvDetail.SuspendLayout();

            dgvDetail.Rows.Clear();
            dgvDetail.Columns.Clear();

            Hashtable rows = new Hashtable();

            int days = DateTime.DaysInMonth(dtpStart.Value.Year,
                dtpStart.Value.Month) - dtpStart.Value.Day + 1
                + dtpEnd.Value.Day;

            decimal[] total = new decimal[days];

            for (int i = 0; i < total.Length; i++)
            {
                total[i] = new decimal(0.0);
            }

            if (rdoFenLei.Checked)
            {
                foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                    Program.MoneyNetDS.JiaoYi_FenLei.Rows)
                {
                    decimal[] values = new decimal[days];

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
                    Program.MoneyNetDS.JiaoYi_FangShi.Rows)
                {
                    decimal[] values = new decimal[days];

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = new decimal(0.0);
                    }

                    rows[row.Name] = values;
                }
            }

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

                    TimeSpan ts = row.JiaoYi_Time.Subtract(dtpStart.Value);

                    if (row.JiaoYi_FangXiang)
                    {
                        (rows[key] as decimal[])[ts.Days] -=
                            row.Jin_E;

                        total[ts.Days] -=
                            row.Jin_E;
                    }
                    else
                    {
                        (rows[key] as decimal[])[ts.Days] +=
                            row.Jin_E;

                        total[ts.Days] +=
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

            for (int i = 0; i < days; i++)
            {
                DateTime t = dtpStart.Value.AddDays(i);

                string name = t.Month + "月" + t.Day + "日";

                dgvDetail.Columns.Add(name,name);
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

            dgvDetail.ResumeLayout();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
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

            if (dgvDetail.SelectedCells[0].ColumnIndex < 1)
                return;

            int column = dgvDetail.SelectedCells[0].ColumnIndex;
            int row = dgvDetail.SelectedCells[0].RowIndex;

            DayDetailFrm frm = new DayDetailFrm();
            frm.SelectedDate = dtpStart.Value.AddDays(column - 1);

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