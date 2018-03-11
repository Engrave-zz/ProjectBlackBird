using System;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;
using System.Collections.Generic;

namespace BusinessLayer.Translators
{
    public static class OrderItem
    {
        public static Entities.OrderItem ToEntity(BusinessObject.OrderItem businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.OrderItem entity = new Entities.OrderItem
            {
                CatalogItemId = businessObject.CatalogItem.CatalogItemId,
                ItemInscription = businessObject.ItemInscription,
                OrderId = businessObject.OrderId,
                OrderItemId = businessObject.OrderItemId,
                QuantityOrdered = businessObject.QuantityOrdered
            };

            return entity;
        }

        public static BusinessObject.OrderItem ToBusinessObject(Entities.OrderItem entity)
        {
            if (entity == null)
                return null;

            BusinessObject.OrderItem businessObject = new BusinessObject.OrderItem
            {
                CatalogItem = new BusinessObject.CatalogItem(entity.CatalogItemId),
                ItemInscription = entity.ItemInscription,
                OrderId = entity.OrderId,
                OrderItemId = entity.OrderItemId,
                QuantityOrdered = entity.QuantityOrdered
            };

            return businessObject;
        }

        public static List<BusinessObject.OrderItem> ToBusinessObject(List<Entities.OrderItem> entities)
        {
            if ((entities == null) || (entities.Count == 0))
                return null;

            List<BusinessObject.OrderItem> businessObjectCollection = new List<BusinessObject.OrderItem>();
            foreach (Entities.OrderItem entity in entities)
            {
                businessObjectCollection.Add(ToBusinessObject(entity));
            }
            return businessObjectCollection;
        }
    }
}
