using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class CatalogItemData
    {
        //Special code for singe record return only. Do not copy and paste for typical queries.
        public static int GetNumberInStock(Guid catalogItemId)
        {
            int numberInStock = 0;

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCatalogItemStockCountCommand objectCommand = new GetCatalogItemStockCountCommand(objectConnection))
                {
                    objectCommand.CatalogItemId = catalogItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return numberInStock;
                        }

                        using (CatalogItemStockCountSqlDataReader objectSqlDataReader = new CatalogItemStockCountSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                numberInStock = objectSqlDataReader.NumberInStock;
                            }
                        }
                    }
                }
            }

            return numberInStock;
        }

        public static CatalogItem GetByItemName(string itemName)
        {
            CatalogItem catalogItem = new CatalogItem();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCatalogItemByItemNameCommand objectCommand = new GetCatalogItemByItemNameCommand(objectConnection))
                {
                    objectCommand.ItemName = itemName;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return catalogItem;
                        }

                        using (CatalogItemSqlDataReader objectSqlDataReader = new CatalogItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                catalogItem = objectSqlDataReader.CatalogItem;
                            }
                        }
                    }
                }
            }

            return catalogItem;
        }

        public static List<CatalogItem> GetByManufacturer(string manufacturer)
        {
            List<CatalogItem> catalogItemList = new List<CatalogItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCatalogItemByManufacturerCommand objectCommand = new GetCatalogItemByManufacturerCommand(objectConnection))
                {
                    objectCommand.Manufacturer = manufacturer;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return catalogItemList;
                        }

                        using (CatalogItemSqlDataReader objectSqlDataReader = new CatalogItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                catalogItemList.Add(objectSqlDataReader.CatalogItem);
                            }
                        }
                    }
                }
            }

            return catalogItemList;
        }

        public static CatalogItem GetByCatalogItemId(Guid catalogItemId)
        {
            CatalogItem catalogItem = new CatalogItem();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCatalogItemByCatalogItemIdCommand objectCommand = new GetCatalogItemByCatalogItemIdCommand(objectConnection))
                {
                    objectCommand.CatalogItemId = catalogItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return catalogItem;
                        }

                        using (CatalogItemSqlDataReader objectSqlDataReader = new CatalogItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                catalogItem = objectSqlDataReader.CatalogItem;
                            }
                        }
                    }
                }
            }

            return catalogItem;
        }
    }
}
