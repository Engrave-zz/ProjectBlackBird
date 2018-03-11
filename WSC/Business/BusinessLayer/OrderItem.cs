// Date created 5/30/14
// Author: Adam Fike
// Description: This class represents an Order Item object.  An Order Item is a specific Inventory Item, which has been
// ordered by a customer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class OrderItem
    {
        // class variables, getters & setters
        private CatalogItem _catalogItem;
        public CatalogItem CatalogItem { get { return _catalogItem; } set { _catalogItem = value; } }

        private string _itemInscription;
        public string ItemInscription { get { return _itemInscription; } set { _itemInscription = value; } }

        private int _quantityOrdered;
        public int QuantityOrdered { get { return _quantityOrdered; } set { _quantityOrdered = value; } }

        private Guid _orderItemId;
        public Guid OrderItemId { get { return _orderItemId; } set { _orderItemId = value; } }

        private Guid _orderId;
        public Guid OrderId { get { return _orderId; } set { _orderId = value; } }

        // Order Item constructor - Null
        public OrderItem()
        {
            _orderItemId = Guid.NewGuid();
            _quantityOrdered = 0;
        }

        // constructor for NEW Order Item - This constructor creates a GUID for the new Order Item
        public OrderItem(CatalogItem catalogItem, string itemInscription, int quantityOrdered)     
        {
            _orderItemId = Guid.NewGuid();
            _catalogItem = catalogItem;
            _itemInscription = itemInscription;
            _quantityOrdered = quantityOrdered;
        }

        // constructor for loading an EXISTING Order Item - This constructor DOES NOT create a new GUID
        public OrderItem(Guid orderItemId, CatalogItem catalogItem, string itemInscription, int quantityOrdered)
        {
            _orderItemId = orderItemId;
            _catalogItem = catalogItem;
            _itemInscription = itemInscription;
            _quantityOrdered = quantityOrdered;
        }

        // My equivalent of a ToString method.  This will return a string list with each string in the list
        // containing one of the inventory item's attributes, to be used to display an inventory item into 
        // a textbox, etc.
        public List<string> ToItemDescription()
        {
            List<string> itemDescription = new List<string>();
            itemDescription.Add("Name: " + CatalogItem.ItemName);
            itemDescription.Add("Vendor: " + CatalogItem.Manufacturer);
            itemDescription.Add("Price: " + CatalogItem.ItemRetailPrice.ToString("C"));
            itemDescription.Add("Inscription Type: " + CatalogItem.InscriptionType.ToString());
            itemDescription.Add("Quantity: " + QuantityOrdered.ToString());

            return itemDescription;
        }
    }
}
