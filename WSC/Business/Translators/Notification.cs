using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public class Notification
    {
        public static Entities.Notification ToEntity(BusinessObject.Notification businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.Notification entity = new Entities.Notification
            {
                OrderId = businessObject.OrderId,
                IsRead = businessObject.IsRead,
                NotificationId = businessObject.NotificationId,
                NotificationMessage = businessObject.NotificationMessage,
                NotificationTypeId = (int)businessObject.NotificationType
            };

            return entity;
        }

        public static BusinessObject.Notification ToBusinessObject(Entities.Notification entity)
        {
            if (entity == null)
                return null;

            BusinessObject.Notification businessObject = new BusinessObject.Notification
            {
                OrderId = entity.OrderId,
                IsRead = entity.IsRead,
                NotificationId = entity.NotificationId,
                NotificationMessage = entity.NotificationMessage,
                NotificationType = (Enumeration.NotificationType)entity.NotificationTypeId
            };

            return businessObject;
        }

        public static List<BusinessObject.Notification> ToBusinessObject(List<Entities.Notification> entities)
        {
            if (entities == null)
                return null;

            List<BusinessObject.Notification> notifications = new List<BusinessObject.Notification>();

            foreach (Entities.Notification notification in entities)
            {
                notifications.Add(ToBusinessObject(notification));
            }

            return notifications;
        }
    }
}
