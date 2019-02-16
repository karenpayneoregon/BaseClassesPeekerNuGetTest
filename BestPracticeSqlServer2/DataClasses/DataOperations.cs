using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnectionsLibrary.ConnectionClass;

namespace BestPracticeSqlServer2.DataClasses
{
    public class DataOperations : SqlServerConnection
    {
        public DataOperations()
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "WorkingWithDataTips_1";
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
