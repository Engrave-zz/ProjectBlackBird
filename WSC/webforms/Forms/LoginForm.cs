using WSC.ApplicationLayer;
using BusinessLayer;
using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSC
{
    public partial class LoginForm : Form
    {
        //Forms
        public Checklist checkListForm;
        public CustomerInfoForm customerInfoForm;
        public NewCustomer newCustomerForm;
        public ManagerMain managerMainForm;
        public ManageUserForm manageUserForm;
        public NewUser newUser;
        public OrderForm orderForm;
        public Orders ordersForm;
        public PasswordChangeForm passwordChangeForm;
        public SalesEmployeeForm salesEmployeeForm;
        public StockClerkForm stockClerkForm;
        public WorkSpecialistForm workSpecialistForm;
        public DashBoardSelectionForm dashBoardSelectionForm;

        //User Security
        protected UserAccount userAccount;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Do nothing if user name or password is empty.
            if ((txtUserName.Text == String.Empty) || (txtUserName.Text == null))
                return;
            if ((txtPassword.Text == String.Empty) || (txtPassword.Text == null))
                return;
            
            userAccount = ApplicationObjects.AuthenticateUser(txtUserName.Text, txtPassword.Text);
            
            if(userAccount.UserName == "invalid" && userAccount.PasswordHash == "invalid")
            {
                MessageBox.Show("Failed to authenticate with inputted username and password."
                    ,"Authentication Failed"
                    ,MessageBoxButtons.OK
                    ,MessageBoxIcon.Exclamation);
                Logout();
                return;
            }
            if (userAccount.HighestPermission == null)
            {
                MessageBox.Show("Invalid permissions token. Please contact your manager."
                    , "Authentication Failed"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }

            //Auto forward them to the highest permission user page.
            switch (userAccount.HighestPermission)
            {
                case (Permission.OperationsManager):
                    ShowDashBoardSelectionForm(userAccount, this);
                    this.Hide();
                    break;
                case (Permission.SalesPerson):
                    ShowSalesEmployeeForm(userAccount, this);
                    this.Hide();
                    break;
                case (Permission.WorkSpecialist):
                    ShowWorkSpecialistForm(userAccount, this);
                    this.Hide();
                    break;
                case (Permission.StockClerk):
                    ShowStockClerkForm(userAccount, this);
                    this.Hide();
                    break;
            }
        }

        private void lnkChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ShowPasswordChangeForm(this);
        }

        public void Logout()
        {
            userAccount = null;
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";

            this.Show();
        }

        public void ShowDashBoardSelectionForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name,"DashBoardSelectionForm") == 0) { form.Show(); return; }
            }

            dashBoardSelectionForm = new DashBoardSelectionForm(user, loginForm);
            dashBoardSelectionForm.Show();
        }

        public void ShowCheckListForm(UserAccount user, Order order, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "Checklist") == 0) { form.Show(); return; }
            }
            
            checkListForm = new Checklist(user, order, loginForm);
            checkListForm.Show();
        }

        public void ShowCustomerInfoForm(UserAccount user, LoginForm loginForm)
        {            
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "CustomerInfoForm") == 0) { form.Show(); return; }
            }

            customerInfoForm = new CustomerInfoForm(user, loginForm);
            customerInfoForm.Show();
        }

        public void ShowManagerMainForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "ManagerMain") == 0) { form.Show(); return; }
            }

            managerMainForm = new ManagerMain(user, loginForm);
            managerMainForm.Show();
        }

        public void ShowManageUserForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "ManageUserForm") == 0) { form.Show(); return; }
            }

            manageUserForm = new ManageUserForm(user, loginForm);
            manageUserForm.Show();
        }

        public void ShowNewUserForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "NewUser") == 0) { form.Show(); return; }
            }

            newUser = new NewUser(user, loginForm);
            newUser.Show();
        }

        public void ShowOrderForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "OrderForm") == 0) { form.Show(); return; }
            }

            orderForm = new OrderForm(user, loginForm);
            orderForm.Show();
        }

        public void ShowOrderForm(UserAccount user, Order order, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "OrderForm") == 0) { form.Show(); return; }
            }

            orderForm = new OrderForm(user, order, loginForm);
            orderForm.Show();
        }

        public void ShowOrderForm(UserAccount user,LoginForm loginForm, Customer customer)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "OrderForm") == 0) { form.Show(); return; }
            }

            orderForm = new OrderForm(user, loginForm, customer);
            orderForm.Show();
        }

        public void ShowOrderForm(UserAccount user, Guid orderId, InventoryItem inventoryItem, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "OrderForm") == 0) { form.Show(); return; }
            }

            orderForm = new OrderForm(user, orderId, inventoryItem, loginForm);
            orderForm.Show();
        }

        public void ShowOrdersForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "Orders") == 0) { form.Show(); return; }
            }

            ordersForm = new Orders(user, loginForm);
            ordersForm.Show();
        }

        public void ShowPasswordChangeForm(LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "PasswordChangeForm") == 0) { form.Show(); return; }
            }

            passwordChangeForm = new PasswordChangeForm(loginForm);
            passwordChangeForm.Show();
        }

        public void ShowSalesEmployeeForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "SalesEmployeeForm") == 0) { form.Show(); return; }
            }

            salesEmployeeForm = new SalesEmployeeForm(user, loginForm);
            salesEmployeeForm.Show();
        }

        public void ShowStockClerkForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "StockClerkForm") == 0) { form.Show(); return; }
            }

            stockClerkForm = new StockClerkForm(user, loginForm);
            stockClerkForm.Show();
        }

        public void ShowWorkSpecialistForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "WorkSpecialistForm") == 0) { form.Show(); return; }
            }

            workSpecialistForm = new WorkSpecialistForm(user, loginForm);
            workSpecialistForm.Show();
        }

        public void ShowNewCustomerForm(UserAccount user, LoginForm loginForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (String.Compare(form.Name, "NewCustomer") == 0) { form.Show(); return; }
            }

            newCustomerForm = new NewCustomer(user, loginForm);
            newCustomerForm.Show();
        }
    }
}
