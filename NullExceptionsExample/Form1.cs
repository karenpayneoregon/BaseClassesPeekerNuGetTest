using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NullExceptionsExample.Classes;

namespace NullExceptionsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeNullArrayItemButton_Click(object sender, EventArgs e) 
        {
            var ops = new ArrayExamples();
            ops.SetValueWithNullArray();

            MessageBox.Show(ops.IsSuccessFul ? "Success" : $"{ops.LastExceptionMessage}");
        }

        private void AttemptToAddItemNullCollectionButton_Click(object sender, EventArgs e)
        {
            var ops = new CollectionExamples();
            ops.CollectionIsNull();

            MessageBox.Show(ops.IsSuccessFul ? "Success" : $"{ops.LastExceptionMessage}");
        }

        private void InvalidCastExceptionFromObjectToIntButton_Click(object sender, EventArgs e)
        {
            var ops = new VariousCommonExceptions();
            ops.InvalidCastException();

            MessageBox.Show(ops.IsSuccessFul ? "Success" : $"{ops.LastExceptionMessage}");
        }

        private void InvalidOperationExceptionButton_Click(object sender, EventArgs e)
        {
            var ops = new VariousCommonExceptions();
            ops.InvalidOperationException();

            MessageBox.Show(ops.IsSuccessFul ? "Success" : $"{ops.LastExceptionMessage}");

            ops.ValidOperationDoneRight();
            MessageBox.Show(ops.IsSuccessFul ? "Success" : $"{ops.LastExceptionMessage}");
        }
    }
}
