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
    public partial class RestoreGuDingFrm : Form
    {
        public RestoreGuDingFrm()
        {
            InitializeComponent();
        }

        private void RestoreGuDingFrm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDetail.Rows.Clear();

            foreach (MoneyNetDS.GuDing_JiaoYi_HistoryRow row in
               Program.MoneyNetDS._GuDing_JiaoYi_History.Rows)
            {
                ZhouQi zhouqi = Money.Net.ZhouQi.FromXmlString(row.ZhouQi); 
                int index = dgvDetail.Rows.Add(false,
                    row.Change_Time,
                    row.Change_Mode,
                    row.MingCheng,
                    row.JiaoYi_FenLei_Name,
                    row.JiaoYi_FangShi_Name,
                    zhouqi.ToString(),
                    row.JiaoYi_FangXiang,
                    !row.JiaoYi_FangXiang,
                    row.Jin_E.ToString(),
                    row.MiaoShu,
                    row.Start_Time,
                    row.HasEndDate,
                    row.Stop_Time,
                    row.Last_Execute_Time);

                dgvDetail.Rows[index].Tag = row;

                if (row.Change_Mode.Equals(ChangeModeEnum.已恢复.ToString()))
                {
                    dgvDetail[2, index].Style.ForeColor = Color.Red;
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Program.MoneyNetDS.AcceptChanges();

            try
            {
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    if (dgvDetail[0, i].Value.Equals(true))
                    {
                        MoneyNetDS.GuDing_JiaoYi_HistoryRow row =
                            dgvDetail.Rows[i].Tag as MoneyNetDS.GuDing_JiaoYi_HistoryRow;

                        if (row.Change_Mode.Equals(ChangeModeEnum.已恢复.ToString()))
                        {
                            DialogResult result = MessageBox.Show(this,
                                "记录:" + row.MingCheng + "[" + row.MiaoShu + "] 已经恢复过了,还要继续恢复么?",
                                "警告",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.No)
                                continue;
                            else if (result == DialogResult.Cancel)
                                throw new Exception("Cancel");
                        }

                        bool bNewRow = true;

                        MoneyNetDS.GuDing_JiaoYiRow newRow = null;

                        if (!row.IsGuDing_IDNull())
                            newRow = Program.MoneyNetDS._GuDing_JiaoYi.FindByID(row.GuDing_ID);

                        if (newRow != null)
                        {
                            bNewRow = false;
                            newRow.BeginEdit();
                        }
                        else
                        {
                            newRow = Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();
                        }

                        newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
                        newRow.JiaoYi_FenLeiRow =
                            Program.MoneyNetDS._JiaoYi_FenLei.FindByID(row.JiaoYi_FenLei_ID);
                        newRow.JiaoYi_FangShiRow =
                            Program.MoneyNetDS._JiaoYi_FangShi.FindByID(row.JiaoYi_FangShi_ID);
                        newRow.Last_Execute_Time = row.Last_Execute_Time;
                        newRow.Start_Time = row.Start_Time;
                        newRow.Stop_Time = row.Stop_Time;
                        newRow.HasEndDate = row.HasEndDate;
                        newRow.Jin_E = row.Jin_E;
                        newRow.MiaoShu = row.MiaoShu;
                        newRow.MingCheng = row.MingCheng;
                        newRow.ZhouQi = row.ZhouQi;

                        if (bNewRow)
                        {
                            Program.MoneyNetDS._GuDing_JiaoYi.Rows.Add(newRow);
                        }
                        else
                        {
                            newRow.EndEdit();
                        }

                        row.BeginEdit();
                        row.GuDing_ID = newRow.ID;
                        row.Change_Mode = ChangeModeEnum.已恢复.ToString();
                        row.EndEdit();
                    }//if
                }//for

                Program.MoneyNetDS.AcceptChanges();
            }
            catch
            {
                Program.MoneyNetDS.RejectChanges();
            }
            finally
            {
                RefreshGrid();
            }
        }
    }
}