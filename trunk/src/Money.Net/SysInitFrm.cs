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
    public partial class SysInitFrm : Form
    {
        public SysInitFrm()
        {
            InitializeComponent();
        }

        private void txtInitialJinE_Validating(object sender, CancelEventArgs e)
        {
            string value = txtJinE.Text.Trim();

            try
            {
                double.Parse(value);

                e.Cancel = false;

                lblJinE.ForeColor = Color.Black;
            }
            catch
            {
                txtJinE.SelectAll();
                e.Cancel = true;

                lblJinE.ForeColor = Color.Red;
            }
        }

        private void SysInitFrm_Load(object sender, EventArgs e)
        {
            txtJinE.Focus();

            txtJinE.Text = Program.GetDefaultYearInitValue().ToString();

            foreach (MoneyNetConfigDS.JiZhang_NianDuRow row in
                Program.ConfigDS.JiZhang_NianDu.Rows)
            {
                cboYears.Items.Add(row.Year);
            }

            if (cboYears.Items.Count == 0)
                cboYears.Items.Add(DateTime.Now.Year);

            cboYears.SelectedItem = Program.GetDefaultYear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.SetDefaultYear(Int32.Parse(cboYears.SelectedItem.ToString()));
            Program.SetDefaultYearInitValue(decimal.Parse(txtJinE.Text.Trim()));

            Close();
        }

        private void cboYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtJinE.Text = Program.GetYearInitialValue(Int32.Parse(cboYears.SelectedItem.ToString())).ToString();
        }
    }
}