using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Notification
    {
        public Guid OrderId { get; set; }
        public Guid NotificationId { get; set; }
        public string NotificationMessage { get; set; }
        public int NotificationTypeId { get; set; }
        public bool IsRead { get; set; }
    }
}
