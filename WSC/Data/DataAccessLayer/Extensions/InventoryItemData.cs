using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class InventoryItemData
    {
        public static List<InventoryItem> GetByOrderId(Guid orderId, int inventoryItemStatusId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByOrderIdCommand objectCommand = new GetInventoryItemByOrderIdCommand(objectConnection))
                {
                    objectCommand.OrderId = orderId;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByInventoryItemId(Guid inventoryItemId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByInventoryItemIdCommand objectCommand = new GetInventoryItemByInventoryItemIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByInventoryItemIdAndInventoryItemStatusId(Guid inventoryItemId, int inventoryItemStatusId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByInventoryItemIdAndInventoryItemStatusIdCommand objectCommand = new GetInventoryItemByInventoryItemIdAndInventoryItemStatusIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByItemName(string itemName, int inventoryItemStatusId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByItemNameCommand objectCommand = new GetInventoryItemByItemNameCommand(objectConnection))
                {
                    objectCommand.ItemName = itemName;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByCatalogItemId(Guid catalogItemId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByCatalogItemIdCommand objectCommand = new GetInventoryItemByCatalogItemIdCommand(objectConnection))
                {
                    objectCommand.CatalogItemId = catalogItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByCatalogItemIdAndInventoryItemStatusId(Guid catalogItemId, int inventoryItemStatusId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByCatalogItemIdAndInventoryItemStatusIdCommand objectCommand = new GetInventoryItemByCatalogItemIdAndInventoryItemStatusIdCommand(objectConnection))
                {
                    objectCommand.CatalogItemId = catalogItemId;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static List<InventoryItem> GetByManufacturer(string manufacturer, int inventoryItemStatusId)
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetInventoryItemByManufacturerCommand objectCommand = new GetInventoryItemByManufacturerCommand(objectConnection))
                {
                    objectCommand.Manufacturer = manufacturer;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return inventoryItemList;
                        }

                        using (InventoryItemSqlDataReader objectSqlDataReader = new InventoryItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                InventoryItem inventoryItem = objectSqlDataReader.InventoryItem;
                                inventoryItemList.Add(inventoryItem);
                            }
                        }
                    }
                }
            }
            return inventoryItemList;
        }

        public static int Insert(Guid? inventoryItemId, Guid catalogItemId, Guid? orderId, int inventoryItemStatusId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertInventoryItemCommand objectCommand = new InsertInventoryItemCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId ?? new Guid();
                    objectCommand.CatalogItemId = catalogItemId;
                    objectCommand.OrderId = orderId;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Delete(Guid inventoryItemId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (DeleteInventoryItemByInventoryItemIdCommand objectCommand = new DeleteInventoryItemByInventoryItemIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Delete(InventoryItem inventoryItem)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (DeleteInventoryItemByInventoryItemIdCommand objectCommand = new DeleteInventoryItemByInventoryItemIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItem.InventoryItemId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Insert(InventoryItem inventoryItem)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertInventoryItemCommand objectCommand = new InsertInventoryItemCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = (inventoryItem.InventoryItemId != Guid.Empty) ? inventoryItem.InventoryItemId : new Guid();
                    objectCommand.CatalogItemId = inventoryItem.CatalogItemId;
                    objectCommand.OrderId = inventoryItem.OrderId;
                    objectCommand.InventoryItemStatusId = inventoryItem.InventoryItemStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByInventoryItemId(Guid inventoryItemId, Guid catalogItemId, Guid? OrderId, int inventoryItemStatusId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateInventoryItemByInventoryItemIdCommand objectCommand = new UpdateInventoryItemByInventoryItemIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId;
                    objectCommand.CatalogItemId = catalogItemId;
                    objectCommand.OrderId = OrderId;
                    objectCommand.InventoryItemStatusId = inventoryItemStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }       

        public static int UpdateByInventoryItemId(InventoryItem inventoryItem)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateInventoryItemByInventoryItemIdCommand objectCommand = new UpdateInventoryItemByInventoryItemIdCommand(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItem.InventoryItemId;
                    objectCommand.OrderId = inventoryItem.OrderId;
                    objectCommand.CatalogItemId = inventoryItem.CatalogItemId;
                    objectCommand.InventoryItemStatusId = inventoryItem.InventoryItemStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }
    }
}
