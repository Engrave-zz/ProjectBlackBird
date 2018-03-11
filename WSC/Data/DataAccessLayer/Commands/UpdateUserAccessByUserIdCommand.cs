using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class UpdateUserAccessByUserIdCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _userId;
        private readonly SqlParameter _userName;
        private readonly SqlParameter _userPassword;
        private readonly SqlParameter _permissionToken;
        private readonly SqlParameter _personId;

        public UpdateUserAccessByUserIdCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public UpdateUserAccessByUserIdCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spUpdatetblUserAccessByUserId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _userId = CreateParameter("userId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _userName = CreateParameter("userName", SqlDbType.VarChar, ParameterDirection.Input);
            _userPassword = CreateParameter("userPassword", SqlDbType.VarChar, ParameterDirection.Input);
            _permissionToken = CreateParameter("permissionToken", SqlDbType.Int, ParameterDirection.Input);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_userId);
            sqlParameterCollection.Add(_userName);
            sqlParameterCollection.Add(_userPassword);
            sqlParameterCollection.Add(_permissionToken);
            sqlParameterCollection.Add(_personId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid UserId
        {
            get { return (Guid)_userId.Value; }
            set { _userId.Value = value; }
        }

        public string UserName
        {
            get { return (string)_userName.Value; }
            set { _userName.Value = value; }
        }

        public string UserPassword
        {
            get { return (string)_userPassword.Value; }
            set { _userPassword.Value = value; }
        }

        public int PermissionToken
        {
            get { return (int)_permissionToken.Value; }
            set { _permissionToken.Value = value; }
        }

        public Guid PersonId
        {
            get { return (Guid)_personId.Value; }
            set { _personId.Value = value; }
        }
    }
}
