using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class login : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_click(object sender, EventArgs e)
        {
            DataSet ds = obj.getData("SELECT * FROM USERS WHERE EMAIL='"+ email.Value + "' AND PASSWORD='"+ password.Value + "' AND STATUS='A'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Name"] = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                Session["User"] = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                Session["Type"] = ds.Tables[0].Rows[0]["USER_TYPE"].ToString();
                
                Session["image"] = "images/2.png";
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }            
        }
    }
}