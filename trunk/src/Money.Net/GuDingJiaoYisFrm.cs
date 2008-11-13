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
    public partial class GuDingJiaoYisFrm : Form
    {
        public GuDingJiaoYisFrm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewGuDingJiaoYiFrm frm = new NewGuDingJiaoYiFrm();

            frm.ShowDialog(this);

            RefreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                MoneyNetDS.GuDing_JiaoYiRow dataRow =
                    dgvData.SelectedRows[0].Tag as MoneyNetDS.GuDing_JiaoYiRow;

                NewGuDingJiaoYiFrm frm = new NewGuDingJiaoYiFrm(dataRow);

                frm.ShowDialog(this);

                RefreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.SelectedRows)
            {
                MoneyNetDS.GuDing_JiaoYiRow dataRow =
                    row.Tag as MoneyNetDS.GuDing_JiaoYiRow;

                Program.UpdateHistory(dataRow, ChangeModeEnum.É¾³ý);

                dataRow.Delete();
            }

            Program.MoneyNetDS.GuDing_JiaoYi.AcceptChanges();

            RefreshGrid();
        }

        private void GuDingJiaoYisFrm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvData.Rows.Clear();

            foreach (MoneyNetDS.GuDing_JiaoYiRow row in
                Program.MoneyNetDS.GuDing_JiaoYi.Rows)
            {
                ZhouQi zhouqi = ZhouQi.FromXmlString(row.ZhouQi);

                int rowIndex = dgvData.Rows.Add(row.MingCheng, zhouqi.ToString());

                dgvData.Rows[rowIndex].Tag = row;
            }

            dgvData.ClearSelection();
        }
    }
}