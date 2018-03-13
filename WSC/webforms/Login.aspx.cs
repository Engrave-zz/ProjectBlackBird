using WSC.ApplicationLayer;
using BusinessLayer;
using BusinessLayer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.webforms
{
    public partial class Login : System.Web.UI.Page
    {
        //User Security
        protected UserAccount userAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserInfo"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtPassword.Text = null;
            txtCity.Text = null;
            txtAddress.Text = null;
            txtEmail.Text = null;
            txtEmailConfirm.Text = null;
            txtUserName.Text = null;
           
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            //Do nothing if user name or password is empty.
            if ((txtUserName.Text == String.Empty) || (txtUserName.Text == null))
                return;
            if ((txtPassword.Text == String.Empty) || (txtPassword.Text == null))
                return;

            userAccount = ApplicationObjects.AuthenticateUser(txtUserName.Text, txtPassword.Text);

            if (userAccount.UserName == "invalid" && userAccount.PasswordHash == "invalid")
            {
                txtError.Text = "Failed to authenticate with inputted username and password, Authentication Failed";
                txtError.Visible = true;
                return;
            }
            if (userAccount.HighestPermission == null)
            {
                txtError.Text = "Invalid permissions token. Please contact your manager, Authentication Failed";
                txtError.Visible = true;
                return;
            }

            txtError.Text = "Success";
            txtError.Visible = true;

            switch (userAccount.HighestPermission)
            {
                case (Permission.OperationsManager):
                    ShowManagerMainForm(userAccount);
                    break;
                case (Permission.SalesPerson):
                    ShowCustomerPage(userAccount);
                    break;
            }
        }
        public void ShowManagerMainForm(UserAccount user)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("UserName", user.UserName);
            ht.Add("Role", "Employee");
            ht.Add("FirstName", user.FirstName);
            ht.Add("LastName", user.LastName);
            Session["UserInfo"] = ht;
        }
        public void ShowCustomerPage(UserAccount user)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("UserName", user.UserName);
            ht.Add("Role", "Customer");
            ht.Add("FirstName", user.FirstName);
            ht.Add("LastName", user.LastName);
            Session["UserInfo"] = ht;
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if((txtFirstName.Text == null) || (txtFirstName.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "Registration Form Error: Please enter your First Name";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your First Name";
                }
            }
            if((txtLastName.Text == null) || (txtLastName.Text == String.Empty))
            {
                if(lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your Last Name";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your Last Name";
                }
            }
            if ((txtEmail.Text == null) || (txtEmail.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please enter your email";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please enter your email";
                }
            }
            if ((txtEmailConfirm.Text == null) || (txtEmailConfirm.Text == String.Empty))
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Please confirm your email";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Please confirm your email";
                }
            }
            if(txtEmail.Text != txtEmailConfirm.Text)
            {
                if (lblError.Visible == true)
                {
                    lblError.Text += "\n Registration Form Error: Emails do not match";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Form Error: Emails do not match";
                }
            }
        }
    }
}