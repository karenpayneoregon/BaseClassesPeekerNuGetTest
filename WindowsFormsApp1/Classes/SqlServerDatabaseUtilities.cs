using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using BaseConnectionLibrary.ConnectionClasses;

namespace WindowsFormsApp1.Classes
{
    /// <summary>
    /// SQL-Server helper methods
    /// See the following MSDN article for information.
    /// https://code.msdn.microsoft.com/SQL-Server-check-if-server-1f53886f
    /// </summary>
    public class SqlServerDatabaseUtilities : SqlServerConnection
    {
        public string ServerName => DatabaseServer;
        /// <summary>
        /// DatabaseServer MUST be an available SQL-Server
        /// DefaultCatalog MUST be a database residing in DatabaseServer
        /// </summary>
        public SqlServerDatabaseUtilities()
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "WorkingWithDataTips_1";
        }
        /// <summary>
        /// Initialize with a specific server and database
        /// </summary>
        /// <param name="pDatabaseServer">Available SQL-Server</param>
        /// <param name="pDefaultCatalog">Database in pDatabaseServer</param>
        public SqlServerDatabaseUtilities(string pDatabaseServer, string pDefaultCatalog)
        {
            DatabaseServer = pDatabaseServer;
            DefaultCatalog = pDefaultCatalog;
        }

        /// <summary> 
        /// Determine if a specific database exists on a known server 
        /// </summary> 
        /// <param name="pServer">Server name</param> 
        /// <param name="pDatabase">Database name</param> 
        /// <returns></returns> 
        public bool DatabaseExists(string pServer, string pDatabase)
        {
            bool success = false;

            try
            {
                using (var cn = new SqlConnection { ConnectionString = ("Data Source=" + (DatabaseServer + ";Initial Catalog=master;Integrated Security=True;")) })
                {
                    using (var cmd = new SqlCommand { Connection = cn, CommandText = ("select * from master.dbo.sysdatabases where name='" + (DefaultCatalog + "'")) })
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        success = reader.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return success;

        }
        /// <summary> 
        /// Determine if a table exist 
        /// </summary> 
        /// <param name="pServer">An available server</param> 
        /// <param name="pDatabase">An existing database</param> 
        /// <param name="pTableName">Table name to check if exists or not</param> 
        /// <returns></returns> 
        public bool TableExists(string pServer, string pDatabase, string pTableName)
        {
            bool success = false;

            try
            {
                using (var cn = new SqlConnection { ConnectionString = ConnectionString }) 
                {
                    using (var cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES " + 
                                          $"WHERE TABLE_NAME='{pTableName}') SELECT 1 ELSE SELECT 0";

                        cn.Open();
                        var result = Convert.ToInt32(cmd.ExecuteScalar());

                        success = result == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return success;

        }
        /// <summary> 
        /// Get table names for a database that exists on an available SQL-Server 
        /// </summary> 
        /// <param name="pServer">Server name</param> 
        /// <param name="pDatabase">Database name</param> 
        /// <returns></returns> 
        public List<string> TableNames(string pServer, string pDatabase)
        {
            var tableNames = new List<string>();


            using (var cn = new SqlConnection { ConnectionString = ConnectionString }) 
            {
                using (var cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText =
                            @"SELECT s.name, o.name 
                              FROM sys.objects o WITH(NOLOCK) 
                              JOIN sys.schemas s WITH(NOLOCK) 
                              ON o.schema_id = s.schema_id 
                              WHERE o.is_ms_shipped = 0 AND RTRIM(o.type) = 'U' 
                              ORDER BY s.name ASC, o.name ASC";

                    cn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var tableName = reader.GetString(1);
                            if (!tableName.Contains("sysdiagrams"))
                            {
                                tableNames.Add(tableName);
                            }

                        }
                    }
                }
            }

            return tableNames;
        }
        /// <summary> 
        /// Determine if SQL-Server is available 
        /// </summary> 
        /// <returns></returns> 
        public async Task<bool> SqlServerIsAvailable()
        {
            bool success = false;

            try
            {
                await Task.Run(() =>
                {

                    var sqlDataSourceEnumeratorInstance = SqlDataSourceEnumerator.Instance;
                    DataTable dt = sqlDataSourceEnumeratorInstance.GetDataSources();

                    if (dt != null)
                    {
                        success = true;
                    }
                });
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return success;
        }
        /// <summary> 
        /// Determine if a specific SQL-Server is available 
        /// </summary> 
        /// <returns></returns> 
        public async Task<bool> SqlServerIsAvailableDefault() 
        {
            bool success = false;

            try
            {
                await Task.Run(() =>
                {
                    var sqlDataSourceEnumeratorInstance = SqlDataSourceEnumerator.Instance;
                    DataTable dt = sqlDataSourceEnumeratorInstance.GetDataSources();

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            var row = dt.AsEnumerable()
                                .FirstOrDefault(r => r.Field<string>("ServerName") == DatabaseServer.ToUpper());

                            success = row != null;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return success;
        }

        /// <summary>
        /// Determine if a specific service is running e.g.
        /// SQL-Server: MSSQLServer
        /// MSSQLSERVER
        /// SQL Server Agent: SQLServerAgent
        /// SQL Server Analysis Services: MSSQLServerOLAPService
        /// SQL Server Browser: SQLBrowser
        /// </summary>
        /// <param name="serviceName">Service name to find</param>
        /// <returns>True if found, false if not</returns>
        public static bool IsSqlServiceRunning(string serviceName)
        {
            var isRunning = false;
            var services = ServiceController.GetServices().Where(sc => sc.ServiceName.Contains("SQL")).ToList();

            foreach (var service in services)
            {
                if (service.ServiceName == serviceName)
                {
                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        isRunning = true;
                    }

                }
            }

            return isRunning;

        }
    }
}