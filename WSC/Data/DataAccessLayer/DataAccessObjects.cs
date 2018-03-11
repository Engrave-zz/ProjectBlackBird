using System;
using DataAccessLayer.Extensions;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataAccessObjects
    {
        public DataAccessObjects() { }

        // USER ACCOUNTS
        public UserAccess GetUserAccountByUserName(string userName)
        {
            return UserAccessData.GetByUserName(userName);
        }

        public List<UserAccess> GetAllUserAccounts()
        {
            return UserAccessData.GetAll();
        }

        public int UpdateUserAccountByUserId(UserAccess user)
        {
            return UserAccessData.UpdateByUserId(user);
        }

        public int InsertUserAccess(UserAccess user)
        {
            return UserAccessData.Insert(user);
        }

        public int DeleteUserAccess(UserAccess user)
        {
            return UserAccessData.Delete(user);
        }

        public int DeleteUserAccess(string username)
        {
            return UserAccessData.Delete(username);
        }

        // NOTIFICATIONS
        public List<Notification> GetNotificationByNotificationId(Guid notificationId)
        {
            return NotificationData.GetByNotificationId(notificationId);
        }

        public List<Notification> GetNotificationByJobRoleAndIsRead(string permissionEnum, bool isRead)
        {
            return NotificationData.GetByJobRoleAndIsRead(permissionEnum, isRead);
        }

        public List<Notification> GetNotificationByJobRole(string permissionEnum)
        {
            return NotificationData.GetByJobRole(permissionEnum);
        }

        public int InsertNotification(Guid? notificationId, Guid orderId, string message, int notificationTypeId, bool isRead)
        {
            return NotificationData.Insert(notificationId, message, orderId, notificationTypeId, isRead);
        }

        public int InsertNotification(Guid? notificationId, Guid orderId, string message, int notificationTypeId)
        {
            return NotificationData.Insert(notificationId, message, orderId, notificationTypeId, false);
        }

        public int UpdateNotification(Notification notification)
        {
            return NotificationData.UpdateByNotificationId(notification);
        }

        public int DeleteNotification(Guid notificationId)
        {
            return NotificationData.DeleteNotification(notificationId);
        }

        // ORDERS
        public List<Order> GetOrderByOrderId(Guid orderId)
        {
            return OrderData.GetByOrderId(orderId);
        }

        public List<Order> GetOrderByLastName(string lastName)
        {
            return OrderData.GetOrderByLastName(lastName);
        }

        public List<Order> GetOrderByInventoryItemId(Guid inventoryItemId)
        {
            return OrderData.GetByInventoryItemId(inventoryItemId);
        }

        public List<Order> GetByOrderStatusId(int orderStatusId)
        {
            return OrderData.GetByOrderStatusId(orderStatusId);
        }

        public List<Order> GetOrders()
        {
            return OrderData.GetAll();
        }

        public int UpdateOrderStatus(Order order)
        {
            return OrderData.UpdateByOrderId(order);
        }

        public int InsertOrder(Order order)
        {
            return OrderData.InsertOrder(order);
        }


        // ORDER ITEMS
        public List<OrderItem> GetOrderItemByOrderItemId(Guid orderItemId)
        {
            return OrderItemData.GetByOrderItemId(orderItemId);
        }

        public List<OrderItem> GetOrderItemByOrderId(Guid orderId)
        {
            return OrderItemData.GetByOrderId(orderId);
        }

        // INVENTORY ITEMS
        public List<InventoryItem> GetInventoryItemByInventoryItemId(Guid inventoryItemId)
        {
            return InventoryItemData.GetByInventoryItemId(inventoryItemId);
        }

        public List<InventoryItem> GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(Guid inventoryItemId, int inventoryItemStatusId)
        {
            return InventoryItemData.GetByInventoryItemIdAndInventoryItemStatusId(inventoryItemId, inventoryItemStatusId);
        }

        public List<InventoryItem> GetInventoryItemByOrderId(Guid orderId, int inventoryItemStatusId)
        {
            return InventoryItemData.GetByOrderId(orderId, inventoryItemStatusId);
        }

        public List<InventoryItem> GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(Guid catalogItemId, int inventoryItemStatusId)
        {
            return InventoryItemData.GetByCatalogItemIdAndInventoryItemStatusId(catalogItemId, inventoryItemStatusId);
        }

        public List<InventoryItem> GetInventoryItemByCatalogItemId(Guid catalogItemId)
        {
            return InventoryItemData.GetByCatalogItemId(catalogItemId);
        }

        public List<InventoryItem> GetInventoryItemByManufacturer(string manufacturer, int inventoryItemStatusId)
        {
            return InventoryItemData.GetByManufacturer(manufacturer, inventoryItemStatusId);
        }

        public List<InventoryItem> GetInventoryItemByItemName(string inventoryItemName, int inventoryItemStatusId)
        {
            return InventoryItemData.GetByItemName(inventoryItemName, inventoryItemStatusId);
        }

        public int UpdateInventoryItem(InventoryItem item)
        {
            return InventoryItemData.UpdateByInventoryItemId(item);
        }

        public int DeleteInventoryItem(InventoryItem item)
        {
            return InventoryItemData.Delete(item);
        }

        // CATALOG ITEMS
        public int GetCatalogItemStockCount(Guid catalogItemId)
        {
            return CatalogItemData.GetNumberInStock(catalogItemId);
        }

        public CatalogItem GetCatalogItemByItemName(string itemName)
        {
            return CatalogItemData.GetByItemName(itemName);
        }

        public CatalogItem GetCatalogItemByCatalogItemId(Guid catalogItemId)
        {
            return CatalogItemData.GetByCatalogItemId(catalogItemId);
        }

        public List<CatalogItem> GetCatalogItemByManufacturer(string manufacturer)
        {
            return CatalogItemData.GetByManufacturer(manufacturer);
        }

        // PERSON, EMPLOYEE, CUSTOMER
        public Person GetPersonByPersonId(Guid personId)
        {
            return PersonData.GetByPersonId(personId);
        }

        public List<Customer> GetCustomerByPersonLastName(string personLastName)
        {
            return CustomerData.GetCustomerByPersonLastName(personLastName);
        }

        public List<Customer> GetCustomerByPersonFirstName(string personFirstName)
        {
            return CustomerData.GetCustomerByPersonFirstName(personFirstName);
        }

        public List<Customer> GetCustomerByPersonEmail(string personEmail)
        {
            return CustomerData.GetCustomerByPersonEmail(personEmail);
        }

        public List<Customer> GetCustomerByPersonPhone(string personPhone)
        {
            return CustomerData.GetCustomerByPersonPhone(personPhone);
        }

        public List<Customer> GetCustomerByCustomerId(Guid customerId)
        {
            return CustomerData.GetCustomerByCustomerId(customerId);
        }

        public Customer GetCustomerByPersonId(Guid personId)
        {
            return CustomerData.GetCustomerByPersonId(personId);
        }

        public int InsertPerson(Person person)
        {
            return PersonData.Insert(person);
        }

        public int InsertPersonFromCustomer(Guid personId, string firstName, string lastName, string phoneNumber, string emailAddress,
                                            int personTypeId)
        {
            return PersonData.Insert(personId, firstName, lastName, phoneNumber, emailAddress, personTypeId);
        }

        public int InsertCustomer(Guid customerId, Guid personId)
        {
            return CustomerData.InsertCustomer(customerId, personId);
        }

        public int UpdatePersonByPersonId(Person person)
        {
            return PersonData.UpdateByPersonId(person);
        }

        // ADDRESS
        public int InsertAddress(Guid addressId, Guid personId, int streetNumber, string streetName, string addressCity,
            string addressState, string addressZip, int addressTypeId)
        {
            return AddressData.InsertAddress(addressId, personId, streetNumber, streetName, addressCity, addressState,
                addressZip, addressTypeId);
        }

        public List<Address> GetAddressByPersonId(Guid personId)
        {
            return AddressData.GetAddressByPersonId(personId);
        }

        public int UpdateAddressByAddressId(Address address)
        {
            return AddressData.UpdateByAddressId(address);
        }
    }
}
