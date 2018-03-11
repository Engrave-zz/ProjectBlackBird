using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetPersonByPersonIdCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _personId;

        public GetPersonByPersonIdCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetPersonByPersonIdCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblPersonByPersonId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_personId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid PersonId
        {
            get { return (Guid)_personId.Value; }
            set { _personId.Value = value; }
        }
    }
}
