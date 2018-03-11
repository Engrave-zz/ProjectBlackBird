using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertNotificationCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _orderId;
        private readonly SqlParameter _notificationId;
        private readonly SqlParameter _notificationMessage;
        private readonly SqlParameter _notificationTypeId;
        private readonly SqlParameter _isRead;

        public InsertNotificationCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertNotificationCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblNotification]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _orderId = CreateParameter("orderId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _notificationId = CreateParameter("notificationId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _notificationMessage = CreateParameter("notificationMessage", SqlDbType.VarChar, ParameterDirection.Input);
            _notificationTypeId = CreateParameter("notificationTypeId", SqlDbType.Int, ParameterDirection.Input);
            _isRead = CreateParameter("isRead", SqlDbType.Bit, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_orderId);
            sqlParameterCollection.Add(_notificationId);
            sqlParameterCollection.Add(_notificationMessage);
            sqlParameterCollection.Add(_notificationTypeId);
            sqlParameterCollection.Add(_isRead);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid OrderId
        {
            get { return (Guid)_orderId.Value; }
            set { _orderId.Value = value; }
        }

        public Guid NotificationId
        {
            get { return (Guid)_notificationId.Value; }
            set { _notificationId.Value = value; }
        }

        public string NotificationMessage
        {
            get { return (string)_notificationMessage.Value; }
            set { _notificationMessage.Value = value; }
        }

        public int NotificationTypeId
        {
            get { return (int)_notificationTypeId.Value; }
            set { _notificationTypeId.Value = value; }
        }

        public bool IsRead
        {
            get { return (bool)_isRead.Value; }
            set { _isRead.Value = value; }
        }
    }
}

