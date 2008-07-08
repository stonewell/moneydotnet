namespace Money.Net.Controls
{
    partial class MonthlyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoEveryMonth = new System.Windows.Forms.RadioButton();
            this.txtMonth1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonth2 = new System.Windows.Forms.TextBox();
            this.rdoMonthWeek = new System.Windows.Forms.RadioButton();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.cboWeekDay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rdoEveryMonth
            // 
            this.rdoEveryMonth.AutoSize = true;
            this.rdoEveryMonth.Location = new System.Drawing.Point(14, 14);
            this.rdoEveryMonth.Name = "rdoEveryMonth";
            this.rdoEveryMonth.Size = new System.Drawing.Size(37, 17);
            this.rdoEveryMonth.TabIndex = 0;
            this.rdoEveryMonth.TabStop = true;
            this.rdoEveryMonth.Text = "每";
            this.rdoEveryMonth.UseVisualStyleBackColor = true;
            // 
            // txtMonth1
            // 
            this.txtMonth1.Location = new System.Drawing.Point(58, 12);
            this.txtMonth1.Name = "txtMonth1";
            this.txtMonth1.Size = new System.Drawing.Size(100, 20);
            this.txtMonth1.TabIndex = 1;
            this.txtMonth1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "个月的";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(215, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 3;
            this.txtDate.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "个月的";
            // 
            // txtMonth2
            // 
            this.txtMonth2.Location = new System.Drawing.Point(58, 48);
            this.txtMonth2.Name = "txtMonth2";
            this.txtMonth2.Size = new System.Drawing.Size(100, 20);
            this.txtMonth2.TabIndex = 6;
            this.txtMonth2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // rdoMonthWeek
            // 
            this.rdoMonthWeek.AutoSize = true;
            this.rdoMonthWeek.Location = new System.Drawing.Point(14, 50);
            this.rdoMonthWeek.Name = "rdoMonthWeek";
            this.rdoMonthWeek.Size = new System.Drawing.Size(37, 17);
            this.rdoMonthWeek.TabIndex = 5;
            this.rdoMonthWeek.TabStop = true;
            this.rdoMonthWeek.Text = "每";
            this.rdoMonthWeek.UseVisualStyleBackColor = true;
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(215, 48);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(121, 21);
            this.cboWeek.TabIndex = 8;
            // 
            // cboWeekDay
            // 
            this.cboWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeekDay.FormattingEnabled = true;
            this.cboWeekDay.Location = new System.Drawing.Point(343, 48);
            this.cboWeekDay.Name = "cboWeekDay";
            this.cboWeekDay.Size = new System.Drawing.Size(121, 21);
            this.cboWeekDay.TabIndex = 9;
            // 
            // MonthlyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboWeekDay);
            this.Controls.Add(this.cboWeek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMonth2);
            this.Controls.Add(this.rdoMonthWeek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonth1);
            this.Controls.Add(this.rdoEveryMonth);
            this.Name = "MonthlyControl";
            this.Size = new System.Drawing.Size(470, 163);
            this.Load += new System.EventHandler(this.MonthlyControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoEveryMonth;
        private System.Windows.Forms.TextBox txtMonth1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonth2;
        private System.Windows.Forms.RadioButton rdoMonthWeek;
        private System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.ComboBox cboWeekDay;
    }
}
