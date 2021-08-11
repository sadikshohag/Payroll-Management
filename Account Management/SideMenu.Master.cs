using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class SideMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if(string.IsNullOrEmpty(Session["Type"].ToString()))
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void logout_click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            //obj.InsertJobConfMarkSales(txName.Value, txtPass1.Value, txtMail.Value, txtMail.Value, txtMobile.Value);
            Response.Redirect("login.aspx");
        }
    }
}