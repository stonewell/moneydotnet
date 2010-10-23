namespace Money.Net
{
    partial class CustomizedDurationSummaryFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizedDurationSummaryFrm));
            this.label3 = new System.Windows.Forms.Label();
            this.JinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoFangShi = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.FengLei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoFenLei = new System.Windows.Forms.RadioButton();
            this.lblXiaoFei = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShouRu = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvDetail = new FixedColumnDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "开始时间:";
            // 
            // JinE
            // 
            this.JinE.HeaderText = "金额";
            this.JinE.Name = "JinE";
            this.JinE.ReadOnly = true;
            // 
            // rdoFangShi
            // 
            this.rdoFangShi.AutoSize = true;
            this.rdoFangShi.Location = new System.Drawing.Point(375, 8);
            this.rdoFangShi.Name = "rdoFangShi";
            this.rdoFangShi.Size = new System.Drawing.Size(73, 17);
            this.rdoFangShi.TabIndex = 3;
            this.rdoFangShi.Text = "交易方式";
            this.rdoFangShi.UseVisualStyleBackColor = true;
            this.rdoFangShi.CheckedChanged += new System.EventHandler(this.rdoFangShi_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "结束时间:";
            // 
            // FengLei
            // 
            this.FengLei.HeaderText = "分类";
            this.FengLei.Name = "FengLei";
            this.FengLei.ReadOnly = true;
            // 
            // rdoFenLei
            // 
            this.rdoFenLei.AutoSize = true;
            this.rdoFenLei.Checked = true;
            this.rdoFenLei.Location = new System.Drawing.Point(308, 8);
            this.rdoFenLei.Name = "rdoFenLei";
            this.rdoFenLei.Size = new System.Drawing.Size(49, 17);
            this.rdoFenLei.TabIndex = 2;
            this.rdoFenLei.TabStop = true;
            this.rdoFenLei.Text = "分类";
            this.rdoFenLei.UseVisualStyleBackColor = true;
            this.rdoFenLei.CheckedChanged += new System.EventHandler(this.rdoFenLei_CheckedChanged);
            // 
            // lblXiaoFei
            // 
            this.lblXiaoFei.AutoSize = true;
            this.lblXiaoFei.ForeColor = System.Drawing.Color.Red;
            this.lblXiaoFei.Location = new System.Drawing.Point(208, 14);
            this.lblXiaoFei.Name = "lblXiaoFei";
            this.lblXiaoFei.Size = new System.Drawing.Size(35, 13);
            this.lblXiaoFei.TabIndex = 5;
            this.lblXiaoFei.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(167, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "消费:";
            // 
            // lblShouRu
            // 
            this.lblShouRu.AutoSize = true;
            this.lblShouRu.ForeColor = System.Drawing.Color.Blue;
            this.lblShouRu.Location = new System.Drawing.Point(54, 14);
            this.lblShouRu.Name = "lblShouRu";
            this.lblShouRu.Size = new System.Drawing.Size(35, 13);
            this.lblShouRu.TabIndex = 3;
            this.lblShouRu.Text = "label3";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblXiaoFei);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblShouRu);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnDetail);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 351);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(469, 40);
            this.panel3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "收入:";
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(308, 9);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "明细";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(391, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "关闭";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FengLei,
            this.JinE});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 66);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(469, 325);
            this.dgvDetail.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rdoFangShi);
            this.panel1.Controls.Add(this.rdoFenLei);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 66);
            this.panel1.TabIndex = 9;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(70, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 9;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(70, 8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 8;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // CustomizedDurationSummaryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 391);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizedDurationSummaryFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "区间合计";
            this.Load += new System.EventHandler(this.CustomizedDurationSummaryFrm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn JinE;
        private System.Windows.Forms.RadioButton rdoFangShi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FengLei;
        private System.Windows.Forms.RadioButton rdoFenLei;
        private System.Windows.Forms.Label lblXiaoFei;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShouRu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnOK;
        private FixedColumnDataGridView dgvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}