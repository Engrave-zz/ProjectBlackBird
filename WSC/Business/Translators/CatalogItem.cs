using System;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;
using System.Collections.Generic;

namespace BusinessLayer.Translators
{
    public static class CatalogItem
    {
        public static BusinessObject.CatalogItem ToBusinessObject(Entities.CatalogItem entity)
        {
            if (entity == null)
                return null;

            BusinessObject.CatalogItem businessObject = new BusinessObject.CatalogItem(entity.CatalogItemId)
            {
                InscriptionType = (Enumeration.InscriptionType)entity.InscriptionTypeId,
                ItemCost = entity.ItemCost,
                Manufacturer = entity.Manufacturer,
                NumberInscriptionLines = entity.NumberInscriptionLines,
                NumberLineCharacters = entity.NumberLineCharacters,
                ItemName = entity.ItemName,
                ItemRetailPrice = entity.ItemRetailPrice
            };

            return businessObject;
        }

        public static List<BusinessObject.CatalogItem> ToBusinessObject(List<Entities.CatalogItem> entities)
        {
            if (entities == null)
                return null;

            List<BusinessObject.CatalogItem> businessObjectList = new List<BusinessObject.CatalogItem>();
            foreach(Entities.CatalogItem entity in entities)
            {
                businessObjectList.Add(Translators.CatalogItem.ToBusinessObject(entity));
            }
            return businessObjectList;
        }

        public static Entities.CatalogItem ToEntity(BusinessObject.CatalogItem businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.CatalogItem entity = new Entities.CatalogItem
            {
                InscriptionTypeId = (int)businessObject.InscriptionType,
                CatalogItemId = businessObject.CatalogItemId,
                ItemCost = businessObject.ItemCost,
                Manufacturer = businessObject.Manufacturer,
                NumberInscriptionLines = businessObject.NumberInscriptionLines,
                NumberLineCharacters = businessObject.NumberLineCharacters,
                ItemName = businessObject.ItemName,
                ItemRetailPrice = businessObject.ItemRetailPrice
            };

            return entity;
        }
    }
}
