using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public DateTime? OrderFulfillDate { get; set; }
        public int OrderStatusId { get; set; }
        public Guid PersonId { get; set; }
    }
}
