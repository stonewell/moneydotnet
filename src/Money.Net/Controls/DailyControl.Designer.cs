namespace Money.Net.Controls
{
    partial class DailyControl
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
            this.rdoEveryDay = new System.Windows.Forms.RadioButton();
            this.txtEveryDay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoWorkDay = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdoEveryDay
            // 
            this.rdoEveryDay.AutoSize = true;
            this.rdoEveryDay.Location = new System.Drawing.Point(14, 9);
            this.rdoEveryDay.Name = "rdoEveryDay";
            this.rdoEveryDay.Size = new System.Drawing.Size(37, 17);
            this.rdoEveryDay.TabIndex = 0;
            this.rdoEveryDay.TabStop = true;
            this.rdoEveryDay.Text = "每";
            this.rdoEveryDay.UseVisualStyleBackColor = true;
            // 
            // txtEveryDay
            // 
            this.txtEveryDay.Location = new System.Drawing.Point(49, 7);
            this.txtEveryDay.Name = "txtEveryDay";
            this.txtEveryDay.Size = new System.Drawing.Size(54, 20);
            this.txtEveryDay.TabIndex = 1;
            this.txtEveryDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtEveryDay_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "天";
            // 
            // rdoWorkDay
            // 
            this.rdoWorkDay.AutoSize = true;
            this.rdoWorkDay.Location = new System.Drawing.Point(14, 45);
            this.rdoWorkDay.Name = "rdoWorkDay";
            this.rdoWorkDay.Size = new System.Drawing.Size(73, 17);
            this.rdoWorkDay.TabIndex = 3;
            this.rdoWorkDay.TabStop = true;
            this.rdoWorkDay.Text = "每工作日";
            this.rdoWorkDay.UseVisualStyleBackColor = true;
            // 
            // DailyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoWorkDay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEveryDay);
            this.Controls.Add(this.rdoEveryDay);
            this.Name = "DailyControl";
            this.Size = new System.Drawing.Size(212, 150);
            this.Load += new System.EventHandler(this.DailyControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoEveryDay;
        private System.Windows.Forms.TextBox txtEveryDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoWorkDay;
    }
}
