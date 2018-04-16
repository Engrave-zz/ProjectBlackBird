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
            // check for valid user session
            if (Session["UserInfo"] != null)
            {
                btnCustomerArea.Visible = true;
                // create hashtable to store session data
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                string strFirstName = ht.ContainsKey("FirstName") ? Convert.ToString(ht["FirstName"]) : "";
                string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
                // make visible the customer area button and welcome labels
                if (strRole == "Employee")
                {
                    Session.Clear();
                    Response.Redirect(Request.RawUrl);
                }
                LoginLbl.Visible = false;
                welcomelbl.Text = "Welcome! " + strUserName;
                welcomelbl.Visible = true;
                //make visible the logout button
                Logoutbtn.Visible = true;
                
            }
        }

        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            // clear login session and redirect user to home page
            Session.Clear();
            Response.Redirect("Home.aspx");
        }
        protected void btnCustomerArea_Click(object sender, EventArgs e)
        {
            // redirect user to the customer page
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btnAddToOrder_Click(object sender, EventArgs e)
        {
            // get the sender button information 
            Button B = (Button)sender;
            string ItemName;
            ItemName = B.ID;

            //create itemname session and redirect to the customer page
            Session["ItemName"] = ItemName;
            Response.Redirect("CustomerPage.aspx");
        }
    }
}