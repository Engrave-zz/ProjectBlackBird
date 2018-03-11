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
    public partial class ManagerMain : Form
    {
        protected UserAccount userAccount;
        private List<Notification> notifications = new List<Notification>();
        private LoginForm _loginForm;

        public ManagerMain(UserAccount user, LoginForm loginForm)
        {
            _loginForm = loginForm;
            userAccount = user;
            InitializeComponent();
        }

        // When the form loads, populate notifications
        private void ManagerMain_Load(object sender, EventArgs e)
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
        
        //TODO - Not sure if we need to remove this.  I don't want the resfresh running if a user is viewing a notification
        // because it might make the currently viewed notification disappear - or go out of view.
        /*private void tmrCheckNotifications_Tick(object sender, EventArgs e)
        {
            RefreshNotifications();
        }*/
       

        private void linkStockClerk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowStockClerkForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkNewOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowOrderForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowCustomerInfoForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Logout();
            this.Close();
        }

        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowNewUserForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkManageUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowManageUserForm(userAccount, _loginForm);
            this.Close();
        }

        private void lnkWorkSpecialist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowWorkSpecialistForm(userAccount, _loginForm);
            this.Close();
        }

        // DELETE NOTIFICATION button click event
        private void btn_DeleteNotification_Click(object sender, EventArgs e)
        {
            {   // Send notification to the database to be deleted
                int returnValue = ApplicationObjects.DeleteNotification(notifications[cbx_Notifications.SelectedIndex].NotificationId);
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

            foreach(Form form in Application.OpenForms)
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

        private void lnkViewOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }
    }
}
