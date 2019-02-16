using BestPracticeSqlServer1_library.GeneralClasses;
using BestPracticeSqlServer1_library.Interfaces;

namespace BestPracticeSqlServer1_library.ConnectionClass
{
    public abstract class SqlServerConnection : BaseExceptionProperties, IConnection
    {
        /// <summary>
        /// This points to your database server
        /// </summary>
        protected string DatabaseServer = "";
        /// <summary>
        /// Name of database containing required tables
        /// </summary>
        protected string DefaultCatalog = "";
        public string ConnectionString
        {
            get
            {
                return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security=True";
            }
        }
    }
}