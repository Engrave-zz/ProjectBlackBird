using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class OrderItemSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalOrderItemId;
        private readonly int _ordinalItemInscription;
        private readonly int _ordinalCatalogItemId;
        private readonly int _ordinalOrderId;
        private readonly int _ordinalQuantityOrdered;

        public OrderItemSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public OrderItemSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public OrderItemSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalOrderItemId = GetOrdinal("orderItemId");
            _ordinalItemInscription = GetOrdinal("itemInscription");
            _ordinalCatalogItemId = GetOrdinal("catalogItemId");
            _ordinalOrderId = GetOrdinal("orderId");
            _ordinalQuantityOrdered = GetOrdinal("quantityOrdered");
        }

        public OrderItem OrderItem
        {
            get 
            {
                OrderItem orderItem = new OrderItem
                {
                    OrderId = GetGuid(_ordinalOrderId),
                    OrderItemId = GetGuid(_ordinalOrderItemId),
                    CatalogItemId = GetGuid(_ordinalCatalogItemId),
                    ItemInscription = GetString(_ordinalItemInscription),
                    QuantityOrdered = GetInt16(_ordinalQuantityOrdered)
                };

                return orderItem;
            }
        }
    }
}

