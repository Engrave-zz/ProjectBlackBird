using System;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class Person
    {
        public static BusinessObject.Person ToBusinessObject(Entities.Person entity)
        {
            if (entity == null)
                return null;

            Enumeration.PersonType personType = (Enumeration.PersonType)entity.PersonTypeId;

            BusinessObject.Person businessObject = new BusinessObject.Person
            {
                EmailAddress = entity.PersonEmail,
                FirstName = entity.PersonFirstName,
                LastName = entity.PersonLastName,
                PersonId = entity.PersonId,
                PhoneNumber = entity.PersonPhone,
                PersonType = personType
            };

            return businessObject;
        }

        public static Entities.Person ToEntity(BusinessObject.Person businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.Person entity = new Entities.Person
            {
                PersonEmail = businessObject.EmailAddress,
                PersonFirstName = businessObject.FirstName,
                PersonLastName = businessObject.LastName,
                PersonId = businessObject.PersonId,
                PersonPhone = businessObject.PhoneNumber,
                PersonTypeId = (int)businessObject.PersonType
            };

            return entity;
        }
    }
}
