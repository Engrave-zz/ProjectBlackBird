using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class OrderSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalOrderId;
        private readonly int _ordinalOrderEntryDate;
        private readonly int _ordinalOrderFulfillDate;
        private readonly int _ordinalOrderStatusId;
        private readonly int _ordinalPersonId;

        public OrderSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public OrderSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public OrderSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalOrderId = GetOrdinal("orderId");
            _ordinalOrderEntryDate = GetOrdinal("orderEntryDate");
            _ordinalOrderFulfillDate = GetOrdinal("orderFulfillDate");
            _ordinalOrderStatusId = GetOrdinal("orderStatusId");
            _ordinalPersonId = GetOrdinal("personId");
        }

        public Order Order
        {
            get 
            {
                Order order = new Order
                {
                    OrderId = GetGuid(_ordinalOrderId),
                    OrderEntryDate = GetDateTime(_ordinalOrderEntryDate),
                    OrderFulfillDate = GetNullableDateTime(_ordinalOrderFulfillDate),
                    OrderStatusId = GetInt32(_ordinalOrderStatusId),
                    PersonId = GetGuid(_ordinalPersonId)
                };

                return order;
            }
        }
    }
}

