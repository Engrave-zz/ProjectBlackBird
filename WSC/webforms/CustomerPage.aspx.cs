using System;
using WSC.ApplicationLayer;
using BusinessLayer;
using DataAccessLayer;
using BusinessLayer.Enumerations;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.webforms
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected CatalogItem CatelogItem;
        private DataTable orderTable;
        protected Order order;
        private List<Customer> Customer = new List<Customer>();
        protected Person Person;
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Logoutbtn.Visible = false;
            welcomelbl.Visible = false;
            if(!IsPostBack)
            {
                ListItem SmallGoldPlaque = new ListItem("Small Gold Plaque", "1");
                ListItem Visor = new ListItem("Visor", "2");
                ListItem SmallSilverPlaque = new ListItem("Small Silver Plaque", "3");
                ListItem TopHat = new ListItem("Top Hat", "4");
                ListItem LargeGoldPlaque = new ListItem("Large Gold Plaque", "5");
                ListItem LargeSilverPlaque = new ListItem("Large Silver Plaque", "6");
                ListItem BaseballHat = new ListItem("Baseball Hat", "7");
                ItemDPList.Items.Add(SmallGoldPlaque);
                ItemDPList.Items.Add(Visor);
                ItemDPList.Items.Add(SmallSilverPlaque);
                ItemDPList.Items.Add(TopHat);
                ItemDPList.Items.Add(LargeGoldPlaque);
                ItemDPList.Items.Add(LargeSilverPlaque);
                ItemDPList.Items.Add(BaseballHat);

            }
            if (Session["UserInfo"] != null)
            {
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                string strFirstName = ht.ContainsKey("FirstName") ? Convert.ToString(ht["FirstName"]) : "";
                string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
                string strPersonID = ht.ContainsKey("PersonID") ? Convert.ToString(ht["PersonID"]) : "";
                string strEmail = ht.ContainsKey("Email") ? Convert.ToString(ht["Email"]) : "";
                lastnamelbl.Text = strUserName.Substring(1, strUserName.Length - 1);
                welcomelbl.Text = "Welcome! " + strUserName;
                welcomelbl.Visible = true;
                Logoutbtn.Visible = true;

                if (!(strRole == "Customer" ))
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }
                if (Session["ItemName"] != null)
                {
                    string ItemName = Session["ItemName"].ToString();
                    ItemName = ItemName.Replace("_", " ");
                    if (!IsPostBack)
                    {
                        ItemDPList.Items.FindByText(ItemName).Selected = true;
                    }
                    SetCatelogInfo(ItemName);
                }

                Orders_Load();
            }
        }
        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }

        protected void ItemDPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedindex = ItemDPList.Items[ItemDPList.SelectedIndex].Text;
            SetCatelogInfo(selectedindex);
        }

        public void SetCatelogInfo(string ItemName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            CatelogItem = _businessObjects.GetCatalogItemByItemName(ItemName);
            lblItemCost.Text = "Cost: " + CatelogItem.ItemCost.ToString();
            string InstriptionTypes = CatelogItem.InscriptionType.ToString();
            lblInscriptionType.Text = "Inscryption Type: " + InstriptionTypes;           
    
        }

        protected void btnOrderNow_Click(object sender, EventArgs e)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            string strLastName = lastnamelbl.Text;

            Order newOrder = new Order();
            OrderItem newItem = new OrderItem();
            string ItemName = ItemDPList.Items[ItemDPList.SelectedIndex].Text;
            CatelogItem = _businessObjects.GetCatalogItemByItemName(ItemName);
            errorlbl.Text = CatelogItem.ItemName;
            errorlbl.Visible = true;
            Customer = _businessObjects.GetCustomerByLastName(strLastName);
            Customer ActualCustomer = new Customer();
            foreach(Customer Cust in Customer)
            {
                if(Cust.PersonType.ToString() == "Customer")
                {
                    ActualCustomer = Cust;
                }
            }
            lastnamelbl.Text = ActualCustomer.PersonType.ToString();
            
            newItem.CatalogItem = CatelogItem;
            newItem.ItemInscription = txtDesiredText.Text;
            newOrder.ItemList.Add(newItem);
            newOrder.OrderEntryDate = DateTime.Now;
            newOrder.Person = ActualCustomer;
            OrderStatus orderstatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Submitted");
            newOrder.OrderStatus = orderstatus;
            int returnValue = ApplicationObjects.CreateOrder(newOrder);
            if(returnValue == 0)
            {
               //rrorlbl.Text = "Success! Your Order Has Been Submitted!";
            }

            txtDesiredText = null;
            lblInscriptionType = null;
            lblItemCost = null;
        }

        private void Orders_Load()
        {
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
            dgvOrders.DataBind();

            //load
            LoadOrders();
        }

        private void LoadOrders()
        {
            orderTable.Rows.Clear();
            foreach (Order order in ApplicationObjects.GetAllOrders())
            {
                if (order.Person.LastName == lastnamelbl.Text)
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
            }
            dgvOrders.DataBind();
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            Orders_Load();
        }
    }
}