using System;
using BusinessLayer.Enumerations;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Notification
    {
        public Notification()
        {
        }                
        public Guid NotificationId { get; set; }
        public Guid OrderId { get; set; }
        public string NotificationMessage { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public Permission PermissionScope { get; set; }

        public List<string> ToNotificationDescription()
        {
            //BusinessObjects _businessObject = new BusinessObjects();              
            //InventoryItem inventoryItem = _businessObject.get
            List<string> notificationDescription = new List<string>();
            notificationDescription.Add("Order ID: " + OrderId.ToString());
            notificationDescription.Add("Notification ID: " + NotificationId.ToString());
            notificationDescription.Add("Message: " + NotificationMessage.ToString());            
            return notificationDescription;
        }
    }
}
