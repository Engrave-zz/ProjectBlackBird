using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class UserAccessSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalUserId;
        private readonly int _ordinalUserName;
        private readonly int _ordinalUserPassword;
        private readonly int _ordinalPersonId;
        private readonly int _ordinalPermissionToken;

        public UserAccessSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public UserAccessSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public UserAccessSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalUserId = GetOrdinal("userId");
            _ordinalUserName = GetOrdinal("userName");
            _ordinalUserPassword = GetOrdinal("userPassword");
            _ordinalPersonId = GetOrdinal("personId");
            _ordinalPermissionToken = GetOrdinal("permissionToken");
        }

        public UserAccess UserAccess
        {
            get 
            {
                UserAccess userAccess = new UserAccess
                {
                    UserId = GetGuid(_ordinalUserId),
                    UserName = GetString(_ordinalUserName),
                    UserPassword = GetString(_ordinalUserPassword),
                    PersonId = GetGuid(_ordinalPersonId),
                    PermissionToken = GetInt32(_ordinalPermissionToken)
                };

                return userAccess;
            }
        }
    }
}
