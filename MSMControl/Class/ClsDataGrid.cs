using MSMControl.Connection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Class
{
    public static class ClsDataGrid
    {
        public static DataGridViewTextBoxColumn Columns(this DataGridView gridView, string name, string headerText,
            string dataProperty, int? width = 100, int? mimWidth = 2, bool visible = true,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft,
            DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable,
            DataGridViewAutoSizeColumnMode columnMode = DataGridViewAutoSizeColumnMode.None)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = dataProperty.Replace("'", "''").Trim().Length is 0 ? name : dataProperty,
                Width = width ?? 100,
                MinimumWidth = mimWidth > 0 ? (int)mimWidth : 2,
                Visible = visible,
                DefaultCellStyle = { Alignment = alignment },
                AutoSizeMode = columnMode,
                SortMode = sortMode,
                ValueType = typeof(string)
            };
            column.HeaderCell.Style.Font = new Font("Verdana", 9, FontStyle.Bold);
            column.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            gridView.Columns.Add(column);
            return column;
        }
        public static DataGridViewTextBoxColumn Columns(this DataGridView gridView, string name, string headerText,string dataProperty, int? width = 100, int? mimWidth = 2, bool visible = true)
        {
            return Columns(gridView, name, headerText, dataProperty, width, mimWidth, visible,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
        }
    }
}
