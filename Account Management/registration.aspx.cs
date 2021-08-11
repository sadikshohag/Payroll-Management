using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class registration : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(email.Value)))
                {
                    obj.userRegister(name.Value, email.Value, phone.Value, password.Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Successfully Registered');", true);
                    Response.Redirect("login.aspx");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Register Again');", true);
                    Response.Redirect("registration.aspx");

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        //public void btn_click()
        //{

        //}
    }
}