namespace Money.Net
{
    partial class DaySummaryFrm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblXiaoFei = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShouRu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoFangShi = new System.Windows.Forms.RadioButton();
            this.rdoFenLei = new System.Windows.Forms.RadioButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetail = new FixedColumnDataGridView();
            this.FengLei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblXiaoFei);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblShouRu);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnDetail);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 342);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 41);
            this.panel3.TabIndex = 2;
            // 
            // lblXiaoFei
            // 
            this.lblXiaoFei.AutoSize = true;
            this.lblXiaoFei.ForeColor = System.Drawing.Color.Red;
            this.lblXiaoFei.Location = new System.Drawing.Point(189, 14);
            this.lblXiaoFei.Name = "lblXiaoFei";
            this.lblXiaoFei.Size = new System.Drawing.Size(35, 13);
            this.lblXiaoFei.TabIndex = 5;
            this.lblXiaoFei.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(148, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "消费:";
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
            this.btnDetail.Location = new System.Drawing.Point(286, 9);
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
            this.btnOK.Location = new System.Drawing.Point(367, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "关闭";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoFangShi);
            this.panel1.Controls.Add(this.rdoFenLei);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 35);
            this.panel1.TabIndex = 3;
            // 
            // rdoFangShi
            // 
            this.rdoFangShi.AutoSize = true;
            this.rdoFangShi.Location = new System.Drawing.Point(306, 9);
            this.rdoFangShi.Name = "rdoFangShi";
            this.rdoFangShi.Size = new System.Drawing.Size(73, 17);
            this.rdoFangShi.TabIndex = 3;
            this.rdoFangShi.Text = "交易方式";
            this.rdoFangShi.UseVisualStyleBackColor = true;
            this.rdoFangShi.CheckedChanged += new System.EventHandler(this.rdoFangShi_CheckedChanged);
            // 
            // rdoFenLei
            // 
            this.rdoFenLei.AutoSize = true;
            this.rdoFenLei.Checked = true;
            this.rdoFenLei.Location = new System.Drawing.Point(251, 9);
            this.rdoFenLei.Name = "rdoFenLei";
            this.rdoFenLei.Size = new System.Drawing.Size(49, 17);
            this.rdoFenLei.TabIndex = 2;
            this.rdoFenLei.TabStop = true;
            this.rdoFenLei.Text = "分类";
            this.rdoFenLei.UseVisualStyleBackColor = true;
            this.rdoFenLei.CheckedChanged += new System.EventHandler(this.rdoFenLei_CheckedChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(44, 7);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
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
            this.dgvDetail.Location = new System.Drawing.Point(0, 35);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(451, 307);
            this.dgvDetail.TabIndex = 4;
            // 
            // FengLei
            // 
            this.FengLei.HeaderText = "分类";
            this.FengLei.Name = "FengLei";
            this.FengLei.ReadOnly = true;
            // 
            // JinE
            // 
            this.JinE.HeaderText = "金额";
            this.JinE.Name = "JinE";
            this.JinE.ReadOnly = true;
            // 
            // DaySummaryFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(451, 383);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DaySummaryFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "每日合计";
            this.Load += new System.EventHandler(this.DaySummaryFrm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private FixedColumnDataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FengLei;
        private System.Windows.Forms.DataGridViewTextBoxColumn JinE;
        private System.Windows.Forms.RadioButton rdoFangShi;
        private System.Windows.Forms.RadioButton rdoFenLei;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShouRu;
        private System.Windows.Forms.Label lblXiaoFei;
        private System.Windows.Forms.Label label4;
    }
}