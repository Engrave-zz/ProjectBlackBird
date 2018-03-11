using WSC.ApplicationLayer;
using BusinessLayer;
using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSC
{
    public partial class WorkSpecialistForm : Form
    {
        protected UserAccount userAccount;
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<Notification> notifications = new List<Notification>();
        private LoginForm _loginForm;

        public WorkSpecialistForm(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
        }

        // When the form loads, populate notifications
        private void WorkSpecialistForm_Load(object sender, EventArgs e)
        {
            lbl_ResultsFound.Text = null;  
            RefreshNotifications();
        }

        // Method will refresh the UI notification information and display
        private void RefreshNotifications()
        {
            // Clear notification detail display box 
            rbox_ClerkNotifications.Clear();

            // Get list of user's notifications
            notifications = ApplicationObjects.CheckAllNotifications(userAccount);

            // Variable to be used for notificaion heaqding (new or read)
            string isRead = null;

            foreach (Notification notification in notifications)
            {
                // If notification is new (unread)
                if (notification.IsRead == false)
                {   // String to insert into notification if notification is new
                    isRead = "New ";
                }
                // Populate combobox drop-down with notifications
                cbx_Notifications.Items.Add(isRead + "Notification: " + notification.NotificationType.ToString());
            }
            // Display total number of notifications
            lbl_Notifications.Text = (notifications.Count.ToString() + " total notifications found");
        }        

        // NOTIFICATION REFRESH button click event
        private void btnRefreshNotifications_Click(object sender, EventArgs e)
        {
            // Clear/reset all fields to prepare for refreshed notification data
            rbox_ClerkNotifications.Clear();
            cbx_Notifications.Items.Clear();
            cbx_Notifications.Text = "";
            notifications.Clear();

            // Refresh notification data
            RefreshNotifications();
        }

        // DELETE NOTIFICATION button click event
        private void btn_DeleteNotificaiton_Click(object sender, EventArgs e)
        {   // Send notification to the database to be deleted
            if (cbx_Notifications.SelectedItem != null)
            {
                int returnValue = ApplicationObjects.DeleteNotification(notifications[cbx_Notifications.SelectedIndex].NotificationId);
            }
            else
            {
                MessageBox.Show("Please select a notification before clicking the [delete] button.", "Delete Notification Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // NOTIFICATION COMBO BOX selected index changed event
        private void cbx_Notifications_SelectedIndexChanged(object sender, EventArgs e)
        {
           BusinessObjects _businessObjects = new BusinessObjects();

           // Clear Notification detail display box
            rbox_ClerkNotifications.Clear();

            // Get description of selected notification
            List<string> notificationDescription = notifications[cbx_Notifications.SelectedIndex].ToNotificationDescription();

            // Write description to notification diplay box
            foreach (string lineItem in notificationDescription)
            {
                rbox_ClerkNotifications.AppendText(lineItem + Environment.NewLine);
            }

            // Mark notification as READ
            notifications[cbx_Notifications.SelectedIndex].IsRead = true;

            // Update database to show notification is READ
            _businessObjects.UpdateNotification(notifications[cbx_Notifications.SelectedIndex]);
        }

        // INVENTORY SEARCH submit button click event
        private void btn_SearchSubmit_Click(object sender, EventArgs e)
        {

            BusinessObjects _businessObjects = new BusinessObjects();
            // Element reset to be performed each time, before a search is ran
            lbl_ResultsFound.Text = null;           // Clear contents of search result label
            cbx_ResultsList.Items.Clear();          // Clear old search results from results combo box
            cbx_ResultsList.Text = "";              // Clear text from visible combobox area
            rbox_clerkSearchDisplay.Clear();        // Clear search results each time a new search is submitted
            inventoryItems = null;

            // Verify that a query type was selected by the user
            if ((cbx_QueryType.SelectedItem == null) || (cbx_InventoryStatus.SelectedItem == null) || (tbx_QueryInput.Text ==""))
            {
                MessageBox.Show("Please make sure all search criteria is filled out and try again", "Invalid Query Input",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // SEARCH BY MANUFACTURER NAME - Chech to see if user entered a Manufacturer Name
            else if (cbx_QueryType.SelectedItem.ToString() == "Manufacturer")
            {
                // Generate a list of Inventory Items that match the Manufacturer Name entered by the user
                inventoryItems = _businessObjects.GetInventoryItemByItemManufacturer(tbx_QueryInput.Text, cbx_InventoryStatus.SelectedIndex);
            }

            // SEARCH BY ITEM NAME - Check to see if user entered an Item Name
            else if (cbx_QueryType.SelectedItem.ToString() == "Item Name")
            {
                // Generate a list of Inventory Items that match the Item Name entered by the user
                inventoryItems = _businessObjects.GetInventoryItemByItemName(tbx_QueryInput.Text, cbx_InventoryStatus.SelectedIndex);
            }

            // SEARCH BY ITEM GUID - Check to see if user entered an ID Number
            else if (cbx_QueryType.SelectedItem.ToString() == "Inventory ID")
            {
                try
                {
                     // Generate a list of Inventory Items that match the Item ID entered by the user
                    inventoryItems = ApplicationObjects.GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(new Guid(tbx_QueryInput.Text), cbx_InventoryStatus.SelectedIndex);
                }
                catch (Exception)
                {   // Catch if a non-Guid was entered
                    MessageBox.Show("Search failed!  You may have entered an invalid ID.  Please check your item ID and try again", "Search Failure",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbox_clerkSearchDisplay.AppendText("Input error - please try again");
                    return;
               }
            }

            // SEARCH BY CATALOG NUMBER - Check to see if user entered an Item Name
            else if (cbx_QueryType.SelectedItem.ToString() == "Catalog Number")
            {
                try
                {
                    // Generate a list of Inventory Items that match the Item Name entered by the user
                    inventoryItems = _businessObjects.GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(new Guid(tbx_QueryInput.Text), cbx_InventoryStatus.SelectedIndex);
                }

                catch (Exception)
                {   // Catch if a non-integer was entered
                    MessageBox.Show("Search failed!  You may have entered an invalid ID.  Please check your catalog ID and try again", "Search Failure",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbox_clerkSearchDisplay.AppendText("Input error - please try again");
                    return;
                }
            }

            // If nothing is populated into the searchDisplay box, we can assume that there were no search results
            else
            {
                lbl_ResultsFound.Text = "No matches found - please try again";
            }

            // Populate label that displays how many results were found
            lbl_ResultsFound.Text = (inventoryItems.Count.ToString() + " result(s) found!");


            // This string list holds the results of an InventoryItem's ToItemDescription method, which actually 
            // returns a list of individual line items, which each hold the item's attributes that will be 
            // displayed on seperate lines of the text box
            try
            {
                List<string> itemDescriptions = inventoryItems.FirstOrDefault().ToItemDescription();
                foreach (string lineItem in itemDescriptions)
                {   // Add each description line item to the text box
                    rbox_clerkSearchDisplay.AppendText(lineItem + Environment.NewLine);
                }

                // Populate the search result combobox with the catalog numbers of the search results
                foreach (InventoryItem inventoryItem in inventoryItems)
                {
                    cbx_ResultsList.Items.Add(inventoryItem.InventoryItemId.ToString());
                }
                // Set the combobox to show the catalog number of the first search record
                cbx_ResultsList.SelectedIndex = 0;
            }
            catch (Exception)
            {
                rbox_clerkSearchDisplay.AppendText("No matches found - please try again");
                return;
            }
        }

        // MARK AS SOLD submit button click event
        private void btn_SubmitRequest_Click(object sender, EventArgs e)
        {
            int updateReturnValue;
            int notificationReturnValue;
            BusinessObjects _businessObjects = new BusinessObjects();

            // Verify that user enterd an order Id, and that they had an inventory item selected in the search result combobox
            if ((tbx_OrderSold.Text == null) || (cbx_ResultsList.SelectedItem == null))
            {
                MessageBox.Show("Invalid input.  Please make sure you have selected an inventory item & entered an Order ID and try again", "Invalid Stock Request",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            // Verify that the item that has been selected is not already marked as SOLD
            else if (inventoryItems[cbx_ResultsList.SelectedIndex].InventoryItemStatus != InventoryItemStatus.Stock)
            {
                MessageBox.Show("You have selected an inventory item that is not in stock.  Please try again", "Invalid Item Status",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
           
            // If user input appears to be valid, continue
            else
            {
                try
                {
                    // Try to convert user input to a Guid  
                    Order order = _businessObjects.GetOrder(new Guid(tbx_OrderSold.Text.ToString()));
            
                    // Verify that an Order was found
                    if (order == null)
                    {
                        MessageBox.Show("We were unable to find an order with the ID that you entered.  Please try again", "No Order Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    // Add order ID to inventory item
                    InventoryItem inventoryItem = inventoryItems[cbx_ResultsList.SelectedIndex];
                    inventoryItem.OrderId = order.OrderId;

                    // Change inventory item status to SOLD                    
                    inventoryItem.InventoryItemStatus = InventoryItemStatus.Sold;
           
                    //Update inventory and populate result value variable
                    updateReturnValue = _businessObjects.UpdateInventoryItem(inventoryItem);

                    // Display message based on success or failue of database update
                    if (updateReturnValue == 0)
                    {
                        BusinessObjects _notificationBusinessObject = new BusinessObjects();
                        // Populate notification fields manually
                        Notification notification = new Notification();
                        notification.OrderId = order.OrderId;
                        notification.NotificationId = Guid.NewGuid();
                        notification.NotificationMessage = ("Please pull inventory item : " +
                                                            inventoryItem.InventoryItemId.ToString());
                        notification.NotificationType = NotificationType.MediaPull;
                        notification.IsRead = false;
                        notification.PermissionScope = Permission.StockClerk;

                        // Insert notification into database table
                        notificationReturnValue = _notificationBusinessObject.InsertNotification(notification);

                        // Database insert success message
                        MessageBox.Show("Your inventory update request was successful.", "Inventory Update",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        // Database insert failure message
                        MessageBox.Show("Your inventory update request has failed, Please try again.", "Inventory Update",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                    // After transaction is complete, re-run original search and refresh search results.
                    btn_SearchSubmit.PerformClick();
                    tbx_OrderSold.Text = "";
                 }       

                 // Show error if user didn't enter an INT
                catch (Exception)
                {
                    MessageBox.Show("You entered an invalid order ID.  Please try again", "Invalid Number",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
        }

        // SEARCH RESULT COMBO BOX index changed event
        private void cbx_ResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbox_clerkSearchDisplay.Clear();
            // Re-populate the item information with the newly selected search result
            List<string> itemDescriptions = inventoryItems[cbx_ResultsList.SelectedIndex].ToItemDescription();
            foreach (string lineItem in itemDescriptions)
            {   // Add each description line item to the text box
                rbox_clerkSearchDisplay.AppendText(lineItem + Environment.NewLine);
            }
        }

        // INVENTORY REQUEST submit button click event
        private void btn_InventoryRequest_Click(object sender, EventArgs e)
        {
            // Verify all fields are NOT null
            if ((tbx_CatalogId.Text != null) && (tbx_Quantity.Text != null))
            {
                try
                {
                    
                    DateTime time = DateTime.Now;   // Variable to be included in notification message
                    int quantity = Convert.ToInt32(tbx_Quantity.Text);  // validate INT input from user
                    int notificationReturnValue;    // Variable to hold return value from database insert
                    BusinessObjects _businessObject = new BusinessObjects();
                    
                    // Get the catalog information for the item that needs to be ordered.  Some of the catalog item info
                    // will be populated into the notification message string
                    CatalogItem catalogItem = _businessObject.GetCatalogItemByCatalogItemId(new Guid(tbx_CatalogId.Text));

                    // Populate notification fields manually
                    Notification notification = new Notification();
                    notification.OrderId = new Guid(tbx_OrderId.Text);
                    notification.NotificationId = Guid.NewGuid();
                    notification.NotificationMessage = ("Please order inventory item --> Item Name: " +
                    catalogItem.ItemName.ToString() + ",  Manufacturer Name: " + catalogItem.Manufacturer.ToString() +
                    ",  Date: " + time.ToString() + ",  Quantity: " + quantity.ToString()) + ", Catalog ID: " +
                    catalogItem.CatalogItemId.ToString();                    
                    notification.NotificationType = NotificationType.RestockItem;
                    notification.IsRead = false;
                    notification.PermissionScope = Permission.StockClerk;

                    // Insert notification into database table
                    notificationReturnValue = _businessObject.InsertNotification(notification);

                    if (notificationReturnValue == 0)
                    {
                        // Database insert success message
                        MessageBox.Show("Your stock request was sent successfully.", "Stock Request",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbx_OrderId.Clear();
                        tbx_CatalogId.Clear();
                        tbx_Quantity.Clear();                        
                    }
                    else
                    {
                        // Database insert failure message
                        MessageBox.Show("Your stock request failed.  Please try again", "Stock Request",
                                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                catch (Exception)
                {
                    // Failure message
                    MessageBox.Show("Your stock request failed.  Please make sure that you filled out all request fields with appropriate information", "Stock Request",
                                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            else
            {
                // Error message due to empty fields in stock request form
                MessageBox.Show("Your stock request is not complete.  Please fill out all fields try again", "Stock Request",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }        
        }

        // COMPLETE ORDER button click event
        private void btn_CompleteOrder_Click(object sender, EventArgs e)
        {
            //Validate order id.
            Guid orderId;
            int returnValue;
            if (!ApplicationObjects.TryParseGuid(tbx_CompleteOrder.Text))
            {
                MessageBox.Show("Invalid order ID format. No update occurred.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                orderId = new Guid(tbx_CompleteOrder.Text);
            }

            Order order = ApplicationObjects.GetOrder(orderId);

            if (order == null)
            {
                MessageBox.Show("Order ID does not exist. No update occurred.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            order.OrderStatus = OrderStatus.WorkComplete;

            returnValue = ApplicationObjects.UpdateOrderStatusWithNotification(order, (Permission)userAccount.PermissionSet.GetHighestPermission());

            // Display output messages based on success/failure of database updates
            if (returnValue == 0)
            {
                // Database update insert was successfull
                MessageBox.Show("Your inventory update request was successful.", "Inventory Update",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Database update failure
                MessageBox.Show("An error occurred and the order status was not updated", "Inventory Update",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }

            foreach (Form form in Application.OpenForms)
            {
                //Don't logout if this is an open form which isn't the login form
                // and isn't this form, which is closing now.
                // *** this condition represents a transition between two forms *** //
                if ((String.Compare(form.Name, "LoginForm") != 0)
                    && (String.Compare(form.Name, this.Name) != 0))
                    return;
            }

            // Log them out. A click to the X button on the Login form will be required to exit like this.
            _loginForm.Logout();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Logout();
            this.Close();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            //Validate order id.
            Guid orderId;
            if (!ApplicationObjects.TryParseGuid(txtViewOrderId.Text))
            {
                MessageBox.Show("Invalid order ID format.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                orderId = new Guid(txtViewOrderId.Text);
            }

            Order order = ApplicationObjects.GetOrder(orderId);

            if (order == null)
            {
                MessageBox.Show("Order ID does not exist.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _loginForm.ShowOrderForm(userAccount, order, _loginForm);
            this.Close();
        }
    }
}
