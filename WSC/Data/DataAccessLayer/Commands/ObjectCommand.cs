using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class ObjectCommand : IDisposable
    {
        private readonly SqlCommand _sqlCommand;
        private bool _isDisposed;

        public ObjectCommand(SqlConnection sqlConnection)
            : this(sqlConnection.CreateCommand())
        {
        }

        public ObjectCommand(SqlCommand sqlCommand)
        {
            _sqlCommand = sqlCommand;
        }

        ~ObjectCommand()
        {
            Dispose(false);
        }

        public SqlCommand Command
        {
            get { return _sqlCommand; }
        }

        public SqlDataReader ExecuteReader()
        {
            return Command.ExecuteReader();
        }

        public void ExecuteNonQuery()
        {
            Command.ExecuteNonQuery();
        }

        public SqlParameter CreateParameter(string name, SqlDbType sqlDbType, ParameterDirection direction)
        {
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = name;
            param.SqlDbType = sqlDbType;
            param.Direction = direction;

            return param;
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed || !isDisposing) return;

            Command.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
