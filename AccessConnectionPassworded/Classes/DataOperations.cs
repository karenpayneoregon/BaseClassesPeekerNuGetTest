using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using BaseConnectionLibrary.ConnectionClasses;
using ProtectedDataConnections;

namespace AccessConnectionPassworded.Classes
{
    public class DataOperations : AccessConnection
    {
        private ConnectionProtection connectionProtection = new ConnectionProtection(Application.ExecutablePath);
        public DataOperations()
        {
            if (!connectionProtection.IsProtected())
            {
                connectionProtection.EncryptFile();
            }

            connectionProtection.DecryptFile();
            ConnectionStringWithPassword = AccessConnectionPassworded.Properties.Settings.Default.ConnectionString;
            connectionProtection.EncryptFile();
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
            using (var cn = new OleDbConnection(ConnectionStringWithPassword))
            {
                using (var cmd = new OleDbCommand { Connection = cn })
                {
                    cmd.CommandText =
                        "SELECT Identifier, CompanyName, ContactName, ContactTitle FROM Customers;";


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
