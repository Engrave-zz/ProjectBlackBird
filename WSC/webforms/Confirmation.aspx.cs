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
            if (Session["Confirmation"] != null)
            {
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["Confirmation"];
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

                lblUserName.Text = "Username: " + strUserName;
                lblUserCreated.Text = "UserCreated: " + strCustomerCreated;
                lblWriteBillingAddress.Text = "WriteBillingAddress: " + strWriteBillingAddress;
                lblWriteMailingAddress.Text = "WriteMailingAddress: " + strWriteMailingAddress;
                lblWritePersonRecord.Text = "WritePersonRecord:" + strWritePersonRecord;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("home.aspx");
        }
    }
}