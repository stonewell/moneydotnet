using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Money.Net.Controls
{
    public partial class YearlyControl : UserControl
    {
        private ZhouQi zhouqi_ = null;

        public YearlyControl()
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

            rdoEveryYear.Checked = zhouqi_.Yearly.Type == YearlyTypeEnum.ByDate;
            rdoYearWeek.Checked = zhouqi_.Yearly.Type == YearlyTypeEnum.ByWeekDay;

            cboMonth1.SelectedItem = zhouqi_.Yearly.Month;
            cboMonth2.SelectedItem = zhouqi_.Yearly.Month;

            txtDate.Text = zhouqi_.Yearly.Date.ToString();

            cboWeek.SelectedItem = new MonthWeekItem(zhouqi_.Yearly.MonthWeek);
            cboWeekDay.SelectedItem = new WeekDayItem(zhouqi_.Yearly.WeekDay);
        }

        private void UpdateZhouQi()
        {
            if (zhouqi_ == null)
                return;

            zhouqi_.Type = ZhouQiTypeEnum.Yearly;

            if (rdoYearWeek.Checked)
            {
                zhouqi_.Yearly.Type = YearlyTypeEnum.ByWeekDay;
                zhouqi_.Yearly.Month = (int)cboMonth2.SelectedItem;
            }
            else
            {
                zhouqi_.Yearly.Type = YearlyTypeEnum.ByDate;
                zhouqi_.Yearly.Month = (int)cboMonth1.SelectedItem;
            }

            zhouqi_.Yearly.Date = Int32.Parse(txtDate.Text);
            zhouqi_.Yearly.MonthWeek = (MonthWeekEnum)(cboWeek.SelectedItem as MonthWeekItem).MonthWeek;
            zhouqi_.Yearly.WeekDay = (DayOfWeek)(cboWeekDay.SelectedItem as WeekDayItem).WeekDay;
        }

        private void YearlyControl_Load(object sender, EventArgs e)
        {
            foreach (MonthWeekEnum mw in Enum.GetValues(typeof(MonthWeekEnum)))
            {
                cboWeek.Items.Add(new MonthWeekItem(mw));
            }

            cboWeek.SelectedItem = new MonthWeekItem(MonthWeekEnum.Last);

            foreach (DayOfWeek dw in Enum.GetValues(typeof(DayOfWeek)))
            {
                cboWeekDay.Items.Add(new WeekDayItem(dw));
            }

            cboWeekDay.SelectedItem = new WeekDayItem(DateTime.Now.DayOfWeek);

            for (int i = 1; i <= 12; i++)
            {
                cboMonth1.Items.Add(i);
                cboMonth2.Items.Add(i);
            }

            cboMonth1.SelectedItem = DateTime.Now.Month;
            cboMonth2.SelectedItem = DateTime.Now.Month;
        }

        private void txtDate_Validating(object sender, CancelEventArgs e)
        {
            TextBox t = sender as TextBox;

            try
            {
                int i = Int32.Parse(t.Text);

                if (i <= 0)
                    throw new Exception();

                t.ForeColor = Color.Black;
            }
            catch
            {
                t.ForeColor = Color.Red;
                e.Cancel = true;
            }
        }
    }
}
