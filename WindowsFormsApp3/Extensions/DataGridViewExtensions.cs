using System.Windows.Forms;

namespace WindowsFormsApp3.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn column in sender.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
