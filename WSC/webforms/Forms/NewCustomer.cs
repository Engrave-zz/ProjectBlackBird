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
using System.Transactions;

namespace WSC
{
    public partial class NewCustomer : Form
    {
        protected LoginForm _loginForm;
        protected UserAccount userAccount;

        public NewCustomer(UserAccount user, LoginForm loginForm)
        {
            _loginForm = loginForm;
            userAccount = user;
            InitializeComponent();
        }

        private void ClearFields()
        {
            this.tbx_FirstName.Text = "";
            this.tbx_LastName.Text = "";
            this.tbx_PhoneNumber.Text = "";
            this.tbx_EMail.Text = "";

            this.tbx_MailingStreetNumber.Text = "";
            this.tbx_MailingStreetName.Text = "";
            this.tbx_MailingCity.Text = "";
            this.tbx_MailingState.Text = "";
            this.tbx_MailingZipCode.Text = "";

            this.tbx_BillingStreetNumber.Text = "";
            this.tbx_BillingStreetName.Text = "";
            this.tbx_BillingCity.Text = "";
            this.tbx_BillingState.Text = "";
            this.tbx_BillingZipCode.Text = "";
        }

       // Begin CREATE CUSTOMER button click event
        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            // BEGIN USER INPUT DATA VALIDATION.....
            // Verify that PERSONAL information was not left blank
            if ((tbx_FirstName.Text == "") || (tbx_LastName.Text == "") || (tbx_PhoneNumber.Text == "") || (tbx_EMail.Text == ""))
            {   // If any personal information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the personal fields and try again.");
                return;
            }

            // Verify that MAILING address information was not left blank
            if ((tbx_MailingStreetNumber.Text == "") || (tbx_MailingStreetName.Text == "") || (tbx_MailingCity.Text == "") ||
                (tbx_MailingState.Text == "") || (tbx_MailingZipCode.Text == ""))
            {   // If any mailing address information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the mailing address fields and try again.");
                return;
            }

            // Verify that BILLING address information was not left blank
            if ((tbx_BillingStreetNumber.Text == "") || (tbx_BillingStreetName.Text == "") || (tbx_BillingCity.Text == "") ||
                (tbx_BillingState.Text == "") || (tbx_BillingZipCode.Text == ""))
            {   // If any billing address information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the billing address fields and try again.");
                return;
            }
            
            // Variable used in TryParse functions
            long number;

            // Validate numeric input for phone number
            if ((!long.TryParse((tbx_PhoneNumber.Text), out number)) || (tbx_PhoneNumber.Text.Length != 10))
            {   // If phone number input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid phone number entered.  Please enter 10 digits (no dashes) & try again.");
                return;
            }

            // validate email address format
            if (!ApplicationObjects.EmailIsValid(tbx_EMail.Text))
            {   // If email address was not in specified format, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid e-mail address entered.  Please try again.");
                return;
            }
            
            // Validate numeric input for street numbers
            if ((!long.TryParse((tbx_MailingStreetNumber.Text), out number)) || (!long.TryParse((tbx_BillingStreetNumber.Text), out number)))
            {   // If street number input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid street number entered.  Please enter only numeric values & try again.");
                return;
            }
            
            // Verify that the state is only 2 characters
            if ((tbx_MailingState.Text.Length != 2) || (tbx_BillingState.Text.Length != 2))
            {   // If state input does not have only 2 characters, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid state entered.  Please enter a 2-letter state abbreviation & try again.");
                return;
            }

            // Validate numeric input for zip codes
            if ((!long.TryParse((tbx_MailingZipCode.Text), out number)) || (!long.TryParse((tbx_BillingZipCode.Text), out number)))
            {   // If zip code input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid zip code entered.  Please enter only numeric values & try again.");
                return;
            }

            // If zip is numeric, validate only 5 digits
            else if ((tbx_MailingZipCode.Text.Length != 5) || (tbx_BillingZipCode.Text.Length != 5))
            {   // If zip code does not have only 5 characters, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid zip code entered.  Please enter only 5 digits & try again.");
                return;
            }
            // .....END USER INPUT DATA VALIDATION
            
            
            // Populate customer object with user input
            Customer customer = new Customer();
            customer.FirstName = tbx_FirstName.Text;
            customer.LastName = tbx_LastName.Text;
            customer.PhoneNumber = tbx_PhoneNumber.Text;
            customer.EmailAddress = tbx_EMail.Text;

            // Populate mailing address object with user input
            Address mailingAddress = new Address();
            mailingAddress.PersonId = customer.PersonId;
            mailingAddress.StreetNumber = int.Parse(tbx_MailingStreetNumber.Text);
            mailingAddress.StreetName = tbx_MailingStreetName.Text;
            mailingAddress.AddressCity = tbx_MailingCity.Text;
            mailingAddress.AddressState = tbx_MailingState.Text;
            mailingAddress.AddressZip = tbx_MailingZipCode.Text;
            mailingAddress.AddressType = AddressType.Mailing;

            // Populate billing address object with user input
            Address billingAddress = new Address();
            billingAddress.PersonId = customer.PersonId;
            billingAddress.StreetNumber = int.Parse(tbx_BillingStreetNumber.Text);
            billingAddress.StreetName = tbx_BillingStreetName.Text;
            billingAddress.AddressCity = tbx_BillingCity.Text;
            billingAddress.AddressState = tbx_BillingState.Text;
            billingAddress.AddressZip = tbx_BillingZipCode.Text;
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
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return;
                }

                // Write CUSTOMER record to database
                BusinessObjects _customerBusinessObject = new BusinessObjects();
                returnValue = _customerBusinessObject.InsertCustomer(customer);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return;
                }
                
                // Write MAILING ADDRESS record to database
                BusinessObjects _mailingAddressBusinessObject = new BusinessObjects();
                returnValue = _mailingAddressBusinessObject.InsertAddress(mailingAddress);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return;
                }

                // Write BILLING ADDRESS record to database
                BusinessObjects _billingAddressBusinessObject = new BusinessObjects();
                returnValue = _billingAddressBusinessObject.InsertAddress(billingAddress);
                if (returnValue == 1)
                {   // If insert fails, rollback transaction & display error message
                    scope.Dispose();
                    ApplicationObjects.DisplayDataStatus(returnValue);
                    return;
                }

                // Committ data transaction & display success message
                scope.Complete();
                ApplicationObjects.DisplayDataStatus(returnValue);
            }// End transaction

            _loginForm.ShowCustomerInfoForm(userAccount, _loginForm);
            this.Close();
        }// End CREATE CUSTOMER button click event

        private void chkBillingSameAsMailing_CheckedChanged(object sender, EventArgs e)
        {
            gbx_BillingAddress.Enabled = !chkBillingSameAsMailing.Checked;

            if (chkBillingSameAsMailing.Checked)
            {
                tbx_BillingStreetNumber.Text = tbx_MailingStreetNumber.Text;
                tbx_BillingStreetName.Text = tbx_MailingStreetName.Text;
                tbx_BillingCity.Text = tbx_MailingCity.Text;
                tbx_BillingState.Text = tbx_MailingState.Text;
                tbx_BillingZipCode.Text = tbx_MailingZipCode.Text;
            }
            else
            {
                tbx_BillingStreetNumber.Text = "";
                tbx_BillingStreetName.Text = "";
                tbx_BillingCity.Text = "";
                tbx_BillingState.Text = "";
                tbx_BillingZipCode.Text = "";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _loginForm.ShowCustomerInfoForm(userAccount, _loginForm);
            this.Close();
        }
    }
}
