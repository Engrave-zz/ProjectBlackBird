using System;
using System.Transactions;
using System.Collections.Generic;
using DataAccessLayer.Extensions;
using Entities = DataAccessLayer.Entities;
using DataAccessLayer;
using Enumeration = BusinessLayer.Enumerations;
using Translators = BusinessLayer.Translators;
using System.Linq;

namespace BusinessLayer
{
    public class BusinessObjects
    {       
        private DataAccessObjects _dataAccessObjects = new DataAccessObjects();

        
        // USER & USER ACCOUNT methods
        public UserAccount GetUserAccountByUserName(string userName)
        {
            Entities.UserAccess userAccessData = _dataAccessObjects.GetUserAccountByUserName(userName);
            UserAccount userAccount = Translators.UserAccount.ToBusinessObject(userAccessData);

            return userAccount;
        }

        public int NewUserAccount(UserAccount user)
        {
            /* Return code values
             * 0 = success
             * 1 = data access failure
             * 2 = username already exists
             */ 
            int returnValue;

            //Validate username
            UserAccount existingUser = Translators.UserAccount.ToBusinessObject(
                _dataAccessObjects.GetUserAccountByUserName(user.UserName));
            //If exists already kick back.
            if(existingUser != null)
            {
                returnValue = 2;
                return returnValue;
            }

            //Build employee
            Person employee = new Person
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PersonId = user.PersonId,
                PhoneNumber = user.PhoneNumber
            };

            //Establish transaction
            using(TransactionScope transaction = new TransactionScope())
            {
                returnValue = _dataAccessObjects.InsertPerson(Translators.Person.ToEntity(employee));
                if (returnValue == 1)
                {
                    transaction.Complete();
                    return returnValue;
                }

                returnValue = _dataAccessObjects.InsertUserAccess(Translators.UserAccount.ToEntity(user));
                if (returnValue == 1)
                {
                    transaction.Complete();
                    return returnValue;
                }

                transaction.Complete();
            }

            return returnValue;
        }

        public List<UserAccount> GetAllUserAccounts()
        {
            List<UserAccount> users = Translators.UserAccount.ToBusinessObject(
                _dataAccessObjects.GetAllUserAccounts());

            return users;
        }

        public int UpdateUserAccountByUserId(UserAccount user)
        {
            return _dataAccessObjects.UpdateUserAccountByUserId(Translators.UserAccount.ToEntity(user));
        }

        public int DeleteUserAccount(UserAccount user)
        {
            return _dataAccessObjects.DeleteUserAccess(Translators.UserAccount.ToEntity(user));
        }

        public int DeleteUserAccount(string username)
        {
            return _dataAccessObjects.DeleteUserAccess(username);
        }

        public int UpdateUserAccountByUserId(Notification notification)
        {
            return _dataAccessObjects.UpdateNotification(Translators.Notification.ToEntity(notification));
        }


        // CATALOG ITEM methods
        public CatalogItem GetCatalogItemByCatalogItemId(Guid catalogItemId)
        {
            CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                _dataAccessObjects.GetCatalogItemByCatalogItemId(catalogItemId));
            
            return catalogItem;      
        }

        public List<CatalogItem> GetCatalogItemByManufacturer(string manufacturer)
        {
            List<CatalogItem> catalogItemList = Translators.CatalogItem.ToBusinessObject(
                _dataAccessObjects.GetCatalogItemByManufacturer(manufacturer));

            return catalogItemList;
        }

        public CatalogItem GetCatalogItemByItemName(string itemName)
        {
            CatalogItem catalogItemList = Translators.CatalogItem.ToBusinessObject(
                _dataAccessObjects.GetCatalogItemByItemName(itemName));

            return catalogItemList;
        }


        // INVENTORY ITEM methods
        public List<InventoryItem> GetInventoryItemByItemName(string itemName, int inventoryItemStatus)
        {           
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(_dataAccessObjects.GetInventoryItemByItemName(itemName, inventoryItemStatus));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;
        }

        public List<InventoryItem> GetInventoryItemByItemManufacturer(string manufacturer, int inventoryItemStatus)
        {
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(_dataAccessObjects.GetInventoryItemByManufacturer(manufacturer, inventoryItemStatus));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach(InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;
        }

        public List<InventoryItem> GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(Guid inventoryItemId, int inventoryItemStatus)
        {
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(
                _dataAccessObjects.GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(inventoryItemId, inventoryItemStatus));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;           
        }

        public List<InventoryItem> GetInventoryItemByOrderId(Guid orderId, int inventoryItemStatus)
        {
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(_dataAccessObjects.GetInventoryItemByOrderId(orderId, inventoryItemStatus));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;
        }

        public List<InventoryItem> GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(Guid catalogItemId, int inventoryItemStatus)
        {
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(
                _dataAccessObjects.GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(catalogItemId, inventoryItemStatus));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;   
        }

        public List<InventoryItem> GetInventoryItemByCatalogItemId(Guid catalogItemId)
        {
            List<InventoryItem> inventoryItemList = Translators.InventoryItem.ToBusinessObject(
                _dataAccessObjects.GetInventoryItemByCatalogItemId(catalogItemId));
            List<InventoryItem> inventoryItems = new List<InventoryItem>();

            foreach (InventoryItem inventoryItem in inventoryItemList)
            {
                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(inventoryItem.CatalogItemId));

                inventoryItems.Add(Translators.InventoryItem.PopulateInventoryItemWithCatalogItemInfo(inventoryItem, catalogItem));
            }
            return inventoryItems;
        }

        public int DeleteInventoryItems(List<InventoryItem> items)
        {
            int returnValue = 1;

            if (items == null || !items.Any())
                return 1;

            foreach (InventoryItem deletionItem in items)
            {
                returnValue = _dataAccessObjects.DeleteInventoryItem(Translators.InventoryItem.ToEntity(deletionItem));
                if (returnValue == 1)
                    break; //exit the loop if any of them fail.
            }

            return returnValue;
        }

        public int DeleteInventoryItem(InventoryItem item)
        {
            return _dataAccessObjects.DeleteInventoryItem(Translators.InventoryItem.ToEntity(item));
        }

        public int UpdateInventoryItem(InventoryItem item)
        {
            return _dataAccessObjects.UpdateInventoryItem(Translators.InventoryItem.ToEntity(item));
        }


        // NOTIFICATION methods
        public int DeleteNotification(Guid notificationId)
        {
            return _dataAccessObjects.DeleteNotification(notificationId); 
        }

        public int InsertNotification(Notification notification)
        {
            int returnValue = _dataAccessObjects.InsertNotification(notification.NotificationId, notification.OrderId,
                notification.NotificationMessage, (int)notification.NotificationType);

            return returnValue;
        }

        public List<Notification> CheckNewNotifications(UserAccount user, bool isRead)
        {
            List<Notification> notificationList =
                Translators.Notification.ToBusinessObject(
                    _dataAccessObjects.GetNotificationByJobRoleAndIsRead(
                        user.HighestPermission.ToString(), isRead));

            return notificationList;
        }

        public List<Notification> CheckAllNotifications(UserAccount user)
        {
            List<Notification> notificationList =
                Translators.Notification.ToBusinessObject(
                    _dataAccessObjects.GetNotificationByJobRole(
                        user.HighestPermission.ToString()));

            return notificationList;
        }

        public int UpdateNotification(Notification notification)
        {
            return _dataAccessObjects.UpdateNotification(Translators.Notification.ToEntity(notification));
        }

        
        // ORDER methods

        // Method takes a database order result and populates it with person & inventory item objects
        public List<Order> PopulateOrders(List<Order> orderList)
        {   // List to be used in the folowing loops
            List<Order> orders = orderList;

            foreach (Order order in orders)
            {   // Get a translated customer [data entity object] by searching ny personId
                Customer orderCustomer = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByPersonId(order.Person.PersonId));

                // Create a fully populated customer [business layer object], based on the partially populated [data entity object]
                Customer populatedCustomer = PopulateCustomer(orderCustomer);

                // Add fully populated person to order
                order.Person = populatedCustomer;

                // Search for order items that are associated with the order
                List<OrderItem> orderItems = Translators.OrderItem.ToBusinessObject(_dataAccessObjects.GetOrderItemByOrderId(order.OrderId));

                if (orderItems == null)
                    continue;

                foreach (OrderItem orderItem in orderItems)
                {   // Search for - and populate the catalog information for each inventory item
                    orderItem.CatalogItem = Translators.CatalogItem.ToBusinessObject(_dataAccessObjects.GetCatalogItemByCatalogItemId(orderItem.CatalogItem.CatalogItemId));
                }

                // add populated order item list to order
                order.ItemList = orderItems;
            }

            return orders;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            List<Entities.Order> orderEntities = _dataAccessObjects.GetOrders();
            if (orderEntities == null)
            {
                orders = new List<Order>();
            }
            else
            {
                foreach(Entities.Order orderEntity in orderEntities)
                {
                    //construct necessary information
                    Order order = new Order();
                    order = Translators.Order.ToBusinessObject(orderEntity);
                    order.Person = Translators.Person.ToBusinessObject(_dataAccessObjects.GetPersonByPersonId(order.Person.PersonId));
                    List<OrderItem> orderItems = Translators.OrderItem.ToBusinessObject(_dataAccessObjects.GetOrderItemByOrderId(order.OrderId));

                    if (orderItems != null)
                    {
                        for (int i = 0; i < orderItems.Count; i++)
                        {
                            orderItems[i].CatalogItem = Translators.CatalogItem.ToBusinessObject(
                                _dataAccessObjects.GetCatalogItemByCatalogItemId(orderItems[i].CatalogItem.CatalogItemId));
                        }
                        order.ItemList = orderItems;
                    }

                    //add to list
                    orders.Add(order);
                }
            }

            return orders;
        }

        /* Method will get a fully populated order, based on a supplied Order Status type, 
        complete with a customer object and a list of inventory item objects*/
        public List<Order> GetOrdersByOrderStatus(BusinessLayer.Enumerations.OrderStatus orderStatus)
        {
            // Translate partially populated order list into a business object list
            List<Order> orders = Translators.Order.ToBusinessObject(_dataAccessObjects.GetByOrderStatusId((int)orderStatus));

            // Send partially populated order list to become fully populated with [customer & address], [inventory item & catalog item]
            List<Order> orderList = PopulateOrders(orders);

            return orderList;
        }

        /* Method will get a fully populated order, based on a supplied inventory item ID, 
        complete with a customer object and a list of inventory item objects*/
        public List<Order> GetOrdersByInventoryItemId(Guid inventoryItemId)
        {
            // Translate partially populated order list into a business object list
            List<Order> orders = Translators.Order.ToBusinessObject(_dataAccessObjects.GetOrderByInventoryItemId(inventoryItemId));

            // Send partially populated order list to become fully populated with [customer & address], [inventory item & catalog item]
            List<Order> orderList = PopulateOrders(orders);

            return orderList;
        }

        /* Method will get a fully populated order, based on a supplied customer last name, 
        complete with a customer object and a list of inventory item objects*/
        public List<Order> GetOrdersByLastName(string lastName)
        {          
            // Translate partially populated order list into a business object list
            List<Order> orders = Translators.Order.ToBusinessObject(_dataAccessObjects.GetOrderByLastName(lastName));

            // Send partially populated order list to become fully populated with [customer & address], [inventory item & catalog item]
            List<Order> orderList = PopulateOrders(orders);

            return orderList;
        }



        public Order GetOrder(Guid orderId)
        {
            Entities.Order orderEntity = _dataAccessObjects.GetOrderByOrderId(orderId).FirstOrDefault();
            if(orderEntity == null)
            {
                //order not found
                return null;
            }

            List<Entities.OrderItem> orderItemEntityList = _dataAccessObjects.GetOrderItemByOrderId(orderEntity.OrderId);
            List<OrderItem> orderItemList = new List<OrderItem>();

            foreach(Entities.OrderItem orderItem in orderItemEntityList)
            {

                CatalogItem catalogItem = Translators.CatalogItem.ToBusinessObject(
                    _dataAccessObjects.GetCatalogItemByCatalogItemId(orderItem.CatalogItemId));

                orderItemList.Add(new OrderItem
                    {
                        ItemInscription = orderItem.ItemInscription,
                        CatalogItem = catalogItem,
                        OrderItemId = orderItem.OrderItemId,
                        QuantityOrdered = orderItem.QuantityOrdered
                    });
            }

            Person person = Translators.Person.ToBusinessObject(
                _dataAccessObjects.GetPersonByPersonId(orderEntity.PersonId));

            Order order = Translators.Order.ToBusinessObject(orderEntity);
            order.ItemList = orderItemList;
            order.Person = person;

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int returnValue = _dataAccessObjects.UpdateOrderStatus(Translators.Order.ToEntity(order));
            return returnValue; 
        }

        public int InsertOrder(Order order)
        {
            int returnValue = _dataAccessObjects.InsertOrder(Translators.Order.ToEntity(order));
            return returnValue;
        }


        // CUSTOMER & PERSON methods

        // Method takes a customer list and populates it with person and address data
        public List<Customer> PopulateCustomers(List<Customer> customerList)
        {
            List<Customer> customers = customerList;
            List<Customer> customerObjectList = new List<Customer>();

            foreach (Customer customer in customerList)
            {
                // Get person object that is associated with Customer object
                Person person = Translators.Person.ToBusinessObject(_dataAccessObjects.GetPersonByPersonId(customer.PersonId));
                // Get address objects that are associated with customer object
                List<Address> addressList = Translators.Address.ToBusinessObject(_dataAccessObjects.GetAddressByPersonId(customer.PersonId));

                customerObjectList.Add(PopulateCustomerWithPersonAndAddress(customer, person, addressList));
            }
            return customerObjectList;
        }

        // Method takes a customer list and populates it with person and address data
        public Customer PopulateCustomer(Customer customer)
        {
            Customer populatedCustomer = customer;

            // Get person object that is associated with Customer object
            Person person = Translators.Person.ToBusinessObject(_dataAccessObjects.GetPersonByPersonId(customer.PersonId));
            // Get address objects that are associated with customer object
            List<Address> addressList = Translators.Address.ToBusinessObject(_dataAccessObjects.GetAddressByPersonId(customer.PersonId));

            populatedCustomer = PopulateCustomerWithPersonAndAddress(customer, person, addressList);

            return populatedCustomer;
        }

        // Method accepts a customer database result and populates with person and address objects
        public static Customer PopulateCustomerWithPersonAndAddress(Customer customer,
            Person person, List<Address> addressList)
        {
            if ((customer == null) || (person == null))
                return null;

            customer.FirstName = person.FirstName;
            customer.LastName = person.LastName;
            customer.PhoneNumber = person.PhoneNumber;
            customer.EmailAddress = person.EmailAddress;
            customer.PersonType = person.PersonType;
            foreach (Address address in addressList)
            {
                if (address.AddressType == Enumeration.AddressType.Billing)
                {
                    customer.BillingAddress = address;
                }

                if (address.AddressType == Enumeration.AddressType.Mailing)
                {
                    customer.MailingAddress = address;
                }
            }
            return customer;
        }
        public int InsertCustomer(Customer customer)
        {
            int returnValue = _dataAccessObjects.InsertCustomer(customer.CustomerId, customer.PersonId);

            return returnValue;
        }

        public int InsertPersonFromCustomer(Customer customer)
        {
            int returnValue = _dataAccessObjects.InsertPersonFromCustomer(customer.PersonId, customer.FirstName,
                customer.LastName, customer.PhoneNumber, customer.EmailAddress, (int)customer.PersonType);

            return returnValue;
        }

        public int UpdatePersonFromCustomer(Customer customer)
        {
            Person person = new Person(customer.PersonId, customer.FirstName, customer.LastName, customer.PhoneNumber, customer.EmailAddress);
            person.PersonType = Enumeration.PersonType.Customer;
            return _dataAccessObjects.UpdatePersonByPersonId(Translators.Person.ToEntity(person));
        }

        // Method gets a list of customers by the first name
        public List<Customer> GetCustomerByFirstName(string personFirstName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByPersonFirstName(personFirstName));
            List<Customer> customers = PopulateCustomers(customerList);
            return customers;
        }

        // Method gets a list of customers by the last name
        public List<Customer> GetCustomerByLastName(string personLastName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByPersonLastName(personLastName));
            List<Customer> customers = PopulateCustomers(customerList);
            return customers;
        }

        // Method gets a list of customers by the phone number
        public List<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByPersonPhone(phoneNumber));
            List<Customer> customers = PopulateCustomers(customerList);
            return customers;
        }

        // Method gets a list of customers by the customer ID
        public List<Customer> GetCustomerByCustomerId(Guid customerId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByCustomerId(customerId));
            List<Customer> customers = PopulateCustomers(customerList);
            return customers;
        }

        // Method gets a list of customers by the customer email address
        public List<Customer> GetCustomerByEmail(string email)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = Translators.Customer.ToBusinessObject(_dataAccessObjects.GetCustomerByPersonEmail(email));
            List<Customer> customers = PopulateCustomers(customerList);
            return customers;
        }

        
        //ADDRESS methods
        public int InsertAddress(Address address)
        {
            int returnValue = _dataAccessObjects.InsertAddress(address.AddressId, address.PersonId, address.StreetNumber,
                address.StreetName, address.AddressCity, address.AddressState, address.AddressZip, (int)address.AddressType);

            return returnValue;
        }

        public int UpdateAddress(Address address)
        {
            return _dataAccessObjects.UpdateAddressByAddressId(Translators.Address.ToEntity(address));
        }


        





    }
}
