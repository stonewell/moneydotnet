namespace Money.Net
{
    partial class NewGuDingJiaoYiFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGuDingJiaoYiFrm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtJinE = new System.Windows.Forms.MaskedTextBox();
            this.lblJinE = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMingCheng = new System.Windows.Forms.Label();
            this.rdoShouRu = new System.Windows.Forms.RadioButton();
            this.rdoXiaoFei = new System.Windows.Forms.RadioButton();
            this.lblFangShi = new System.Windows.Forms.Label();
            this.lblFenLei = new System.Windows.Forms.Label();
            this.txtMiaoShu = new System.Windows.Forms.TextBox();
            this.lvwFangShi = new System.Windows.Forms.ListView();
            this.lvwFenLei = new System.Windows.Forms.ListView();
            this.lblZhouQi = new System.Windows.Forms.Label();
            this.btnZhouQi = new System.Windows.Forms.Button();
            this.txtZhouQi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.chkEndTime = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(333, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtJinE
            // 
            this.txtJinE.Location = new System.Drawing.Point(212, 372);
            this.txtJinE.Name = "txtJinE";
            this.txtJinE.Size = new System.Drawing.Size(194, 20);
            this.txtJinE.TabIndex = 17;
            this.txtJinE.Validating += new System.ComponentModel.CancelEventHandler(this.txtJinE_Validating);
            // 
            // lblJinE
            // 
            this.lblJinE.AutoSize = true;
            this.lblJinE.Location = new System.Drawing.Point(209, 353);
            this.lblJinE.Name = "lblJinE";
            this.lblJinE.Size = new System.Drawing.Size(43, 13);
            this.lblJinE.TabIndex = 16;
            this.lblJinE.Text = "金额：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "描述：";
            // 
            // lblMingCheng
            // 
            this.lblMingCheng.AutoSize = true;
            this.lblMingCheng.Location = new System.Drawing.Point(5, 4);
            this.lblMingCheng.Name = "lblMingCheng";
            this.lblMingCheng.Size = new System.Drawing.Size(43, 13);
            this.lblMingCheng.TabIndex = 0;
            this.lblMingCheng.Text = "名称：";
            // 
            // rdoShouRu
            // 
            this.rdoShouRu.AutoSize = true;
            this.rdoShouRu.Location = new System.Drawing.Point(82, 373);
            this.rdoShouRu.Name = "rdoShouRu";
            this.rdoShouRu.Size = new System.Drawing.Size(49, 17);
            this.rdoShouRu.TabIndex = 15;
            this.rdoShouRu.Text = "收入";
            this.rdoShouRu.UseVisualStyleBackColor = true;
            // 
            // rdoXiaoFei
            // 
            this.rdoXiaoFei.AutoSize = true;
            this.rdoXiaoFei.Checked = true;
            this.rdoXiaoFei.Location = new System.Drawing.Point(9, 372);
            this.rdoXiaoFei.Name = "rdoXiaoFei";
            this.rdoXiaoFei.Size = new System.Drawing.Size(49, 17);
            this.rdoXiaoFei.TabIndex = 14;
            this.rdoXiaoFei.TabStop = true;
            this.rdoXiaoFei.Text = "消费";
            this.rdoXiaoFei.UseVisualStyleBackColor = true;
            // 
            // lblFangShi
            // 
            this.lblFangShi.AutoSize = true;
            this.lblFangShi.Location = new System.Drawing.Point(8, 227);
            this.lblFangShi.Name = "lblFangShi";
            this.lblFangShi.Size = new System.Drawing.Size(67, 13);
            this.lblFangShi.TabIndex = 11;
            this.lblFangShi.Text = "交易方式：";
            // 
            // lblFenLei
            // 
            this.lblFenLei.AutoSize = true;
            this.lblFenLei.Location = new System.Drawing.Point(8, 101);
            this.lblFenLei.Name = "lblFenLei";
            this.lblFenLei.Size = new System.Drawing.Size(43, 13);
            this.lblFenLei.TabIndex = 9;
            this.lblFenLei.Text = "分类：";
            // 
            // txtMiaoShu
            // 
            this.txtMiaoShu.Location = new System.Drawing.Point(8, 417);
            this.txtMiaoShu.MaxLength = 255;
            this.txtMiaoShu.Multiline = true;
            this.txtMiaoShu.Name = "txtMiaoShu";
            this.txtMiaoShu.Size = new System.Drawing.Size(398, 101);
            this.txtMiaoShu.TabIndex = 19;
            // 
            // lvwFangShi
            // 
            this.lvwFangShi.FullRowSelect = true;
            this.lvwFangShi.HideSelection = false;
            this.lvwFangShi.Location = new System.Drawing.Point(8, 246);
            this.lvwFangShi.MultiSelect = false;
            this.lvwFangShi.Name = "lvwFangShi";
            this.lvwFangShi.Size = new System.Drawing.Size(398, 101);
            this.lvwFangShi.TabIndex = 12;
            this.lvwFangShi.UseCompatibleStateImageBehavior = false;
            this.lvwFangShi.View = System.Windows.Forms.View.List;
            this.lvwFangShi.Validating += new System.ComponentModel.CancelEventHandler(this.lvwFangShi_Validating);
            // 
            // lvwFenLei
            // 
            this.lvwFenLei.FullRowSelect = true;
            this.lvwFenLei.HideSelection = false;
            this.lvwFenLei.Location = new System.Drawing.Point(8, 120);
            this.lvwFenLei.MultiSelect = false;
            this.lvwFenLei.Name = "lvwFenLei";
            this.lvwFenLei.Size = new System.Drawing.Size(398, 101);
            this.lvwFenLei.TabIndex = 10;
            this.lvwFenLei.UseCompatibleStateImageBehavior = false;
            this.lvwFenLei.View = System.Windows.Forms.View.List;
            this.lvwFenLei.Validating += new System.ComponentModel.CancelEventHandler(this.lvwFenLei_Validating);
            // 
            // lblZhouQi
            // 
            this.lblZhouQi.AutoSize = true;
            this.lblZhouQi.Location = new System.Drawing.Point(212, 4);
            this.lblZhouQi.Name = "lblZhouQi";
            this.lblZhouQi.Size = new System.Drawing.Size(43, 13);
            this.lblZhouQi.TabIndex = 2;
            this.lblZhouQi.Text = "周期：";
            // 
            // btnZhouQi
            // 
            this.btnZhouQi.Location = new System.Drawing.Point(333, 20);
            this.btnZhouQi.Name = "btnZhouQi";
            this.btnZhouQi.Size = new System.Drawing.Size(75, 23);
            this.btnZhouQi.TabIndex = 4;
            this.btnZhouQi.Text = "周期...";
            this.btnZhouQi.UseVisualStyleBackColor = true;
            this.btnZhouQi.Click += new System.EventHandler(this.btnZhouQi_Click);
            // 
            // txtZhouQi
            // 
            this.txtZhouQi.BackColor = System.Drawing.SystemColors.Window;
            this.txtZhouQi.Location = new System.Drawing.Point(212, 21);
            this.txtZhouQi.Name = "txtZhouQi";
            this.txtZhouQi.ReadOnly = true;
            this.txtZhouQi.Size = new System.Drawing.Size(115, 20);
            this.txtZhouQi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "交易方向：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(10, 70);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(177, 20);
            this.dtpStartTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(211, 70);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(177, 20);
            this.dtpEndTime.TabIndex = 8;
            // 
            // chkEndTime
            // 
            this.chkEndTime.AutoSize = true;
            this.chkEndTime.Location = new System.Drawing.Point(211, 48);
            this.chkEndTime.Name = "chkEndTime";
            this.chkEndTime.Size = new System.Drawing.Size(86, 17);
            this.chkEndTime.TabIndex = 7;
            this.chkEndTime.Text = "终止时间：";
            this.chkEndTime.UseVisualStyleBackColor = true;
            this.chkEndTime.CheckedChanged += new System.EventHandler(this.chkEndTime_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(10, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(246, 528);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // NewGuDingJiaoYiFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(415, 559);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkEndTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZhouQi);
            this.Controls.Add(this.btnZhouQi);
            this.Controls.Add(this.lblZhouQi);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtJinE);
            this.Controls.Add(this.lblJinE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMingCheng);
            this.Controls.Add(this.rdoShouRu);
            this.Controls.Add(this.rdoXiaoFei);
            this.Controls.Add(this.lblFangShi);
            this.Controls.Add(this.lblFenLei);
            this.Controls.Add(this.txtMiaoShu);
            this.Controls.Add(this.lvwFangShi);
            this.Controls.Add(this.lvwFenLei);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGuDingJiaoYiFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "固定周期交易";
            this.Load += new System.EventHandler(this.GuDingJiaoYiFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox txtJinE;
        private System.Windows.Forms.Label lblJinE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMingCheng;
        private System.Windows.Forms.RadioButton rdoShouRu;
        private System.Windows.Forms.RadioButton rdoXiaoFei;
        private System.Windows.Forms.Label lblFangShi;
        private System.Windows.Forms.Label lblFenLei;
        private System.Windows.Forms.TextBox txtMiaoShu;
        private System.Windows.Forms.ListView lvwFangShi;
        private System.Windows.Forms.ListView lvwFenLei;
        private System.Windows.Forms.Label lblZhouQi;
        private System.Windows.Forms.Button btnZhouQi;
        private System.Windows.Forms.TextBox txtZhouQi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.CheckBox chkEndTime;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOK;
    }
}