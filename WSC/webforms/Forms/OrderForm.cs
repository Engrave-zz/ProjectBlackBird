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
    public partial class OrderForm : Form
    {
        protected UserAccount userAccount;
        protected Order order;
        private LoginForm _loginForm;
        private Customer customer;
       
        protected InventoryItem inventoryItem;

        public OrderForm(UserAccount user, Order _order, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            order = _order;
            InitializeComponent();

        }

        public OrderForm(UserAccount user, Guid orderId, InventoryItem invItem, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
            order = ApplicationObjects.GetOrder(orderId);
            inventoryItem = invItem;
        }

        public OrderForm(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
        }

        public OrderForm(UserAccount user, LoginForm loginForm, Customer orderCustomer)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
            customer = orderCustomer;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            if(userAccount.PermissionSet.IsWorkSpecialist)
                btnOrderList.Visible = false;
            if (userAccount.PermissionSet.IsOperationsManager)
                btnValidate.Visible = true;
            
            // Make sure check box is not selected at run-ime
            cbSameAsMailing.Checked = false;
            
            //populating text input and label areas of the OrderForm Form
            if (order != null)
            {
                //order Id
                lblOrder.Text = order.OrderId.ToString();
                //Customer Name
                if ((order.Person.FirstName != null && order.Person.FirstName != String.Empty)
                    && (order.Person.LastName != null && order.Person.LastName != String.Empty))
                {
                    txtCustomer.Text = order.Person.FirstName + " " + order.Person.LastName;
                }
                //phone Number
                txtPhoneNumber.Text = (order.Person.PhoneNumber != null) ? order.Person.PhoneNumber.ToString() : "";
                //email
                txtEmail.Text = (order.Person.EmailAddress != null) ? order.Person.EmailAddress: "";
                //Order status ---
                cboxOrderStatus.SelectedItem = order.OrderStatus;
                
                decimal price = 0;
                bool isPrinting = false;
                bool isEngraving = false;
                foreach(OrderItem orderItem in order.ItemList)
                {
                    //Price - SUM of the order items
                    price = price + orderItem.CatalogItem.ItemRetailPrice;
                    //Order Items
                    foreach (string line in orderItem.ToItemDescription())
                    {
                        lstOrderItems.Items.Add(line);
                    }
                    lstOrderItems.Items.Add("------------------------------"); // Divider
                    //Order JobType
                    if(orderItem.CatalogItem.InscriptionType == InscriptionType.Printable)
                    {
                        isPrinting = true;
                    }
                    if (orderItem.CatalogItem.InscriptionType == InscriptionType.Engraveable)
                    {
                        isEngraving = true;
                    }
                }
                if(isPrinting && isEngraving)
                {
                    cboxJobType.SelectedIndex = 2;
                }
                else if(isEngraving)
                {
                    cboxJobType.SelectedIndex = 1;
                }
                else if (isPrinting)
                {
                    cboxJobType.SelectedIndex = 0;
                }
                txtQuote.Text = price.ToString();
                //Date
                lblDate.Text = order.OrderEntryDate.ToString();
            }
            
            // If a customer object was passed into this form, populate customer info onto form fields
            else if (customer != null)
            {   // Populate customer personal information
                txtCustomer.Text = customer.FirstName + " " + customer.LastName;
                txtPhoneNumber.Text = customer.PhoneNumber;
                txtEmail.Text = customer.EmailAddress;

                // Populate customer mailing address information
                txtStreetNumber.Text = customer.MailingAddress.StreetNumber.ToString();
                txtStreetName.Text = customer.MailingAddress.StreetName;
                txtCity.Text = customer.MailingAddress.AddressCity;
                txtState.Text = customer.MailingAddress.AddressState;
                txtZipcode.Text = customer.MailingAddress.AddressZip;

                // Populate customer billing address information                
                txtBillingStreetNumber.Text = customer.BillingAddress.StreetNumber.ToString();
                txtBillingStreetName.Text = customer.BillingAddress.StreetName;
                txtBillingCity.Text = customer.BillingAddress.AddressCity;
                txtBillingState.Text = customer.BillingAddress.AddressState;
                txtBillingZipcode.Text = customer.BillingAddress.AddressZip;
            }

            else
            {
                cboxOrderStatus.SelectedIndex = 0;
                cboxOrderStatus.Enabled = false;
                lblDate.Text = DateTime.Now.ToString();
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            //Forward to validation checklist
            _loginForm.ShowCheckListForm(userAccount, order, _loginForm);
            this.Close();
        }

        private void btnInvalidate_Click(object sender, EventArgs e)
        {
            //Invalid request notification
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //populate objects with UI data
            //ORDER
            OrderStatus orderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), this.cboxOrderStatus.Text);
            order.OrderStatus = orderStatus;

            //CUSTOMER
            char[] delimiterChars = { ' ' };
            string[] names = this.txtCustomer.Text.Split(delimiterChars);

            Address mailingAddress = new Address
            {
                StreetNumber = Convert.ToInt32(this.txtStreetNumber.Text),
                StreetName = this.txtStreetName.Text,
                AddressCity = this.txtCity.Text,
                AddressState = this.txtState.Text,
                AddressZip = this.txtZipcode.Text
            };

            Address billingAddress = new Address
            {
                StreetNumber = Convert.ToInt32(this.txtBillingStreetNumber.Text),
                StreetName = this.txtBillingStreetName.Text,
                AddressCity = this.txtBillingCity.Text,
                AddressState = this.txtBillingState.Text,
                AddressZip = this.txtBillingZipcode.Text
            };

            Customer customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = names[0],
                LastName = names[1],
                PhoneNumber = this.txtPhoneNumber.Text,
                EmailAddress = this.txtEmail.Text,
                MailingAddress = mailingAddress,
                BillingAddress = billingAddress
            };

            order.Person = (Person)customer;

            if (order != null && customer != null)
            {
                int returnValue = ApplicationObjects.CreateCustomer(customer); 

                if (returnValue == 0)
                    returnValue = ApplicationObjects.CreateOrder(order);

                ApplicationObjects.DisplayDataStatus(returnValue);

                if (returnValue == 0)
                {
                    //Return to order list
                    _loginForm.ShowOrdersForm(userAccount, _loginForm);
                    this.Close();
                }
            }
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
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

        private void cbSameAsMailing_CheckedChanged(object sender, EventArgs e)
        {
            grpBillingAddress.Enabled = !cbSameAsMailing.Checked;

            if(cbSameAsMailing.Enabled)
            {
                txtBillingCity.Text = txtCity.Text;
                this.txtBillingState.Text = this.txtState.Text;
                this.txtBillingStreetName.Text = this.txtStreetName.Text;
                this.txtBillingStreetNumber.Text = this.txtStreetNumber.Text;
                this.txtBillingZipcode.Text = this.txtZipcode.Text;
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            if (userAccount.PermissionSet.IsWorkSpecialist)
            {
                _loginForm.ShowWorkSpecialistForm(userAccount, _loginForm);
            }
            else if (userAccount.PermissionSet.IsOperationsManager)
            {
                _loginForm.ShowManagerMainForm(userAccount, _loginForm);
            }
            else if (userAccount.PermissionSet.IsSalesPerson)
            {
                _loginForm.ShowSalesEmployeeForm(userAccount, _loginForm);
            }
            else if (userAccount.PermissionSet.IsWorkSpecialist)
            {
                _loginForm.ShowWorkSpecialistForm(userAccount, _loginForm);
            }

            this.Close();
        }
    }
}
