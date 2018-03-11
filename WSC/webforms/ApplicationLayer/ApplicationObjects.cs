using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using Enumeration = BusinessLayer.Enumerations;
using System.Text.RegularExpressions;


namespace WSC.ApplicationLayer
{
    public static class ApplicationObjects
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
        
        // USER RELATED METHODS
        public static UserAccount AuthenticateUser(string userName, string password)
        {   /// Accepts login input and sets the appropriate UserAccount object and permissions token
            BusinessObjects _businessObjects = new BusinessObjects();
            UserAccount userAccount = _businessObjects.GetUserAccountByUserName(userName);

            if(userAccount == null)
            {
                userAccount = new UserAccount("invalid", "invalid", true);
            }

            if(!userAccount.MatchPassword(password))
            {
                userAccount.ClearPermissionSet();
            }

            return userAccount;
        }
        
        public static int ChangePassword(UserAccount userWithNewPassword)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.UpdateUserAccountByUserId(userWithNewPassword);
        }

        public static int NewUser(UserAccount user)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            int returnValue = _businessObjects.NewUserAccount(user);

            return returnValue;
        }

        // CUSTOMER METHODS
        public static int UpdateCustomer(Customer customer)
        {
            // Transaction to perform 4 inter-related data inserts on multiple database tables
            using (TransactionScope scope = new TransactionScope())
            {
                int returnValue = 1;

                // Write PERSON record to database
                BusinessObjects _personBusinessObject = new BusinessObjects();
                returnValue = _personBusinessObject.UpdatePersonFromCustomer(customer);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return 1;
                }

                // Write MAILING ADDRESS record to database
                BusinessObjects _mailingAddressBusinessObject = new BusinessObjects();
                returnValue = _mailingAddressBusinessObject.UpdateAddress(customer.MailingAddress);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return 1;
                }

                // Write BILLING ADDRESS record to database
                BusinessObjects _billingAddressBusinessObject = new BusinessObjects();
                returnValue = _billingAddressBusinessObject.UpdateAddress(customer.BillingAddress);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return 1;
                }

                // Committ data transaction & display success message
                scope.Complete();
                ApplicationObjects.DisplayDataStatus(returnValue);
                return 0;
            }// End transaction

        }
        
        public static List<Customer> GetCustomerByFirstName(string firstName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = _businessObjects.GetCustomerByFirstName(firstName);
            return customerList;
        }

        public static List<Customer> GetCustomerByLastName(string lastName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = _businessObjects.GetCustomerByLastName(lastName);
            return customerList;
        }

        public static List<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = _businessObjects.GetCustomerByLastName(phoneNumber);
            return customerList;
        }

        public static List<Customer> GetCustomerByCustomerId(Guid customerId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = _businessObjects.GetCustomerByCustomerId(customerId);
            return customerList;
        }

        public static List<Customer> GetCustomerByEmail(string emailAddress)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Customer> customerList = _businessObjects.GetCustomerByEmail(emailAddress);
            return customerList;
        }
        
        // NOTIFICATION METHODS
        public static List<Notification> CheckNewNotifications(UserAccount user, bool isRead = false)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Notification> notificationList = _businessObjects.CheckNewNotifications(user, isRead);
            return notificationList;
        }

        public static List<Notification> CheckAllNotifications(UserAccount user)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<Notification> notificationList = _businessObjects.CheckAllNotifications(user);
            return notificationList;
        }

        public static int DeleteNotification(Guid notificationId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.DeleteNotification(notificationId);
        }

        public static int NewNotification(Notification notification)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            int returnValue = _businessObjects.InsertNotification(notification);

            return returnValue;
        }

        
        // INVENTORY ITEM METHODS
        public static List<InventoryItem> GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(Guid inventoryItemId, int inventoryItemStatus)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(inventoryItemId, inventoryItemStatus);
        }

        public static List<InventoryItem> GetInventoryItemByInventoryItemId(InventoryItem inventoryItem, int inventoryItemStatus)
        {
            if (inventoryItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (inventoryItem.InventoryItemId != null && inventoryItem.InventoryItemId != Guid.Empty)
                    ? _businessObjects.GetInventoryItemByCatalogItemId(inventoryItem.InventoryItemId)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static List<InventoryItem> GetInventoryItemByCatalogItemId(Guid catalogItemId, int inventoryItemStatus)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetInventoryItemByCatalogItemId(catalogItemId);
        }

        public static List<InventoryItem> GetInventoryItemByCatalogItemId(InventoryItem inventoryItem)
        {
            if (inventoryItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (inventoryItem.CatalogItemId != null && inventoryItem.CatalogItemId != Guid.Empty)
                    ? _businessObjects.GetInventoryItemByCatalogItemId(inventoryItem.CatalogItemId)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static List<InventoryItem> GetInventoryItemByCatalogItemId(CatalogItem catalogItem)
        {
            if (catalogItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (catalogItem.CatalogItemId != null && catalogItem.CatalogItemId != Guid.Empty)
                    ? _businessObjects.GetInventoryItemByCatalogItemId(catalogItem.CatalogItemId)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static CatalogItem GetCatalogItemByCatalogItemId(CatalogItem catalogItem)
        {
            if (catalogItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (catalogItem.CatalogItemId != null && catalogItem.CatalogItemId != Guid.Empty)
                    ? _businessObjects.GetCatalogItemByCatalogItemId(catalogItem.CatalogItemId)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static CatalogItem GetCatalogItemByCatalogItemId(Guid catalogItemId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return (catalogItemId != Guid.Empty)
                ? _businessObjects.GetCatalogItemByCatalogItemId(catalogItemId)
                : null;
        }

        public static List<InventoryItem> GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(InventoryItem inventoryItem, int inventoryItemStatus)
        {
            if (inventoryItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (inventoryItem.CatalogItemId != null && inventoryItem.CatalogItemId != Guid.Empty)
                    ? _businessObjects.GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(inventoryItem.CatalogItemId, inventoryItemStatus)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static List<InventoryItem> GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(CatalogItem catalogItem, int inventoryItemStatus)
        {
            if (catalogItem != null)
            {
                BusinessObjects _businessObjects = new BusinessObjects();
                return (catalogItem.CatalogItemId != null && catalogItem.CatalogItemId != Guid.Empty)
                    ? _businessObjects.GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(catalogItem.CatalogItemId, inventoryItemStatus)
                    : null;
            }
            else
            {
                return null;
            }
        }

        public static int UpdateInventoryItem(InventoryItem item)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.UpdateInventoryItem(item);
        }

        public static void RemoveOrderItemsFromInventory(Order order)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            using (TransactionScope scope = new TransactionScope())
            {
                int returnValue = 1;
                foreach (OrderItem orderItem in order.ItemList)
                {
                    //Get list of items in the inventory that match the catalog id and are on hold by this order
                    List<InventoryItem> inventoryList = (List<InventoryItem>)ApplicationObjects.GetInventoryItemByCatalogItemId(orderItem.CatalogItem
                        ).Where(o => o.OrderId == order.OrderId);

                    returnValue = _businessObjects.DeleteInventoryItems(inventoryList);
                    if (returnValue == 1)
                    {
                        scope.Dispose(); //kick transactionscope thus rolling back transaction.
                        break;
                    }
                }

                if (returnValue == 0)
                    scope.Complete(); //commit transaction
            }
        }

        public static void RemoveInventoryItemFromInventory(InventoryItem item)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            int returnValue;
            returnValue = _businessObjects.DeleteInventoryItem(item);
            DisplayDataStatus(returnValue);
            if (returnValue == 0)
            {
                int notificationReturnValue;
                BusinessObjects _notificationBusinessObject = new BusinessObjects();
                Notification notification = new Notification();
                notification.OrderId = item.OrderId;
                notification.NotificationId = Guid.NewGuid();
                notification.NotificationMessage = ("Inventory item is en route : " +
                                       item.InventoryItemId.ToString());
                notification.NotificationType = BusinessLayer.Enumerations.NotificationType.EnRoute;
                notification.IsRead = false;
                notification.PermissionScope = BusinessLayer.Enumerations.Permission.WorkSpecialist;

                // INSERT notification to database
                notificationReturnValue = _notificationBusinessObject.InsertNotification(notification);

                if(notificationReturnValue == 0)
                {
                    MessageBox.Show("A notification has been sent to the Work specialist", "Item Sent to Work Specialist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(notificationReturnValue == 1)
                {
                    MessageBox.Show("There was a problem sending a notification to the Work Specialist - please notify them manually that the item is on the way", "Item Sent to Work Specialist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

     
        // ORDER METHODS
        public static int UpdateOrderStatusWithNotification(Order order, Enumeration.Permission senderPermissionScope)
        {
            int returnValue = 1;

            BusinessObjects _businessObjects = new BusinessObjects();
            returnValue = _businessObjects.UpdateOrder(order);

            if (returnValue == 1)
                return returnValue;

            Notification notification = new Notification
            {
                NotificationId = Guid.NewGuid(),
                IsRead = false,
                OrderId = order.OrderId
            };

            string message = "";
            switch (order.OrderStatus)
            {
                case Enumeration.OrderStatus.WorkComplete:
                    message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = Work Complete";
                    notification.NotificationMessage = message;
                    notification.NotificationType = Enumeration.NotificationType.WorkComplete;
                    notification.PermissionScope = Enumeration.Permission.OperationsManager;
                    returnValue = _businessObjects.InsertNotification(notification);
                    break;
                case Enumeration.OrderStatus.EnRoute:
                    message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = En Route";
                    notification.NotificationMessage = message;
                    notification.NotificationType = Enumeration.NotificationType.EnRoute;
                    notification.PermissionScope = Enumeration.Permission.WorkSpecialist;
                    returnValue = _businessObjects.InsertNotification(notification);
                    break;
                case Enumeration.OrderStatus.Delivered:
                    if (senderPermissionScope == Enumeration.Permission.SalesPerson)
                    {
                        message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = Delivered";
                        notification.NotificationMessage = message;
                        notification.NotificationType = Enumeration.NotificationType.Delivered;
                        notification.PermissionScope = Enumeration.Permission.OperationsManager;
                        returnValue = _businessObjects.InsertNotification(notification);
                    }
                    else if (senderPermissionScope == Enumeration.Permission.StockClerk)
                    {
                        message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = Delivered";
                        notification.NotificationMessage = message;
                        notification.NotificationType = Enumeration.NotificationType.Delivered;
                        notification.PermissionScope = Enumeration.Permission.WorkSpecialist;
                        returnValue = _businessObjects.InsertNotification(notification);
                    }
                    break;
                case Enumeration.OrderStatus.Complete:
                    message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = Order Complete";
                    notification.NotificationMessage = message;
                    notification.NotificationType = Enumeration.NotificationType.OrderComplete;
                    notification.PermissionScope = Enumeration.Permission.SalesPerson;
                    returnValue = _businessObjects.InsertNotification(notification);
                    break;
                case Enumeration.OrderStatus.FailedValidation:
                    message = "Order ID: " + order.OrderId.ToString() + " - STATUS CHANGE = Failed Validation";
                    notification.NotificationMessage = message;
                    notification.NotificationType = Enumeration.NotificationType.FailedQualityControl;
                    notification.PermissionScope = Enumeration.Permission.WorkSpecialist;
                    returnValue = _businessObjects.InsertNotification(notification);
                    break;
            }

            return returnValue;
        }      

        public static Order GetOrder(Guid orderId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetOrder(orderId);
        }

        public static List<Order> GetAllOrders()
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetAllOrders();
        }

        public static List<Order> GetOrderByOrderStatus(Enumeration.OrderStatus orderStatus)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetOrdersByOrderStatus(orderStatus);
        }

        public static List<Order> GetOrderByInventoryItemId(Guid inventoryItemId)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.GetOrdersByInventoryItemId(inventoryItemId);
        }

       
        public static bool TryParseGuid(string guidInput)
        {
            try
            {
                new Guid(guidInput);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // UTILITY METHODS
        
        // Method will display a failure or success messagebox based on the passed parameter of a return value
        public static void DisplayDataStatus(int returnValue)
        {
            if (returnValue == 1)
            {   // If data update/insert failed....
                MessageBox.Show("There was a problem with your request.  Please try again.",
                       "Data Processing Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (returnValue == 0)
            {   // If data update/insert succeeded
                MessageBox.Show("Your request was successfully completed.",
                       "Data Processing Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        // Method will display a message passed by the user...designed to be used for missing/invalidinput
        public static void DisplayInvalidInput(string message)
        {
            MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // Verify email address format
        public static bool EmailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public static int CreateOrder(Order order)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.InsertOrder(order);
        }

        public static int CreateCustomer(Customer customer)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            return _businessObjects.InsertPersonFromCustomer(customer);
        }
    }
}
