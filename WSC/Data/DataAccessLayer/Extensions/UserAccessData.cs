using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class UserAccessData
    {
        public static List<UserAccess> GetAll()
        {
            List<UserAccess> userAccessList = new List<UserAccess>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetUserAccessCommand objectCommand = new GetUserAccessCommand(objectConnection))
                {
                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return userAccessList;
                        }

                        using (UserAccessSqlDataReader objectSqlDataReader = new UserAccessSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                UserAccess userAccess = objectSqlDataReader.UserAccess;
                                userAccessList.Add(userAccess);
                            }
                        }
                    }
                }
            }

            return userAccessList;
        }

        public static UserAccess GetByUserName(string userName)
        {
            UserAccess userAccess = new UserAccess();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetUserAccessByUserNameCommand objectCommand = new GetUserAccessByUserNameCommand(objectConnection))
                {
                    objectCommand.UserName = userName;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return null;
                        }

                        using (UserAccessSqlDataReader objectSqlDataReader = new UserAccessSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                userAccess = objectSqlDataReader.UserAccess;
                            }
                        }
                    }
                }
            }

            return userAccess;
        }

        public static int Insert(Guid? userId, string userName, string userPassword, 
            int permissionToken, Guid personId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertUserAccessCommand objectCommand = new InsertUserAccessCommand(objectConnection))
                {
                    objectCommand.UserId = userId ?? new Guid();
                    objectCommand.UserName = userName;
                    objectCommand.UserPassword = userPassword;
                    objectCommand.PermissionToken = permissionToken;
                    objectCommand.PersonId = personId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Insert(UserAccess userAccess)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertUserAccessCommand objectCommand = new InsertUserAccessCommand(objectConnection))
                {
                    objectCommand.UserId = userAccess.UserId;
                    objectCommand.UserName = userAccess.UserName;
                    objectCommand.UserPassword = userAccess.UserPassword;
                    objectCommand.PermissionToken = userAccess.PermissionToken;
                    objectCommand.PersonId = userAccess.PersonId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByUserId(UserAccess userAccess)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateUserAccessByUserIdCommand objectCommand = new UpdateUserAccessByUserIdCommand(objectConnection))
                {
                    objectCommand.UserId = userAccess.UserId;
                    objectCommand.UserName = userAccess.UserName;
                    objectCommand.UserPassword = userAccess.UserPassword;
                    objectCommand.PersonId = userAccess.PersonId;
                    objectCommand.PermissionToken = userAccess.PermissionToken;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByUserId(Guid userId, string userName, string userPassword, Guid personId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateUserAccessByUserIdCommand objectCommand = new UpdateUserAccessByUserIdCommand(objectConnection))
                {
                    objectCommand.UserId = userId;
                    objectCommand.UserName = userName;
                    objectCommand.UserPassword = userPassword;
                    objectCommand.PersonId = personId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Delete(string username)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (DeleteUserAccessByUsernameCommand objectCommand = new DeleteUserAccessByUsernameCommand(objectConnection))
                {
                    objectCommand.Username = username;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Delete(UserAccess user)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (DeleteUserAccessByUsernameCommand objectCommand = new DeleteUserAccessByUsernameCommand(objectConnection))
                {
                    objectCommand.Username = user.UserName;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }
    }
}
