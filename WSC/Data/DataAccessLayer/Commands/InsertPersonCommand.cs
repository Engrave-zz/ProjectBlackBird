using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertPersonCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _personId;
        private readonly SqlParameter _personFirstName;
        private readonly SqlParameter _personLastName;
        private readonly SqlParameter _personPhone;
        private readonly SqlParameter _personEmail;
        private readonly SqlParameter _personTypeId;

        public InsertPersonCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertPersonCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblPerson]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _personFirstName = CreateParameter("personFirstName", SqlDbType.VarChar, ParameterDirection.Input);
            _personLastName = CreateParameter("personLastName", SqlDbType.VarChar, ParameterDirection.Input);
            _personPhone = CreateParameter("personPhone", SqlDbType.Char, ParameterDirection.Input);
            _personEmail = CreateParameter("personEmail", SqlDbType.VarChar, ParameterDirection.Input);
            _personTypeId = CreateParameter("personTypeId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_personId);
            sqlParameterCollection.Add(_personFirstName);
            sqlParameterCollection.Add(_personLastName);
            sqlParameterCollection.Add(_personPhone);
            sqlParameterCollection.Add(_personEmail);
            sqlParameterCollection.Add(_personTypeId);
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

        public string PersonFirstName
        {
            get { return (string)_personFirstName.Value; }
            set { _personFirstName.Value = value; }
        }

        public string PersonLastName
        {
            get { return (string)_personLastName.Value; }
            set { _personLastName.Value = value; }
        }

        public string PersonPhone
        {
            get { return (string)_personPhone.Value; }
            set { _personPhone.Value = value; }
        }

        public string PersonEmail
        {
            get { return (string)_personEmail.Value; }
            set { _personEmail.Value = value; }
        }

        public int PersonTypeId
        {
            get { return (int)_personTypeId.Value; }
            set { _personTypeId.Value = value; }
        }
    }
}

