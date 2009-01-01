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
    public partial class ImportDataFrm : Form
    {
        private MoneyNetDS ds_ = null;

        public ImportDataFrm()
        {
            InitializeComponent();
        }

        public MoneyNetDS ImportingDataSet
        {
            get
            {
                return ds_;
            }

            set
            {
                ds_ = value;
            }
        }

        private void ImportMappingFrm_Load(object sender, EventArgs e)
        {
            if (ds_ != null)
            {
                InitializeFenLei();
                InitializeFangShi();
                InitializeGuDing();
            }

            tabControl1.SelectedIndex = 1;
            tabControl1.SelectedIndex = 0;

            rdoAll.Checked = true;
            rdoButton_Click(rdoAll, new EventArgs());

            dtpStart.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpStart.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpEnd.MaxDate = new DateTime(Program.GetDefaultYear(), 12, 31);
            dtpEnd.MinDate = new DateTime(Program.GetDefaultYear(), 1, 1);

            dtpStart.Value = new DateTime(Program.GetDefaultYear(),
                DateTime.Now.Month, DateTime.Now.Day);
            dtpEnd.Value = new DateTime(Program.GetDefaultYear(),
                DateTime.Now.Month, DateTime.Now.Day);
        }

        private void InitializeGuDing()
        {
            dgvData.Rows.Clear();

            foreach (MoneyNetDS.GuDing_JiaoYiRow row in
                ds_.GuDing_JiaoYi.Rows)
            {
                ZhouQi zhouqi = ZhouQi.FromXmlString(row.ZhouQi);

                int rowIndex = dgvData.Rows.Add(false, row.MingCheng, zhouqi.ToString());

                dgvData.Rows[rowIndex].Tag = row;
            }

            dgvData.ClearSelection();
        }

        private void InitializeFangShi()
        {
            ArrayList importingFangShi = GetImportFangShi();
            ArrayList currentFangShi = GetCurrentFangShi();

            Hashtable mapping = GenerateMapping(importingFangShi, currentFangShi);

            mcFangShi.Mappings = mapping;
            mcFangShi.MappingSource = importingFangShi;
            mcFangShi.MappingTarget = currentFangShi;
            mcFangShi.RefreshData();
        }

        private Hashtable GenerateMapping(ArrayList importing, ArrayList current)
        {
            Hashtable results = new Hashtable();

            foreach (LstItem sItem in importing)
            {
                foreach (LstItem tItem in current)
                {
                    if (sItem.Name.Equals(tItem.Name))
                    {
                        results[sItem] = tItem;
                    }
                }
            }

            return results;
        }

        private ArrayList GetCurrentFangShi()
        {
            ArrayList result = new ArrayList();
            foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                Program.MoneyNetDS.JiaoYi_FangShi.Rows)
            {
                result.Add(new LstItem(row.ID, row.Name));
            }

            return result;
        }

        private ArrayList GetImportFangShi()
        {
            ArrayList result = new ArrayList();
            foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                ds_.JiaoYi_FangShi.Rows)
            {
                result.Add(new LstItem(row.ID, row.Name));
            }

            return result;
        }

        private void InitializeFenLei()
        {
            ArrayList importingFenLei = GetImportFenLei();
            ArrayList currentFenLei = GetCurrentFenLei();

            Hashtable mapping = GenerateMapping(importingFenLei, currentFenLei);

            mcFenLei.Mappings = mapping;
            mcFenLei.MappingSource = importingFenLei;
            mcFenLei.MappingTarget = currentFenLei;
            mcFenLei.RefreshData();
        }

        private ArrayList GetCurrentFenLei()
        {
            ArrayList result = new ArrayList();
            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                Program.MoneyNetDS.JiaoYi_FenLei.Rows)
            {
                result.Add(new LstItem(row.ID, row.Name));
            }

            return result;
        }

        private ArrayList GetImportFenLei()
        {
            ArrayList result = new ArrayList();
            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                ds_.JiaoYi_FenLei.Rows)
            {
                result.Add(new LstItem(row.ID, row.Name));
            }

            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }
            else
            {
                MergeFenLei(ds_);
                MergeFangShi(ds_);
                MergeGuDing();
                MergeRiChang(ds_);

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void MergeGuDing()
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if (dgvData[0, i].Value.Equals(true))
                {
                    MoneyNetDS.GuDing_JiaoYiRow row =
                        dgvData.Rows[i].Tag as MoneyNetDS.GuDing_JiaoYiRow;

                    MoneyNetDS.GuDing_JiaoYiRow newRow =
                        Program.MoneyNetDS.GuDing_JiaoYi.NewGuDing_JiaoYiRow();

                    newRow.MingCheng = row.MingCheng;

                    newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
                    newRow.Start_Time = row.Start_Time;
                    newRow.Stop_Time = row.Stop_Time;
                    newRow.HasEndDate = row.HasEndDate;
                    newRow.Jin_E = row.Jin_E;
                    newRow.MiaoShu = row.MiaoShu;
                    newRow.JiaoYi_FangShiRow = FindFangShi(row.JiaoYi_FangShi_ID, row.JiaoYi_FangShiRow.Name);
                    newRow.JiaoYi_FenLeiRow = FindFenLei(row.JiaoYi_FenLei_ID, row.JiaoYi_FenLeiRow.Name);
                    newRow.ZhouQi = row.ZhouQi;

                    Program.MoneyNetDS.GuDing_JiaoYi.Rows.Add(newRow);
                }
            }
        }

        private void MergeFangShi(MoneyNetDS ds)
        {
            IDictionary mappings = mcFangShi.Mappings;

            foreach (MoneyNetDS.JiaoYi_FangShiRow row1 in
                ds.JiaoYi_FangShi.Rows)
            {
                bool found = mappings.Contains(new LstItem(row1.ID, row1.Name));

                if (!found)
                {
                    MoneyNetDS.JiaoYi_FangShiRow row =
                        Program.MoneyNetDS.JiaoYi_FangShi.NewJiaoYi_FangShiRow();

                    row.Name = row1.Name;

                    Program.MoneyNetDS.JiaoYi_FangShi.Rows.Add(row);
                }
            }
        }

        private void MergeFenLei(MoneyNetDS ds)
        {
            IDictionary mappings = mcFenLei.Mappings;

            foreach (MoneyNetDS.JiaoYi_FenLeiRow row1 in
                ds.JiaoYi_FenLei.Rows)
            {
                bool found = mappings.Contains(new LstItem(row1.ID, row1.Name));

                if (!found)
                {
                    MoneyNetDS.JiaoYi_FenLeiRow row =
                        Program.MoneyNetDS.JiaoYi_FenLei.NewJiaoYi_FenLeiRow();

                    row.Name = row1.Name;

                    Program.MoneyNetDS.JiaoYi_FenLei.Rows.Add(row);
                }
            }
        }

        private void MergeRiChang(MoneyNetDS ds)
        {
            if (rdoNone.Checked)
                return;

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                ds.RiChang_JiaoYi.Rows)
            {
                if (row.JiaoYi_Time.Year == Program.GetDefaultYear())
                {
                    if (rdoAll.Checked ||
                        rdoPart.Checked &&
                        (row.JiaoYi_Time.Month > dtpStart.Value.Month ||
                        row.JiaoYi_Time.Month == dtpStart.Value.Month &&
                        row.JiaoYi_Time.Day >= dtpStart.Value.Day) &&
                        (row.JiaoYi_Time.Month < dtpEnd.Value.Month ||
                        row.JiaoYi_Time.Month == dtpEnd.Value.Month &&
                        row.JiaoYi_Time.Day <= dtpEnd.Value.Day))
                    {
                        MoneyNetDS.RiChang_JiaoYiRow newRow =
                            Program.MoneyNetDS.RiChang_JiaoYi.NewRiChang_JiaoYiRow();

                        newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
                        newRow.JiaoYi_FenLeiRow =
                            FindFenLei(row.JiaoYi_FenLei_ID, row.JiaoYi_FenLeiRow.Name);
                        newRow.JiaoYi_FangShiRow =
                            FindFangShi(row.JiaoYi_FangShi_ID, row.JiaoYi_FangShiRow.Name);
                        newRow.JiaoYi_Time = row.JiaoYi_Time;
                        newRow.Jin_E = row.Jin_E;
                        newRow.MiaoShu = row.MiaoShu;
                        newRow.MingCheng = row.MingCheng;

                        Program.MoneyNetDS.RiChang_JiaoYi.Rows.Add(newRow);
                    }
                }
            }
        }

        private MoneyNetDS.JiaoYi_FangShiRow FindFangShi(int ID, string name)
        {
            IDictionary mappings = mcFangShi.Mappings;

            LstItem item = new LstItem(ID, name);

            if (mappings.Contains(item))
            {
                item = mappings[item] as LstItem;

                return Program.MoneyNetDS.JiaoYi_FangShi.FindByID(item.ID);
            }

            foreach (MoneyNetDS.JiaoYi_FangShiRow row in
                Program.MoneyNetDS.JiaoYi_FangShi.Rows)
            {
                if (row.Name.Equals(name))
                {
                    return row;
                }
            }

            throw new Exception("交易方式" + name + "未定义");
        }

        private MoneyNetDS.JiaoYi_FenLeiRow FindFenLei(int ID, string name)
        {
            IDictionary mappings = mcFenLei.Mappings;

            LstItem item = new LstItem(ID, name);

            if (mappings.Contains(item))
            {
                item = mappings[item] as LstItem;

                return Program.MoneyNetDS.JiaoYi_FenLei.FindByID(item.ID);
            }

            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                Program.MoneyNetDS.JiaoYi_FenLei.Rows)
            {
                if (row.Name.Equals(name))
                {
                    return row;
                }
            }

            throw new Exception("分类" + name + "未定义");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrev.Enabled = true;
            btnOK.Text = "下一步";

            if (tabControl1.SelectedIndex == 0)
            {
                btnPrev.Enabled = false;
            }

            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                btnOK.Text = "确定";
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void rdoButton_Click(object sender, EventArgs e)
        {
            if (rdoPart.Checked)
            {
                lblStart.Enabled = true;
                lblEnd.Enabled = true;
                dtpEnd.Enabled = true;
                dtpStart.Enabled = true;
            }
            else
            {
                lblStart.Enabled = false;
                lblEnd.Enabled = false;
                dtpEnd.Enabled = false;
                dtpStart.Enabled = false;
            }
        }

    }
}