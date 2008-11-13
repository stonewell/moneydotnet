namespace Money.Net
{
    partial class FangShiDurationSummaryFrm
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
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dgvDetail = new Money.Net.FixedColumnDataGridView();
            this.���� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.��� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFangShi = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAllRecords = new System.Windows.Forms.Button();
            this.lblXiaoFei = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShouRu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(69, 34);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 12;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "����ʱ��:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd dddd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(69, 8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 10;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.����,
            this.���});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 88);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(575, 323);
            this.dgvDetail.TabIndex = 15;
            // 
            // ����
            // 
            this.����.Frozen = true;
            this.����.HeaderText = "����";
            this.����.Name = "����";
            this.����.ReadOnly = true;
            // 
            // ���
            // 
            this.���.HeaderText = "���";
            this.���.Name = "���";
            this.���.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "��ʼʱ��:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboFangShi);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 88);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "���׷�ʽ:";
            // 
            // cboFangShi
            // 
            this.cboFangShi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFangShi.FormattingEnabled = true;
            this.cboFangShi.Location = new System.Drawing.Point(69, 60);
            this.cboFangShi.Name = "cboFangShi";
            this.cboFangShi.Size = new System.Drawing.Size(200, 21);
            this.cboFangShi.TabIndex = 13;
            this.cboFangShi.SelectedIndexChanged += new System.EventHandler(this.cboFenLei_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(491, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "�ر�";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAllRecords);
            this.panel3.Controls.Add(this.lblXiaoFei);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblShouRu);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnDetail);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 411);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 41);
            this.panel3.TabIndex = 14;
            // 
            // btnAllRecords
            // 
            this.btnAllRecords.Location = new System.Drawing.Point(329, 9);
            this.btnAllRecords.Name = "btnAllRecords";
            this.btnAllRecords.Size = new System.Drawing.Size(75, 23);
            this.btnAllRecords.TabIndex = 15;
            this.btnAllRecords.Text = "ȫ����¼";
            this.btnAllRecords.UseVisualStyleBackColor = true;
            this.btnAllRecords.Click += new System.EventHandler(this.btnAllRecords_Click);
            // 
            // lblXiaoFei
            // 
            this.lblXiaoFei.AutoSize = true;
            this.lblXiaoFei.ForeColor = System.Drawing.Color.Red;
            this.lblXiaoFei.Location = new System.Drawing.Point(199, 14);
            this.lblXiaoFei.Name = "lblXiaoFei";
            this.lblXiaoFei.Size = new System.Drawing.Size(35, 13);
            this.lblXiaoFei.TabIndex = 14;
            this.lblXiaoFei.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(158, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "����:";
            // 
            // lblShouRu
            // 
            this.lblShouRu.AutoSize = true;
            this.lblShouRu.ForeColor = System.Drawing.Color.Blue;
            this.lblShouRu.Location = new System.Drawing.Point(45, 14);
            this.lblShouRu.Name = "lblShouRu";
            this.lblShouRu.Size = new System.Drawing.Size(35, 13);
            this.lblShouRu.TabIndex = 12;
            this.lblShouRu.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(4, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "����:";
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(410, 9);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "��ϸ";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // FangShiDurationSummaryFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 452);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FangShiDurationSummaryFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���׷�ʽ����ϼ�";
            this.Load += new System.EventHandler(this.FenLeiDurationDetailFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private FixedColumnDataGridView dgvDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFangShi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ����;
        private System.Windows.Forms.DataGridViewTextBoxColumn ���;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnAllRecords;
        private System.Windows.Forms.Label lblXiaoFei;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShouRu;
        private System.Windows.Forms.Label label4;
    }
}