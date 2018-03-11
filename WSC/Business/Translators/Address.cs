using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class Address
    {
        public static BusinessObject.Address ToBusinessObject(Entities.Address entity)
        {
            if (entity == null)
                return null;

            BusinessObject.Address businessObject = new BusinessObject.Address
            {
                AddressId = entity.AddressId,
                PersonId = entity.PersonId,
                StreetNumber = entity.StreetNumber,
                StreetName = entity.StreetName,
                AddressCity = entity.AddressCity,
                AddressState = entity.AddressState,
                AddressZip = entity.AddressZip,
                AddressType = (Enumeration.AddressType)entity.AddressTypeId
            };

            return businessObject;
        }

        public static Entities.Address ToEntity(BusinessObject.Address businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.Address entity = new Entities.Address
            {
                AddressId = businessObject.AddressId,
                PersonId = businessObject.PersonId,
                StreetNumber = businessObject.StreetNumber,
                StreetName = businessObject.StreetName,
                AddressCity = businessObject.AddressCity,
                AddressState = businessObject.AddressState,
                AddressZip = businessObject.AddressZip,
                AddressTypeId = (int)businessObject.AddressType
            };

            return entity;
        }

        public static List<BusinessObject.Address> ToBusinessObject(List<Entities.Address> entities)
        {
            if (entities == null)
                return null;

            Enumeration.AddressType addressType;

            List<BusinessObject.Address> businessObjectList = new List<BusinessObject.Address>();
            foreach (Entities.Address entity in entities)
            {
                addressType = (Enumeration.AddressType)entity.AddressTypeId;
                businessObjectList.Add(
                    new BusinessObject.Address(entity.AddressId, entity.PersonId, entity.StreetNumber, entity.StreetName,entity.AddressCity,
                        entity.AddressState, entity.AddressZip, addressType)
                    {
                        AddressId = entity.AddressId,
                        PersonId = entity.PersonId,
                        StreetNumber = entity.StreetNumber,
                        StreetName = entity.StreetName,
                        AddressCity = entity.AddressCity,
                        AddressState = entity.AddressState,
                        AddressZip = entity.AddressZip,
                        AddressType = addressType

                    });
            }
            return businessObjectList;
        }

        
    }
}
