using WSC.ApplicationLayer;
using BusinessLayer;
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
    public partial class SalesEmployeeForm : Form
    {
        protected UserAccount userAccount;
        private List<Notification> notifications = new List<Notification>();
        private LoginForm _loginForm;
        private List<CatalogItem> catalogItemCollection = new List<CatalogItem>();

        public SalesEmployeeForm(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
        }

        // When the form loads, populate notifications
        private void SalesEmployeeForm_Load(object sender, EventArgs e)
        {
            RefreshNotifications();
            lbl_CatalogResultsFound.Text = "";
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

        private void lnkSalesOrderForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowOrderForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkInventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowStockClerkForm(userAccount, _loginForm);
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowCustomerInfoForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkOrders_Click(object sender, EventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Logout();
            this.Close();
        }

        // DELETE NOTIFICATION button click event
        private void btn_DeleteNotification_Click(object sender, EventArgs e)
        {
            // Send notification to the database to be deleted
            if (cbx_Notifications.SelectedIndex >= 0)
            {
                int returnValue = ApplicationObjects.DeleteNotification(notifications[cbx_Notifications.SelectedIndex].NotificationId);
            }
        }

        private void lnkLogout_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Logout();
            this.Close();
        }

        //TODO - Not sure if we need to remove this.  I don't want the resfresh running if a user is viewing a notification
        // because it might make the currently viewed notification disappear - or go out of view.
        /*private void tmrCheckNotifications_Tick(object sender, EventArgs e)
        {
            RefreshNotifications();
        }*/

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

        private void lnkOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkCreateOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowOrderForm(userAccount, _loginForm);
            this.Close();
        }

        private void btn_SearchSubmit_Click(object sender, EventArgs e)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            // Element reset to be performed each time, before a search is ran
            lbl_CatalogResultsFound.Text = null;           // Clear contents of search result label
            cbx_CatalogResultsList.Items.Clear();          // Clear old search results from results combo box
            cbx_CatalogResultsList.Text = "";              // Clear text from visible combobox area
            rbx_CatalogSearchResults.Clear();        // Clear search results each time a new search is submitted
            catalogItemCollection = null;                  // Clear inventory items from list

            // Verify that a query type was selected by the user
            if (cbx_CatalogQueryType.SelectedItem == null)
            {
                MessageBox.Show("You forgot to select a query type.  Please try again", "Invalid Query",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // SEARCH BY MANUFACTURER NAME - Chech to see if user entered a Manufacturer Name
            else if (cbx_CatalogQueryType.SelectedItem.ToString() == "Manufacturer")
            {
                // Generate a list of Inventory Items that match the Manufacturer Name entered by the user
                catalogItemCollection = _businessObjects.GetCatalogItemByManufacturer(tbx_CatalogQueryInput.Text);
            }

            // SEARCH BY ITEM NAME - Check to see if user entered an Item Name
            else if (cbx_CatalogQueryType.SelectedItem.ToString() == "Item Name")
            {
                // Generate a list of Catalog Items that match the Item Name entered by the user
                catalogItemCollection = (catalogItemCollection == null) ? new List<CatalogItem>() : catalogItemCollection;
                catalogItemCollection.Add(_businessObjects.GetCatalogItemByItemName(tbx_CatalogQueryInput.Text));
            }

            // SEARCH BY ITEM GUID - Check to see if user entered an ID Number
            else if (cbx_CatalogQueryType.SelectedItem.ToString() == "Catalog ID")
            {
                try
                {
                    // Generate a list of Catalog Items that match the Item ID entered by the user
                    catalogItemCollection = (catalogItemCollection == null) ? new List<CatalogItem>() : catalogItemCollection;
                    catalogItemCollection.Add(ApplicationObjects.GetCatalogItemByCatalogItemId(new Guid(tbx_CatalogQueryInput.Text)));
                }
                catch (Exception)
                {   // Catch if a non-Guid was entered
                    MessageBox.Show("You entered an invalid ID.  Please make sure that the ID contains 32 characters and 4 hyphens", "Invalid GUID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    rbx_CatalogSearchResults.AppendText("Input error - please try again");
                    return;
                }
            }

            // If nothing is populated into the searchDisplay box, we can assume that there were no search results
            else
            {
                lbl_CatalogResultsFound.Text = "No results found";
            }

            // Populate label that displays how many results were found
            lbl_CatalogResultsFound.Text = (catalogItemCollection.Count.ToString() + " result(s) found!");

            // This string list holds the results of an CatalogItem's ToItemDescription method, which actually 
            // returns a list of individual line items, which each hold the item's attributes that will be 
            // displayed on seperate lines of the text box
            List<string> itemDescriptions = (catalogItemCollection.Count > 0) 
                                                    ? catalogItemCollection.FirstOrDefault().ToItemDescription()
                                                    : new List<string>();
            foreach (string lineItem in itemDescriptions)
            {   // Add each description line item to the text box
                rbx_CatalogSearchResults.AppendText(lineItem + Environment.NewLine);
            }

            // Populate the search result combobox with the Catalog Id numbers of the search results
            foreach (CatalogItem catalogItem in catalogItemCollection)
            {
                cbx_CatalogResultsList.Items.Add(catalogItem.CatalogItemId.ToString());
            }
            // Set the combobox to show the catalog number of the first search record
            if(cbx_CatalogResultsList.Items.Count > 0)
                cbx_CatalogResultsList.SelectedIndex = 0;
        }

        private void cbx_ResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbx_CatalogSearchResults.Clear();
            // Re-populate the item information with the newly selected search result
            List<string> itemDescriptions = catalogItemCollection[cbx_CatalogResultsList.SelectedIndex].ToItemDescription();
            foreach (string lineItem in itemDescriptions)
            {   // Add each description line item to the text box
                rbx_CatalogSearchResults.AppendText(lineItem + Environment.NewLine);
            }
        }

        private void btn_CreateNewOrder_Click(object sender, EventArgs e)
        {
            if (catalogItemCollection.Count > 0)
            {
                Order newOrder = new Order();
                OrderItem newItem = new OrderItem();
                newItem.CatalogItem = catalogItemCollection[cbx_CatalogResultsList.SelectedIndex];
                newOrder.ItemList.Add(newItem);
                _loginForm.ShowOrderForm(userAccount, newOrder, _loginForm);
            }
            else
            {
                _loginForm.ShowOrderForm(userAccount, _loginForm);
            }
            this.Close();
        }
    }
}
