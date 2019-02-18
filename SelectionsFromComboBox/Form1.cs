using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SelectionsFromComboBox.Classes;

namespace SelectionsFromComboBox
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Made private so that if there were other methods besides
        /// the initial read we have access to the class methods.
        /// </summary>
        private readonly DataOperations _dataOperations = new DataOperations();
        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
            cboPickList.SelectionChangeCommitted += CboPickList_SelectionChangeCommitted;
        }
        private void CboPickList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AssertSelection();
        }

        /// <summary>
        /// Color change not practical but useful for teaching
        /// </summary>
        private void AssertSelection()
        {
            var row = ((DataRowView)cboPickList.SelectedItem).Row;
            if (row.Field<int>("ProductID") == 0)
            {
                lblPickListDescription.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPickListDescription.ForeColor = SystemColors.ControlText;
            }

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            var dt = _dataOperations.GetAllProducts();

            cboPickList.DataSource = dt;
            cboPickList.DisplayMember = "ProductName";

            lblPickListDescription.DataBindings.Add("Text", dt, "ProductName");
            lblPickListIdentifier.DataBindings.Add("Text", dt, "ProductID");

            AssertSelection();
        }
        /// <summary>
        /// Find current product if not the first row for make a selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productByIdentifierButton_Click(object sender, EventArgs e)
        {
            // Cast SelectedItem to a DataRow
            var row = ((DataRowView)cboPickList.SelectedItem).Row;

            // Obtain the primary key
            var pKey = row.Field<int>("ProductID");

            // if primary key is 0 this means the row is the row for prompting for a proper selection
            if (pKey <= 0) return;

            // Search for the primary key, get back a DataTable.
            // See comments in readme.md
            var productRow = _dataOperations
                .GetProductsByIdentifier(pKey)
                .AsEnumerable()
                .FirstOrDefault();

            // check for errors via IsSuccessFule
            if (_dataOperations.IsSuccessFul)
            {
                if (productRow != null) MessageBox.Show($"Key: {pKey}, row data: {string.Join(",", productRow.ItemArray)}");
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }
    }
}
