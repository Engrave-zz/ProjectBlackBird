using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSC.ApplicationLayer;
using BusinessLayer;
using DataAccessLayer;
using BusinessLayer.Enumerations;
using System.Data;

namespace WSC.webforms
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        private DataTable orderTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                string strFirstName = ht.ContainsKey("FirstName") ? Convert.ToString(ht["FirstName"]) : "";
                string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
                string strPersonID = ht.ContainsKey("PersonID") ? Convert.ToString(ht["PersonID"]) : "";
                string strEmail = ht.ContainsKey("Email") ? Convert.ToString(ht["Email"]) : "";
                welcomelbl.Text = "Welcome! " + strUserName;
                welcomelbl.Visible = true;
                Logoutbtn.Visible = true;

                if (!(strRole == "Employee"))
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                Orders_Load();
            }

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
            orderTable.Columns.Add(new DataColumn("Order Status", typeof(string)));
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
                    DataRow newRow = orderTable.NewRow();
                    newRow["Order Id"] = order.OrderId.ToString();
                    newRow["First Name"] = order.Person.FirstName;
                    newRow["Last Name"] = order.Person.LastName;
                    newRow["Entry Date"] = order.OrderEntryDate.ToString();
                    newRow["Fulfilled Date"] = (order.OrderFulfillDate != null) ? order.OrderFulfillDate.ToString() : "not filled";
                    newRow["Number of Items"] = order.NumberOrderItems.ToString();
                    newRow["Order Status"] = order.OrderStatus.ToString();
                    orderTable.Rows.Add(newRow);
                
            }
            dgvOrders.DataBind();
        }

        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }
    }
}