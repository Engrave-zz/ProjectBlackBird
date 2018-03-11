using System;
using System.Collections.Generic;
using BusinessObject = BusinessLayer;
using Entities = DataAccessLayer.Entities;
using Enumeration = BusinessLayer.Enumerations;

namespace BusinessLayer.Translators
{
    public static class Order
    {
        public static Entities.Order ToEntity(BusinessObject.Order businessObject)
        {
            if (businessObject == null)
                return null;

            Entities.Order entity = new Entities.Order
            {
                OrderEntryDate = businessObject.OrderEntryDate,
                OrderFulfillDate = businessObject.OrderFulfillDate,
                OrderStatusId = (int)businessObject.OrderStatus,
                OrderId = businessObject.OrderId,
                PersonId = businessObject.Person.PersonId
            };

            return entity;
        }

        public static List<BusinessObject.Order> ToBusinessObject(List<Entities.Order> entityOrders)
        {
            List<BusinessObject.Order> objectOrders = new List<BusinessObject.Order>();
            
            foreach(Entities.Order eOrder in entityOrders)
            {
                objectOrders.Add(ToBusinessObject(eOrder));
            }

            return objectOrders;

        }
        
        public static BusinessObject.Order ToBusinessObject(Entities.Order entity)
        {
            if (entity == null)
                return null;

            BusinessObject.Order businessObject = new BusinessObject.Order
            {
                OrderEntryDate = entity.OrderEntryDate,
                OrderFulfillDate = entity.OrderFulfillDate,
                OrderId = entity.OrderId,
                OrderStatus = (Enumeration.OrderStatus)entity.OrderStatusId,
                Person = new BusinessObject.Person(entity.PersonId)
            };

            return businessObject;
        }

        public static Enumeration.OrderStatus ConvertStringToOrderStatus(string status)
        {
            Enumeration.OrderStatus orderStatus = new Enumeration.OrderStatus();

            orderStatus = Enumeration.OrderStatus.None;

            if ((status.ToLower() == "failed validation") || (status.ToLower() == "failedvalidation"))
            {
                orderStatus = Enumeration.OrderStatus.FailedValidation;
            }

            else if (status.ToLower() == "submitted")
            {
                orderStatus = Enumeration.OrderStatus.Submitted;
            }

            else if ((status.ToLower() == "work complete") || (status.ToLower() == "workcomplete"))
            {
                orderStatus = Enumeration.OrderStatus.WorkComplete;
            }

            else if (status.ToLower() == "delivered")
            {
                orderStatus = Enumeration.OrderStatus.WorkComplete;
            }

            else if ((status.ToLower() == "en route") || (status.ToLower() == "enroute"))
            {
                orderStatus = Enumeration.OrderStatus.EnRoute;
            }

            else if (status.ToLower() == "complete")
            {
                orderStatus = Enumeration.OrderStatus.Complete;
            }

            return orderStatus;

        }
    }
}
