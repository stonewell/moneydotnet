using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Money.Net.Controls
{
    public partial class DailyControl : UserControl
    {
        private ZhouQi zhouqi_ = null;

        public DailyControl()
        {
            InitializeComponent();
        }

        private void DailyControl_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public ZhouQi ZhouQi
        {
            get
            {
                UpdateZhouQi();

                return zhouqi_;
            }

            set
            {
                zhouqi_ = value;

                RefreshData();
            }
        }

        private void UpdateZhouQi()
        {
            if (zhouqi_ == null)
                return;
            zhouqi_.Type = ZhouQiTypeEnum.Daily;

            if (rdoEveryDay.Checked)
            {
                zhouqi_.Daily.Type = DailyTypeEnum.EveryDay;
            }
            else
            {
                zhouqi_.Daily.Type = DailyTypeEnum.EveryWorkday;
            }

            zhouqi_.Daily.Days = Int32.Parse(txtEveryDay.Text);
        }

        private void RefreshData()
        {
            if (zhouqi_ == null)
                return;

            rdoEveryDay.Checked = zhouqi_.Daily.Type == DailyTypeEnum.EveryDay;
            rdoWorkDay.Checked = zhouqi_.Daily.Type == DailyTypeEnum.EveryWorkday;

            txtEveryDay.Text = zhouqi_.Daily.Days.ToString();
        }

        private void txtEveryDay_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int i = Int32.Parse(txtEveryDay.Text);

                if (i <= 0)
                    throw new Exception();

                txtEveryDay.ForeColor = Color.Black;
            }
            catch
            {
                txtEveryDay.ForeColor = Color.Red;
                e.Cancel = true;
            }
        }
    }
}
