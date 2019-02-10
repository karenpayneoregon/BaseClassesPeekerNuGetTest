using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomers = new BindingSource();

        /// <summary>
        /// Indicates administrator mode.
        /// </summary>
        private bool _adminMode = false;
        public Form1(string[] commandArguments)
        {
            InitializeComponent();
            Shown += Form1_Shown;

            if (commandArguments.Length != 1) return;
            _adminMode = commandArguments[0].ToUpper() == "-ADMIN";

        }
        /// <summary>
        /// Load data from backend database with a WHERE condition on customers
        /// contact title.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            DataOperations ops = new DataOperations();

            bsCustomers.DataSource = ops.GetCustomersByTitle("Owner");

            if (ops.IsSuccessFul)
            {
                dataGridView1.DataSource = bsCustomers;
            }
            else
            {
                MessageBox.Show($"{ops.LastExceptionMessage}");
            }

        }
        /// <summary>
        /// Check if the server is available which is specified in DatabaseServer
        /// from SqlServerConnection class in the NuGet package BaseConnectionLibrary.
        ///
        /// The underlying code keeps the application responsive yet there will be a
        /// wait period for the check to take place if the server is available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void serverAvailableButton_Click(object sender, EventArgs e)
        {

            var ops = new SqlServerDatabaseUtilities();
            var available = await ops.SqlServerIsAvailableDefault();
            var englishText = available == true ? "yes" : "no";

            MessageBox.Show($"{ops.ServerName} is available '{englishText}'");

        }
    }
}
