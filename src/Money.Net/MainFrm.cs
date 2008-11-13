using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Money.Net.DB;
using System.Collections;

namespace Money.Net
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void 交易分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenLeiFrm form = new FenLeiFrm();

            form.ShowDialog(this);
        }

        private void 交易方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FangShiFrm form = new FangShiFrm();

            form.ShowDialog(this);
        }

        private void 当日交易ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodayFrm form = new TodayFrm();

            form.ShowDialog(this);

            RefreshData();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysInitFrm frm = new SysInitFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 每日合计_Click(object sender, EventArgs e)
        {
            DaySummaryFrm frm = new DaySummaryFrm();

            DateTime time = 
                new DateTime(Program.GetDefaultYear(), DateTime.Now.Month, DateTime.Now.Day);

            frm.SelectedDate = time;

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 每日明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayDetailFrm frm = new DayDetailFrm();
            DateTime time =
                new DateTime(Program.GetDefaultYear(), DateTime.Now.Month, DateTime.Now.Day);

            frm.SelectedDate = time;

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 月度合计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthSummaryFrm frm = new MonthSummaryFrm();
            frm.SelectedMonth = DateTime.Now.Month;

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 月度明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthDetailFrm frm = new MonthDetailFrm();
            frm.SelectedMonth = DateTime.Now.Month;

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 年度合计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YearSummaryFrm frm = new YearSummaryFrm();

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 年度明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YearDetailFrm frm = new YearDetailFrm();

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 记帐年度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JiZhangNianDuFrm frm = new JiZhangNianDuFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMoneyNet frm = new AboutMoneyNet();

            frm.ShowDialog(this);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void InitYearSummary()
        {
            groupBox1.Text = Program.GetDefaultYear() + "年";
            lblYearInit.Text = Program.GetDefaultYearInitValue().ToString();

            decimal yearInit = decimal.Parse(lblYearInit.Text);
            decimal xiaofei = new decimal(0.0);
            decimal shouru = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (row.JiaoYi_Time.Year == Program.GetDefaultYear())
                {
                    if (row.JiaoYi_FangXiang)
                    {
                        xiaofei += row.Jin_E;
                    }
                    else
                    {
                        shouru += row.Jin_E;
                    }
                }
            }

            decimal yearEnd = yearInit + shouru - xiaofei;

            lblYearShouRu.Text = shouru.ToString();
            lblYearXiaoFei.Text = xiaofei.ToString();
            lblYearYuE.Text = yearEnd.ToString();
        }

        private void InitMonthSummary()
        {
            groupBox2.Text = DateTime.Now.Month + "月";

            lblMonthInit.Text = Program.GetDefaultYearInitValue().ToString();

            decimal monthInit = decimal.Parse(lblMonthInit.Text);
            decimal xiaofei = new decimal(0.0);
            decimal shouru = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (row.JiaoYi_Time.Year == Program.GetDefaultYear())
                {
                    if (row.JiaoYi_Time.Month == DateTime.Now.Month)
                    {
                        if (row.JiaoYi_FangXiang)
                        {
                            xiaofei += row.Jin_E;
                        }
                        else
                        {
                            shouru += row.Jin_E;
                        }
                    }
                    else if (row.JiaoYi_Time.Month < DateTime.Now.Month)
                    {
                        if (row.JiaoYi_FangXiang)
                        {
                            monthInit -= row.Jin_E;
                        }
                        else
                        {
                            monthInit += row.Jin_E;
                        }
                    }
                }
            }

            decimal monthEnd = monthInit + shouru - xiaofei;

            lblMonthInit.Text = monthInit.ToString();
            lblMonthShouRu.Text = shouru.ToString();
            lblMonthXiaoFei.Text = xiaofei.ToString();
            lblMonthYuE.Text = monthEnd.ToString();
        }

        public void RefreshData()
        {
            InitMonthSummary();
            InitYearSummary();

            InitMainFrmFenLeiYear();
            InitMainFrmFenLeiMonth();
        }

        private void InitMainFrmFenLeiMonth()
        {
            dgvFenLeiMonth.Rows.Clear();

            int fenlei = Program.GetMainFrmFenLei(Program.GetDefaultYear());

            if (fenlei < 0)
            {
                groupBox4.Text = "";

                return;
            }

            MoneyNetDS.JiaoYi_FenLeiRow row =
                Program.MoneyNetDS.JiaoYi_FenLei.FindByID(fenlei);

            string fenleiname = fenlei.ToString();

            if (row == null)
            {
                fenleiname = fenlei + "类";
            }
            else
            {
                fenleiname = row.Name;
            }

            Hashtable values = new Hashtable();

            decimal total = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow jy_row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (jy_row.JiaoYi_Time.Year == Program.GetDefaultYear() &&
                    jy_row.JiaoYi_Time.Month == DateTime.Now.Month &&
                    jy_row.JiaoYi_FenLei_ID == fenlei)
                {
                    decimal value = new decimal(0.0);

                    if (values.ContainsKey(jy_row.MingCheng))
                    {
                        value = (decimal)values[jy_row.MingCheng];
                    }

                    if (jy_row.JiaoYi_FangXiang)
                    {
                        total -= jy_row.Jin_E;
                        value -= jy_row.Jin_E;
                    }
                    else
                    {
                        total += jy_row.Jin_E;
                        value += jy_row.Jin_E;
                    }

                    values[jy_row.MingCheng] = value;
                }
            }

            if (total < 0)
            {
                groupBox4.ForeColor = Color.Red;
                groupBox4.Text = fenleiname + "当月消费:" + (total * -1).ToString();
            }
            else
            {
                groupBox4.ForeColor = Color.Blue;
                groupBox4.Text = fenleiname + "当月收入:" + total.ToString();
            }

            foreach (string key in values.Keys)
            {
                decimal value = (decimal)values[key];

                if (value < 0)
                {
                    int rowIndex = dgvFenLeiMonth.Rows.Add(key, value * -1);
                    dgvFenLeiMonth[0, rowIndex].Style.ForeColor = Color.Red;
                    dgvFenLeiMonth[1, rowIndex].Style.ForeColor = Color.Red;
                }
                else
                {
                    int rowIndex = dgvFenLeiMonth.Rows.Add(key, value);
                    dgvFenLeiMonth[0, rowIndex].Style.ForeColor = Color.Blue;
                    dgvFenLeiMonth[1, rowIndex].Style.ForeColor = Color.Blue;
                }
            }

            dgvFenLeiMonth.ClearSelection();
        }

        private void InitMainFrmFenLeiYear()
        {
            dgvFenLeiYear.Rows.Clear();

            int fenlei = Program.GetMainFrmFenLei(Program.GetDefaultYear());

            if (fenlei < 0)
            {
                groupBox3.Text = "";

                return;
            }

            MoneyNetDS.JiaoYi_FenLeiRow row =
                Program.MoneyNetDS.JiaoYi_FenLei.FindByID(fenlei);

            string fenleiname = fenlei.ToString();

            if (row == null)
            {
                fenleiname = fenlei + "类";
            }
            else
            {
                fenleiname = row.Name;
            }

            Hashtable values = new Hashtable();

            decimal total = new decimal(0.0);

            foreach (MoneyNetDS.RiChang_JiaoYiRow jy_row in
                Program.MoneyNetDS.RiChang_JiaoYi.Rows)
            {
                if (jy_row.JiaoYi_Time.Year == Program.GetDefaultYear() &&
                    jy_row.JiaoYi_FenLei_ID == fenlei)
                {
                    decimal value = new decimal(0.0);

                    if (values.ContainsKey(jy_row.MingCheng))
                    {
                        value = (decimal)values[jy_row.MingCheng];
                    }

                    if (jy_row.JiaoYi_FangXiang)
                    {
                        total -= jy_row.Jin_E;
                        value -= jy_row.Jin_E;
                    }
                    else
                    {
                        total += jy_row.Jin_E;
                        value += jy_row.Jin_E;
                    }

                    values[jy_row.MingCheng] = value;
                }
            }

            if (total < 0)
            {
                groupBox3.ForeColor = Color.Red;
                groupBox3.Text = fenleiname + "当年消费:" + (total * -1).ToString();
            }
            else
            {
                groupBox3.ForeColor = Color.Blue;
                groupBox3.Text = fenleiname + "当年收入:" + total.ToString();
            }

            foreach (string key in values.Keys)
            {
                decimal value = (decimal)values[key];

                if (value < 0)
                {
                    int rowIndex = dgvFenLeiYear.Rows.Add(key, value * -1);
                    dgvFenLeiYear[0, rowIndex].Style.ForeColor = Color.Red;
                    dgvFenLeiYear[1, rowIndex].Style.ForeColor = Color.Red;
                }
                else
                {
                    int rowIndex = dgvFenLeiYear.Rows.Add(key, value);
                    dgvFenLeiYear[0, rowIndex].Style.ForeColor = Color.Blue;
                    dgvFenLeiYear[1, rowIndex].Style.ForeColor = Color.Blue;
                }
            }

            dgvFenLeiYear.ClearSelection();
        }

        private void 主界面配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainFrmSettings frm = new MainFrmSettings();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 固定交易ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuDingJiaoYisFrm frm = new GuDingJiaoYisFrm();

            frm.ShowDialog(this);
        }

        private void 合并记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string f = openFileDialog1.FileName;

                Program.MoneyNetDS.AcceptChanges();

                try
                {
                    MoneyNetDS ds = new MoneyNetDS();
                    ds.ReadXml(f);

                    ImportDataFrm frm = new ImportDataFrm();
                    frm.ImportingDataSet = ds;

                    if (DialogResult.Cancel == frm.ShowDialog(this))
                    {
                        Program.MoneyNetDS.RejectChanges();
                        RefreshData();
                        return;
                    }

                    RefreshData();

                    Program.MoneyNetDS.AcceptChanges();
                }
                catch (Exception ex)
                {
                    Program.MoneyNetDS.RejectChanges();

                    MessageBox.Show("读取数据文件:" + f + "错误:" + ex.Message, 
                        "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 自定义合计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomizedDurationSummaryFrm frm = new CustomizedDurationSummaryFrm();

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 自定义明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomizedDurationDetailFrm frm = new CustomizedDurationDetailFrm();

            frm.ShowDialog(this);
            RefreshData();
        }

        private void 区间分类明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenLeiDurationDetailFrm frm = new FenLeiDurationDetailFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 区间交易方式明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FangShiDurationDetailFrm frm = new FangShiDurationDetailFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 区间分类合计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenLeiDurationSummaryFrm frm = new FenLeiDurationSummaryFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 区间交易方式合计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FangShiDurationSummaryFrm frm = new FangShiDurationSummaryFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 恢复日常交易记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreRiChangFrm frm = new RestoreRiChangFrm();

            frm.ShowDialog(this);

            RefreshData();
        }

        private void 恢复固定交易记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreGuDingFrm frm = new RestoreGuDingFrm();

            frm.ShowDialog(this);

            RefreshData();
        }
    }
}