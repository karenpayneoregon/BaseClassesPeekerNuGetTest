using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseConnectionLibrary;
using FileHandlingExceptions.Classes;

namespace FileHandlingExceptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Non-existing file for demonstration
        /// </summary>
        private readonly string _badFileName =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Custmers.txt");

        /// <summary>
        /// Non-existing file for demonstration
        /// </summary>
        private readonly string _goodFileName =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Customers.txt");

        /// <summary>
        /// Read non-existing file (file name is misspelled) with
        /// BaseExceptionProperties from NuGet package
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readNonExistingBaseExceptionPropertiesFileButton_Click(object sender, EventArgs e)
        {
            var ops = new FileOperations();
            var lineList = ops.ReadFileWithBaseExceptionProperties(_badFileName);

            MessageBox.Show(ops.IsSuccessFul ? "Success" : ops.LastExceptionMessage);
        }
        /// <summary>
        /// Read non-existing file (file name is misspelled)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readNonExistingConventionalFileButton_Click(object sender, EventArgs e)
        {
            var ops = new FileOperations();

            try
            {
                var lineList = ops.ReadFileWithOutBaseExceptionProperties(_badFileName);

                MessageBox.Show("Success");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// Read existing file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readExistingBaseExceptionPropertiesFileButton_Click(object sender, EventArgs e)
        {
            var ops = new FileOperations();
            var lineList = ops.ReadFileWithBaseExceptionProperties(_goodFileName);

            MessageBox.Show(ops.IsSuccessFul ? "Success" : ops.LastExceptionMessage);
        }
    }
}
