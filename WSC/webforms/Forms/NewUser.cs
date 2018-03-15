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
    public partial class NewUser : Form
    {
        protected UserAccount userAccount;
        private LoginForm _loginForm;

        public NewUser(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            bool userInfoIsValid = ValidateUserInformation();
            if (!userInfoIsValid)
                return;

            UserAccount newUser = new UserAccount(txtUsername.Text, txtUserPassword.Text, false);
            newUser.EmailAddress = txtEmailAddress.Text;
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.PhoneNumber = txtPhoneNumber.Text;
            
            foreach(object item in chklstRoles.CheckedItems)
            {
                PermissionSet permissionSet = new PermissionSet();
                switch (item.ToString())
                {
                    case "Operational Manager":
                        permissionSet.IsManager = true;
                        permissionSet.IsStockClerk = true;
                        permissionSet.IsCustomer = true;
                        permissionSet.IsWorkSpecialist = true;
                        break;
                    case "Sales Person": permissionSet.IsCustomer = true;
                        break;
                    case "Printing / Engraving Specialist": permissionSet.IsWorkSpecialist = true;
                        break;
                    case "Stock Clerk": permissionSet.IsStockClerk = true;
                        break;
                }
                newUser.PermissionSet = permissionSet;
            }

            int returnValue = ApplicationObjects.NewUser(newUser);
            ApplicationObjects.DisplayDataStatus(returnValue);
            if (returnValue == 1)
            {
                return;
            }
            else if (returnValue == 2)
            {
                MessageBox.Show("A user by this name already exists.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _loginForm.ShowManagerMainForm(userAccount, _loginForm);
            this.Close();
        }

        public bool ValidateUserInformation()
        {
            // BEGIN USER INPUT DATA VALIDATION.....
            // Verify that PERSONAL information was not left blank
            if ((this.txtFirstName.Text == "") || (this.txtLastName.Text == "") || (this.txtPhoneNumber.Text == "")
                || (this.txtEmailAddress.Text == "") || (this.txtUsername.Text == "") || (this.txtUserPassword.Text == "")
                || (this.txtManagerPassword.Text == ""))
            {   // If any personal information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the personal fields and try again.");
                return false;
            }

            // Variable used in TryParse functions
            long number;

            // Validate numeric input for phone number
            if ((!long.TryParse((txtPhoneNumber.Text), out number)) || (txtPhoneNumber.Text.Length != 10))
            {   // If phone number input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid phone number entered.  Please enter 10 digits (no dashes) & try again.");
                return false;
            }

            // validate email address format
            if (!ApplicationObjects.EmailIsValid(txtEmailAddress.Text))
            {   // If email address was not in specified format, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid e-mail address entered.  Please try again.");
                return false;
            }

            // validate user name
            if (!(txtUsername.Text.Length >= 4))
            {   
                ApplicationObjects.DisplayInvalidInput("Invalid username entered.  Your username must be four characters or longer.");
                return false;
            }

            // validate password
            if (!(txtUserPassword.Text.Length >= 4))
            {
                ApplicationObjects.DisplayInvalidInput("Invalid password entered.  Your password must be four characters or longer.");
                return false;
            }
            // .....END USER INPUT DATA VALIDATION

            return true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _loginForm.ShowManageUserForm(userAccount, _loginForm);
            this.Close();
        }
    }
}
