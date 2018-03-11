using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetOrderByOrderId : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _orderId;

        public GetOrderByOrderId(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetOrderByOrderId(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblOrderByOrderId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _orderId = CreateParameter("orderId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_orderId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid OrderId
        {
            get { return (Guid)_orderId.Value; }
            set { _orderId.Value = value; }
        }
    }
}
