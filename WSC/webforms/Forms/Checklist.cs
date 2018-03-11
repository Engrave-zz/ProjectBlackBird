using WSC.ApplicationLayer;
using BusinessLayer;
using BusinessLayer.Enumerations;
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
    public partial class Checklist : Form
    {
        protected UserAccount userAccount;
        protected LoginForm _loginForm;
        protected Order _order;

        public Checklist(UserAccount user, Order order, LoginForm loginForm)
        {
            InitializeComponent();
            userAccount = user;
            _order = order;
            _loginForm = loginForm;
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

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(chbAllItems.Checked 
                && chbCorrectInscriptions.Checked
                && chbDamage.Checked
                && chbMedia.Checked
                && chbSpelling.Checked)
            {
                //mark order valid and send notification
                _order.OrderStatus = OrderStatus.Complete;
                ApplicationObjects.UpdateOrderStatusWithNotification(_order, (Permission)userAccount.PermissionSet.GetHighestPermission());
            }
            else
            {
                //mark order invalid and send notification
                _order.OrderStatus = OrderStatus.FailedValidation;
                ApplicationObjects.UpdateOrderStatusWithNotification(_order, (Permission)userAccount.PermissionSet.GetHighestPermission());
            }

            _loginForm.ShowOrdersForm(userAccount, _loginForm);
            this.Close();
        }
    }
}
