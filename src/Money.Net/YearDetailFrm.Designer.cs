namespace Money.Net
{
    partial class YearDetailFrm
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
            this.lblYear = new System.Windows.Forms.Label();
            this.rdoFangShi = new System.Windows.Forms.RadioButton();
            this.rdoFenLei = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDetail = new Money.Net.FixedColumnDataGridView();
            this.btnMonthDetail = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblYear);
            this.panel1.Controls.Add(this.rdoFangShi);
            this.panel1.Controls.Add(this.rdoFenLei);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 35);
            this.panel1.TabIndex = 10;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(44, 11);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(35, 13);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "label1";
            // 
            // rdoFangShi
            // 
            this.rdoFangShi.AutoSize = true;
            this.rdoFangShi.Location = new System.Drawing.Point(227, 9);
            this.rdoFangShi.Name = "rdoFangShi";
            this.rdoFangShi.Size = new System.Drawing.Size(73, 17);
            this.rdoFangShi.TabIndex = 8;
            this.rdoFangShi.Text = "交易方式";
            this.rdoFangShi.UseVisualStyleBackColor = true;
            this.rdoFangShi.CheckedChanged += new System.EventHandler(this.rdoFangShi_CheckedChanged);
            // 
            // rdoFenLei
            // 
            this.rdoFenLei.AutoSize = true;
            this.rdoFenLei.Checked = true;
            this.rdoFenLei.Location = new System.Drawing.Point(172, 9);
            this.rdoFenLei.Name = "rdoFenLei";
            this.rdoFenLei.Size = new System.Drawing.Size(49, 17);
            this.rdoFenLei.TabIndex = 7;
            this.rdoFenLei.TabStop = true;
            this.rdoFenLei.Text = "分类";
            this.rdoFenLei.UseVisualStyleBackColor = true;
            this.rdoFenLei.CheckedChanged += new System.EventHandler(this.rdoFenLei_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "年份:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(491, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "关闭";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMonthDetail);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 41);
            this.panel3.TabIndex = 11;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 35);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(575, 251);
            this.dgvDetail.TabIndex = 12;
            // 
            // btnMonthDetail
            // 
            this.btnMonthDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonthDetail.Location = new System.Drawing.Point(410, 9);
            this.btnMonthDetail.Name = "btnMonthDetail";
            this.btnMonthDetail.Size = new System.Drawing.Size(75, 23);
            this.btnMonthDetail.TabIndex = 1;
            this.btnMonthDetail.Text = "每月明细";
            this.btnMonthDetail.UseVisualStyleBackColor = true;
            this.btnMonthDetail.Click += new System.EventHandler(this.btnMonthDetail_Click);
            // 
            // YearDetailFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(575, 327);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "YearDetailFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "年度明细";
            this.Load += new System.EventHandler(this.YearDetailFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoFangShi;
        private System.Windows.Forms.RadioButton rdoFenLei;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel3;
        private FixedColumnDataGridView dgvDetail;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnMonthDetail;
    }
}