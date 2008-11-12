namespace Money.Net
{
    partial class RestoreGuDingFrm
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
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.SelectCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ChangeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FengLei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiaoYiFangShi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZhouQi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XiaoFei = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShouRu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.JinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiaoShu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasEndTime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastExecuteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRestore);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(925, 41);
            this.panel3.TabIndex = 3;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(760, 9);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "恢复";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(841, 9);
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
            this.SelectCol,
            this.ChangeTime,
            this.ChangeMode,
            this.MingCheng,
            this.FengLei,
            this.JiaoYiFangShi,
            this.ZhouQi,
            this.XiaoFei,
            this.ShouRu,
            this.JinE,
            this.MiaoShu,
            this.StartTime,
            this.HasEndTime,
            this.StopTime,
            this.LastExecuteTime});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(925, 352);
            this.dgvDetail.TabIndex = 4;
            // 
            // SelectCol
            // 
            this.SelectCol.HeaderText = "";
            this.SelectCol.Name = "SelectCol";
            this.SelectCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectCol.Width = 20;
            // 
            // ChangeTime
            // 
            this.ChangeTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChangeTime.HeaderText = "修改时间";
            this.ChangeTime.Name = "ChangeTime";
            this.ChangeTime.ReadOnly = true;
            this.ChangeTime.Width = 80;
            // 
            // ChangeMode
            // 
            this.ChangeMode.HeaderText = "修改方式";
            this.ChangeMode.Name = "ChangeMode";
            this.ChangeMode.ReadOnly = true;
            // 
            // MingCheng
            // 
            this.MingCheng.HeaderText = "名称";
            this.MingCheng.Name = "MingCheng";
            this.MingCheng.ReadOnly = true;
            // 
            // FengLei
            // 
            this.FengLei.HeaderText = "分类";
            this.FengLei.Name = "FengLei";
            this.FengLei.ReadOnly = true;
            // 
            // JiaoYiFangShi
            // 
            this.JiaoYiFangShi.HeaderText = "交易方式";
            this.JiaoYiFangShi.Name = "JiaoYiFangShi";
            this.JiaoYiFangShi.ReadOnly = true;
            // 
            // ZhouQi
            // 
            this.ZhouQi.HeaderText = "周期";
            this.ZhouQi.Name = "ZhouQi";
            this.ZhouQi.ReadOnly = true;
            // 
            // XiaoFei
            // 
            this.XiaoFei.HeaderText = "消费";
            this.XiaoFei.Name = "XiaoFei";
            this.XiaoFei.ReadOnly = true;
            this.XiaoFei.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.XiaoFei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ShouRu
            // 
            this.ShouRu.HeaderText = "收入";
            this.ShouRu.Name = "ShouRu";
            this.ShouRu.ReadOnly = true;
            this.ShouRu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShouRu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // JinE
            // 
            this.JinE.HeaderText = "金额";
            this.JinE.Name = "JinE";
            this.JinE.ReadOnly = true;
            // 
            // MiaoShu
            // 
            this.MiaoShu.HeaderText = "描述";
            this.MiaoShu.Name = "MiaoShu";
            this.MiaoShu.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // HasEndTime
            // 
            this.HasEndTime.HeaderText = "无结束日期";
            this.HasEndTime.Name = "HasEndTime";
            this.HasEndTime.ReadOnly = true;
            // 
            // StopTime
            // 
            this.StopTime.HeaderText = "结束时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            // 
            // LastExecuteTime
            // 
            this.LastExecuteTime.HeaderText = "上次执行时间";
            this.LastExecuteTime.Name = "LastExecuteTime";
            this.LastExecuteTime.ReadOnly = true;
            // 
            // RestoreGuDingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(925, 393);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel3);
            this.MinimizeBox = false;
            this.Name = "RestoreGuDingFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "恢复日常交易记录";
            this.Load += new System.EventHandler(this.RestoreGuDingFrm_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MingCheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn FengLei;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiaoYiFangShi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZhouQi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn XiaoFei;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShouRu;
        private System.Windows.Forms.DataGridViewTextBoxColumn JinE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiaoShu;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastExecuteTime;
    }
}