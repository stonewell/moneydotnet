using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Money.Net
{
    public partial class JiaoYiZhouQiFrm : Form
    {
        private ZhouQi zhouqi_ = null;

        public JiaoYiZhouQiFrm(ZhouQi zhouqi)
        {
            zhouqi_ = zhouqi;

            InitializeComponent();
        }

        public ZhouQi ZhouQi
        {
            get
            {
                if (rdoWeek.Checked)
                {
                    zhouqi_ = weeklyControl1.ZhouQi;
                }
                else if (rdoDay.Checked)
                {
                    zhouqi_ = dailyControl1.ZhouQi;
                }
                else if (rdoMonth.Checked)
                {
                    zhouqi_ = monthlyControl1.ZhouQi;
                }
                else if (rdoYear.Checked)
                {
                    zhouqi_ = yearlyControl1.ZhouQi;
                }

                return zhouqi_;
            }

            set
            {
                zhouqi_ = value;

                dailyControl1.ZhouQi = value;
                monthlyControl1.ZhouQi = value;
                weeklyControl1.ZhouQi = value;
                yearlyControl1.ZhouQi = value;
            }
        }

        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            dailyControl1.Visible = false;
            monthlyControl1.Visible = false;
            weeklyControl1.Visible = false;
            yearlyControl1.Visible = false;
        }

        private void rdoDay_CheckedChanged(object sender, EventArgs e)
        {
            dailyControl1.Visible = true;
            monthlyControl1.Visible = false;
            weeklyControl1.Visible = false;
            yearlyControl1.Visible = false;

            dailyControl1.ZhouQi = zhouqi_;
        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
            dailyControl1.Visible = false;
            monthlyControl1.Visible = false;
            weeklyControl1.Visible = true;
            yearlyControl1.Visible = false;

            weeklyControl1.ZhouQi = zhouqi_;
        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            dailyControl1.Visible = false;
            monthlyControl1.Visible = true;
            weeklyControl1.Visible = false;
            yearlyControl1.Visible = false;

            monthlyControl1.ZhouQi = zhouqi_;
        }

        private void rdoYear_CheckedChanged(object sender, EventArgs e)
        {
            dailyControl1.Visible = false;
            monthlyControl1.Visible = false;
            weeklyControl1.Visible = false;
            yearlyControl1.Visible = true;

            yearlyControl1.ZhouQi = zhouqi_;
        }

        private void JiaoYiZhouQiFrm_Load(object sender, EventArgs e)
        {
            switch (zhouqi_.Type)
            {
                case ZhouQiTypeEnum.Monthly:
                    rdoMonth.Checked = true;
                    break;
                case ZhouQiTypeEnum.Daily:
                    rdoDay.Checked = true;
                    break;
                case ZhouQiTypeEnum.None:
                    rdoNone.Checked = true;
                    break;
                case ZhouQiTypeEnum.Weekly:
                    rdoWeek.Checked = true;
                    break;
                case ZhouQiTypeEnum.Yearly:
                    rdoYear.Checked = true;
                    break;
                default:
                    rdoWeek.Checked = true;
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}