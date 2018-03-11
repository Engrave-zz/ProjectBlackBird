using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public string ItemInscription { get; set; }
        public Guid CatalogItemId { get; set; }
        public int QuantityOrdered { get; set; }
        public Guid OrderId { get; set; }
    }
}
