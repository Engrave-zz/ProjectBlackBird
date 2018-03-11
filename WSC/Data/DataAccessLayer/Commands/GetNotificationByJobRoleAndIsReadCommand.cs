using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetNotificationByJobRoleAndIsReadCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _permissionEnum;
        private readonly SqlParameter _isRead;

        public GetNotificationByJobRoleAndIsReadCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetNotificationByJobRoleAndIsReadCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblNotificationsByJobRoleAndIsRead]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _permissionEnum = CreateParameter("permissionEnum", SqlDbType.VarChar, ParameterDirection.Input);
            _isRead = CreateParameter("isRead", SqlDbType.Bit, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_permissionEnum);
            sqlParameterCollection.Add(_isRead);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public string PermissionEnum
        {
            get { return (string)_permissionEnum.Value; }
            set { _permissionEnum.Value = value; }
        }

        public bool IsRead
        {
            get { return (bool)_isRead.Value; }
            set { _isRead.Value = value; }
        }
    }
}

