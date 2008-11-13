namespace Money.Net
{
    partial class SysInitFrm
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
            this.lblJinE = new System.Windows.Forms.Label();
            this.txtJinE = new System.Windows.Forms.TextBox();
            this.cboYears = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 38);
            this.panel1.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(257, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblJinE
            // 
            this.lblJinE.AutoSize = true;
            this.lblJinE.Location = new System.Drawing.Point(13, 42);
            this.lblJinE.Name = "lblJinE";
            this.lblJinE.Size = new System.Drawing.Size(67, 13);
            this.lblJinE.TabIndex = 0;
            this.lblJinE.Text = "初始金额：";
            // 
            // txtJinE
            // 
            this.txtJinE.Location = new System.Drawing.Point(74, 38);
            this.txtJinE.Name = "txtJinE";
            this.txtJinE.Size = new System.Drawing.Size(258, 20);
            this.txtJinE.TabIndex = 1;
            this.txtJinE.Text = "0.0";
            this.txtJinE.Validating += new System.ComponentModel.CancelEventHandler(this.txtInitialJinE_Validating);
            // 
            // cboYears
            // 
            this.cboYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYears.FormattingEnabled = true;
            this.cboYears.Location = new System.Drawing.Point(75, 8);
            this.cboYears.Name = "cboYears";
            this.cboYears.Size = new System.Drawing.Size(160, 21);
            this.cboYears.TabIndex = 6;
            this.cboYears.SelectedIndexChanged += new System.EventHandler(this.cboYears_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "当前年度：";
            // 
            // SysInitFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 103);
            this.Controls.Add(this.cboYears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJinE);
            this.Controls.Add(this.lblJinE);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysInitFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统初始化";
            this.Load += new System.EventHandler(this.SysInitFrm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblJinE;
        private System.Windows.Forms.TextBox txtJinE;
        private System.Windows.Forms.ComboBox cboYears;
        private System.Windows.Forms.Label label1;
    }
}