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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var dt = new DataTable();

            var selectStatement =
                "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " +
                "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, " +
                "Country, JoinDate AS Joined " +
                "FROM dbo.Customers " +
                "WHERE ActiveStatus = @ActiveStatus";

            using (var cn = new SqlConnection { ConnectionString = "Data Source=KARENS-PC;Initial Catalog=WorkingWithDataTips_1;Integrated Security=True" })
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
