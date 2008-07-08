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
    public partial class FangShiFrm : Form
    {
        public FangShiFrm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string value = txtMingCheng.Text.Trim();

            if (value.Length == 0)
                return;

            foreach(LstItem item in lstFangShi.Items)
            {
                if (item.Name.Equals(value))
                {
                    lstFangShi.SelectedIndex =
                        lstFangShi.Items.IndexOf(item);

                    return;
                }
            }

            MoneyNetDS.JiaoYi_FangShiRow row =
                Program.MoneyNetDS.JiaoYi_FangShi.NewJiaoYi_FangShiRow();

            row.Name = value;

            Program.MoneyNetDS.JiaoYi_FangShi.Rows.Add(row);

            int index = lstFangShi.Items.Add(new LstItem(row.ID,value));

            lstFangShi.SelectedIndex = index;

            txtMingCheng.Focus();
            txtMingCheng.SelectAll();
       }

        private void FangShiFrm_Load(object sender, EventArgs e)
        {
            foreach (MoneyNetDS.JiaoYi_FangShiRow row in Program.MoneyNetDS.JiaoYi_FangShi.Rows)
            {
                lstFangShi.Items.Add(new LstItem(row.ID,row.Name));
            }

            txtMingCheng.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = txtMingCheng.Text.Trim();

            if (value.Length == 0)
                return;

            if (lstFangShi.SelectedIndex < 0)
                return;

            try
            {
                LstItem item = lstFangShi.SelectedItem as LstItem;

                MoneyNetDS.JiaoYi_FangShiRow row =
                    Program.MoneyNetDS.JiaoYi_FangShi.FindByID(item.ID);

                row.BeginEdit();
                row.Name = value;
                row.EndEdit();

                lstFangShi.Items.Remove(item);
                item.Name = value;
                lstFangShi.Items.Add(item);

                lstFangShi.SelectedIndex = lstFangShi.Items.IndexOf(item);
                txtMingCheng.Focus();
                txtMingCheng.SelectAll();
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFangShi.SelectedIndex < 0)
                return;

            try
            {
                LstItem item = lstFangShi.SelectedItem as LstItem;

                MoneyNetDS.JiaoYi_FangShiRow row =
                    Program.MoneyNetDS.JiaoYi_FangShi.FindByID(item.ID);

                row.Delete();

                lstFangShi.Items.Remove(item);

                lstFangShi.SelectedIndex = -1;

                txtMingCheng.Focus();
                txtMingCheng.SelectAll();

                Program.MoneyNetDS.JiaoYi_FangShi.AcceptChanges();
            }
            catch
            {
                Program.MoneyNetDS.JiaoYi_FangShi.RejectChanges();
            }
        }
    }
}