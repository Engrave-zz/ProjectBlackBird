using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.webforms
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logoutbtn.Visible = false;
            welcomelbl.Visible = false;
            if (Session["UserInfo"] != null)
            {
                btnCustomerArea.Visible = true;
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                string strFirstName = ht.ContainsKey("FirstName") ? Convert.ToString(ht["FirstName"]) : "";
                string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
                LoginLbl.Visible = false;
                welcomelbl.Text = "Welcome! " + strUserName;
                welcomelbl.Visible = true;
                Logoutbtn.Visible = true;
                
            }
        }

        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }
        protected void btnCustomerArea_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btnAddToOrder_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            string ItemName;
            ItemName = B.ID;

            Session["ItemName"] = ItemName;
            Response.Redirect("CustomerPage.aspx");
        }
    }
}