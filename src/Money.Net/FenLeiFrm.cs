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
    public partial class FenLeiFrm : Form
    {
        public FenLeiFrm()
        {
            InitializeComponent();
        }

        private void FenLeiFrm_Load(object sender, EventArgs e)
        {
            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in Program.MoneyNetDS.JiaoYi_FenLei.Rows)
            {
                lstFenLei.Items.Add(new LstItem(row.ID, row.Name));
            }

            txtMingCheng.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string value = txtMingCheng.Text.Trim();

            if (value.Length == 0)
                return;

            foreach (LstItem item in lstFenLei.Items)
            {
                if (item.Name.Equals(value))
                {
                    lstFenLei.SelectedIndex =
                        lstFenLei.Items.IndexOf(item);

                    return;
                }
            }

            MoneyNetDS.JiaoYi_FenLeiRow row =
                Program.MoneyNetDS.JiaoYi_FenLei.NewJiaoYi_FenLeiRow();

            row.Name = value;

            Program.MoneyNetDS.JiaoYi_FenLei.Rows.Add(row);

            int index = lstFenLei.Items.Add(new LstItem(row.ID, value));

            lstFenLei.SelectedIndex = index;

            txtMingCheng.Focus();
            txtMingCheng.SelectAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = txtMingCheng.Text.Trim();

            if (value.Length == 0)
                return;

            if (lstFenLei.SelectedIndex < 0)
                return;

            try
            {
                LstItem item = lstFenLei.SelectedItem as LstItem;

                MoneyNetDS.JiaoYi_FenLeiRow row =
                    Program.MoneyNetDS.JiaoYi_FenLei.FindByID(item.ID);

                row.BeginEdit();
                row.Name = value;
                row.EndEdit();

                lstFenLei.Items.Remove(item);
                item.Name = value;
                lstFenLei.Items.Add(item);

                lstFenLei.SelectedIndex = lstFenLei.Items.IndexOf(item);
                txtMingCheng.Focus();
                txtMingCheng.SelectAll();
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFenLei.SelectedIndex < 0)
                return;

            try
            {
                LstItem item = lstFenLei.SelectedItem as LstItem;

                MoneyNetDS.JiaoYi_FenLeiRow row =
                    Program.MoneyNetDS.JiaoYi_FenLei.FindByID(item.ID);

                row.Delete();

                lstFenLei.Items.Remove(item);

                lstFenLei.SelectedIndex = -1;

                txtMingCheng.Focus();
                txtMingCheng.SelectAll();

                Program.MoneyNetDS.JiaoYi_FenLei.AcceptChanges();
            }
            catch
            {
                Program.MoneyNetDS.JiaoYi_FenLei.RejectChanges();
            }
        }
    }
}