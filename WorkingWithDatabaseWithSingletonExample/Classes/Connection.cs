using System.Data;
using System.Data.SqlClient;

namespace WorkingWithDatabaseWithSingletonExample.Classes
{
    /// <summary>
    /// Central connection for entire project.
    /// Unwise to keep a connection open any longer than necessary.
    /// </summary>
    public class Connection
    {

        public static Connection ObjConnection;
        private static readonly object _lockobject = new object();

        public static Connection GetInstance() 
        {
            lock (_lockobject)
            {
                if (ObjConnection == null)
                {
                    ObjConnection = new Connection();
                }

            }

            return ObjConnection;
        }

        private Connection() {}

        public static SqlConnection Connect()
        {
           
            var connectionString = Properties.Settings.Default.MainConnection;

            var cn = new SqlConnection(connectionString);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            else
            {
                cn.Close();
            }

            return cn;

        }
    }
}
