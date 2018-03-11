using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class InventoryItem
    {
        public Guid InventoryItemId { get; set; }
        public Guid CatalogItemId { get; set; }
        public Guid OrderId { get; set; }
        public int InventoryItemStatusId { get; set; }
    }
}
