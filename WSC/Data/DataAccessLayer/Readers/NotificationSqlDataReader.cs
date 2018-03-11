using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class NotificationSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalNotificationId;
        private readonly int _ordinalOrderId;
        private readonly int _ordinalNotificationMessage;       
        private readonly int _ordinalNotificationTypeId;
        private readonly int _ordinalIsRead;

        public NotificationSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public NotificationSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public NotificationSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalNotificationId = GetOrdinal("notificationId");
            _ordinalOrderId = GetOrdinal("orderId");
            _ordinalNotificationMessage = GetOrdinal("notificationMessage");            
            _ordinalNotificationTypeId = GetOrdinal("notificationTypeId");
            _ordinalIsRead = GetOrdinal("isRead");
        }

        public Notification Notification
        {
            get 
            {
                Notification notification = new Notification
                {
                    NotificationId = GetGuid(_ordinalNotificationId),                    
                    OrderId = GetGuid(_ordinalOrderId),
                    NotificationMessage = GetString(_ordinalNotificationMessage),
                    NotificationTypeId = GetInt32(_ordinalNotificationTypeId),
                    IsRead = GetBoolean(_ordinalIsRead)
                };

                return notification;
            }
        }
    }
}

