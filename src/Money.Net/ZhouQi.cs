using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Net
{
    public enum ZhouQiTypeEnum
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum DailyTypeEnum
    {
        EveryDay,
        EveryWorkday,
    }

    public class DailyZhouQi
    {
        public DailyTypeEnum Type = DailyTypeEnum.EveryDay;
        public int Days = 1;

        public override string ToString()
        {
            if (Type == DailyTypeEnum.EveryDay)
            {
                return "每" + Days + "天";
            }
            else
            {
                return "每个工作日";
            }
        }
    }

    public class WeeklyZhouQi
    {
        public int Weeks = 1;
        public DayOfWeek[] WeekDays = new DayOfWeek[] { DateTime.Now.DayOfWeek };

        public override string ToString()
        {
            string tmp = "";

            for(int i = 0;i < WeekDays.Length;i++)
            {
                if (i > 0)
                {
                    tmp += ",";
                }

                tmp += EnumFormater.ToString(WeekDays[i]);
            }

            return "每" + Weeks + "周的" + tmp;
        }
    }

    public enum MonthlyTypeEnum
    {
        ByDate,
        ByWeekDay
    }

    public enum MonthWeekEnum
    {
        First,
        Second,
        Third,
        Fourth,
        Last
    };

    public static class EnumFormater
    {
        public static string ToString(MonthWeekEnum monthweek)
        {
            switch (monthweek)
            {
                case MonthWeekEnum.First:
                    return "第一个";
                case MonthWeekEnum.Fourth:
                    return "第四个";
                case MonthWeekEnum.Last:
                    return "最后一个";
                case MonthWeekEnum.Second:
                    return "第二个";
                case MonthWeekEnum.Third:
                    return "第三个";
                default:
                    return monthweek.ToString();
            }
        }

        public static string ToString(DayOfWeek weekday)
        {
            switch (weekday)
            {
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Saturday:
                    return "星期六";
                case DayOfWeek.Sunday:
                    return "星期日";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                default:
                    return weekday.ToString();
            }
        }
    }

    public class MonthlyZhouQi
    {
        public MonthlyTypeEnum Type = MonthlyTypeEnum.ByDate;

        public int Months = 1;

        public int Date = DateTime.Now.Day;

        public MonthWeekEnum MonthWeek = MonthWeekEnum.Last;
        public DayOfWeek WeekDay = DateTime.Now.DayOfWeek;

        public override string ToString()
        {
            if (Type == MonthlyTypeEnum.ByDate)
            {
                return "每" + Months + "月的" + Date + "号";
            }
            else
            {
                return "每" + Months + "月的" + 
                    EnumFormater.ToString(MonthWeek) + 
                    EnumFormater.ToString(WeekDay);
            }
        }
    }

    public enum YearlyTypeEnum
    {
        ByDate,
        ByWeekDay
    }

    public class YearlyZhouQi
    {
        public YearlyTypeEnum Type = YearlyTypeEnum.ByDate;

        public int Month = DateTime.Now.Month;
        public int Date = DateTime.Now.Day;

        public MonthWeekEnum MonthWeek = MonthWeekEnum.Last;
        public DayOfWeek WeekDay = DateTime.Now.DayOfWeek;

        public override string ToString()
        {
            if (Type == YearlyTypeEnum.ByDate)
            {
                return "每年" + Month + "月的" + Date + "号";
            }
            else
            {
                return "每年" + Month + "月的" + 
                    EnumFormater.ToString(MonthWeek) +
                    EnumFormater.ToString(WeekDay);
            }
        }
    }

    [System.Xml.Serialization.XmlRoot()]
    public class ZhouQi
    {
        public ZhouQiTypeEnum Type = ZhouQiTypeEnum.Weekly;

        public DailyZhouQi Daily = new DailyZhouQi();
        public WeeklyZhouQi Weekly = new WeeklyZhouQi();
        public MonthlyZhouQi Monthly = new MonthlyZhouQi();
        public YearlyZhouQi Yearly = new YearlyZhouQi();

        public override string ToString()
        {
            switch (Type)
            {
                case ZhouQiTypeEnum.None:
                    return "无周期";
                case ZhouQiTypeEnum.Daily:
                    return Daily.ToString();
                case ZhouQiTypeEnum.Weekly:
                    return Weekly.ToString();
                case ZhouQiTypeEnum.Monthly:
                    return Monthly.ToString();
                case ZhouQiTypeEnum.Yearly:
                    return Yearly.ToString();
            }

            return base.ToString();
        }

        private static readonly System.Xml.Serialization.XmlSerializer xs_ =
            new System.Xml.Serialization.XmlSerializer(typeof(ZhouQi));

        public static ZhouQi FromXmlString(string xml)
        {
            return xs_.Deserialize(new System.IO.StringReader(xml)) as ZhouQi;
        }

        public static string ToXmlString(ZhouQi zhouqi)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();

            xs_.Serialize(sw, zhouqi);

            return sw.ToString();
        }
    }
}
