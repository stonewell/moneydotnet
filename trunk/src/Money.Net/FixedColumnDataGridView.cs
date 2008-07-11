using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Money.Net
{
#if PocketPC
    public class FixedColumnDataGridView : DataGrid
#else
    public class FixedColumnDataGridView : DataGridView
#endif
    {
        private int fixedColumn_ = 0;

        public FixedColumnDataGridView()
        {
            base.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.MultiSelect = false;

            this.ColumnAdded += 
                new DataGridViewColumnEventHandler(FixedColumnDataGridView_ColumnAdded);

            this.CellValueChanged += 
                new DataGridViewCellEventHandler(FixedColumnDataGridView_CellValueChanged);

            this.SelectionChanged += new EventHandler(FixedColumnDataGridView_SelectionChanged);
        }

#if !PocketPC
        public new DataGridViewSelectionMode SelectionMode
        {
            get
            {
                return DataGridViewSelectionMode.CellSelect;
            }

            set
            {
                base.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
        }
#endif

#if !PocketPC
        [Category("Appearance")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
#endif
        [DefaultValue(0)]
        public int FixedColumn
        {
            get
            {
                return fixedColumn_;
            }

            set
            {
                fixedColumn_ = value;

                for (int i = 0; i <= fixedColumn_; i++)
                {
                    Columns[i].Frozen = true;
                    Columns[i].CellTemplate = new FixedColumnDataGridCell();
                }
            }
        }

        private bool ShouldSerializeFixedColumn()
        {
            return true;
        }

        private void FixedColumnDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.SelectedCells.Count == 0)
                return;

            this.SelectionChanged -=
                new EventHandler(FixedColumnDataGridView_SelectionChanged);

            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j <= FixedColumn; j++)
                {
                    if (this[j, i].Selected)
                    {
                        this[j, i].Selected = false;

                        if (Columns.Count > FixedColumn + 1)
                        {
                            this[FixedColumn + 1, i].Selected = true;
                        }
                    }
                }
            }

            this.SelectionChanged +=
                new EventHandler(FixedColumnDataGridView_SelectionChanged);
        }

#if !PocketPC
        private void FixedColumnDataGridView_CellValueChanged(object sender, 
            DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= FixedColumn && e.RowIndex >= 0)
            {
                this[e.ColumnIndex, e.RowIndex].Style.BackColor =
                    Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void FixedColumnDataGridView_ColumnAdded(object sender, 
            DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index <= FixedColumn)
            {
                e.Column.Frozen = true;
                e.Column.CellTemplate = new FixedColumnDataGridCell();
            }
        }
#endif
    }

#if !PocketPC
    public class FixedColumnDataGridCell : DataGridViewTextBoxCell
    {
        public override DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded,
            bool firstVisibleColumn,
            bool firstVisibleRow)
        {
            FixedColumnDataGridView gv =
                this.DataGridView as FixedColumnDataGridView;

            if (ColumnIndex <= gv.FixedColumn)
            {
                Style.BackColor =
                    Color.FromKnownColor(KnownColor.Control);

                dataGridViewAdvancedBorderStylePlaceHolder.Left =
                    ColumnIndex == 0 ? DataGridViewAdvancedCellBorderStyle.OutsetDouble : DataGridViewAdvancedCellBorderStyle.Outset;
                dataGridViewAdvancedBorderStylePlaceHolder.Top =
                    DataGridViewAdvancedCellBorderStyle.Outset;

                dataGridViewAdvancedBorderStylePlaceHolder.Right =
                    DataGridViewAdvancedCellBorderStyle.Outset;
                dataGridViewAdvancedBorderStylePlaceHolder.Bottom =
                    DataGridViewAdvancedCellBorderStyle.Outset;
            }
            else
            {
                dataGridViewAdvancedBorderStylePlaceHolder.Left =
                    DataGridViewAdvancedCellBorderStyle.None;
                dataGridViewAdvancedBorderStylePlaceHolder.Top =
                    DataGridViewAdvancedCellBorderStyle.None;

                dataGridViewAdvancedBorderStylePlaceHolder.Right =
                    DataGridViewAdvancedCellBorderStyle.Single;
                dataGridViewAdvancedBorderStylePlaceHolder.Bottom =
                    DataGridViewAdvancedCellBorderStyle.Single;
            }

            return dataGridViewAdvancedBorderStylePlaceHolder;
        }
    }
#endif
}
