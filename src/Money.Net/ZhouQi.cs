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
                return "ÿ" + Days + "��";
            }
            else
            {
                return "ÿ��������";
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

            return "ÿ" + Weeks + "�ܵ�" + tmp;
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
                    return "��һ��";
                case MonthWeekEnum.Fourth:
                    return "���ĸ�";
                case MonthWeekEnum.Last:
                    return "���һ��";
                case MonthWeekEnum.Second:
                    return "�ڶ���";
                case MonthWeekEnum.Third:
                    return "������";
                default:
                    return monthweek.ToString();
            }
        }

        public static string ToString(DayOfWeek weekday)
        {
            switch (weekday)
            {
                case DayOfWeek.Friday:
                    return "������";
                case DayOfWeek.Monday:
                    return "����һ";
                case DayOfWeek.Saturday:
                    return "������";
                case DayOfWeek.Sunday:
                    return "������";
                case DayOfWeek.Thursday:
                    return "������";
                case DayOfWeek.Tuesday:
                    return "���ڶ�";
                case DayOfWeek.Wednesday:
                    return "������";
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
                return "ÿ" + Months + "�µ�" + Date + "��";
            }
            else
            {
                return "ÿ" + Months + "�µ�" + 
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
                return "ÿ��" + Month + "�µ�" + Date + "��";
            }
            else
            {
                return "ÿ��" + Month + "�µ�" + 
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
                    return "������";
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
