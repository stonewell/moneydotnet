namespace Money.Net
{
    partial class JiaoYiZhouQiFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.rdoYear = new System.Windows.Forms.RadioButton();
            this.rdoMonth = new System.Windows.Forms.RadioButton();
            this.rdoWeek = new System.Windows.Forms.RadioButton();
            this.rdoDay = new System.Windows.Forms.RadioButton();
            this.yearlyControl1 = new Money.Net.Controls.YearlyControl();
            this.monthlyControl1 = new Money.Net.Controls.MonthlyControl();
            this.weeklyControl1 = new Money.Net.Controls.WeeklyControl();
            this.dailyControl1 = new Money.Net.Controls.DailyControl();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 38);
            this.panel1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(437, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(518, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdoNone);
            this.splitContainer1.Panel1.Controls.Add(this.rdoYear);
            this.splitContainer1.Panel1.Controls.Add(this.rdoMonth);
            this.splitContainer1.Panel1.Controls.Add(this.rdoWeek);
            this.splitContainer1.Panel1.Controls.Add(this.rdoDay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.yearlyControl1);
            this.splitContainer1.Panel2.Controls.Add(this.monthlyControl1);
            this.splitContainer1.Panel2.Controls.Add(this.weeklyControl1);
            this.splitContainer1.Panel2.Controls.Add(this.dailyControl1);
            this.splitContainer1.Size = new System.Drawing.Size(604, 185);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 6;
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Location = new System.Drawing.Point(5, 10);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(61, 17);
            this.rdoNone.TabIndex = 9;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "无周期";
            this.rdoNone.UseVisualStyleBackColor = true;
            this.rdoNone.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // rdoYear
            // 
            this.rdoYear.AutoSize = true;
            this.rdoYear.Location = new System.Drawing.Point(5, 148);
            this.rdoYear.Name = "rdoYear";
            this.rdoYear.Size = new System.Drawing.Size(37, 17);
            this.rdoYear.TabIndex = 8;
            this.rdoYear.TabStop = true;
            this.rdoYear.Text = "年";
            this.rdoYear.UseVisualStyleBackColor = true;
            this.rdoYear.CheckedChanged += new System.EventHandler(this.rdoYear_CheckedChanged);
            // 
            // rdoMonth
            // 
            this.rdoMonth.AutoSize = true;
            this.rdoMonth.Location = new System.Drawing.Point(5, 113);
            this.rdoMonth.Name = "rdoMonth";
            this.rdoMonth.Size = new System.Drawing.Size(37, 17);
            this.rdoMonth.TabIndex = 7;
            this.rdoMonth.TabStop = true;
            this.rdoMonth.Text = "月";
            this.rdoMonth.UseVisualStyleBackColor = true;
            this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
            // 
            // rdoWeek
            // 
            this.rdoWeek.AutoSize = true;
            this.rdoWeek.Location = new System.Drawing.Point(5, 78);
            this.rdoWeek.Name = "rdoWeek";
            this.rdoWeek.Size = new System.Drawing.Size(37, 17);
            this.rdoWeek.TabIndex = 6;
            this.rdoWeek.TabStop = true;
            this.rdoWeek.Text = "周";
            this.rdoWeek.UseVisualStyleBackColor = true;
            this.rdoWeek.CheckedChanged += new System.EventHandler(this.rdoWeek_CheckedChanged);
            // 
            // rdoDay
            // 
            this.rdoDay.AutoSize = true;
            this.rdoDay.Location = new System.Drawing.Point(5, 43);
            this.rdoDay.Name = "rdoDay";
            this.rdoDay.Size = new System.Drawing.Size(37, 17);
            this.rdoDay.TabIndex = 5;
            this.rdoDay.TabStop = true;
            this.rdoDay.Text = "日";
            this.rdoDay.UseVisualStyleBackColor = true;
            this.rdoDay.CheckedChanged += new System.EventHandler(this.rdoDay_CheckedChanged);
            // 
            // yearlyControl1
            // 
            this.yearlyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearlyControl1.Location = new System.Drawing.Point(0, 0);
            this.yearlyControl1.Name = "yearlyControl1";
            this.yearlyControl1.Size = new System.Drawing.Size(489, 181);
            this.yearlyControl1.TabIndex = 3;
            this.yearlyControl1.ZhouQi = null;
            // 
            // monthlyControl1
            // 
            this.monthlyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthlyControl1.Location = new System.Drawing.Point(0, 0);
            this.monthlyControl1.Name = "monthlyControl1";
            this.monthlyControl1.Size = new System.Drawing.Size(489, 181);
            this.monthlyControl1.TabIndex = 2;
            this.monthlyControl1.ZhouQi = null;
            // 
            // weeklyControl1
            // 
            this.weeklyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklyControl1.Location = new System.Drawing.Point(0, 0);
            this.weeklyControl1.Name = "weeklyControl1";
            this.weeklyControl1.Size = new System.Drawing.Size(489, 181);
            this.weeklyControl1.TabIndex = 1;
            this.weeklyControl1.ZhouQi = null;
            // 
            // dailyControl1
            // 
            this.dailyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyControl1.Location = new System.Drawing.Point(0, 0);
            this.dailyControl1.Name = "dailyControl1";
            this.dailyControl1.Size = new System.Drawing.Size(489, 181);
            this.dailyControl1.TabIndex = 0;
            this.dailyControl1.ZhouQi = null;
            // 
            // JiaoYiZhouQiFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(604, 223);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JiaoYiZhouQiFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "交易周期";
            this.Load += new System.EventHandler(this.JiaoYiZhouQiFrm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdoYear;
        private System.Windows.Forms.RadioButton rdoMonth;
        private System.Windows.Forms.RadioButton rdoWeek;
        private System.Windows.Forms.RadioButton rdoDay;
        private System.Windows.Forms.RadioButton rdoNone;
        private Money.Net.Controls.YearlyControl yearlyControl1;
        private Money.Net.Controls.MonthlyControl monthlyControl1;
        private Money.Net.Controls.WeeklyControl weeklyControl1;
        private Money.Net.Controls.DailyControl dailyControl1;
    }
}