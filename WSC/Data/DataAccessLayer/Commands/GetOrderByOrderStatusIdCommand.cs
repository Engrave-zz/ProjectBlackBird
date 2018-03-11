using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetOrderByOrderStatusId : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _orderStatusId;

        public GetOrderByOrderStatusId(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetOrderByOrderStatusId(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblOrderByOrderStatusId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _orderStatusId = CreateParameter("orderStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_orderStatusId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public int OrderStatusId
        {
            get { return (int)_orderStatusId.Value; }
            set { _orderStatusId.Value = value; }
        }
    }
}
