using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;

namespace DataAccessLayer.Readers
{
    public class ObjectSqlDataReader : IDisposable
    {
        private bool _isDisposed;

        protected SqlDataReader SqlDataReader { get; set; }

        public ObjectSqlDataReader(ObjectCommand objectCommand)
        {
            SqlDataReader = objectCommand.ExecuteReader();
        }

        public ObjectSqlDataReader(SqlCommand sqlCommand)
        {
            SqlDataReader = sqlCommand.ExecuteReader();
        }

        public ObjectSqlDataReader(SqlDataReader sqlDataReader)
        {
            SqlDataReader = sqlDataReader;
        }

        ~ObjectSqlDataReader()
        {
            Dispose(false);
        }

        protected SqlDataReader DataReader
        {
            get { return SqlDataReader; }
        }

        public bool Read()
        {
            return SqlDataReader.Read();
        }

        protected int GetOrdinal(string name)
        {
            try
            {
                return SqlDataReader.GetOrdinal(name);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }
        protected int GetInt32(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? 0 : SqlDataReader.GetInt32(ordinal);
        }

        protected short GetInt16(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? (short)0 : SqlDataReader.GetInt16(ordinal);
        }

        protected decimal GetDecimal(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? 0 : SqlDataReader.GetDecimal(ordinal);
        }

        protected byte GetByte(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? byte.MinValue : SqlDataReader.GetByte(ordinal);
        }

        protected bool GetBoolean(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? false : SqlDataReader.GetBoolean(ordinal);
        }

        protected Guid GetGuid(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? Guid.Empty : SqlDataReader.GetGuid(ordinal);
        }

        protected string GetString(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : SqlDataReader.GetString(ordinal);
        }

        protected DateTime GetDateTime(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? DateTime.MinValue : SqlDataReader.GetDateTime(ordinal);
        }

        protected byte[] GetBytes(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : SqlDataReader.GetSqlBytes(ordinal).Value;
        }

        protected short? GetNullableInt16(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (short?)SqlDataReader.GetInt16(ordinal);
        }

        protected short? GetNullableInt32(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (short?)SqlDataReader.GetInt32(ordinal);
        }

        protected bool? GetNullableBoolean(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (bool?)SqlDataReader.GetBoolean(ordinal);
        }

        protected DateTime? GetNullableDateTime(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (DateTime?)SqlDataReader.GetDateTime(ordinal);
        }

        protected Guid? GetNullableGuid(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (Guid?)SqlDataReader.GetGuid(ordinal);
        }

        protected Decimal? GetNullableDecimal(int ordinal)
        {
            return (ordinal < 0 || SqlDataReader.IsDBNull(ordinal)) ? null : (Decimal?)SqlDataReader.GetDecimal(ordinal);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed || !isDisposing) return;

            DataReader.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
