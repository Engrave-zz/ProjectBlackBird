using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class InventoryItem
    {
        public static BusinessObject.InventoryItem ToBusinessObject(Entities.InventoryItem entity)
        {
            if (entity == null)
                return null;

            BusinessObject.InventoryItem businessObject = new BusinessObject.InventoryItem(entity.CatalogItemId)
            {
                InventoryItemId = entity.InventoryItemId,
                OrderId = entity.OrderId,
                InventoryItemStatus = (Enumeration.InventoryItemStatus)entity.InventoryItemStatusId
            };

            return businessObject;
        }

        public static BusinessObject.InventoryItem PopulateInventoryItemWithCatalogItemInfo(BusinessObject.InventoryItem inventoryItem
            , BusinessObject.CatalogItem catalogItem)
        {
            if ((inventoryItem == null) || (catalogItem == null))
                return null;

            inventoryItem.ItemName = catalogItem.ItemName;
            inventoryItem.Manufacturer = catalogItem.Manufacturer;
            inventoryItem.NumberInscriptionLines = catalogItem.NumberInscriptionLines;
            inventoryItem.NumberLineCharacters = catalogItem.NumberLineCharacters;
            inventoryItem.ItemCost = catalogItem.ItemCost;
            inventoryItem.ItemRetailPrice = catalogItem.ItemRetailPrice;
            inventoryItem.InscriptionType = catalogItem.InscriptionType;
            inventoryItem.UpdateNumberInStock();

            return inventoryItem;
        }

        public static List<BusinessObject.InventoryItem> PopulateInventoryItemWithCatalogItemInfo(List<BusinessObject.InventoryItem> inventoryItems
            , BusinessObject.CatalogItem catalogItem)
        {
            if ((inventoryItems == null) || (catalogItem == null))
                return null;

            List<BusinessObject.InventoryItem> items = new List<BusinessObject.InventoryItem>();
            foreach(BusinessObject.InventoryItem item in inventoryItems)
            {
                items.Add(PopulateInventoryItemWithCatalogItemInfo(item, catalogItem));
            }
            return items;
        }

        public static List<BusinessObject.InventoryItem> ToBusinessObject(List<Entities.InventoryItem> entities)
        {
            if (entities == null)
                return null;

            List<BusinessObject.InventoryItem> businessObjectList = new List<BusinessObject.InventoryItem>();
            foreach(Entities.InventoryItem entity in entities)
            {
                businessObjectList.Add(
                    new BusinessObject.InventoryItem(entity.CatalogItemId)
                    {
                        InventoryItemId = entity.InventoryItemId,
                        OrderId = entity.OrderId,
                        InventoryItemStatus = (Enumeration.InventoryItemStatus)entity.InventoryItemStatusId
                    });
            }
            return businessObjectList;
        }

        public static Entities.InventoryItem ToEntity(BusinessObject.InventoryItem businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.InventoryItem entity = new Entities.InventoryItem
            {
                InventoryItemId = businessObject.InventoryItemId,
                CatalogItemId = businessObject.CatalogItemId,
                OrderId = businessObject.OrderId,
                InventoryItemStatusId = (int)businessObject.InventoryItemStatus
            };

            return entity;
        }
    }
}
