using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Money.Net.DB;

namespace Money.Net
{
    public partial class JiZhangNianDuFrm : Form
    {
        private class NianDuItem
        {
            public MoneyNetConfigDS.JiZhang_NianDuRow row_ = null;

            public NianDuItem(MoneyNetConfigDS.JiZhang_NianDuRow row)
            {
                row_ = row;
            }

            public override string ToString()
            {
                return row_.Year.ToString();
            }

            public override bool Equals(object obj)
            {
                if (obj is NianDuItem)
                {
                    NianDuItem tmp = obj as NianDuItem;

                    return tmp.row_.Year.Equals(row_.Year);
                }

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return row_.Year.GetHashCode();
            }
        }

        public JiZhangNianDuFrm()
        {
            InitializeComponent();
        }

        private void JiZhangNianDuFrm_Load(object sender, EventArgs e)
        {
            nudYear.Value = DateTime.Now.Year;

            LoadData();
        }

        private void LoadData()
        {
            foreach (MoneyNetConfigDS.JiZhang_NianDuRow row in
                Program.ConfigDS.JiZhang_NianDu.Rows)
            {
                lstYears.Items.Add(new NianDuItem(row));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string filename = txtPath.Text.Trim();

            if (filename.Length == 0)
                return;

            bool newfile = false;

            if (!System.IO.File.Exists(filename))
            {
                try
                {
                    MoneyNetConfigDS ds = new MoneyNetConfigDS();

                    ds.WriteXml(filename);
                    newfile = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MoneyNetConfigDS.JiZhang_NianDuRow row =
                Program.ConfigDS.JiZhang_NianDu.NewJiZhang_NianDuRow();

            row.Year = Decimal.ToInt32(nudYear.Value);
            row.FilePath = txtPath.Text;

            NianDuItem item = new NianDuItem(row);

            if (lstYears.Items.Contains(item))
            {
                if (newfile)
                {
                    try
                    {
                        System.IO.File.Delete(filename);
                    }
                    catch
                    {
                    }
                }
                return;
            }

            Program.ConfigDS.JiZhang_NianDu.Rows.Add(row);

            lstYears.Items.Add(item);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstYears.SelectedIndex < 0)
                return;

            string filename = txtPath.Text.Trim();

            if (filename.Length == 0)
                return;

            bool newfile = false;
            if (!System.IO.File.Exists(filename))
            {
                try
                {
                    MoneyNetConfigDS ds = new MoneyNetConfigDS();

                    ds.WriteXml(filename);
                    newfile = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MoneyNetConfigDS.JiZhang_NianDuRow row =
                Program.ConfigDS.JiZhang_NianDu.NewJiZhang_NianDuRow();

            row.Year = Decimal.ToInt32(nudYear.Value);
            row.FilePath = txtPath.Text;

            NianDuItem item = new NianDuItem(row);

            if (lstYears.Items.IndexOf(item) != lstYears.SelectedIndex)
            {
                if (newfile)
                {
                    try
                    {
                        System.IO.File.Delete(filename);
                    }
                    catch
                    {
                    }
                }
                return;
            }

            item = lstYears.Items[lstYears.SelectedIndex] as NianDuItem;

            item.row_.BeginEdit();
            item.row_.FilePath = txtPath.Text;
            item.row_.EndEdit();

            lstYears.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstYears.SelectedIndex < 0)
            {
                return;
            }

            NianDuItem item =
                lstYears.Items[lstYears.SelectedIndex] as NianDuItem;

            if (item.row_.Year == Program.GetDefaultYear())
            {
                MessageBox.Show("不能删除当前记账年度:" + item.row_.Year,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确定删除记帐年度:" + item.row_.Year + "么?",
                "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            if (System.IO.File.Exists(item.row_.FilePath))
            {
                if (DialogResult.Yes == MessageBox.Show("同时删除记帐年度文件:" + item.row_.FilePath + "么?",
                "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    System.IO.File.Delete(item.row_.FilePath);
                }
            }

            lstYears.Items.Remove(item);
            item.row_.Delete();

            Program.ConfigDS.JiZhang_NianDu.AcceptChanges();
        }

        private void lstYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstYears.SelectedIndex < 0)
            {
                return;
            }

            NianDuItem item =
                lstYears.Items[lstYears.SelectedIndex] as NianDuItem;

            nudYear.Value = item.row_.Year;
            txtPath.Text = item.row_.FilePath;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog(this))
            {
                txtPath.Text = saveFileDialog1.FileName;
            }
        }
    }
}