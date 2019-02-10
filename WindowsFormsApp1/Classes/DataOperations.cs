using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using BaseConnectionLibrary.ConnectionClasses;
using DataProviderCommandHelpers;

namespace WindowsFormsApp1.Classes
{
    public class DataOperations : SqlServerConnection
    {
        /// <summary>
        /// Used to display or not to display SQL statements
        /// </summary>
        /// <returns></returns>
        public bool RevealCommand { get; set; }

        /// <summary>
        /// Setup connection and if command text should be shown
        /// </summary>
        /// <param name="pRevealCommand"></param>
        public DataOperations(bool pRevealCommand = false)
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "WorkingWithDataTips_1";
            RevealCommand = pRevealCommand;
        }
        /// <summary>
        /// Return active or inactive customers
        /// </summary>
        /// <param name="pStatus">Status of customers</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomersByStatus(bool pStatus = true)
        {

            var dt = new DataTable();

            mHasException = false;

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

                        if (RevealCommand)
                        {
                            Console.WriteLine($"SQL From {MethodBase.GetCurrentMethod()}");
                            Console.WriteLine(cmd.RevealCommandQuery());
                        }

                        dt.Load(cmd.ExecuteReader());
                        dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                    }
                    catch (Exception ex)
                    {

                        mHasException = true;
                        mLastException = ex;

                    }

                }
            }

            return dt;
        }
        /// <summary>
        /// Spy on a connection
        /// </summary>
        /// <param name="sender">SqlClient connection object</param>
        /// <param name="args"></param>
        private void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Return Customers by contact title
        /// </summary>
        /// <param name="pContactTitle">Contact title type</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomersByTitle(string pContactTitle = "Owner")
        {

            var dt = new DataTable();

            mHasException = false;

            var selectStatement = 
                "SELECT CustomerIdentifier, CompanyName AS Company, ContactName AS Contact, " + 
                "ContactTitle AS Title, StreetAddress AS Street,City, PostalCode AS Postal, Country, " + 
                "JoinDate AS Joined " + 
                "FROM dbo.Customers " + 
                "WHERE ContactTitle = @ContactTitle";

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {

                cn.InfoMessage += ConnectionInfoMessage;

                cn.FireInfoMessageEventOnUserErrors = true;

                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = selectStatement;
                    cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle);

                    try
                    {

                        if (RevealCommand)
                        {
                            Console.WriteLine($"SQL From {MethodBase.GetCurrentMethod()}");
                            Console.WriteLine(cmd.RevealCommandQuery());
                        }

                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                        dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;

                    }
                    catch (Exception ex)
                    {

                        mHasException = true;
                        mLastException = ex;

                    }

                }
            }

            return dt;

        }

    }
}