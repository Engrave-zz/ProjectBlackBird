using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.Enumerations;

namespace WSC
{
    public partial class DashBoardSelectionForm : Form
    {
        protected LoginForm _loginForm;
        protected UserAccount userAccount;

        public DashBoardSelectionForm(UserAccount user, LoginForm loginForm)
        {
            _loginForm = loginForm;
            userAccount = user;
            if (!user.PermissionSet.IsOperationsManager)
            {
                cbRole.Enabled = false;
                btnGO.Enabled = false;
            }
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            switch (cbRole.SelectedItem.ToString())
            {
                case ("Operations Manager"):
                    userAccount.PermissionSet.IsSalesPerson = false;
                    userAccount.PermissionSet.IsStockClerk = false;
                    userAccount.PermissionSet.IsWorkSpecialist = false;
                    _loginForm.ShowManagerMainForm(userAccount, _loginForm);
                    this.Close();
                    break;
                case ("Sales Person"):
                    userAccount.PermissionSet.IsOperationsManager = false;
                    userAccount.PermissionSet.IsStockClerk = false;
                    userAccount.PermissionSet.IsWorkSpecialist = false;
                    _loginForm.ShowSalesEmployeeForm(userAccount, _loginForm);
                    this.Close();
                    break;
                case ("Printing / Engraving Specialist"):
                    userAccount.PermissionSet.IsOperationsManager = false;
                    userAccount.PermissionSet.IsSalesPerson = false;
                    userAccount.PermissionSet.IsStockClerk = false;
                    _loginForm.ShowWorkSpecialistForm(userAccount, _loginForm);
                    this.Close();
                    break;
                case ("Stock Room Clerk"):
                    userAccount.PermissionSet.IsOperationsManager = false;
                    userAccount.PermissionSet.IsSalesPerson = false;
                    userAccount.PermissionSet.IsWorkSpecialist = false;
                    _loginForm.ShowStockClerkForm(userAccount, _loginForm);
                    this.Close();
                    break;
            }
        }

        private void DashBoardSelectionForm_Load(object sender, EventArgs e)
        {
            cbRole.SelectedIndex = 0;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _loginForm.Logout();
            this.Close();
        }
    }
}
