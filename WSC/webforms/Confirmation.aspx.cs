using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.webforms
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get confirmation session
            if (Session["Confirmation"] != null)
            {
                // store confirmation sesion data in hashtable
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["Confirmation"];

                // declare variables and assign session data from hashtable
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strCustomerCreated = ht.ContainsKey("CustomerCreated") ? Convert.ToString(ht["CustomerCreated"]) : "";
                string strWriteBillingAddress = ht.ContainsKey("WriteBillingAddress") ? Convert.ToString(ht["WriteBillingAddress"]) : "";
                string strWriteMailingAddress = ht.ContainsKey("WriteMailingAddress") ? Convert.ToString(ht["WriteMailingAddress"]) : "";
                string strWritePersonRecord = ht.ContainsKey("WritePersonRecord") ? Convert.ToString(ht["WritePersonRecord"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                if (!(strRole == "Customer"))
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                // display username and successmessage to customer
                lblConfirm.Text += "Username: " + strUserName;
                lblConfirm.Text += "\n UserCreated: " + strCustomerCreated;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // confirmation button clears the session and redirects user to the login page
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}