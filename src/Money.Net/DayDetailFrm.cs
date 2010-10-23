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
    public partial class DayDetailFrm : Form
    {
        public DayDetailFrm()
        {
            InitializeComponent();
        }

        private void DetailedFrm_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpDate.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);
        }

        public DateTime SelectedDate
        {
            get{
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
            dgvDetail.Rows.Clear();

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
               Program.MoneyNetDS._RiChang_JiaoYi.Rows)
            {
                if ((row.JiaoYi_Time.Year == dtpDate.Value.Year) &&
                    (row.JiaoYi_Time.Month == dtpDate.Value.Month) &&
                    (row.JiaoYi_Time.Date == dtpDate.Value.Date))
                {
                    int index = dgvDetail.Rows.Add(row.ID.ToString(),
                        row.MingCheng,
                        row.JiaoYi_FenLeiRow.Name,
                        row.JiaoYi_FangShiRow.Name,
                        row.JiaoYi_FangXiang,
                        !row.JiaoYi_FangXiang,
                        row.Jin_E.ToString(),
                        row.MiaoShu);

                    dgvDetail.Rows[index].Tag = row;
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要删除这些选择的数据么?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            System.Collections.ArrayList results = 
                new System.Collections.ArrayList();

            foreach (DataGridViewCell cell in dgvDetail.SelectedCells)
            {
                MoneyNetDS.RiChang_JiaoYiRow dataRow =
                    cell.OwningRow.Tag as MoneyNetDS.RiChang_JiaoYiRow;

                Program.UpdateHistory(dataRow, ChangeModeEnum.删除);

                dataRow.Delete();

                results.Add(cell.OwningRow);
            }

            foreach (DataGridViewRow row in results)
            {
                dgvDetail.Rows.Remove(row);
            }

            Program.MoneyNetDS._RiChang_JiaoYi.AcceptChanges();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
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