namespace Money.Net.Controls
{
    partial class YearlyControl
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
            this.rdoEveryYear = new System.Windows.Forms.RadioButton();
            this.cboMonth1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.rdoYearWeek = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonth2 = new System.Windows.Forms.ComboBox();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.cboWeekDay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoEveryYear
            // 
            this.rdoEveryYear.AutoSize = true;
            this.rdoEveryYear.Location = new System.Drawing.Point(14, 18);
            this.rdoEveryYear.Name = "rdoEveryYear";
            this.rdoEveryYear.Size = new System.Drawing.Size(49, 17);
            this.rdoEveryYear.TabIndex = 0;
            this.rdoEveryYear.TabStop = true;
            this.rdoEveryYear.Text = "每年";
            this.rdoEveryYear.UseVisualStyleBackColor = true;
            // 
            // cboMonth1
            // 
            this.cboMonth1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth1.FormattingEnabled = true;
            this.cboMonth1.Location = new System.Drawing.Point(72, 16);
            this.cboMonth1.Name = "cboMonth1";
            this.cboMonth1.Size = new System.Drawing.Size(121, 21);
            this.cboMonth1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "月";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(230, 16);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 3;
            this.txtDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtDate_Validating);
            // 
            // rdoYearWeek
            // 
            this.rdoYearWeek.AutoSize = true;
            this.rdoYearWeek.Location = new System.Drawing.Point(14, 56);
            this.rdoYearWeek.Name = "rdoYearWeek";
            this.rdoYearWeek.Size = new System.Drawing.Size(49, 17);
            this.rdoYearWeek.TabIndex = 4;
            this.rdoYearWeek.TabStop = true;
            this.rdoYearWeek.Text = "每年";
            this.rdoYearWeek.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "月";
            // 
            // cboMonth2
            // 
            this.cboMonth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth2.FormattingEnabled = true;
            this.cboMonth2.Location = new System.Drawing.Point(72, 54);
            this.cboMonth2.Name = "cboMonth2";
            this.cboMonth2.Size = new System.Drawing.Size(121, 21);
            this.cboMonth2.TabIndex = 5;
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(230, 54);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(121, 21);
            this.cboWeek.TabIndex = 7;
            // 
            // cboWeekDay
            // 
            this.cboWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeekDay.FormattingEnabled = true;
            this.cboWeekDay.Location = new System.Drawing.Point(360, 54);
            this.cboWeekDay.Name = "cboWeekDay";
            this.cboWeekDay.Size = new System.Drawing.Size(121, 21);
            this.cboWeekDay.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "号";
            // 
            // YearlyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboWeekDay);
            this.Controls.Add(this.cboWeek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMonth2);
            this.Controls.Add(this.rdoYearWeek);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMonth1);
            this.Controls.Add(this.rdoEveryYear);
            this.Name = "YearlyControl";
            this.Size = new System.Drawing.Size(498, 178);
            this.Load += new System.EventHandler(this.YearlyControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoEveryYear;
        private System.Windows.Forms.ComboBox cboMonth1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.RadioButton rdoYearWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonth2;
        private System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.ComboBox cboWeekDay;
        private System.Windows.Forms.Label label3;
    }
}
