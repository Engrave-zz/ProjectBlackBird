using WSC.ApplicationLayer;
using BusinessLayer;
using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace WSC.webforms
{
    public partial class Login : System.Web.UI.Page
    {
        //User Security
        protected UserAccount userAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                Response.Redirect("Home.aspx");
            }

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (lblError.Visible == true)
            {
                lblError.Text = null;
            }
            //Do nothing if user name or password is empty.
            if ((txtUserName.Text == String.Empty) || (txtUserName.Text == null))
                return;
            if ((txtPassword.Text == String.Empty) || (txtPassword.Text == null))
                return;

            userAccount = ApplicationObjects.AuthenticateUser(txtUserName.Text, txtPassword.Text);

            if (userAccount.UserName == "invalid" && userAccount.PasswordHash == "invalid")
            {
                lblError.Text += "Failed to authenticate with inputted username and password, Authentication Failed";
                lblError.Visible = true;
                return;
            }
            if (userAccount.HighestPermission == null)
            {
                lblError.Text += "Invalid permissions token. Please contact Help-Desk, Authentication Failed";
                lblError.Visible = true;
                return;
            }

            txtError.Text = "Success";
            txtError.Visible = true;

            switch (userAccount.HighestPermission)
            {
                case (Permission.Manager):
                    ShowManagerMainForm(userAccount);
                    break;
                case (Permission.Customer):
                    ShowCustomerPage(userAccount);
                    break;
            }
        }
        public void ShowManagerMainForm(UserAccount user)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("UserName", user.UserName);
            ht.Add("Role", "Employee");
            ht.Add("FirstName", user.FirstName);
            ht.Add("LastName", user.LastName);
            ht.Add("Email", user.EmailAddress);
            ht.Add("PersonID", user.PersonId);
            Session["UserInfo"] = ht;
        }
        public void ShowCustomerPage(UserAccount user)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("UserName", user.UserName);
            ht.Add("Role", "Customer");
            ht.Add("FirstName", user.FirstName);
            ht.Add("LastName", user.LastName);
            ht.Add("PersonID", user.PersonId);
            ht.Add("Email", user.EmailAddress);
            Session["UserInfo"] = ht;
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Call ValidateRegistration Function
            bool isvailid = ValidateRegistration();
            System.Collections.Hashtable confirmht = new System.Collections.Hashtable();
            if (isvailid == true)
            {
                PermissionSet permissionSet = new PermissionSet();
                permissionSet.IsCustomer = true;
                //add code here to register user.
                string regUserName = txtFirstName.Text.Substring(0, 1) + txtLastName.Text;
                UserAccount newUser = new UserAccount(regUserName, txtRegPassword.Text, false);
                newUser.EmailAddress = txtEmail.Text;
                newUser.FirstName = txtFirstName.Text;
                newUser.LastName = txtLastName.Text;
                newUser.PhoneNumber = txtPhoneNumber.Text;
                newUser.PermissionSet = permissionSet;

                int returnUserValue = ApplicationObjects.NewUser(newUser);
                //Display Status Upon Success
                confirmht.Add("UserName", newUser.UserName);
                if (returnUserValue == 1)
                {
                    return;
                }
                else if (returnUserValue == 2)
                {
                    lblError.Visible = true;
                    lblError.Text = "A user by this name already exists, duplicate user";
                    return;
                }

                // Populate customer object with user input
                Customer customer = new Customer();
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.PhoneNumber = txtPhoneNumber.Text;
                customer.EmailAddress = txtEmail.Text;

                // Populate mailing address object with user input
                Address mailingAddress = new Address();
                mailingAddress.PersonId = customer.PersonId;
                mailingAddress.StreetNumber = int.Parse(txtAddressStreetNumber.Text);
                mailingAddress.StreetName = txtAddressStreetName.Text;
                mailingAddress.AddressCity = txtCity.Text;
                mailingAddress.AddressState = txtState.Text;
                mailingAddress.AddressZip = txtZipCode.Text;
                mailingAddress.AddressType = AddressType.Mailing;

                // Populate billing address object with user input
                Address billingAddress = new Address();
                billingAddress.PersonId = customer.PersonId;
                billingAddress.StreetNumber = int.Parse(txtBillingAddressStreetNumber.Text);
                billingAddress.StreetName = txtBillingAddressStreetName.Text;
                billingAddress.AddressCity = txtBillingCity.Text;
                billingAddress.AddressState = txtBillingState.Text;
                billingAddress.AddressZip = txtBillingZipCode.Text;
                billingAddress.AddressType = AddressType.Billing;

                // Transaction to perform 4 inter-related data inserts on multiple database tables
                using (TransactionScope scope = new TransactionScope())
                {
                    int returnValue = 1;

                    // Write PERSON record to database
                    BusinessObjects _personBusinessObject = new BusinessObjects();
                    returnValue = _personBusinessObject.InsertPersonFromCustomer(customer);
                    if (returnValue == 1)
                    {   // If insert fails, rollback transaction & display error message
                        confirmht.Add("WritePersonRecord", "Failed");
                        scope.Dispose();
                        return;
                    }

                    // Write CUSTOMER record to database
                    BusinessObjects _customerBusinessObject = new BusinessObjects();
                    returnValue = _customerBusinessObject.InsertCustomer(customer);
                    if (returnValue == 1)
                    {   // If insert fails, rollback transaction & display error message
                        confirmht.Add("WriteCustomerRecord", "Failed");
                        scope.Dispose();
                        return;
                    }

                    // Write MAILING ADDRESS record to database
                    BusinessObjects _mailingAddressBusinessObject = new BusinessObjects();
                    returnValue = _mailingAddressBusinessObject.InsertAddress(mailingAddress);
                    if (returnValue == 1)
                    {   // If insert fails, rollback transaction & display error message
                        confirmht.Add("WriteMailingAddress", "Failed");
                        scope.Dispose();
                        return;
                    }

                    // Write BILLING ADDRESS record to database
                    BusinessObjects _billingAddressBusinessObject = new BusinessObjects();
                    returnValue = _billingAddressBusinessObject.InsertAddress(billingAddress);
                    if (returnValue == 1)
                    {   // If insert fails, rollback transaction & display error message
                        confirmht.Add("WriteBillingAddress", "Failed");
                        scope.Dispose();
                        return;
                    }
                    // Committ data transaction & display success message
                    confirmht.Add("CustomerCreated", "Success");
                    confirmht.Add("WriteBillingAddress", "Success");
                    confirmht.Add("WriteMailingAddress", "Success");
                    confirmht.Add("WriteCustomerRecord", "Success");
                    confirmht.Add("WritePersonRecord", "Success");
                    confirmht.Add("Role", "Customer");
                    scope.Complete();
                }// End transaction

                Session["Confirmation"] = confirmht;
                Response.Redirect("Confirmation.aspx");

                txtFirstName.Text = null;
                txtLastName.Text = null;
                txtCity.Text = null;
                txtAddressStreetName.Text = null;
                txtAddressStreetNumber.Text = null;
                txtEmail.Text = null;
                txtEmailConfirm.Text = null;
                txtRegPassword.Text = null;
                txtRegPasswordConfirm.Text = null;
            }
        }

        protected void chckBoxSameAsMailing_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBoxSameAsMailing.Checked)
            {
                txtBillingAddressStreetName.Text = txtAddressStreetName.Text;
                txtBillingAddressStreetNumber.Text = txtAddressStreetNumber.Text;
                txtBillingCity.Text = txtCity.Text;
                txtBillingState.Text = txtState.Text;
                txtBillingZipCode.Text = txtZipCode.Text;
            }
            else
            {
                txtBillingAddressStreetName.Text = null;
                txtBillingAddressStreetNumber.Text = null;
                txtBillingCity.Text = null;
                txtBillingState.Text = null;
                txtBillingZipCode.Text = null;
            }
        }

        public bool ValidateRegistration()
        {
            if (lblError.Visible == true)
            {
                lblError.Text = null;
            }
            if ((txtFirstName.Text == null) || (txtFirstName.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "Registration Form Error: Please enter your First Name";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your First Name";
                    return false;
                }
            }
            if ((txtLastName.Text == null) || (txtLastName.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your Last Name";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your Last Name";
                    return false;
                }
            }
            if ((txtEmail.Text == null) || (txtEmail.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your email";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your email";
                    return false;
                }
            }
            if ((txtAddressStreetName.Text == null) || (txtAddressStreetName.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your address street name";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your address streat name";
                    return false;
                }
            }
            if ((txtAddressStreetNumber.Text == null) || (txtAddressStreetNumber.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your address street number";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your address street number";
                    return false;
                }
            }
            if ((txtEmailConfirm.Text == null) || (txtEmailConfirm.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please confirm your email";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please confirm your email";
                    return false;
                }
            }
            if (txtEmail.Text != txtEmailConfirm.Text)
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Emails do not match";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Emails do not match";
                    return false;
                }
            }
            if ((txtRegPassword.Text == null) || (txtRegPassword.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Password cannot be blank";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Password cannot be blank";
                    return false;
                }
            }
            if ((txtRegPasswordConfirm.Text == null) || (txtRegPasswordConfirm.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please confirm your password";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please confirm your password";
                    return false;
                }
            }
            if (txtRegPasswordConfirm.Text != txtRegPassword.Text)
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Passwords do not match";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Passwords do not match";
                    return false;
                }
            }
            if ((txtBillingAddressStreetName.Text == null) || (txtBillingAddressStreetName.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: enter billing street name";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: enter billing street name";
                    return false;
                }
            }
            if ((txtBillingAddressStreetNumber.Text == null) || (txtBillingAddressStreetNumber.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: enter billing street number";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: enter billing street number";
                    return false;
                }
            }
            if ((txtBillingCity.Text == null) || (txtBillingCity.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: enter billing city";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: enter billing city";
                    return false;
                }
            }
            if ((txtBillingState.Text == null) || (txtBillingState.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: enter billing state";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: enter billing state";
                    return false;
                }
            }
            if ((txtBillingZipCode.Text == null) || (txtBillingZipCode.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: enter billing Zip Code";
                    return false;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: enter billing Zip Code";
                    return false;
                }
            }
            return true;
        }
    }
}