using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class NotificationData
    {
        public static List<Notification> GetByNotificationId(Guid notificationId)
        {
            List<Notification> notificationList = new List<Notification>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetNotificationByNotificationIdCommand objectCommand = new GetNotificationByNotificationIdCommand(objectConnection))
                {
                    objectCommand.NotificationId = notificationId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return notificationList;
                        }

                        using (NotificationSqlDataReader objectSqlDataReader = new NotificationSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Notification notification = objectSqlDataReader.Notification;
                                notificationList.Add(notification);
                            }
                        }
                    }
                }
            }
            return notificationList;
        }

        public static int UpdateByNotificationId(Notification notification)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateNotificationByNotificationIdCommand objectCommand = new UpdateNotificationByNotificationIdCommand(objectConnection))
                {
                    objectCommand.NotificationId = notification.NotificationId;
                    objectCommand.OrderId = notification.OrderId;
                    objectCommand.NotificationMessage = notification.NotificationMessage;
                    objectCommand.NotificationTypeId = notification.NotificationTypeId;
                    objectCommand.IsRead = notification.IsRead;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static List<Notification> GetByJobRoleAndIsRead(string permissionEnum, bool isRead)
        {
            List<Notification> notificationList = new List<Notification>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetNotificationByJobRoleAndIsReadCommand objectCommand = new GetNotificationByJobRoleAndIsReadCommand(objectConnection))
                {
                    objectCommand.PermissionEnum = permissionEnum;
                    objectCommand.IsRead = isRead;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return notificationList;
                        }

                        using (NotificationSqlDataReader objectSqlDataReader = new NotificationSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Notification notification = objectSqlDataReader.Notification;
                                notificationList.Add(notification);
                            }
                        }
                    }
                }
            }

            return notificationList;
        }

        public static List<Notification> GetByJobRole(string permissionEnum)
        {
            List<Notification> notificationList = new List<Notification>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetNotificationByJobRoleCommand objectCommand = new GetNotificationByJobRoleCommand(objectConnection))
                {
                    objectCommand.PermissionEnum = permissionEnum;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return notificationList;
                        }

                        using (NotificationSqlDataReader objectSqlDataReader = new NotificationSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Notification notification = objectSqlDataReader.Notification;
                                notificationList.Add(notification);
                            }
                        }
                    }
                }
            }

            return notificationList;
        }

        public static int Insert(Guid? notificationId, string notificationMessage, Guid orderId, int notificationTypeId, bool isRead)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertNotificationCommand objectCommand = new InsertNotificationCommand(objectConnection))
                {
                    objectCommand.NotificationId = notificationId ?? Guid.NewGuid();
                    objectCommand.NotificationMessage = notificationMessage;
                    objectCommand.OrderId = orderId;
                    objectCommand.NotificationTypeId = notificationTypeId;
                    objectCommand.IsRead = isRead;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Insert(Notification notification)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertNotificationCommand objectCommand = new InsertNotificationCommand(objectConnection))
                {
                    objectCommand.NotificationId = notification.NotificationId;
                    objectCommand.NotificationMessage = notification.NotificationMessage;
                    objectCommand.OrderId = notification.OrderId;
                    objectCommand.NotificationTypeId = notification.NotificationTypeId;
                    objectCommand.IsRead = notification.IsRead;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int DeleteNotification(Guid notificationId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (DeleteNotificationByNotificationIdCommand objectCommand = new DeleteNotificationByNotificationIdCommand(objectConnection))
                {
                    objectCommand.NotificationId = notificationId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }
    }
}
