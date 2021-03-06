﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessConnectionPassworded.Classes;
using AccessConnectionPassworded.Extensions;

namespace AccessConnectionPassworded
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bsCustomerBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var ops = new DataOperations();
            _bsCustomerBindingSource.DataSource = ops.LoadCustomersPartialData();

            if (ops.IsSuccessFul)
            {
                dataGridView1.DataSource = _bsCustomerBindingSource;
                dataGridView1.ExpandColumns();
            }
            else
            {
                MessageBox.Show($"Failed to load data{Environment.NewLine}{ops.LastExceptionMessage}");
            }
        }
    }
}
