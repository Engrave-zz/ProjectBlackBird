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
using System.Transactions;

namespace WSC
{
    public partial class CustomerInfoForm : Form
    {
        // Local class/form variables that are used in more than one sub-procedure
        protected UserAccount userAccount;
        private LoginForm _loginForm;
        private List<Customer> customers = new List<Customer>();
        private long longValidation;
        private Guid guidValidation;

        
        // ACTION EVENTS

        // FORM LOAD event
        public CustomerInfoForm(UserAccount user, LoginForm loginForm)
        {
            _loginForm = loginForm;
            userAccount = user;
            InitializeComponent();
            //Make sure all form fields are clear/empty
            ClearResults();
            //Make all customer data fields read-only by default
            MakeReadOnly();
            //Hide save changes button
            btn_SaveChanges.Visible = false;
            cbx_CustomerResultsList.Visible = false;
            cbx_SameAsMailing.Visible = false;
        }

        // CREATE CUSTOMER BUTTON click event
        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {   // Send user to NewCustomer form
            _loginForm.ShowNewCustomerForm(userAccount, _loginForm);
            this.Close();
        }

        // CUSTOMER SEARCH BUTTON click event
        private void btn_CustomerSearch_Click(object sender, EventArgs e)
        {
            // Make sure all controls are visible
            gbx_SearchCriteria.Visible = true;
            btn_ViewOrders.Visible = true;
            btn_CreateCustomer.Visible = true;
            btn_CustomerSearch.Visible = true; ;
            btn_MainPage.Visible = true;
            btn_EnableEditing.Visible = true;
            btn_NewOrder.Visible = true;
            btn_SaveChanges.Visible = false;
            lbl_CustomerResultSort.Visible = false;
            
            //Make all customer data fields read-only by default
            MakeReadOnly();

            //Reset form to prepare for new search results
            ClearResults();

            // Verify that a query type was selected by the user
            if ((cbx_CustomerSearchType.SelectedItem == null) || (tbx_CustomerSearchInput.Text == null))
            {
                ApplicationObjects.DisplayInvalidInput("Please make sure all search criterea is filled out.");
                return;
            }

            // SEARCH BY CUSTOMER FIRST NAME - Chech to see if user entered a customer first name
            else if (cbx_CustomerSearchType.SelectedItem.ToString() == "First Name")
            {
                // Generate a list of customers that match the first name entered by the user
                customers = ApplicationObjects.GetCustomerByFirstName(tbx_CustomerSearchInput.Text);

                // If customer list is empty, display no results found
                if (customers == null)
                {
                    lbl_CustomerResultsFound.Text = "No results found!";
                }

                else
                {
                    // Populate the search results combo box with result first and last names
                    foreach (Customer customer in customers)
                    {
                        cbx_CustomerResultsList.Items.Add(customer.FirstName + " " + customer.LastName);
                    }

                    // Change result label to show how results are listed in the results combobox
                    lbl_CustomerResultSort.Text = "results listed by [first name] [last name]";
                    lbl_CustomerResultsFound.Text = cbx_CustomerResultsList.Items.Count.ToString() + " results found!";
                }
            }

            // SEARCH BY CUSTOMER LAST NAME - Check to see if user entered a customer last name
            else if (cbx_CustomerSearchType.SelectedItem.ToString() == "Last Name")
            {
                // Generate a list of customers that match the last name entered by the user
                customers = ApplicationObjects.GetCustomerByLastName(tbx_CustomerSearchInput.Text);

                if (customers == null)
                {
                    lbl_CustomerResultsFound.Text = "No results found!";
                }

                else
                {
                    // Populate the search results combo box with result last, first names
                    foreach (Customer customer in customers)
                    {
                        cbx_CustomerResultsList.Items.Add(customer.LastName + ", " + customer.FirstName);
                    }

                    // Change result label to show how results are listed in the results combobox
                    lbl_CustomerResultSort.Text = "results listed by [last name], [first name]";
                    lbl_CustomerResultsFound.Text = cbx_CustomerResultsList.Items.Count.ToString() + " results found!";
                }
            }

            // SEARCH BY CUSTOMER ID - Check to see if user entered a customer ID
            else if (cbx_CustomerSearchType.SelectedItem.ToString() == "Customer ID")
            {    //if invalid Guid, display error
                if (!Guid.TryParse((tbx_CustomerSearchInput.Text), out guidValidation))
                {
                    ApplicationObjects.DisplayInvalidInput("Invalid customer ID.  Please try again.");
                    return;
                }

                //If valid Guid, continue with search
                else
                {
                    // Generate a list of customers that match the customer ID entered by the user
                    customers = ApplicationObjects.GetCustomerByCustomerId(Guid.Parse(tbx_CustomerSearchInput.Text));

                    if (customers == null)
                    {
                        lbl_CustomerResultsFound.Text = "No results found!";
                    }

                    else
                    {
                        // Populate the search results combo box with result last, first names
                        foreach (Customer customer in customers)
                        {
                            cbx_CustomerResultsList.Items.Add(customer.CustomerId.ToString());
                        }

                        // Change result label to show how results are listed in the results combobox
                        lbl_CustomerResultSort.Text = "results listed by [customer id]";
                        lbl_CustomerResultsFound.Text = cbx_CustomerResultsList.Items.Count.ToString() + " results found!";
                    }
                }
            }

            // SEARCH BY CUSTOMER PHONE NUMBER - Check to see if user entered a customer phone number
            else if (cbx_CustomerSearchType.SelectedItem.ToString() == "Phone Number")
            {
                // Validate numeric input for phone number
                if ((!long.TryParse((tbx_CustomerSearchInput.Text), out longValidation)) || (tbx_CustomerSearchInput.Text.Length != 10))
                {
                    ApplicationObjects.DisplayInvalidInput("Invalid phone number entered.  Please enter 10 digits (no dashes) & try again.");
                    return;
                }
                else
                {
                    // Generate a list of customers that match the phone number entered by the user
                    customers = ApplicationObjects.GetCustomerByPhoneNumber(tbx_CustomerSearchInput.Text);

                    // If customer list is empty, display no results found
                    if (customers == null)
                    {
                        lbl_CustomerResultsFound.Text = "No results found!";
                    }

                    else
                    {
                        // Populate the search results combo box with result last, first names
                        foreach (Customer customer in customers)
                        {
                            cbx_CustomerResultsList.Items.Add(customer.PhoneNumber);
                        }

                        // Change result label to show how results are listed in the results combobox
                        lbl_CustomerResultSort.Text = "results listed by [phone number]";
                        lbl_CustomerResultsFound.Text = cbx_CustomerResultsList.Items.Count.ToString() + " results found!";
                    }
                }
            }

            // SEARCH BY CUSTOMER EMAIL ADDRESS - Check to see if user entered a customer email address
            else if (cbx_CustomerSearchType.SelectedItem.ToString() == "Email Address")
            {
                // validate email address format
                if (!ApplicationObjects.EmailIsValid(tbx_CustomerSearchInput.Text))
                {
                    ApplicationObjects.DisplayInvalidInput("Invalid e-mail address entered.  Please try again.");
                    return;
                }
                else
                {
                    // Generate a list of customers that match the email address entered by the user
                    customers = ApplicationObjects.GetCustomerByEmail(tbx_CustomerSearchInput.Text);

                    // If customer list is empty, display no results found
                    if (customers == null)
                    {
                        lbl_CustomerResultsFound.Text = "No results found!";
                    }

                    else
                    {
                        // Populate the search results combo box with result last, first names
                        foreach (Customer customer in customers)
                        {
                            cbx_CustomerResultsList.Items.Add(customer.EmailAddress);
                        }

                        // Change result label to show how results are listed in the results combobox
                        lbl_CustomerResultSort.Text = "results listed by [email address]";
                        lbl_CustomerResultsFound.Text = cbx_CustomerResultsList.Items.Count.ToString() + " results found!";
                    }
                }
            }
            // If the customer list is empty (no results found)
            if (customers.Count == 0)
            {   // Display no results found
                lbl_CustomerResultsFound.Text = "No results found!";
                return;
            }
            
            // If customer list is not empty, display results
            else
            {
                lbl_CustomerResultSort.Visible = true;
                cbx_CustomerResultsList.Visible = true;
                cbx_CustomerResultsList.SelectedIndex = 0;

                //Populate Customer details for first search result
                PopulateCustomerDetailsWithSelectedIndex();
            }           
        }

        // CUSTOMER SEARCH RESULT COMBO BOX index changed event
        private void cbx_CustomerResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate Customer fields with data drom selected customer in combobox when selected item is changed
            PopulateCustomerDetailsWithSelectedIndex();
        }

        // SAVE CHANGES BUTTON click event - Save changes made to currently selected customer
        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            // BEGIN USER INPUT DATA VALIDATION.....
            // Verify that PERSONAL information was not left blank
            if ((this.tbx_FirstName.Text == "") || (this.tbx_LastName.Text == "") || (this.tbx_PhoneNumber.Text == "") || (this.tbx_EMail.Text == ""))
            {   // If any personal information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the personal fields and try again.");
                return;
            }

            // Verify that MAILING address information was not left blank
            if ((this.tbx_MailingStreetNumber.Text == "") || (this.tbx_MailingStreetName.Text == "") || (this.tbx_MailingCity.Text == "") ||
                (this.tbx_MailingState.Text == "") || (this.tbx_MailingZipCode.Text == ""))
            {   // If any mailing address information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the mailing address fields and try again.");
                return;
            }

            // Verify that BILLING address information was not left blank
            if ((this.tbx_BillingStreetNumber.Text == "") || (this.tbx_BillingStreetName.Text == "") || (this.tbx_BillingCity.Text == "") ||
                (this.tbx_BillingState.Text == "") || (this.tbx_BillingZipCode.Text == ""))
            {   // If any billing address information was blank, display error and break code
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have filled out all of the billing address fields and try again.");
                return;
            }

            // Validate numeric input for phone number
            if ((!long.TryParse((this.tbx_PhoneNumber.Text), out longValidation)) || (this.tbx_PhoneNumber.Text.Length != 10))
            {   // If phone number input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid phone number entered.  Please enter 10 digits (no dashes) & try again.");
                return;
            }

            // validate email address format
            if (!ApplicationObjects.EmailIsValid(this.tbx_EMail.Text))
            {   // If email address was not in specified format, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid e-mail address entered.  Please try again.");
                return;
            }

            // Validate numeric input for street numbers
            if ((!long.TryParse((this.tbx_MailingStreetNumber.Text), out longValidation)) || (!long.TryParse((this.tbx_BillingStreetNumber.Text), out longValidation)))
            {   // If street number input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid street number entered.  Please enter only numeric values & try again.");
                return;
            }

            // Verify that the state is only 2 characters
            if ((this.tbx_MailingState.Text.Length != 2) || (this.tbx_BillingState.Text.Length != 2))
            {   // If state input does not have only 2 characters, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid state entered.  Please enter a 2-letter state abbreviation & try again.");
                return;
            }

            // Validate numeric input for zip codes
            if ((!long.TryParse((this.tbx_MailingZipCode.Text), out longValidation)) || (!long.TryParse((this.tbx_BillingZipCode.Text), out longValidation)))
            {   // If zip code input was not numeric, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid zip code entered.  Please enter only numeric values & try again.");
                return;
            }

            // If zip is numeric, validate only 5 digits
            else if ((this.tbx_MailingZipCode.Text.Length != 5) || (this.tbx_BillingZipCode.Text.Length != 5))
            {   // If zip code does not have only 5 characters, display error and break code
                ApplicationObjects.DisplayInvalidInput("Invalid zip code entered.  Please enter only 5 digits & try again.");
                return;
            }
            // .....END USER INPUT DATA VALIDATION

            // Take the user input from the text boxes and update the currently selected...
            // ...customer's information within the customer object
            PopulateCustomerObjectWithDetails();

            // Send update request to business layer
            int returnValue = ApplicationObjects.UpdateCustomer(customers[cbx_CustomerResultsList.SelectedIndex]);

            // Re-run search
            if (returnValue == 0)
            {   // If update successfull, re-run search based on the customerID of the customer that was just updated
                cbx_CustomerSearchType.SelectedIndex = 2;
                tbx_CustomerSearchInput.Text = customers[cbx_CustomerResultsList.SelectedIndex].CustomerId.ToString();
            }

            // Perform search button click to re-populate search results
            gbx_SearchCriteria.Visible = true;
            btn_ViewOrders.Visible = true;
            btn_CreateCustomer.Visible = true;
            btn_CustomerSearch.Visible = true; ;
            btn_MainPage.Visible = true;
            btn_EnableEditing.Visible = true;
            btn_NewOrder.Visible = true;
            btn_SaveChanges.Visible = false;
            lbl_CustomerResultSort.Visible = false;
            cbx_SameAsMailing.Visible = true;
            btn_CustomerSearch.PerformClick();
        }

        // VIEW CUSTOMER ORDERS BUTTON click event
        private void btn_ViewOrders_Click(object sender, EventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }

        // CREATE NEW ORDER BUTTON click event - forward selected customer to New Order Form
        private void btn_NewOrder_Click(object sender, EventArgs e)
        {
            if (cbx_CustomerResultsList.SelectedIndex >= 0)
                _loginForm.ShowOrderForm(userAccount, _loginForm, customers[cbx_CustomerResultsList.SelectedIndex]);
            else
                _loginForm.ShowOrderForm(userAccount, _loginForm);

            this.Close();
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            //if statement for manager user account is true then goes to manager page or else sales employee page

            if (userAccount.PermissionSet.IsOperationsManager)
                _loginForm.ShowManagerMainForm(userAccount, _loginForm);


            else if (userAccount.PermissionSet.IsSalesPerson)
                _loginForm.ShowSalesEmployeeForm(userAccount, _loginForm);

            this.Close();
        }
        
        // ENABLE EDITING BUTTON click event - Enable the currently selected customer to be edited
        private void btn_EnableEditing_Click(object sender, EventArgs e)
        {
            // Display instruction message to user
            MessageBox.Show("After editing the customer data, click the [Save Changes] button to finalize your changes",
                       "Editing has been enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Make textboxes editable
            RemoveReadOnly();

            // Change label at the top of the form, while editing is enabled
            lbl_CustomerSearch.Text = "Customer Editing Enabled";

            // Hide search constrols, to prevent user from altering search criteria in the...
            // ...middle of a customer-edit
            gbx_SearchCriteria.Visible = false;

            // Hide all other buttons until user is done editing the currently selected customer
            btn_ViewOrders.Visible = false;
            btn_CreateCustomer.Visible = false;
            btn_CustomerSearch.Visible = false;
            btn_MainPage.Visible = false;
            btn_EnableEditing.Visible = false;
            btn_NewOrder.Visible = false;
            btn_SaveChanges.Visible = true;

            cbx_SameAsMailing.Visible = true;
        }

        // SAME AS MAILING CHECKBOX click event
        private void cbx_SameAsMailing_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_SameAsMailing.Checked)
            {
                //set all billing address text boxes to match the mailing address text boxes
                tbx_BillingStreetNumber.Text = tbx_MailingStreetNumber.Text;
                tbx_BillingStreetName.Text = tbx_MailingStreetName.Text;
                tbx_BillingCity.Text = tbx_MailingCity.Text;
                tbx_BillingState.Text = tbx_MailingState.Text;
                tbx_BillingZipCode.Text = tbx_MailingZipCode.Text;
            }
        }

        
        // UTILITY METHODS

        // Make all customer data fields read-only
        private void MakeReadOnly()
        {
            this.tbx_FirstName.ReadOnly = true;
            this.tbx_LastName.ReadOnly = true;
            this.tbx_PhoneNumber.ReadOnly = true;
            this.tbx_EMail.ReadOnly = true;

            this.tbx_MailingStreetNumber.ReadOnly = true;
            this.tbx_MailingStreetName.ReadOnly = true;
            this.tbx_MailingCity.ReadOnly = true;
            this.tbx_MailingState.ReadOnly = true;
            this.tbx_MailingZipCode.ReadOnly = true;

            this.tbx_BillingStreetNumber.ReadOnly = true;
            this.tbx_BillingStreetName.ReadOnly = true;
            this.tbx_BillingCity.ReadOnly = true;
            this.tbx_BillingState.ReadOnly = true;
            this.tbx_BillingZipCode.ReadOnly = true;

            this.tbx_FirstName.BackColor = SystemColors.ScrollBar;
            this.tbx_LastName.BackColor = SystemColors.ScrollBar;
            this.tbx_PhoneNumber.BackColor = SystemColors.ScrollBar;
            this.tbx_EMail.BackColor = SystemColors.ScrollBar;

            this.tbx_MailingStreetNumber.BackColor = SystemColors.ScrollBar;
            this.tbx_MailingStreetName.BackColor = SystemColors.ScrollBar;
            this.tbx_MailingCity.BackColor = SystemColors.ScrollBar;
            this.tbx_MailingState.BackColor = SystemColors.ScrollBar;
            this.tbx_MailingZipCode.BackColor = SystemColors.ScrollBar;

            this.tbx_BillingStreetNumber.BackColor = SystemColors.ScrollBar;
            this.tbx_BillingStreetName.BackColor = SystemColors.ScrollBar;
            this.tbx_BillingCity.BackColor = SystemColors.ScrollBar;
            this.tbx_BillingState.BackColor = SystemColors.ScrollBar;
            this.tbx_BillingZipCode.BackColor = SystemColors.ScrollBar;
        }

        // Make all customer data fields editable
        private void RemoveReadOnly()
        {
            this.tbx_FirstName.ReadOnly = false;
            this.tbx_LastName.ReadOnly = false;
            this.tbx_PhoneNumber.ReadOnly = false;
            this.tbx_EMail.ReadOnly = false;

            this.tbx_MailingStreetNumber.ReadOnly = false;
            this.tbx_MailingStreetName.ReadOnly = false;
            this.tbx_MailingCity.ReadOnly = false;
            this.tbx_MailingState.ReadOnly = false;
            this.tbx_MailingZipCode.ReadOnly = false;

            this.tbx_BillingStreetNumber.ReadOnly = false;
            this.tbx_BillingStreetName.ReadOnly = false;
            this.tbx_BillingCity.ReadOnly = false;
            this.tbx_BillingState.ReadOnly = false;
            this.tbx_BillingZipCode.ReadOnly = false;

            this.tbx_FirstName.BackColor = SystemColors.Window;
            this.tbx_LastName.BackColor = SystemColors.Window;
            this.tbx_PhoneNumber.BackColor = SystemColors.Window;
            this.tbx_EMail.BackColor = SystemColors.Window;

            this.tbx_MailingStreetNumber.BackColor = SystemColors.Window;
            this.tbx_MailingStreetName.BackColor = SystemColors.Window;
            this.tbx_MailingCity.BackColor = SystemColors.Window;
            this.tbx_MailingState.BackColor = SystemColors.Window;
            this.tbx_MailingZipCode.BackColor = SystemColors.Window;

            this.tbx_BillingStreetNumber.BackColor = SystemColors.Window;
            this.tbx_BillingStreetName.BackColor = SystemColors.Window;
            this.tbx_BillingCity.BackColor = SystemColors.Window;
            this.tbx_BillingState.BackColor = SystemColors.Window;
            this.tbx_BillingZipCode.BackColor = SystemColors.Window;
        }

        // Reset form fields and prepare for new search
        private void ClearResults()
        {
            //Clear Customer details
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

            btn_SaveChanges.Visible = false;                // Hide save changes button
            lbl_CustomerResultsFound.Text = "";           // Clear contents of search result label
            cbx_CustomerResultsList.Items.Clear();          // Clear old search results from results combo box
            cbx_CustomerResultsList.Text = "";              // Clear text from visible combobox area
            customers = null;
            lbl_CustomerResultSort.Text = "";
        }

        // Populates customer data-related text boxes with the customer data that... 
        // ...pertains to the selected item in the results combobox
        private void PopulateCustomerDetailsWithSelectedIndex()
        {
            this.tbx_FirstName.Text = customers[cbx_CustomerResultsList.SelectedIndex].FirstName;
            this.tbx_LastName.Text = customers[cbx_CustomerResultsList.SelectedIndex].LastName;
            this.tbx_PhoneNumber.Text = customers[cbx_CustomerResultsList.SelectedIndex].PhoneNumber.ToString();
            this.tbx_EMail.Text = customers[cbx_CustomerResultsList.SelectedIndex].EmailAddress;

            this.tbx_MailingStreetNumber.Text = customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.StreetNumber.ToString();
            this.tbx_MailingStreetName.Text = customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.StreetName;
            this.tbx_MailingCity.Text = customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressCity;
            this.tbx_MailingState.Text = customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressState;
            this.tbx_MailingZipCode.Text = customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressZip.ToString();

            this.tbx_BillingStreetNumber.Text = customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.StreetNumber.ToString();
            this.tbx_BillingStreetName.Text = customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.StreetName;
            this.tbx_BillingCity.Text = customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressCity;
            this.tbx_BillingState.Text = customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressState;
            this.tbx_BillingZipCode.Text = customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressZip.ToString();
        }

        // Populates the customer object that pretains with the selected index of the results combobox,... 
        // ...with data from the text boxes
        private void PopulateCustomerObjectWithDetails()
        {
            customers[cbx_CustomerResultsList.SelectedIndex].FirstName = this.tbx_FirstName.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].LastName = this.tbx_LastName.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].PhoneNumber = this.tbx_PhoneNumber.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].EmailAddress = this.tbx_EMail.Text;

            customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.StreetNumber = int.Parse(this.tbx_MailingStreetNumber.Text);
            customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.StreetName = this.tbx_MailingStreetName.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressCity = this.tbx_MailingCity.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressState = this.tbx_MailingState.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].MailingAddress.AddressZip = this.tbx_MailingZipCode.Text;

            customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.StreetNumber = int.Parse(this.tbx_BillingStreetNumber.Text);
            customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.StreetName = this.tbx_BillingStreetName.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressCity = this.tbx_BillingCity.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressState = this.tbx_BillingState.Text;
            customers[cbx_CustomerResultsList.SelectedIndex].BillingAddress.AddressZip = this.tbx_BillingZipCode.Text;
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
    }



}
