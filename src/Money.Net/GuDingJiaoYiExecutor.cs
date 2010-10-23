using System;
using System.Collections.Generic;
using System.Text;
using Money.Net.DB;
using System.Collections;

namespace Money.Net
{
    class GuDingJiaoYiExecutor
    {
        private MoneyNetDate CurrentTime_ =
            new MoneyNetDate(DateTime.Now);

        public GuDingJiaoYiExecutor()
        {
        }

        public void Execute()
        {
            MoneyNetDate t =
                new MoneyNetDate(CurrentTime_);

            foreach (MoneyNetDS.GuDing_JiaoYiRow row in
                Program.MoneyNetDS._GuDing_JiaoYi.Rows)
            {
                if (!row.IsLast_Execute_TimeNull())
                {
                    MoneyNetDate t2 = new MoneyNetDate(row.Last_Execute_Time);

                    if (CurrentTime_ <= t2)
                    {
                        continue;
                    }
                }

                if (row.Start_Time <= t)
                {
                    ZhouQi zhouqi = ZhouQi.FromXmlString(row.ZhouQi);

                    ArrayList results = CheckZhouQi(row, zhouqi);

                    foreach(MoneyNetDate md in results)
                    {
                        ExecuteRow(row,md);
                    }
                }
            }
        }

        private void ExecuteRow(MoneyNetDS.GuDing_JiaoYiRow row, MoneyNetDate md)
        {
            if (md.Year != Program.GetDefaultYear())
                return;

            row.BeginEdit();
            row.Last_Execute_Time = md.ToDate();
            row.EndEdit();

            MoneyNetDS.RiChang_JiaoYiRow rRow =
                Program.MoneyNetDS._RiChang_JiaoYi.NewRiChang_JiaoYiRow();

            rRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
            rRow.JiaoYi_FenLeiRow = Program.MoneyNetDS._JiaoYi_FenLei.FindByID(row.JiaoYi_FenLei_ID);
            rRow.JiaoYi_FangShiRow = Program.MoneyNetDS._JiaoYi_FangShi.FindByID(row.JiaoYi_FangShi_ID);
            rRow.JiaoYi_Time = md.ToDate();
            rRow.Jin_E = row.Jin_E;
            rRow.MiaoShu = row.MiaoShu;
            rRow.MingCheng = row.MingCheng;

            Program.MoneyNetDS._RiChang_JiaoYi.Rows.Add(rRow);
        }

        private ArrayList CheckZhouQi(MoneyNetDS.GuDing_JiaoYiRow row, ZhouQi zhouqi)
        {
            if (zhouqi.Type == ZhouQiTypeEnum.None)
            {
                if (row.IsLast_Execute_TimeNull())
                {
                    ArrayList results = new ArrayList();
                    results.Add(CurrentTime_);

                    return results;
                }
                else
                {
                    return new ArrayList();
                }
            }

            switch (zhouqi.Type)
            {
                case ZhouQiTypeEnum.Daily:
                    return CheckDaily(row, zhouqi);
                case ZhouQiTypeEnum.Monthly:
                    return CheckMonth(row, zhouqi);
                case ZhouQiTypeEnum.Weekly:
                    return CheckWeek(row, zhouqi);
                case ZhouQiTypeEnum.Yearly:
                    return CheckYear(row, zhouqi);
            }

            return new ArrayList();
        }

        private ArrayList CheckYear(MoneyNetDS.GuDing_JiaoYiRow row, ZhouQi zhouqi)
        {
            ArrayList cresults = new ArrayList();

            MoneyNetDate t = new MoneyNetDate(row.Start_Time);

            if (!row.IsLast_Execute_TimeNull())
            {
                t = new MoneyNetDate(row.Last_Execute_Time);
            }

            t.Month = zhouqi.Yearly.Month;
            t.Day = 1;

            if (t < row.Start_Time)
            {
                t.Day = row.Start_Time.Day;
            }

            while (true)
            {
                if (t > CurrentTime_)
                    break;

                if (row.HasEndDate && t > row.Stop_Time)
                    break;

                if (zhouqi.Yearly.Type == YearlyTypeEnum.ByDate)
                {
                    t.Day = zhouqi.Yearly.Date;

                    bool save = true;

                    if (!row.IsLast_Execute_TimeNull())
                    {
                        save = t != new MoneyNetDate(row.Last_Execute_Time);
                    }

                    if (t <= CurrentTime_ && save)
                    {
                        if (row.HasEndDate && t <= row.Stop_Time)
                        {
                            cresults.Add(t);
                        }
                        else if (!row.HasEndDate)
                        {
                            cresults.Add(t);
                        }
                    }
                }
                else
                {
                    ArrayList results = new ArrayList();

                    for (int i = 1; i < DateTime.DaysInMonth(t.Year, t.Month); i++)
                    {
                        MoneyNetDate tmp = new MoneyNetDate(t.Year, t.Month, i);

                        if (tmp.DayOfWeek == zhouqi.Yearly.WeekDay)
                        {
                            results.Add(tmp);
                        }
                    }

                    MoneyNetDate tmp1 = null;

                    switch (zhouqi.Yearly.MonthWeek)
                    {
                        case MonthWeekEnum.First:
                            if (results.Count > 0)
                            {
                                tmp1 = (MoneyNetDate)results[0];
                            }
                            break;
                        case MonthWeekEnum.Second:
                            if (results.Count > 1)
                            {
                                tmp1 = (MoneyNetDate)results[1];
                            }
                            break;
                        case MonthWeekEnum.Third:
                            if (results.Count > 2)
                            {
                                tmp1 = (MoneyNetDate)results[2];
                            }
                            break;
                        case MonthWeekEnum.Fourth:
                            if (results.Count > 3)
                            {
                                tmp1 = (MoneyNetDate)results[3];
                            }
                            break;
                        case MonthWeekEnum.Last:
                            if (results.Count > 0)
                            {
                                tmp1 = (MoneyNetDate)results[results.Count - 1];
                            }
                            break;
                        default:
                            break;
                    }

                    if (tmp1 != null)
                    {
                        t = tmp1;

                        bool save = true;

                        if (!row.IsLast_Execute_TimeNull())
                        {
                            save = t != new MoneyNetDate(row.Last_Execute_Time);
                        }

                        if (t <= CurrentTime_ && save)
                        {
                            if (row.HasEndDate && t <= row.Stop_Time)
                            {
                                cresults.Add(t);
                            }
                            else if (!row.HasEndDate)
                            {
                                cresults.Add(t);
                            }
                        }
                    }
                }//if

                t = t.AddYears(1);
            }//while

            return cresults;
        }

        private ArrayList CheckWeek(MoneyNetDS.GuDing_JiaoYiRow row, ZhouQi zhouqi)
        {
            ArrayList cresults = new ArrayList();

            MoneyNetDate t = new MoneyNetDate(row.Start_Time);

            if (!row.IsLast_Execute_TimeNull())
            {
                t = new MoneyNetDate(row.Last_Execute_Time);
            }

            while (true)
            {
                t = t.AddDays(-1 * (t.DayOfWeek - DayOfWeek.Sunday));

                if (t > CurrentTime_)
                    break;

                if (row.HasEndDate && t > row.Stop_Time)
                    break;

                MoneyNetDate tmp = new MoneyNetDate(t);

                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < zhouqi.Weekly.WeekDays.Length; j++)
                    {
                        if (tmp.DayOfWeek == zhouqi.Weekly.WeekDays[j])
                        {
                            bool save = true;

                            if (!row.IsLast_Execute_TimeNull())
                            {
                                save = tmp != new MoneyNetDate(row.Last_Execute_Time);
                            }

                            if (tmp <= CurrentTime_ && save)
                            {
                                if (row.HasEndDate && tmp <= row.Stop_Time)
                                {
                                    cresults.Add(tmp);
                                }
                                else if (!row.HasEndDate)
                                {
                                    cresults.Add(tmp);
                                }
                            }
                        }
                    }

                    tmp = tmp.AddDays(1);
                }

                t = t.AddDays(zhouqi.Weekly.Weeks * 7);
            }//while

            return cresults;
        }

        private ArrayList CheckMonth(MoneyNetDS.GuDing_JiaoYiRow row, ZhouQi zhouqi)
        {
            ArrayList cresults = new ArrayList();

            MoneyNetDate t = new MoneyNetDate(row.Start_Time);

            if (!row.IsLast_Execute_TimeNull())
            {
                t = new MoneyNetDate(row.Last_Execute_Time);
            }

            while (true)
            {
                if (t > CurrentTime_)
                    break;
                if (row.HasEndDate && t > row.Stop_Time)
                    break;

                MoneyNetDate t1 = null;

                if (zhouqi.Monthly.Type == MonthlyTypeEnum.ByDate)
                {
                    if (DateTime.DaysInMonth(t.Year, t.Month) >= zhouqi.Monthly.Date)
                    {
                        t1 = new MoneyNetDate(t.Year, t.Month, zhouqi.Monthly.Date);
                    }
                }
                else
                {
                    ArrayList results = new ArrayList();

                    for (int i = 1; i < DateTime.DaysInMonth(t.Year, t.Month); i++)
                    {
                        MoneyNetDate tmp = new MoneyNetDate(t.Year, t.Month, i);

                        if (tmp.DayOfWeek == zhouqi.Monthly.WeekDay)
                        {
                            results.Add(tmp);
                        }
                    }

                    switch (zhouqi.Monthly.MonthWeek)
                    {
                        case MonthWeekEnum.First:
                            if (results.Count > 0)
                            {
                                t1 = (MoneyNetDate)results[0];
                            }
                            break;
                        case MonthWeekEnum.Second:
                            if (results.Count > 1)
                            {
                                t1 = (MoneyNetDate)results[1];
                            }
                            break;
                        case MonthWeekEnum.Third:
                            if (results.Count > 2)
                            {
                                t1 = (MoneyNetDate)results[2];
                            }
                            break;
                        case MonthWeekEnum.Fourth:
                            if (results.Count > 3)
                            {
                                t1 = (MoneyNetDate)results[3];
                            }
                            break;
                        case MonthWeekEnum.Last:
                            if (results.Count > 0)
                            {
                                t1 = (MoneyNetDate)results[results.Count - 1];
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (t1 != null)
                {
                    bool save = true;

                    if (!row.IsLast_Execute_TimeNull())
                    {
                        save = t1 != new MoneyNetDate(row.Last_Execute_Time);
                    }

                    if (t1 <= CurrentTime_ && save)
                    {
                        if (row.HasEndDate && t1 <= row.Stop_Time)
                        {
                            cresults.Add(t1);
                        }
                        else if (!row.HasEndDate)
                        {
                            cresults.Add(t1);
                        }
                    }
                }

                t = t.AddMonths(zhouqi.Monthly.Months);
            }//while

            return cresults;
        }

        private ArrayList CheckDaily(MoneyNetDS.GuDing_JiaoYiRow row, ZhouQi zhouqi)
        {
            ArrayList cresults = new ArrayList();

            MoneyNetDate t = new MoneyNetDate(row.Start_Time);

            if (!row.IsLast_Execute_TimeNull())
            {
                t = new MoneyNetDate(row.Last_Execute_Time);
            }

            while (true)
            {
                if (t > CurrentTime_)
                    break;
                if (row.HasEndDate && t > row.Stop_Time)
                    break;

                if (zhouqi.Daily.Type == DailyTypeEnum.EveryWorkday)
                {
                    if (t.DayOfWeek != DayOfWeek.Sunday &&
                        t.DayOfWeek != DayOfWeek.Saturday)
                    {
                        bool save = true;

                        if (!row.IsLast_Execute_TimeNull())
                        {
                            save = t != new MoneyNetDate(row.Last_Execute_Time);
                        }

                        if (save)
                        {
                            cresults.Add(t);
                        }
                    }

                    t = t.AddDays(1);
                }
                else
                {
                    bool save = true;

                    if (!row.IsLast_Execute_TimeNull())
                    {
                        save = t != new MoneyNetDate(row.Last_Execute_Time);
                    }

                    if (save)
                    {
                        cresults.Add(t);
                    }

                    t = t.AddDays(zhouqi.Daily.Days);
                }//for
            }//while

            return cresults;
        }

#if TEST 
        public void TestZhouQi()
        {
            TestYear1();
            TestYear2();
            TestYear3();

            TestMonth1();
            TestMonth2();
        }

        private void TestYear1()
        {
            MoneyNetDS.GuDing_JiaoYiRow row =
                Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();

            ZhouQi zhouqi = new ZhouQi();

            zhouqi.Type = ZhouQiTypeEnum.Yearly;
            zhouqi.Yearly.Type = YearlyTypeEnum.ByDate;
            zhouqi.Yearly.Month = DateTime.Now.Month;
            zhouqi.Yearly.Date = DateTime.Now.Day;

            row.Start_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            row.HasEndDate = false;
            row.SetLast_Execute_TimeNull();

            System.Diagnostics.Debug.Assert(CheckYear(row, zhouqi).Count == 1, "TestYear1 Fail");
        }

        private void TestYear2()
        {
            MoneyNetDS.GuDing_JiaoYiRow row =
                Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();

            ZhouQi zhouqi = new ZhouQi();

            zhouqi.Type = ZhouQiTypeEnum.Yearly;
            zhouqi.Yearly.Type = YearlyTypeEnum.ByDate;
            zhouqi.Yearly.Month = DateTime.Now.Month;
            zhouqi.Yearly.Date = DateTime.Now.Day;

            row.Start_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            row.HasEndDate = true;
            row.Stop_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            System.Diagnostics.Debug.Assert(CheckYear(row, zhouqi).Count == 1, "TestYear2 Fail");
        }

        private void TestYear3()
        {
            MoneyNetDS.GuDing_JiaoYiRow row =
                Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();

            ZhouQi zhouqi = new ZhouQi();

            zhouqi.Type = ZhouQiTypeEnum.Yearly;
            zhouqi.Yearly.Type = YearlyTypeEnum.ByWeekDay;
            zhouqi.Yearly.Month = DateTime.Now.Month;
            zhouqi.Yearly.MonthWeek = MonthWeekEnum.First;
            zhouqi.Yearly.WeekDay = DayOfWeek.Monday;

            row.Start_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            row.HasEndDate = true;
            row.Stop_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            row.Last_Execute_Time = new DateTime(DateTime.Now.Year - 1,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            System.Diagnostics.Debug.Assert(CheckYear(row, zhouqi).Count == 1, "TestYear3 Fail");
        }

        private void TestMonth1()
        {
            MoneyNetDS.GuDing_JiaoYiRow row =
                Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();

            ZhouQi zhouqi = new ZhouQi();

            zhouqi.Type = ZhouQiTypeEnum.Monthly;
            zhouqi.Monthly.Type = MonthlyTypeEnum.ByDate;
            zhouqi.Monthly.Months = 1;
            zhouqi.Monthly.Date = DateTime.Now.Day;
            zhouqi.Monthly.MonthWeek = MonthWeekEnum.First;
            zhouqi.Monthly.WeekDay = DayOfWeek.Monday;

            CurrentTime_ = CurrentTime_.AddMonths(1);

            row.Start_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            row.HasEndDate = false;
            row.Stop_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            row.Last_Execute_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            System.Diagnostics.Debug.Assert(CheckZhouQi(row, zhouqi).Count == 1, "TestMonth1 Fail");
        }

        private void TestMonth2()
        {
            MoneyNetDS.GuDing_JiaoYiRow row =
                Program.MoneyNetDS._GuDing_JiaoYi.NewGuDing_JiaoYiRow();

            ZhouQi zhouqi = new ZhouQi();

            zhouqi.Type = ZhouQiTypeEnum.Monthly;
            zhouqi.Monthly.Type = MonthlyTypeEnum.ByWeekDay;
            zhouqi.Monthly.Months = 2;
            zhouqi.Monthly.Date = DateTime.Now.Day;
            zhouqi.Monthly.MonthWeek = MonthWeekEnum.First;
            zhouqi.Monthly.WeekDay = DayOfWeek.Monday;

            CurrentTime_ = new MoneyNetDate(DateTime.Now.AddMonths(2));
            CurrentTime_.Day += 5;

            row.Start_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            row.HasEndDate = false;
            row.Stop_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            row.Last_Execute_Time = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month - 2, DateTime.Now.Day, 23, 59, 59);

            System.Diagnostics.Debug.Assert(CheckZhouQi(row, zhouqi).Count == 2, "TestMonth2 Fail");
        }
#endif
    }
}
