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
    public partial class MainFrmSettings : Form
    {
        public MainFrmSettings()
        {
            InitializeComponent();
        }

        private void MainFrmSettings_Load(object sender, EventArgs e)
        {
            foreach (MoneyNetDS.JiaoYi_FenLeiRow row in
                Program.MoneyNetDS._JiaoYi_FenLei.Rows)
            {
                cboFenLei.Items.Add(new LstItem(row.ID,row.Name));
            }

            int fenlei = Program.GetMainFrmFenLei();

            if (fenlei >= 0 && cboFenLei.Items.Contains(new LstItem(fenlei,"")))
            {
                cboFenLei.SelectedIndex = 
                    cboFenLei.Items.IndexOf(new LstItem(fenlei,""));
            }
            else
            {
                cboFenLei.SelectedIndex = -1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboFenLei.SelectedIndex >= 0)
            {
                Program.SetMainFrmFenLei((cboFenLei.SelectedItem as LstItem).ID);

                Close();
            }
        }
    }
}