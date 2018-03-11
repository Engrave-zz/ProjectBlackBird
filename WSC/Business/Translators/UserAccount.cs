using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class UserAccount
    {
        public static Entities.UserAccess ToEntity(BusinessObject.UserAccount businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.UserAccess entity = new Entities.UserAccess
            {
                UserId = businessObject.UserAccountId,
                PersonId = businessObject.PersonId,
                UserName = businessObject.UserName,
                UserPassword = businessObject.PasswordHash,
                PermissionToken = businessObject.PermissionSet.Token
            };

            return entity;
        }

        public static List<BusinessObject.UserAccount> ToBusinessObject(List<Entities.UserAccess> entities)
        {
            if ((entities == null) || (entities.Count == 0))
                return null;

            List<BusinessObject.UserAccount> businessObjectCollection = new List<BusinessObject.UserAccount>();
            foreach(Entities.UserAccess entity in entities)
            {
                businessObjectCollection.Add(ToBusinessObject(entity));
            }
            return businessObjectCollection;
        }

        public static BusinessObject.UserAccount ToBusinessObject(Entities.UserAccess entity)
        {
            if (entity == null)
                return null;

            BusinessObject.UserAccount businessObject = new BusinessObject.UserAccount(
                entity.UserId,
                entity.PersonId,
                entity.UserName,
                entity.UserPassword,
                new PermissionSet(entity.PermissionToken), 
                true);

            return businessObject;
        }
    }
}
