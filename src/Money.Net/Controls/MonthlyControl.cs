using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Money.Net.Controls
{
    public class MonthWeekItem
    {
        public MonthWeekEnum MonthWeek = MonthWeekEnum.Last;

        public MonthWeekItem(MonthWeekEnum monthWeek)
        {
            MonthWeek = monthWeek;
        }

        public override string ToString()
        {
            return EnumFormater.ToString(MonthWeek);
        }

        public override bool Equals(object obj)
        {
            if (obj is MonthWeekItem)
            {
                MonthWeekItem item = obj as MonthWeekItem;

                return item.MonthWeek == MonthWeek;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    public class WeekDayItem
    {
        public DayOfWeek WeekDay = DateTime.Now.DayOfWeek;

        public WeekDayItem(DayOfWeek weekday)
        {
            WeekDay = weekday;
        }

        public override string ToString()
        {
            return EnumFormater.ToString(WeekDay);
        }

        public override bool Equals(object obj)
        {
            if (obj is WeekDayItem)
            {
                WeekDayItem item = obj as WeekDayItem;

                return item.WeekDay == WeekDay;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    public partial class MonthlyControl : UserControl
    {
        private ZhouQi zhouqi_ = null;

        public MonthlyControl()
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

            rdoEveryMonth.Checked = zhouqi_.Monthly.Type == MonthlyTypeEnum.ByDate;
            rdoMonthWeek.Checked = zhouqi_.Monthly.Type == MonthlyTypeEnum.ByWeekDay;

            txtDate.Text = zhouqi_.Monthly.Date.ToString();
            txtMonth1.Text = zhouqi_.Monthly.Months.ToString();
            txtMonth2.Text = zhouqi_.Monthly.Months.ToString();
            cboWeek.SelectedItem = new MonthWeekItem(zhouqi_.Monthly.MonthWeek);
            cboWeekDay.SelectedItem = new WeekDayItem(zhouqi_.Monthly.WeekDay);
        }

        private void UpdateZhouQi()
        {
            if (zhouqi_ == null)
                return;
            zhouqi_.Type = ZhouQiTypeEnum.Monthly;

            if (rdoEveryMonth.Checked)
            {
                zhouqi_.Monthly.Type = MonthlyTypeEnum.ByDate;
                zhouqi_.Monthly.Months = Int32.Parse(txtMonth1.Text);
            }
            else
            {
                zhouqi_.Monthly.Type = MonthlyTypeEnum.ByWeekDay;
                zhouqi_.Monthly.Months = Int32.Parse(txtMonth2.Text);
            }

            zhouqi_.Monthly.Date = Int32.Parse(txtDate.Text);
            zhouqi_.Monthly.MonthWeek = (MonthWeekEnum)(cboWeek.SelectedItem as MonthWeekItem).MonthWeek;
            zhouqi_.Monthly.WeekDay = (DayOfWeek)(cboWeekDay.SelectedItem as WeekDayItem).WeekDay;
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
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

        private void MonthlyControl_Load(object sender, EventArgs e)
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
        }
    }
}
