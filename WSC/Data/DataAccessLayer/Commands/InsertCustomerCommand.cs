using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertCustomerCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _customerId;
        private readonly SqlParameter _personId;

  

        public InsertCustomerCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertCustomerCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblCustomer]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _customerId = CreateParameter("customerId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);


            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_customerId);
            sqlParameterCollection.Add(_personId);

     
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
        
        public Guid PersonId
        {
            get { return (Guid)_personId.Value; }
            set { _personId.Value = value; }
        }
    }
}

