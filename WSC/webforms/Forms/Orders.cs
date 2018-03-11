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
    public partial class Orders : Form
    {
        protected UserAccount userAccount;
        private LoginForm _loginForm;
        private DataTable orderTable;

        public Orders(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
            GetOrderList();
        }

        public void GetOrderList()
        {

        }

        // REVIEW ORDER DETAILS BUTTON click event
        private void btnReviewOrder_Click(object sender, EventArgs e)
        {
            //if statement for user account: manager or sales oriented forms
            Guid selectedOrderId = new Guid(dgvOrders.Rows[dgvOrders.SelectedRows[0].Index].Cells[0].Value.ToString());
            Order order = ApplicationObjects.GetOrder(selectedOrderId);

            _loginForm.ShowOrderForm(userAccount, order, _loginForm);
            this.Close();
        }

        // CREATE NEW ORDER BUTTON click event
        private void btnOrderForm_Click(object sender, EventArgs e)
        {
            //if statement for user account: manager or sales oriented forms
            if (userAccount.PermissionSet.IsOperationsManager)
                _loginForm.ShowOrderForm(userAccount, _loginForm);


            else if (userAccount.PermissionSet.IsSalesPerson)
                _loginForm.ShowSalesEmployeeForm(userAccount, _loginForm);

            this.Close();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //**may need work** clickable cell row content
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            
            //if statement for user account: manager or sales oriented forms
            /*ManagerMain ManagerMain = new ManagerMain(userAccount);
            SalesEmployeeForm salesEmployeeForm = new SalesEmployeeForm(userAccount);
            this.Close();
            if (userAccount.PermissionSet.IsOperationsManager == true)
                ManagerMain.Show();


            else if (userAccount.PermissionSet.IsSalesPerson)
                salesEmployeeForm.Show();
            */
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //update the customer data grid whenever text change occurs
            LoadOrders();
            if ((dgvOrders.Rows.Count >= 1) && (txtSearch.Text != String.Empty))
            {
                List<string> values = new List<string>();
                string str = cbSearchFields.SelectedItem.ToString();
                string value;
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (cbSearchFields.SelectedItem.ToString() == "Order Status")
                        value = ((OrderStatus)row.Cells[str].Value).ToString();
                    else
                        value = row.Cells[str].Value.ToString();

                    values.Add(value);
                }

                foreach (string selectedValue in values)
                {
                    if (!(selectedValue.ToLower().Contains(txtSearch.Text.ToLower())))
                    {
                        DataGridViewRow row;
                        if (cbSearchFields.SelectedItem.ToString() == "Order Status")
                        {
                            row = dgvOrders.Rows
                                                .Cast<DataGridViewRow>()
                                                .Where(r => ((OrderStatus)r.Cells[str].Value).ToString().Equals(selectedValue))
                                                .First();
                        }
                        else 
                        {
                            row = dgvOrders.Rows
                                                .Cast<DataGridViewRow>()
                                                .Where(r => r.Cells[str].Value.ToString().Equals(selectedValue))
                                                .First();
                        }

                        dgvOrders.Rows.Remove(dgvOrders.Rows[row.Index]);
                    }
                }
            }
        }

        private void btnMainPage_Click_1(object sender, EventArgs e)
        {
            //if statement for user account: manager or sales oriented forms
            if (userAccount.PermissionSet.IsOperationsManager)
                _loginForm.ShowManagerMainForm(userAccount, _loginForm);


            else if (userAccount.PermissionSet.IsSalesPerson)
                _loginForm.ShowSalesEmployeeForm(userAccount, _loginForm);

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

        private void Orders_Load(object sender, EventArgs e)
        {
            //Control visualization
            btnDelivered.Visible = userAccount.PermissionSet.IsSalesPerson;
            cbSearchFields.SelectedIndex = 0;

            //Bind the data grid view
            orderTable = new DataTable();
            orderTable.Columns.Add(new DataColumn("Order Id", typeof(Guid)));
            orderTable.Columns.Add(new DataColumn("First Name", typeof(string)));
            orderTable.Columns.Add(new DataColumn("Last Name", typeof(string)));
            orderTable.Columns.Add(new DataColumn("Entry Date", typeof(string)));
            orderTable.Columns.Add(new DataColumn("Fulfilled Date", typeof(string)));
            orderTable.Columns.Add(new DataColumn("Number of Items", typeof(int)));
            orderTable.Columns.Add(new DataColumn("Order Status", typeof(OrderStatus)));
            dgvOrders.DataSource = orderTable;

            //load
            LoadOrders();
        }

        private void LoadOrders()
        {
            orderTable.Rows.Clear();
            foreach(Order order in ApplicationObjects.GetAllOrders())
            {
                DataRow newRow = orderTable.NewRow();
                newRow["Order Id"] = order.OrderId.ToString();
                newRow["First Name"] = order.Person.FirstName;
                newRow["Last Name"] = order.Person.LastName;
                newRow["Entry Date"] = order.OrderEntryDate.ToString();
                newRow["Fulfilled Date"] = (order.OrderFulfillDate != null) ? order.OrderFulfillDate.ToString() : "not filled";
                newRow["Number of Items"] = order.NumberOrderItems.ToString();
                newRow["Order Status"] = order.OrderStatus;
                orderTable.Rows.Add(newRow);
            }

            dgvOrders.AutoResizeColumns();
        }

        private void btnDelivered_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
            {
                MessageBox.Show("You must select one and only one order.",
                    "Please select a row", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Get order object
            Guid selectedOrderId = new Guid(dgvOrders.Rows[dgvOrders.SelectedRows[0].Index].Cells[0].Value.ToString());
            Order order = ApplicationObjects.GetOrder(selectedOrderId);

            order.OrderStatus = OrderStatus.Delivered;
            order.OrderFulfillDate = DateTime.Now;
            ApplicationObjects.UpdateOrderStatusWithNotification(order, (Permission)userAccount.PermissionSet.GetHighestPermission());

            //refresh the view
            LoadOrders();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadOrders();
        }

        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
            List<Order> ordersList = new List<Order>();
            if ((cbSearchFields.SelectedItem == null) || (tbx_Search.Text == ""))
            {
                ApplicationObjects.DisplayInvalidInput("Please make sure that you have entered search criteria.");
            }
            else if (cbSearchFields.SelectedItem.ToString() == "Inventory Item Id")
            {
                try
                {
                    // Generate a list of IOrders that match the Inventory Item ID entered by the user
                    ordersList = ApplicationObjects.GetOrderByInventoryItemId(new Guid(tbx_Search.Text));
                }
                catch (Exception)
                {   // Catch if a non-Guid was entered
                    ApplicationObjects.DisplayInvalidInput("Search failed!  You may have entered an invalid ID.  Please check your item ID and try again");
                    return;
                }
            }
            else if (cbSearchFields.SelectedItem.ToString() == "Order Id")
            {
                try
                {
                    // Generate a list of Orders that match the Order ID entered by the user
                    ordersList.Add(ApplicationObjects.GetOrder(new Guid(tbx_Search.Text)));
                }
                catch (Exception)
                {   // Catch if a non-Guid was entered
                    ApplicationObjects.DisplayInvalidInput("Search failed!  You may have entered an invalid ID.  Please check your item ID and try again");
                    return;
                }
            }
            else if (cbSearchFields.SelectedItem.ToString() == "Order Status")
            {
                // Convert user input into enum, before passing to search method
                OrderStatus orderStatus = BusinessLayer.Translators.Order.ConvertStringToOrderStatus(tbx_Search.Text);

                if (orderStatus == OrderStatus.None)
                {
                    ApplicationObjects.DisplayInvalidInput("You may have entered an invalid order status type.  Please try again");
                    return;
                }

                // Generate a list of Orders that match the Order ID entered by the user
                ordersList = ApplicationObjects.GetOrderByOrderStatus(orderStatus);
            }

            orderTable.Rows.Clear();
            if (ordersList.Count > 0)
            {
                foreach (Order order in ordersList)
                {
                    DataRow newRow = orderTable.NewRow();
                    newRow["Order Id"] = order.OrderId.ToString();
                    newRow["First Name"] = order.Person.FirstName;
                    newRow["Last Name"] = order.Person.LastName;
                    newRow["Entry Date"] = order.OrderEntryDate.ToString();
                    newRow["Fulfilled Date"] = (order.OrderFulfillDate != null) ? order.OrderFulfillDate.ToString() : "not filled";
                    newRow["Number of Items"] = order.NumberOrderItems.ToString();
                    newRow["Order Status"] = order.OrderStatus;
                    orderTable.Rows.Add(newRow);
                }

                dgvOrders.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("Your search turned up no results.  Please try again.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
