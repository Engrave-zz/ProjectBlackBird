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
    public partial class ManageUserForm : Form
    {
        protected UserAccount userAccount;
        private LoginForm _loginForm;

        public ManageUserForm(UserAccount user, LoginForm loginForm)
        {
            userAccount = user;
            _loginForm = loginForm;
            InitializeComponent();
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

        private void ManageUserForm_Load(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            List<UserAccount> users = _businessObjects.GetAllUserAccounts();
            lstUsers.Items.Clear();

            if (users != null)
            {
                foreach (UserAccount user in users)
                {
                    ListViewItem item = new ListViewItem(
                        new string[] { user.UserName, user.HighestPermission.ToString() }
                        );
                    this.lstUsers.Items.Add(item);
                }
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            _loginForm.ShowManagerMainForm(userAccount, _loginForm);
            this.Close();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            _loginForm.ShowNewUserForm(userAccount, _loginForm);
            this.Close();
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if(lstUsers.SelectedIndices.Count == 0)
            {
                MessageBox.Show("You must select a user to delete.", "No user selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure that you would like to remove this user?", "Confirm - DROP USER"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.No || result == DialogResult.Cancel)
                return;

            BusinessObjects _businessObjects = new BusinessObjects();
            int returnValue = _businessObjects.DeleteUserAccount(lstUsers.SelectedItems[0].Text);

            if(returnValue == 0)
                MessageBox.Show("User deleted successfully.", "Result"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshUserList();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            RefreshUserList();
        }
    }
}
