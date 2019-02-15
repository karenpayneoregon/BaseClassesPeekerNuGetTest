using System;
using System.IO;
using System.Windows.Forms;
using WindowsApp3a.Classes;

namespace WindowsApp3a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exportExcelButton_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var rowsExported = 0;

            var ops = new DataOperations();
            ops.WriteCustomerTableToXmlFile(fileName, ref rowsExported);

            MessageBox.Show(ops.IsSuccessFul ? $"Done, exported {rowsExported} rows" : $"Error{Environment.NewLine}{ops.LastExceptionMessage}");
        }
    }
}
