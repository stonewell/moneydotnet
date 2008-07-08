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
    public partial class RestoreRiChangFrm : Form
    {
        public RestoreRiChangFrm()
        {
            InitializeComponent();
        }

        private void RestoreRiChangFrm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDetail.Rows.Clear();

            foreach (MoneyNetDS.RiChang_JiaoYi_HistoryRow row in
               Program.MoneyNetDS.RiChang_JiaoYi_History.Rows)
            {
                int index = dgvDetail.Rows.Add(false,
                    row.Change_Time,
                    row.Change_Mode,
                    row.MingCheng,
                    row.JiaoYi_FenLei_Name,
                    row.JiaoYi_FangShi_Name,
                    row.JiaoYi_FangXiang,
                    !row.JiaoYi_FangXiang,
                    row.Jin_E.ToString(),
                    row.MiaoShu);

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
                        MoneyNetDS.RiChang_JiaoYi_HistoryRow row =
                            dgvDetail.Rows[i].Tag as MoneyNetDS.RiChang_JiaoYi_HistoryRow;

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

                        MoneyNetDS.RiChang_JiaoYiRow newRow = null;

                        if (!row.IsRiChang_IDNull())
                            newRow = Program.MoneyNetDS.RiChang_JiaoYi.FindByID(row.RiChang_ID);

                        if (newRow != null)
                        {
                            bNewRow = false;
                            newRow.BeginEdit();
                        }
                        else
                        {
                            newRow = Program.MoneyNetDS.RiChang_JiaoYi.NewRiChang_JiaoYiRow();
                        }

                        newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
                        newRow.JiaoYi_FenLeiRow =
                            Program.MoneyNetDS.JiaoYi_FenLei.FindByID(row.JiaoYi_FenLei_ID);
                        newRow.JiaoYi_FangShiRow =
                            Program.MoneyNetDS.JiaoYi_FangShi.FindByID(row.JiaoYi_FangShi_ID);
                        newRow.JiaoYi_Time = row.JiaoYi_Time;
                        newRow.Jin_E = row.Jin_E;
                        newRow.MiaoShu = row.MiaoShu;
                        newRow.MingCheng = row.MingCheng;

                        if (bNewRow)
                        {
                            Program.MoneyNetDS.RiChang_JiaoYi.Rows.Add(newRow);
                        }
                        else
                        {
                            newRow.EndEdit();
                        }

                        row.BeginEdit();
                        row.RiChang_ID = newRow.ID;
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