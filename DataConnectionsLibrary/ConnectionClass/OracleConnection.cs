using System;
using DataConnectionsLibrary.GeneralClasses;
using DataConnectionsLibrary.Interfaces;

namespace DataConnectionsLibrary.ConnectionClass
{
    public abstract class OracleConnection : BaseExceptionProperties, IConnection
    {
        public bool UseTNS { get; set; }
        public string DataServer { get; set; }
        public string Host { get; set; }
        private int _Port = 1521;
        public int Port
        {
            get => _Port;
            set => _Port = value;
        }
        public string ServiceName { get; set; }

        /// <summary> 
        /// Defaults to true 
        /// </summary> 
        /// <returns></returns> 
        private bool _PersistSecurityInfo = true;
        public bool PersistSecurityInfo
        {
            get => _PersistSecurityInfo;
            set => _PersistSecurityInfo = value;
        }
        /// <summary> 
        /// Defaults to false 
        /// </summary> 
        /// <returns></returns> 
        public bool Enlist { get; set; }
        /// <summary> 
        /// Defaults to 10 
        /// </summary> 
        /// <returns></returns> 
        private int _StatementCacheSize = 10;
        public int StatementCacheSize
        {
            get => _StatementCacheSize;
            set => _StatementCacheSize = value;
        }
        private bool _Pooling = true;
        public bool Pooling
        {
            get => _Pooling;
            set => _Pooling = value;
        }

        /// <summary> 
        /// Defaults to 15 
        /// </summary> 
        /// <returns></returns> 
        private int _ConnectionTimeout = 15;
        public int ConnectionTimeout
        {
            get => _ConnectionTimeout;
            set => _ConnectionTimeout = value;
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        /// <summary> 
        /// Compose connection string from properties above. 
        /// </summary> 
        /// <returns></returns> 
        private string ComposeConnectionString()
        {

            var template = "";

            if (UseTNS)
            {

                template = $"Data Source={DataServer};Persist Security Info={PersistSecurityInfo};" +
                           $"Enlist={Enlist};Pooling={Pooling};Statement Cache Size={StatementCacheSize};";

                if (string.IsNullOrWhiteSpace(UserId))
                {
                    return template;
                }

                if (!(string.IsNullOrWhiteSpace(Password)))
                {
                    template = template + $"User ID={UserId};Password={Password};";
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return template;

        }

        public string ConnectionString =>
            ComposeConnectionString();
    }
}
