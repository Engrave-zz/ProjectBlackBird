using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;
using BusinessLayer.Translators;
using System.Data.SqlTypes;

namespace BusinessLayer
{
    public class Order
    {
        // class variables, getters & setters
        internal Guid _orderId;
        public Guid OrderId { get { return _orderId; } set { _orderId = value; } }

        private DateTime _orderEntryDate;
        public DateTime OrderEntryDate { get { return _orderEntryDate; } set { _orderEntryDate = value; } }

        private DateTime? _orderFulfillDate;
        public DateTime? OrderFulfillDate { get { return _orderFulfillDate; } set { _orderFulfillDate = value; } }

        private List<OrderItem> _itemList;
        public List<OrderItem> ItemList { get { return _itemList; } set { _itemList = value; } }

        public int NumberOrderItems { get { return ItemList.Count(); } }

        internal OrderStatus _orderStatus;
        public OrderStatus OrderStatus { get { return _orderStatus; } set { _orderStatus = value; } }

        internal Person _person;
        public Person Person { get { return _person; } set { _person = value; } }

        public Order()
        {
            _orderId = Guid.NewGuid();
            _person = new Person();
            _orderEntryDate = DateTime.Today;
            _itemList = new List<OrderItem>();
        }

        // constructor for NEW Order - This constructor creates a GUID for the new order
        public Order(List<OrderItem> itemList)
        {
            _orderId = Guid.NewGuid();
            _orderEntryDate = DateTime.Today;
            _itemList = itemList;
            _person = new Person();
            _itemList = new List<OrderItem>();
        }

        // constructor for loading an EXISTING Order - This constructor DOES NOT create a new GUID, or order entry date.  All information is loaded
        // from the database.
        public Order(Guid orderId, DateTime orderEntryDate, List<OrderItem> itemList)
        {
            _orderId = orderId;            
            _orderEntryDate = DateTime.Today;
            _itemList = itemList;
            _person = new Person();
            _itemList = new List<OrderItem>();
        }

        public string DeleteOrder(Order order)
        {
            //Add code to delete order
            return "Order has been deleted";
        }

        
    }
}
