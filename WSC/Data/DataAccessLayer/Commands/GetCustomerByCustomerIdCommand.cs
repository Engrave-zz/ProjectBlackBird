using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetCustomerByCustomerIdCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _customerId;

        public GetCustomerByCustomerIdCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetCustomerByCustomerIdCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblCustomerByCustomerId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _customerId = CreateParameter("customerId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_customerId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid CustomerId
        {
            get { return (Guid)_customerId.Value; }
            set { _customerId.Value = value; }
        }
    }
}
