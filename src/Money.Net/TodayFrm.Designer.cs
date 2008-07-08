namespace Money.Net
{
    partial class TodayFrm
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lvwFenLei = new System.Windows.Forms.ListView();
            this.lvwFangShi = new System.Windows.Forms.ListView();
            this.txtMiaoShu = new System.Windows.Forms.TextBox();
            this.lblFenLei = new System.Windows.Forms.Label();
            this.lblFangShi = new System.Windows.Forms.Label();
            this.rdoXiaoFei = new System.Windows.Forms.RadioButton();
            this.rdoShouRu = new System.Windows.Forms.RadioButton();
            this.lblMingCheng = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJinE = new System.Windows.Forms.MaskedTextBox();
            this.lblJinE = new System.Windows.Forms.Label();
            this.txtTodayXiaoFei = new System.Windows.Forms.TextBox();
            this.txtTodayShouRu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboMingCheng = new System.Windows.Forms.ComboBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(12, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(182, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.Value = new System.DateTime(2008, 2, 22, 0, 0, 0, 0);
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lvwFenLei
            // 
            this.lvwFenLei.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFenLei.FullRowSelect = true;
            this.lvwFenLei.HideSelection = false;
            this.lvwFenLei.Location = new System.Drawing.Point(12, 80);
            this.lvwFenLei.MultiSelect = false;
            this.lvwFenLei.Name = "lvwFenLei";
            this.lvwFenLei.Size = new System.Drawing.Size(400, 101);
            this.lvwFenLei.TabIndex = 4;
            this.lvwFenLei.UseCompatibleStateImageBehavior = false;
            this.lvwFenLei.View = System.Windows.Forms.View.List;
            this.lvwFenLei.Validating += new System.ComponentModel.CancelEventHandler(this.lvwFenLei_Validating);
            this.lvwFenLei.SelectedIndexChanged += new System.EventHandler(this.lvwFenLei_SelectedIndexChanged);
            // 
            // lvwFangShi
            // 
            this.lvwFangShi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFangShi.FullRowSelect = true;
            this.lvwFangShi.HideSelection = false;
            this.lvwFangShi.Location = new System.Drawing.Point(12, 206);
            this.lvwFangShi.MultiSelect = false;
            this.lvwFangShi.Name = "lvwFangShi";
            this.lvwFangShi.Size = new System.Drawing.Size(400, 101);
            this.lvwFangShi.TabIndex = 6;
            this.lvwFangShi.UseCompatibleStateImageBehavior = false;
            this.lvwFangShi.View = System.Windows.Forms.View.List;
            this.lvwFangShi.Validating += new System.ComponentModel.CancelEventHandler(this.lvwFangShi_Validating);
            // 
            // txtMiaoShu
            // 
            this.txtMiaoShu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiaoShu.Location = new System.Drawing.Point(12, 377);
            this.txtMiaoShu.MaxLength = 255;
            this.txtMiaoShu.Multiline = true;
            this.txtMiaoShu.Name = "txtMiaoShu";
            this.txtMiaoShu.Size = new System.Drawing.Size(400, 101);
            this.txtMiaoShu.TabIndex = 12;
            // 
            // lblFenLei
            // 
            this.lblFenLei.AutoSize = true;
            this.lblFenLei.Location = new System.Drawing.Point(12, 61);
            this.lblFenLei.Name = "lblFenLei";
            this.lblFenLei.Size = new System.Drawing.Size(43, 13);
            this.lblFenLei.TabIndex = 3;
            this.lblFenLei.Text = "分类：";
            // 
            // lblFangShi
            // 
            this.lblFangShi.AutoSize = true;
            this.lblFangShi.Location = new System.Drawing.Point(12, 187);
            this.lblFangShi.Name = "lblFangShi";
            this.lblFangShi.Size = new System.Drawing.Size(67, 13);
            this.lblFangShi.TabIndex = 5;
            this.lblFangShi.Text = "交易方式：";
            // 
            // rdoXiaoFei
            // 
            this.rdoXiaoFei.AutoSize = true;
            this.rdoXiaoFei.Location = new System.Drawing.Point(12, 38);
            this.rdoXiaoFei.Name = "rdoXiaoFei";
            this.rdoXiaoFei.Size = new System.Drawing.Size(49, 17);
            this.rdoXiaoFei.TabIndex = 1;
            this.rdoXiaoFei.TabStop = true;
            this.rdoXiaoFei.Text = "消费";
            this.rdoXiaoFei.UseVisualStyleBackColor = true;
            // 
            // rdoShouRu
            // 
            this.rdoShouRu.AutoSize = true;
            this.rdoShouRu.Location = new System.Drawing.Point(85, 39);
            this.rdoShouRu.Name = "rdoShouRu";
            this.rdoShouRu.Size = new System.Drawing.Size(49, 17);
            this.rdoShouRu.TabIndex = 2;
            this.rdoShouRu.TabStop = true;
            this.rdoShouRu.Text = "收入";
            this.rdoShouRu.UseVisualStyleBackColor = true;
            // 
            // lblMingCheng
            // 
            this.lblMingCheng.AutoSize = true;
            this.lblMingCheng.Location = new System.Drawing.Point(12, 313);
            this.lblMingCheng.Name = "lblMingCheng";
            this.lblMingCheng.Size = new System.Drawing.Size(43, 13);
            this.lblMingCheng.TabIndex = 7;
            this.lblMingCheng.Text = "名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "描述：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "当日消费：";
            // 
            // txtJinE
            // 
            this.txtJinE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJinE.Location = new System.Drawing.Point(216, 332);
            this.txtJinE.Name = "txtJinE";
            this.txtJinE.Size = new System.Drawing.Size(196, 20);
            this.txtJinE.TabIndex = 10;
            this.txtJinE.Validating += new System.ComponentModel.CancelEventHandler(this.txtJinE_Validating);
            // 
            // lblJinE
            // 
            this.lblJinE.AutoSize = true;
            this.lblJinE.Location = new System.Drawing.Point(213, 313);
            this.lblJinE.Name = "lblJinE";
            this.lblJinE.Size = new System.Drawing.Size(43, 13);
            this.lblJinE.TabIndex = 8;
            this.lblJinE.Text = "金额：";
            // 
            // txtTodayXiaoFei
            // 
            this.txtTodayXiaoFei.ForeColor = System.Drawing.Color.Red;
            this.txtTodayXiaoFei.Location = new System.Drawing.Point(77, 493);
            this.txtTodayXiaoFei.Name = "txtTodayXiaoFei";
            this.txtTodayXiaoFei.ReadOnly = true;
            this.txtTodayXiaoFei.Size = new System.Drawing.Size(117, 20);
            this.txtTodayXiaoFei.TabIndex = 14;
            // 
            // txtTodayShouRu
            // 
            this.txtTodayShouRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTodayShouRu.Location = new System.Drawing.Point(277, 493);
            this.txtTodayShouRu.Name = "txtTodayShouRu";
            this.txtTodayShouRu.ReadOnly = true;
            this.txtTodayShouRu.Size = new System.Drawing.Size(135, 20);
            this.txtTodayShouRu.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 497);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "当日收入：";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(256, 532);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "新增 (&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(337, 532);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "关闭 (&C)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboMingCheng
            // 
            this.cboMingCheng.FormattingEnabled = true;
            this.cboMingCheng.Location = new System.Drawing.Point(15, 330);
            this.cboMingCheng.Name = "cboMingCheng";
            this.cboMingCheng.Size = new System.Drawing.Size(179, 21);
            this.cboMingCheng.TabIndex = 9;
            this.cboMingCheng.Validating += new System.ComponentModel.CancelEventHandler(this.cboMingCheng_Validating);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(175, 532);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 17;
            this.btnDetail.Text = "明细 (&D)";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // TodayFrm
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(424, 566);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.cboMingCheng);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtTodayShouRu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTodayXiaoFei);
            this.Controls.Add(this.txtJinE);
            this.Controls.Add(this.lblJinE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMingCheng);
            this.Controls.Add(this.rdoShouRu);
            this.Controls.Add(this.rdoXiaoFei);
            this.Controls.Add(this.lblFangShi);
            this.Controls.Add(this.lblFenLei);
            this.Controls.Add(this.txtMiaoShu);
            this.Controls.Add(this.lvwFangShi);
            this.Controls.Add(this.lvwFenLei);
            this.Controls.Add(this.dtpDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TodayFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "今天";
            this.Load += new System.EventHandler(this.TodayFrm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TodayFrm_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ListView lvwFenLei;
        private System.Windows.Forms.ListView lvwFangShi;
        private System.Windows.Forms.TextBox txtMiaoShu;
        private System.Windows.Forms.Label lblFenLei;
        private System.Windows.Forms.Label lblFangShi;
        private System.Windows.Forms.RadioButton rdoXiaoFei;
        private System.Windows.Forms.RadioButton rdoShouRu;
        private System.Windows.Forms.Label lblMingCheng;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtJinE;
        private System.Windows.Forms.Label lblJinE;
        private System.Windows.Forms.TextBox txtTodayXiaoFei;
        private System.Windows.Forms.TextBox txtTodayShouRu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboMingCheng;
        private System.Windows.Forms.Button btnDetail;
    }
}