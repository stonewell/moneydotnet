namespace Money.Net.Controls
{
    partial class MappingControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMapping = new System.Windows.Forms.Button();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.lstTarget = new System.Windows.Forms.ListBox();
            this.pnlMapping = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMapping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnMapping
            // 
            this.btnMapping.Location = new System.Drawing.Point(218, 4);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(75, 23);
            this.btnMapping.TabIndex = 0;
            this.btnMapping.Text = "button1";
            this.btnMapping.UseVisualStyleBackColor = true;
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // lstSource
            // 
            this.lstSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSource.FormattingEnabled = true;
            this.lstSource.Location = new System.Drawing.Point(0, 0);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(166, 316);
            this.lstSource.TabIndex = 1;
            this.lstSource.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstSource_DrawItem);
            this.lstSource.SelectedIndexChanged += new System.EventHandler(this.lstSource_SelectedIndexChanged);
            // 
            // lstTarget
            // 
            this.lstTarget.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstTarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstTarget.FormattingEnabled = true;
            this.lstTarget.Location = new System.Drawing.Point(344, 0);
            this.lstTarget.Name = "lstTarget";
            this.lstTarget.Size = new System.Drawing.Size(166, 316);
            this.lstTarget.TabIndex = 2;
            this.lstTarget.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstTarget_DrawItem);
            this.lstTarget.SelectedIndexChanged += new System.EventHandler(this.lstTarget_SelectedIndexChanged);
            // 
            // pnlMapping
            // 
            this.pnlMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapping.Location = new System.Drawing.Point(166, 0);
            this.pnlMapping.Name = "pnlMapping";
            this.pnlMapping.Size = new System.Drawing.Size(178, 320);
            this.pnlMapping.TabIndex = 3;
            this.pnlMapping.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapping_Paint);
            // 
            // MappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMapping);
            this.Controls.Add(this.lstTarget);
            this.Controls.Add(this.lstSource);
            this.Controls.Add(this.panel1);
            this.Name = "MappingControl";
            this.Size = new System.Drawing.Size(510, 350);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MappingControl_Layout);
            this.Load += new System.EventHandler(this.MappingControl_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.ListBox lstTarget;
        private System.Windows.Forms.Panel pnlMapping;
        private System.Windows.Forms.Button btnMapping;

    }
}
