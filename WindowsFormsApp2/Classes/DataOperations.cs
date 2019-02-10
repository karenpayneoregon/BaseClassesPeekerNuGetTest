using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Classes
{
    public class DataOperations
    {
        /// <summary>
        /// Replace with your SQL Server name
        /// </summary>
        private string Server = "KARENS-PC";
        /// <summary>
        /// Database in which data resides, see SQL_Script.sql
        /// </summary>
        private string Catalog = "WorkingWithDataTips_1";
        /// <summary>
        /// Connection string for connecting to the database
        /// </summary>
        private string ConnectionString;

        public DataOperations()
        {
            ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
        }
        /// <summary>
        /// Return active or inactive customers
        /// </summary>
        /// <param name="pStatus">Status of customers</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomersByStatus(bool pStatus = true)
        {

            var dt = new DataTable();

            var selectStatement =
                "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " +
                "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, " +
                "Country, JoinDate AS Joined " +
                "FROM dbo.Customers " +
                "WHERE ActiveStatus = @ActiveStatus";


            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = selectStatement;
                    cmd.Parameters.AddWithValue("@ActiveStatus", pStatus);

                    try
                    {

                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                        dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
            }

            return dt;
        }

        /// <summary>
        /// Return Customers by contact title
        /// </summary>
        /// <param name="pContactTitle">Contact title type</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomersByTitle(string pContactTitle = "Owner")
        {

            var dt = new DataTable();

            string selectStatement =
                "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " +
                "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, Country, " +
                "JoinDate AS Joined " +
                "FROM dbo.Customers " +
                "WHERE ContactTitle = @ContactTitle";

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {

                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = selectStatement;
                    cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle);

                    try
                    {

                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                        dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
            }

            return dt;

        }

    }
}
