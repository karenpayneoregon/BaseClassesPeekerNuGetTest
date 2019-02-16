using System;
using System.Data;
using System.Windows.Forms;
using BestPracticeSqlServer1.DataClasses;

namespace BestPracticeSqlServer1
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomers = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            var ops = new DataOperations();

            bsCustomers.DataSource = ops.GetCustomersByStatus();

            if (ops.IsSuccessFul)
            {
                dataGridView1.DataSource = bsCustomers;
            }
            else
            {
                MessageBox.Show($"{ops.LastExceptionMessage}");

            }

        }
    }
}
