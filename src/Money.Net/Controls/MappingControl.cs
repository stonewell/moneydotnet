using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Money.Net.Controls
{
    public partial class MappingControl : UserControl
    {
        private IList mappingSource_ = null;
        private IList mappingTarget_ = null;
        private IDictionary mappings_ = new Hashtable();
        private bool bMapping_ = true;
        private int targetTopIndex_ = -1;
        private int sourceTopIndex_ = -1;

        public MappingControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList MappingSource
        {
            get
            {
                return mappingSource_;
            }

            set
            {
                mappingSource_ = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList MappingTarget
        {
            get
            {
                return mappingTarget_;
            }

            set
            {
                mappingTarget_ = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDictionary Mappings
        {
            get
            {
                return mappings_;
            }

            set
            {
                mappings_ = value;
            }
        }

        private void lstSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBtnMappingStatus();

            sourceTopIndex_ = lstSource.TopIndex;
        }

        private void lstTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBtnMappingStatus();

            targetTopIndex_ = lstTarget.TopIndex;
        }

        private void UpdateBtnMappingStatus()
        {
            if (lstSource.SelectedItem != null &&
                lstTarget.SelectedItem != null)
            {
                if (mappings_.Contains(lstSource.SelectedItem))
                {
                    if (mappings_[lstSource.SelectedItem] == lstTarget.SelectedItem)
                    {
                        btnMapping.Text = "解除配对";
                        bMapping_ = false;
                    }
                    else
                    {
                        btnMapping.Text = "配对";
                        bMapping_ = true;
                    }
                }
                else
                {
                    btnMapping.Text = "配对";
                    bMapping_ = true;
                }

                btnMapping.Enabled = true;
            }
            else
            {
                btnMapping.Text = "配对";
                bMapping_ = true;
                btnMapping.Enabled = false;
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            if (lstSource.SelectedItem != null &&
                lstTarget.SelectedItem != null)
            {
                Graphics g = pnlMapping.CreateGraphics();

                if (bMapping_)
                {
                    if (mappings_.Contains(lstSource.SelectedItem))
                    {
                        DrawMappingLine(g, lstSource.SelectedItem,
                            mappings_[lstSource.SelectedItem], false);
                    }

                    mappings_[lstSource.SelectedItem] =
                        lstTarget.SelectedItem;

                    DrawMappingLine(g, lstSource.SelectedItem,
                        lstTarget.SelectedItem, true);
                }
                else
                {
                    mappings_.Remove(lstSource.SelectedItem);

                    DrawMappingLine(g, lstSource.SelectedItem,
                        lstTarget.SelectedItem, false);
                }

                g.Dispose();
            }

            UpdateBtnMappingStatus();
        }

        private void MappingControl_Load(object sender, EventArgs e)
        {
            RefreshData();

            UpdateBtnMappingStatus();
        }

        private void RefreshMapping()
        {
            Graphics g = pnlMapping.CreateGraphics();

            g.Clear(pnlMapping.BackColor);

            IDictionaryEnumerator it =
                mappings_.GetEnumerator();

            while (it.MoveNext())
            {
                DrawMappingLine(g, it.Key, it.Value, true);
            }

            g.Dispose();
        }

        private void DrawMappingLine(Graphics g, object source, object target, bool draw)
        {
            int sourceIndex = lstSource.Items.IndexOf(source);
            int targetIndex = lstTarget.Items.IndexOf(target);

            if (sourceIndex >= 0 && targetIndex >= 0)
            {
                int sourceTop = lstSource.Top +
                    (sourceIndex - lstSource.TopIndex) * lstSource.ItemHeight +
                    lstSource.ItemHeight / 2;
                int targetTop = lstTarget.Top +
                    (targetIndex - lstTarget.TopIndex) * lstTarget.ItemHeight +
                    lstTarget.ItemHeight / 2;

                Pen p = Pens.Black;
                if (!draw)
                {
                    p = new Pen(pnlMapping.BackColor);
                }

                g.DrawLine(p,
                    0, sourceTop, pnlMapping.Width, targetTop);
            }
        }

        private void MappingControl_Layout(object sender, LayoutEventArgs e)
        {
            btnMapping.Left =
                (Width - btnMapping.Width) / 2;
        }

        public void RefreshData()
        {
            lstTarget.Items.Clear();
            lstSource.Items.Clear();

            if (mappingSource_ != null)
            {
                foreach (object o in mappingSource_)
                {
                    lstSource.Items.Add(o);
                }

                if (lstSource.Items.Count > 0)
                    lstSource.SelectedIndex = 0;
            }

            if (mappingTarget_ != null)
            {
                foreach (object o in mappingTarget_)
                    lstTarget.Items.Add(o);

                if (lstTarget.Items.Count > 0)
                    lstTarget.SelectedIndex = 0;
            }

            if (mappings_ != null)
            {
                RefreshMapping();
            }

            targetTopIndex_ = lstTarget.TopIndex;
            sourceTopIndex_ = lstSource.TopIndex;
        }

        private void lstTarget_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Set the DrawMode property to draw fixed sized items.
            lstTarget.DrawMode = DrawMode.OwnerDrawFixed;
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = new SolidBrush(e.ForeColor);

            // Draw the current item text based on the current Font and the custom brush settings.
            e.Graphics.DrawString(lstTarget.Items[e.Index].ToString(), 
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();

            if (targetTopIndex_ != lstTarget.TopIndex)
            {
                RefreshMapping();
            }

            targetTopIndex_ = lstTarget.TopIndex;
        }

        private void lstSource_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Set the DrawMode property to draw fixed sized items.
            lstSource.DrawMode = DrawMode.OwnerDrawFixed;
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = new SolidBrush(e.ForeColor);

            // Draw the current item text based on the current Font and the custom brush settings.
            e.Graphics.DrawString(lstSource.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();

            if (sourceTopIndex_ != lstSource.TopIndex)
            {
                RefreshMapping();
            }

            sourceTopIndex_ = lstSource.TopIndex;
        }

        private void pnlMapping_Paint(object sender, PaintEventArgs e)
        {
            RefreshMapping();
        }
    }
}
