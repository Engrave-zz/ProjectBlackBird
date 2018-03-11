using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer.Commands
{
    public class ObjectConnection : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private bool _isDisposed;

        private static string ConnectionString(string connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public ObjectConnection(string connectionStringName = "WSCConnectionString")
        {
            _sqlConnection = new SqlConnection(ConnectionString(connectionStringName));
        }

        public SqlConnection Connection
        {
            get { return _sqlConnection; }
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }

        public SqlCommand CreateCommand()
        {
            return Connection.CreateCommand();
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed || !isDisposing) return;

            _sqlConnection.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ObjectConnection()
        {
            Dispose(false);
        }
    }
}
