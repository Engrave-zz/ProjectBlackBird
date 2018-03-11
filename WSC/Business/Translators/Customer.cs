using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class Customer
    {
        public static BusinessObject.Customer ToBusinessObject(Entities.Customer entity)
        {
            if (entity == null)
                return null;

            BusinessObject.Customer businessObject = new BusinessObject.Customer
            {
                CustomerId = entity.CustomerId,
                PersonId = entity.PersonId 
            };

            return businessObject;
        }

        public static Entities.Customer ToEntity(BusinessObject.Customer businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.Customer entity = new Entities.Customer
            {
                CustomerId = businessObject.CustomerId,
                PersonId = businessObject.PersonId
            };

            return entity;
        }

        public static List<BusinessObject.Customer> ToBusinessObject(List<Entities.Customer> entities)
        {
            if (entities == null)
                return null;

            List<BusinessObject.Customer> businessObjectList = new List<BusinessObject.Customer>();
            foreach (Entities.Customer entity in entities)
            {
                businessObjectList.Add(
                    new BusinessObject.Customer(entity.PersonId, entity.CustomerId)
                    {
                        PersonId = entity.PersonId,
                        CustomerId = entity.CustomerId,

                    });
            }
            return businessObjectList;
        }
    }
}
