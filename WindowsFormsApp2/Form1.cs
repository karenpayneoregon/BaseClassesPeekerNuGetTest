using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Classes;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomers = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ops = new DataOperations();

            try
            {
                bsCustomers.DataSource = ops.GetCustomersByTitle("Owner");
                dataGridView1.DataSource = bsCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
