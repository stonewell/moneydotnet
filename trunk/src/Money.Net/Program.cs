using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Money.Net.DB;

namespace Money.Net
{
    public enum ChangeModeEnum
    {
        编辑,
        删除,
        已恢复
    };

    static class Program
    {
        private static MoneyNetDS moneyNetDS_ =
            new MoneyNetDS();

        private static readonly MoneyNetConfigDS configDS_ =
            new MoneyNetConfigDS();

        private static string defaultYearFilePath_ = null;

        public static MoneyNetDS MoneyNetDS
        {
            get
            {
                return moneyNetDS_;
            }
        }

        public static MoneyNetConfigDS ConfigDS
        {
            get
            {
                return configDS_;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!LoadData())
            {
                Application.Exit();
                return;
            }

            GuDingJiaoYi();

            Application.Run(new MainFrm());

            SaveData();
        }

        private static void GuDingJiaoYi()
        {
            try
            {
                GuDingJiaoYiExecutor e = new GuDingJiaoYiExecutor();
                e.Execute();

                moneyNetDS_.AcceptChanges();
#if TEST
            e.TestZhouQi();
#endif
            }
            catch (Exception ex)
            {
                moneyNetDS_.RejectChanges();

                MessageBox.Show("执行固定周期交易错误:" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SaveData()
        {
            configDS_.WriteXml(AppDomain.CurrentDomain.BaseDirectory +
            System.IO.Path.DirectorySeparatorChar + "Money.Net.Config.xml");

            try
            {
                moneyNetDS_.AcceptChanges();
                moneyNetDS_.WriteXml(defaultYearFilePath_);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据文件:" + defaultYearFilePath_ + "错误:" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool LoadData()
        {
            return LoadData(false);
        }

        private static bool LoadData(bool reload)
        {
            if (!reload)
            {
                if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory +
                    System.IO.Path.DirectorySeparatorChar + "Money.Net.Config.xml"))
                {
                    configDS_.ReadXml(AppDomain.CurrentDomain.BaseDirectory +
                    System.IO.Path.DirectorySeparatorChar + "Money.Net.Config.xml");
                }
            }
            else
            {
                moneyNetDS_ = new MoneyNetDS();
            }

            int year = GetDefaultYear();

            defaultYearFilePath_ = GetYearFilePath(year);

            if (defaultYearFilePath_ == null)
            {
                if (DialogResult.Cancel == MessageBox.Show("请设置记帐年度：" + year +
                        "的数据文件路径", "系统设置",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information))
                {
                    if (DialogResult.Yes == MessageBox.Show("记帐年度：" + year +
                        "未设置数据文件系统无法运行，要退出系统么?", "确认退出",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        return false;
                    }
                }

                while (defaultYearFilePath_ == null)
                {
                    JiZhangNianDuFrm frm = new JiZhangNianDuFrm();

                    frm.ShowDialog();

                    defaultYearFilePath_ = GetYearFilePath(year);

                    if (defaultYearFilePath_ == null)
                    {
                        if (DialogResult.Yes == MessageBox.Show("记帐年度：" + year +
                            "未设置数据文件系统无法运行，要退出系统么?", "确认退出",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            return false;
                        }
                    }
                }
            }

            if (System.IO.File.Exists(defaultYearFilePath_))
            {
                try
                {
                    moneyNetDS_.ReadXml(defaultYearFilePath_);
                    moneyNetDS_.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取数据文件:" + defaultYearFilePath_ + "错误:" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return true;
        }

        public static decimal GetYearInitialValue(int year)
        {
            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName(year + "InitialAMount");

            if (row != null)
            {
                return decimal.Parse(row.Value);
            }
            else
            {
                return new decimal(0.0);
            }
        }

        public static void SetYearInitialValue(int year, decimal val)
        {
            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName(year + "InitialAMount");

            if (row != null)
            {
                row.BeginEdit();
                row.Value = val.ToString();
                row.EndEdit();
            }
            else
            {
                row = Program.ConfigDS.XiTong_PeiZhi.NewXiTong_PeiZhiRow();
                row.Name = year + "InitialAMount";
                row.Value = val.ToString();
                Program.ConfigDS.XiTong_PeiZhi.Rows.Add(row);
            }
        }

        public static int GetDefaultYear()
        {
            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName("DefaultYear");

            if (row != null)
            {
                return Int32.Parse(row.Value);
            }
            else
            {
                return DateTime.Now.Year;
            }
        }

        public static void SetDefaultYear(int year)
        {
            SaveData();

            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName("DefaultYear");

            if (row != null)
            {
                row.BeginEdit();
                row.Name = "DefaultYear";
                row.Value = year.ToString();
                row.EndEdit();
            }
            else
            {
                row =
                    Program.ConfigDS.XiTong_PeiZhi.NewXiTong_PeiZhiRow();

                row.Name = "DefaultYear";
                row.Value = year.ToString();

                Program.ConfigDS.XiTong_PeiZhi.Rows.Add(row);
            }

            LoadData(true);
        }

        public static decimal GetDefaultYearInitValue()
        {
            return GetYearInitialValue(GetDefaultYear());
        }

        public static void SetDefaultYearInitValue(decimal val)
        {
            SetYearInitialValue(GetDefaultYear(), val);
        }

        public static string GetYearFilePath(int year)
        {
            MoneyNetConfigDS.JiZhang_NianDuRow row =
                ConfigDS.JiZhang_NianDu.FindByYear(year);

            if (row == null)
                return null;

            return row.FilePath;
        }

        public static void SetYearFilePath(int year, string filepath)
        {
            MoneyNetConfigDS.JiZhang_NianDuRow row =
                ConfigDS.JiZhang_NianDu.FindByYear(year);

            if (row == null)
            {
                row = ConfigDS.JiZhang_NianDu.NewJiZhang_NianDuRow();
                row.FilePath = filepath;
                row.Year = year;
                ConfigDS.JiZhang_NianDu.Rows.Add(row);
            }
            else
            {
                row.BeginEdit();
                row.FilePath = filepath;
                row.EndEdit();
            }
        }

        public static void DeleteYear(int year)
        {
            MoneyNetConfigDS.JiZhang_NianDuRow row =
                ConfigDS.JiZhang_NianDu.FindByYear(year);

            if (row != null)
            {
                row.Delete();
            }

            ConfigDS.JiZhang_NianDu.AcceptChanges();
        }

        public static int GetMainFrmFenLei(int year)
        {
            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName(year + "MainFrmFenLei");

            if (row != null)
            {
                return Int32.Parse(row.Value);
            }
            else
            {
                return -1;
            }
        }

        public static void SetMainFrmFenLei(int year, int fenlei)
        {
            MoneyNetConfigDS.XiTong_PeiZhiRow row =
                Program.ConfigDS.XiTong_PeiZhi.FindByName(year + "MainFrmFenLei");

            if (row != null)
            {
                row.BeginEdit();
                row.Value = fenlei.ToString();
                row.EndEdit();
            }
            else
            {
                row = Program.ConfigDS.XiTong_PeiZhi.NewXiTong_PeiZhiRow();
                row.Name = year + "MainFrmFenLei";
                row.Value = fenlei.ToString();
                Program.ConfigDS.XiTong_PeiZhi.Rows.Add(row);
            }
        }

        public static void UpdateHistory(MoneyNetDS.RiChang_JiaoYiRow row, ChangeModeEnum mode)
        {
            MoneyNetDS.RiChang_JiaoYi_HistoryRow newRow =
                Program.MoneyNetDS.RiChang_JiaoYi_History.NewRiChang_JiaoYi_HistoryRow();

            newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
            newRow.JiaoYi_FenLei_Name = row.JiaoYi_FenLeiRow.Name;
            newRow.JiaoYi_FangShi_Name = row.JiaoYi_FangShiRow.Name;
            newRow.JiaoYi_FenLei_ID = row.JiaoYi_FenLeiRow.ID;
            newRow.JiaoYi_FangShi_ID = row.JiaoYi_FangShiRow.ID;
            newRow.JiaoYi_Time = row.JiaoYi_Time;
            newRow.Jin_E = row.Jin_E;
            newRow.MiaoShu = row.MiaoShu;
            newRow.MingCheng = row.MingCheng;
            newRow.Change_Mode = mode.ToString();
            newRow.Change_Time = DateTime.Now;
            newRow.RiChang_ID = row.ID;

            Program.MoneyNetDS.RiChang_JiaoYi_History.Rows.Add(newRow);
        }

        public static void UpdateHistory(MoneyNetDS.GuDing_JiaoYiRow row, ChangeModeEnum mode)
        {
            MoneyNetDS.GuDing_JiaoYi_HistoryRow newRow =
                Program.MoneyNetDS.GuDing_JiaoYi_History.NewGuDing_JiaoYi_HistoryRow();

            newRow.JiaoYi_FangXiang = row.JiaoYi_FangXiang;
            newRow.JiaoYi_FenLei_Name = row.JiaoYi_FenLeiRow.Name;
            newRow.JiaoYi_FangShi_Name = row.JiaoYi_FangShiRow.Name;
            newRow.JiaoYi_FenLei_ID = row.JiaoYi_FenLeiRow.ID;
            newRow.JiaoYi_FangShi_ID = row.JiaoYi_FangShiRow.ID;
            newRow.Last_Execute_Time = row.Last_Execute_Time;
            newRow.Stop_Time = row.Stop_Time;
            newRow.Start_Time = row.Start_Time;
            newRow.HasEndDate = row.HasEndDate;
            newRow.ZhouQi = row.ZhouQi;
            newRow.Jin_E = row.Jin_E;
            newRow.MiaoShu = row.MiaoShu;
            newRow.MingCheng = row.MingCheng;
            newRow.Change_Mode = mode.ToString();
            newRow.Change_Time = DateTime.Now;
            newRow.GuDing_ID = row.ID;

            Program.MoneyNetDS.GuDing_JiaoYi_History.Rows.Add(newRow);
        }
    }
}