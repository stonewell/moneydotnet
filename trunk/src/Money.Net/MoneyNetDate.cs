using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Net
{
    class MoneyNetDate : IComparable
    {
        public int Year;
        public int Month;
        public int Day;

        public MoneyNetDate(DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
        }

        public MoneyNetDate(MoneyNetDate dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
        }

        public MoneyNetDate(int y, int m, int d)
        {
            Year = y;
            Month = m;
            Day = d;
        }

        public MoneyNetDate AddMonths(int months)
        {
            return new MoneyNetDate(ToDate().AddMonths(months));
        }

        public MoneyNetDate AddDays(int days)
        {
            return new MoneyNetDate(ToDate().AddDays(days));
        }

        public DateTime ToDate()
        {
            return new DateTime(Year, Month, Day, 0, 0, 0);
        }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return ToDate().DayOfWeek;
            }
        }

        public MoneyNetDate AddYears(int p)
        {
            int newYear = Year + p;

            int newDay = Day;

            if (newDay > DateTime.DaysInMonth(newYear, Month))
            {
                newDay = DateTime.DaysInMonth(Year, Month);
            }

            return new MoneyNetDate(newYear, Month, newDay);
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj is MoneyNetDate)
            {
                MoneyNetDate t = obj as MoneyNetDate;

                return t.Year == Year && t.Month == Month && t.Day == Day;
            }

            if (obj is DateTime)
            {
                DateTime t = (DateTime)obj;

                return t.Year == Year && t.Month == Month && t.Day == Day;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ToDate().GetHashCode();
        }

        public override string ToString()
        {
            return ToDate().ToString();
        }
        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is MoneyNetDate)
            {
                return ToDate().CompareTo((obj as MoneyNetDate).ToDate());
            }

            return -1;
        }

        #endregion

        #region Operators
        public static bool operator <(MoneyNetDate t1, MoneyNetDate t2)
        {
            return t1.ToDate() < t2.ToDate();
        }

        public static bool operator >(MoneyNetDate t1, MoneyNetDate t2)
        {
            return t1.ToDate() > t2.ToDate();
        }

        public static bool operator <(MoneyNetDate t1, DateTime t2)
        {
            return t1.ToDate() < new MoneyNetDate(t2).ToDate();
        }

        public static bool operator >(MoneyNetDate t1, DateTime t2)
        {
            return t1.ToDate() > new MoneyNetDate(t2).ToDate();
        }

        public static bool operator <(DateTime t1, MoneyNetDate t2)
        {
            return new MoneyNetDate(t1).ToDate() < t2;
        }

        public static bool operator >(DateTime t1, MoneyNetDate t2)
        {
            return new MoneyNetDate(t1).ToDate() > t2;
        }

        public static bool operator <=(MoneyNetDate t1, MoneyNetDate t2)
        {
            return t1.ToDate() <= t2.ToDate();
        }

        public static bool operator >=(MoneyNetDate t1, MoneyNetDate t2)
        {
            return t1.ToDate() >= t2.ToDate();
        }

        public static bool operator <=(MoneyNetDate t1, DateTime t2)
        {
            return t1.ToDate() <= new MoneyNetDate(t2).ToDate();
        }

        public static bool operator >=(MoneyNetDate t1, DateTime t2)
        {
            return t1.ToDate() >= new MoneyNetDate(t2).ToDate();
        }

        public static bool operator <=(DateTime t1, MoneyNetDate t2)
        {
            return new MoneyNetDate(t1).ToDate() <= t2.ToDate();
        }

        public static bool operator >=(DateTime t1, MoneyNetDate t2)
        {
            return new MoneyNetDate(t1).ToDate() >= t2.ToDate();
        }

        public static bool operator ==(MoneyNetDate t1, MoneyNetDate t2)
        {
            try
            {
                return t1.Equals(t2);
            }
            catch (NullReferenceException)
            {
                try
                {
                    return t2.Equals(t1);
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool operator !=(MoneyNetDate t1, MoneyNetDate t2)
        {
            try
            {
                return !t1.Equals(t2);
            }
            catch (NullReferenceException)
            {
                try
                {
                    return !t2.Equals(t1);
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion

    }
}
