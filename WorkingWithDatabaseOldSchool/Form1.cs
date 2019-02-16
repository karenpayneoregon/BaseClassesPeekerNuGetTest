using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingWithDatabaseOldSchool
{
    /// <summary>
    /// In this code sample there are many things wrong, starting
    /// by placing data access code in the form, in this case in form load.
    /// Next, naming of variables starting with 'my', this has zero meaning.
    /// Next, the connection string is done incorrectly unlike in the button
    /// event, missing a semi-colon.
    /// Next, not reporting what the error was.
    /// Next, the command text is all on one line, makes it hard to read.
    /// Next, explicitly naming variables e.g.
    /// SqlConnection myConnection = new SqlConnection
    /// rather than
    /// var cn = new SqlConnection
    /// while
    /// var myDataTable = new DataTable();
    /// is fine using implicit variable as we know it's a DataTable.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var myDataTable = new DataTable();

            var mySelectStatement = "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, Country, JoinDate AS Joined FROM dbo.Customers WHERE ActiveStatus = @ActiveStatus";


            var myServer = "KARENS-PC;";
            var myDatabaseWrong = "WorkingWithDataTips_1";

            var myConnectionString = "Data Source=" +  myServer +
                                     "Initial Catalog=" + myDatabaseWrong +
                                     "Integrated Security=True";

            using (SqlConnection myConnection = new SqlConnection { ConnectionString = myConnectionString })
            {
                using (SqlCommand myCommand = new SqlCommand { Connection = myConnection })
                {
                    myCommand.CommandText = mySelectStatement;
                    myCommand.Parameters.AddWithValue("@ActiveStatus", true);

                    try
                    {

                        myConnection.Open();

                        myDataTable.Load(myCommand.ExecuteReader());
                        myDataTable.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                        dataGridView1.DataSource = myDataTable;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went really wrong!!!");
                    }

                }
            }
        }

        private void badConnectionStringButton_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();

            var selectStatement =
                "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " +
                "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, " +
                "Country, JoinDate AS Joined " +
                "FROM dbo.Customers " +
                "WHERE ActiveStatus = @ActiveStatus";


            var rightWay = "Data Source=KARENS-PC;" + 
                           "Initial Catalog=WorkingWithDataTips_1;" + 
                           "Integrated Security=True";


            using (var cn = new SqlConnection { ConnectionString = rightWay })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = selectStatement;
                    cmd.Parameters.AddWithValue("@ActiveStatus", true);

                    try
                    {

                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                        dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                        dataGridView1.DataSource = dt;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Something went really wrong!!!{Environment.NewLine}{ex.Message}");
                    }

                }
            }
        }
    }
}
