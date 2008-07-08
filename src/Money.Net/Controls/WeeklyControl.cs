using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Money.Net.Controls
{
    public partial class WeeklyControl : UserControl
    {
        private ZhouQi zhouqi_ = null;

        public WeeklyControl()
        {
            InitializeComponent();
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

        private void RefreshData()
        {
            if (zhouqi_ == null)
                return;

            txtWeeks.Text = zhouqi_.Weekly.Weeks.ToString();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            foreach (DayOfWeek dw in zhouqi_.Weekly.WeekDays)
            {
                switch (dw)
                {
                    case DayOfWeek.Monday:
                        checkBox1.Checked = true;
                        break;
                    case DayOfWeek.Tuesday:
                        checkBox2.Checked = true;
                        break;
                    case DayOfWeek.Wednesday:
                        checkBox3.Checked = true;
                        break;
                    case DayOfWeek.Thursday:
                        checkBox4.Checked = true;
                        break;
                    case DayOfWeek.Friday:
                        checkBox5.Checked = true;
                        break;
                    case DayOfWeek.Saturday:
                        checkBox6.Checked = true;
                        break;
                    case DayOfWeek.Sunday:
                        checkBox7.Checked = true;
                        break;
                }
            }
        }

        private void UpdateZhouQi()
        {
            if (zhouqi_ == null)
                return;
            zhouqi_.Type = ZhouQiTypeEnum.Weekly;
            zhouqi_.Weekly.Weeks = Int32.Parse(txtWeeks.Text);

            ArrayList results = new ArrayList();

            if (checkBox1.Checked) results.Add(DayOfWeek.Monday);
            if (checkBox2.Checked) results.Add(DayOfWeek.Tuesday);
            if (checkBox3.Checked) results.Add(DayOfWeek.Wednesday);
            if (checkBox4.Checked) results.Add(DayOfWeek.Thursday);
            if (checkBox5.Checked) results.Add(DayOfWeek.Friday);
            if (checkBox6.Checked) results.Add(DayOfWeek.Saturday);
            if (checkBox7.Checked) results.Add(DayOfWeek.Sunday);

            zhouqi_.Weekly.WeekDays =
                results.ToArray(typeof(DayOfWeek)) as DayOfWeek[];
        }

        private void txtWeeks_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int i = Int32.Parse(txtWeeks.Text);

                if (i <= 0)
                    throw new Exception();

                txtWeeks.ForeColor = Color.Black;
            }
            catch
            {
                txtWeeks.ForeColor = Color.Red;
                e.Cancel = true;
            }
        }
    }
}
