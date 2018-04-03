using System;
using WSC.ApplicationLayer;
using BusinessLayer;
using Entities = DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Enumerations;
using DataAccessLayer.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.webforms
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        private DataAccessObjects _dataAccessObjects = new DataAccessObjects();
        protected CatalogItem CatelogItem;
        protected Customer Customer;
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Logoutbtn.Visible = false;
            welcomelbl.Visible = false;
            if(!IsPostBack)
            {
                ListItem SmallGoldPlaque = new ListItem("Small Gold Plaque", "1");
                ListItem Visor = new ListItem("Visor", "2");
                ListItem SmallSilverPlaque = new ListItem("Small Silver Plaque", "3");
                ListItem TopHat = new ListItem("Top Hat", "4");
                ListItem LargeGoldPlaque = new ListItem("Large Gold Plaque", "5");
                ListItem LargeSilverPlaque = new ListItem("Large Silver Plaque", "6");
                ListItem BaseballHat = new ListItem("Baseball Hat", "7");
                ItemDPList.Items.Add(SmallGoldPlaque);
                ItemDPList.Items.Add(Visor);
                ItemDPList.Items.Add(SmallSilverPlaque);
                ItemDPList.Items.Add(TopHat);
                ItemDPList.Items.Add(LargeGoldPlaque);
                ItemDPList.Items.Add(LargeSilverPlaque);
                ItemDPList.Items.Add(BaseballHat);

            }
            if (Session["UserInfo"] != null)
            {
                System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
                string strUserName = ht.ContainsKey("UserName") ? Convert.ToString(ht["UserName"]) : "";
                string strRole = ht.ContainsKey("Role") ? Convert.ToString(ht["Role"]) : "";
                string strFirstName = ht.ContainsKey("FirstName") ? Convert.ToString(ht["FirstName"]) : "";
                string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
                string strPersonID = ht.ContainsKey("PersonID") ? Convert.ToString(ht["PersonID"]) : "";
                welcomelbl.Text = "Welcome! " + strUserName;
                welcomelbl.Visible = true;
                Logoutbtn.Visible = true;

                if (!(strRole == "Customer" ))
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }
                if (Session["ItemName"] != null)
                {
                    string ItemName = Session["ItemName"].ToString();
                    ItemName = ItemName.Replace("_", " ");
                    if (!IsPostBack)
                    {
                        ItemDPList.Items.FindByText(ItemName).Selected = true;
                    }
                    SetCatelogInfo(ItemName);
                }
            }
        }
        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }

        protected void ItemDPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedindex = ItemDPList.Items[ItemDPList.SelectedIndex].Text;
            SetCatelogInfo(selectedindex);
        }

        public void SetCatelogInfo(string ItemName)
        {
            BusinessObjects _businessObjects = new BusinessObjects();
            CatelogItem = _businessObjects.GetCatalogItemByItemName(ItemName);
            lblItemCost.Text = "Cost: " + CatelogItem.ItemCost.ToString();
            string InstriptionTypes = CatelogItem.InscriptionType.ToString();
            lblInscriptionType.Text = "Inscryption Type: " + InstriptionTypes;           
    
        }

        protected void btnOrderNow_Click(object sender, EventArgs e)
        {
            System.Collections.Hashtable ht = (System.Collections.Hashtable)Session["UserInfo"];
            string strPersonID = ht.ContainsKey("PersonID") ? Convert.ToString(ht["PersonID"]) : "";
            string strLastName = ht.ContainsKey("LastName") ? Convert.ToString(ht["LastName"]) : "";
            //BusinessObjects _businessObjects = new BusinessObjects();
           // ApplicationObjects.GetCustomerByLastName(strLastName);
                
        }
    }
}