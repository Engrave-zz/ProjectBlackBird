using WSC.ApplicationLayer;
using BusinessLayer;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer.Enumerations;

namespace WSC
{
    public partial class StockClerkForm : Form
    {
        protected UserAccount userAccount;
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<Notification> notifications = new List<Notification>();
        private LoginForm _loginForm;

        public StockClerkForm(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
            lbl_ResultsFound.Text = "";
        }
        // When the form loads, populate notifications
        private void StockClerkForm_Load(object sender, EventArgs e)
        {
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

        private void btn_clerknotifysubmit_Click(object sender, EventArgs e)
        {
            //Validate order id.
            Guid orderId;
            if (!ApplicationObjects.TryParseGuid(tbox_clerknotifyid.Text))
            {
                MessageBox.Show("Invalid order ID format. No update occurred.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                orderId = new Guid(tbox_clerknotifyid.Text);
            }

            Order order = ApplicationObjects.GetOrder(orderId);
            if (order == null)
            {
                MessageBox.Show("Order ID does not exist. No update occurred.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Validate that at least one of the radio button is selected.
            if (!rbtn_NotifyEnRoute.Checked && !rbtn_NotifyDelivered.Checked)
            {
                MessageBox.Show("Either the \"En Route\" or the \"Delivered\" radio button must be selected. No update occurred.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Prevent decrementing if status was already maked as delivered.
            if ((order.OrderStatus != OrderStatus.Delivered) && (rbtn_NotifyDelivered.Checked))
            {
                string message = "Marking this order as \"Delivered\" will set the status for all items in the order " +
                    "and decrement the available number in stock. Are you sure you'd like to mark this order \"Delivered\"?";
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                //Update order status and submit notifications
                order.OrderStatus = OrderStatus.Delivered;
                ApplicationObjects.UpdateOrderStatusWithNotification(order, (Permission)userAccount.PermissionSet.GetHighestPermission());

                /*************************************/
                //TODO: Re-think this location for the deletes. Should the stock clerk mark delivered to the customer or 
                //just to the engraver. If to the engraver, then should the engraver handle the inventory decrementation?
                /*************************************/

                //Delete from inventory because the material has been delivered.
                //ApplicationObjects.RemoveOrderItemsFromInventory(order);
            }
            //Do nothing if En Route was already set.
            else if ((order.OrderStatus != OrderStatus.EnRoute) && (rbtn_NotifyEnRoute.Checked))
            {
                //Validate order id.                
                if (!ApplicationObjects.TryParseGuid(tbox_clerknotifyid.Text))
                {
                    MessageBox.Show("Invalid order ID format. No update occurred.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //Update order status and submit notifications
                    order.OrderStatus = OrderStatus.EnRoute;

                    ApplicationObjects.UpdateOrderStatusWithNotification(order, (Permission)userAccount.PermissionSet.GetHighestPermission());
                    BusinessObjects _notificationBusinessObject = new BusinessObjects();
                    
                    
                    int notificationReturnValue;
                    Notification notification = new Notification();
                    notification.OrderId = new Guid(tbox_clerknotifyid.Text);
                    notification.NotificationId = Guid.NewGuid();
                    notification.NotificationMessage = ("Inventory item has been ordered and is en route : " +
                                           inventoryItems[cbx_ResultsList.SelectedIndex].InventoryItemId.ToString());
                    notification.NotificationType = NotificationType.EnRoute;
                    notification.IsRead = false;
                    notification.PermissionScope = Permission.WorkSpecialist;

                    // INSERT notification to database
                    notificationReturnValue = _notificationBusinessObject.InsertNotification(notification);

                    if (notificationReturnValue == 0)
                    {
                        /* Database (inventory update) & (notification insert) success message.
                         This message displays if the inventory database update was successful, 
                         and the notificaiton insert was successfull*/
                        MessageBox.Show("Your inventory update request was successful.  A notification has been sent to the Work Specialist", "Inventory Update",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        /* Database (inventory update SUCCESS) but (notification insert FAILURE) message.
                        This message displays if the inventory database update was successful, 
                        but the notification failed for some reason*/
                        MessageBox.Show("Your inventory update request was successful.  However, an error prevented a" +
                            "notification from being sent to the Work Specialist", "Inventory Update",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }            
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
            inventoryItems = null;                  // Clear inventory items from list
            cbx_InventoryStatus.Text = "";

            // Verify that a query type was selected by the user
            if ((cbx_QueryType.SelectedItem == null) || (cbx_InventoryStatus.SelectedItem == null) || (tbx_QueryInput.Text == ""))
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
                    inventoryItems = ApplicationObjects.GetInventoryItemByInventoryItemIdAndInventoryItemStatusId(
                        new Guid(tbx_QueryInput.Text), cbx_InventoryStatus.SelectedIndex);
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
                    inventoryItems = _businessObjects.GetInventoryItemByCatalogItemIdAndInventoryItemStatusId(
                        new Guid(tbx_QueryInput.Text), cbx_InventoryStatus.SelectedIndex);
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


            // If inventory item list is not empty.....
            if (inventoryItems.Count > 0)
            {
                // This string list holds the results of an InventoryItem's ToItemDescription method, which actually 
                // returns a list of individual line items, which each hold the item's attributes that will be 
                // displayed on seperate lines of the text box
                List<string> itemDescriptions = inventoryItems.FirstOrDefault().ToItemDescription();
                foreach (string lineItem in itemDescriptions)
                {   // Add each description line item to the text box
                    rbox_clerkSearchDisplay.AppendText(lineItem + Environment.NewLine);
                }

                // Populate the search result combobox with the Inventory Id numbers of the search results
                foreach (InventoryItem inventoryItem in inventoryItems)
                {
                    cbx_ResultsList.Items.Add(inventoryItem.InventoryItemId.ToString());
                }
                // Set the combobox to show the catalog number of the first search record
                cbx_ResultsList.SelectedIndex = 0;
            }
            // If inventoryITem list is empty...
            else
            {   // Display "no results found"
                lbl_ResultsFound.Text = "No matches found - please try again";
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

        // DELETE NOTIFICATION button click event
        private void btn_DeleteNotification_Click(object sender, EventArgs e)
        {
            if (cbx_Notifications.SelectedItem != null)
            {
                // Send notification to the database to be deleted
                int returnValue = ApplicationObjects.DeleteNotification(notifications[cbx_Notifications.SelectedIndex].NotificationId);
            }
            else
            {
                MessageBox.Show("Please select a notification before clicking the [delete] button.", "Delete Notification Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        // DELETE FROM INVENTORY BUTTON click event
        private void btn_DeleteFromInventory_Click(object sender, EventArgs e)
        {
            // Verify that user selected an inventory item in the search result combobox
            if (cbx_ResultsList.SelectedItem == null)
            {
                MessageBox.Show("No Inventory Item Selected.  Please select an inventory item from the drop-down list and try again", "Invalid Status Change",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // Verify that the item is in SOLD status...any other status can't be marked as DELIVERED
            else if (inventoryItems[cbx_ResultsList.SelectedIndex].InventoryItemStatus != InventoryItemStatus.Sold)
            {
                MessageBox.Show("You can only deliver an item that is currently in 'Sold' status.  Please try again", "Invalid Item Status",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // If user input appears to be valid, continue
            else
            {
                // Delete inventory item from database 
                ApplicationObjects.RemoveInventoryItemFromInventory(inventoryItems[cbx_ResultsList.SelectedIndex]);

                // Clear all fields to prepare for next search.
                ResetInventorySearch();
            }
        }

        // Method clears all fields in preparation for a new search
        private void ResetInventorySearch()
        {
            cbx_QueryType.SelectedText = "";
            cbx_QueryType.Text = "";
            tbx_QueryInput.Text = "";
            cbx_InventoryStatus.SelectedText = "";
            cbx_InventoryStatus.Text = "";
            lbl_ResultsFound.Text = "";
            cbx_ResultsList.Items.Clear();
            cbx_ResultsList.SelectedText = "";
            cbx_ResultsList.Text = "";
            rbox_clerkSearchDisplay.Clear();
        }
    }
}
