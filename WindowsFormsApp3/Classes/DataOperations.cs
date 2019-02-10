using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using BaseConnectionLibrary.ConnectionClasses;

namespace WindowsFormsApp3.Classes
{
    public class DataOperations : AccessConnection
    {
        public DataOperations()
        {
            DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb");
        }
        /// <summary>
        /// Provides a way for testing a data connection
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            mHasException = false;

            using (var cn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    cn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    mHasException = true;
                    mLastException = ex;
                }
            }

            return IsSuccessFul;

        }
        /// <summary>
        /// Load data from joined tables
        /// </summary>
        /// <returns></returns>
        public DataTable LoadCustomersPartialData() 
        {
            using (var cn = new OleDbConnection(ConnectionString))
            {
                using (var cmd = new OleDbCommand { Connection = cn })
                {
                    cmd.CommandText = 
                        "SELECT C.Identifier, C.CompanyName AS Company, C.ContactName AS Contact, CT.Title " + 
                        "FROM CustomersContactTitle AS CT " + 
                        "INNER JOIN Customers AS C ON CT.ContactTitleId = C.ContactTitleId " + 
                        "ORDER BY C.CompanyName;";


                    DataTable dt = new DataTable();


                    try
                    {
                        cn.Open();
                        dt.Load(cmd.ExecuteReader() ?? throw new InvalidOperationException());
                        dt.Columns["Identifier"].ColumnMapping = MappingType.Hidden;

                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }

                    return dt;

                }
            }
        }
    }
}
