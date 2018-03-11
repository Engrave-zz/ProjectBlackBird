using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class InventoryItemSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalInventoryItemId;
        private readonly int _ordinalCatalogItemId;
        private readonly int _ordinalOrderId;
        private readonly int _ordinalInventoryItemStatusId;

        public InventoryItemSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public InventoryItemSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public InventoryItemSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalInventoryItemId = GetOrdinal("inventoryItemId");
            _ordinalCatalogItemId = GetOrdinal("catalogItemId");
            _ordinalOrderId = GetOrdinal("orderId");
            _ordinalInventoryItemStatusId = GetOrdinal("inventoryItemStatusId");
        }

        public InventoryItem InventoryItem
        {
            get 
            {
                InventoryItem inventoryItem = new InventoryItem
                {
                    InventoryItemId = GetGuid(_ordinalInventoryItemId),
                    CatalogItemId = GetGuid(_ordinalCatalogItemId),
                    OrderId = GetGuid(_ordinalOrderId),
                    InventoryItemStatusId = GetInt32(_ordinalInventoryItemStatusId)
                };

                return inventoryItem;
            }
        }
    }
}

