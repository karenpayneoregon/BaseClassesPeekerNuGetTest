using System;
using System.Data.OleDb;
using DataConnectionsLibrary.GeneralClasses;
using DataConnectionsLibrary.Interfaces;

namespace DataConnectionsLibrary.ConnectionClass
{
    public abstract class AccessConnection : BaseExceptionProperties, IConnection
    {
        private readonly OleDbConnectionStringBuilder _builder = 
            new OleDbConnectionStringBuilder { Provider = "Microsoft.ACE.OLEDB.12.0" };

        /// <summary>
        /// Database name and path
        /// </summary>
        protected string DefaultCatalog = "";
        public string ConnectionString
        {
            get
            {

                if (string.IsNullOrWhiteSpace(DefaultCatalog))
                {
                    throw new Exception("Database name and path not provided.");
                }

                _builder.DataSource = DefaultCatalog;

                return _builder.ConnectionString;

            }
        }
        /// <summary>
        /// Connection string with user name and password generated using the protection class
        /// ProtectedDataConnections.ConnectionProtection
        /// </summary>
        public string ConnectionStringWithPassword { get; set; }
    }
}
