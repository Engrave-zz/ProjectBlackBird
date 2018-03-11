using WSC.ApplicationLayer;
using BusinessLayer;
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
    public partial class PasswordChangeForm : Form
    {
        protected UserAccount userAccount;
        private LoginForm _loginForm;

        public PasswordChangeForm(LoginForm loginForm)
        {
            _loginForm = loginForm;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _loginForm.Logout();
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Authenticate user
            userAccount = ApplicationObjects.AuthenticateUser(this.txtUserID.Text, this.txtOldPwd.Text);

            if (userAccount == null || userAccount.HighestPermission == null) 
            {
                DialogResult result = MessageBox.Show("Failed to authenticate user.", "Authentication failed!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                if (result == DialogResult.Retry)
                {
                    return;
                }
                else
                {
                    _loginForm.Logout();
                    this.Close();
                    return;
                }
            }

            //Verify the text boxes are not empty
            if (!(this.txtNewPwd.Text == String.Empty) && !(this.txtConfirmPwd.Text == String.Empty))
            {
                //Validate new and confirmed passwords match
                if (String.Compare(this.txtNewPwd.Text, this.txtConfirmPwd.Text) != 0)
                {
                    DialogResult result = MessageBox.Show("Your new and confirmed passwords did not match.", "Password mismatch", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                    if (result == DialogResult.Retry)
                    {
                        return;
                    }
                    else
                    {
                        _loginForm.Logout();
                        this.Close();
                        return;
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Both new and confirmed password boxes must be populated.", "Invalid input!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                if (result == DialogResult.Retry)
                {
                    return;
                }
                else
                {
                    _loginForm.Logout();
                    this.Close();
                    return;
                }
            }

            //Change password
            userAccount.PasswordHash = this.txtNewPwd.Text;
            ApplicationObjects.ChangePassword(userAccount);

            //Logout to re-authenticate
            MessageBox.Show("Password change complete. Please re-log in.","Success!",MessageBoxButtons.OK,MessageBoxIcon.None);
            _loginForm.Logout();
            this.Close();
        }
    }
}
