using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class PayScale_Verification : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadData();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        public void loadData()
        {
            string sql = "SELECT *, START_BASIC+HOUSE_RENT+CONVEYANCE+MEDICAL+TADA+OTHERS AS GROSS FROM EMPLOYEE E, PAY_SCALE_ASSIGN P, DESIGNATION D"
                        +" WHERE E.ID = P.EMP_ID AND E.IS_VERIFY = 'No' AND D.DSG_ID = E.DSG_ID";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptr.DataSource = ds;
                rptr.DataBind();
            }
        }
        protected void btnSendPR_Click(object sender, EventArgs e)
        {
            //string sysdate = System.DateTime.Now.ToString("dd-MMM-yyyy");
            //LinkButton cb = (LinkButton)sender;
            //Repeater row = (Repeater)cb.NamingContainer;
            //HiddenField lblUserReqDtlsID = (HiddenField)row.FindControl("lblUserReqDtlsID");
            //string ids = lblUserReqDtlsID.Value;

            string empID = (sender as LinkButton).CommandArgument;
            string msg = obj.updateData("UPDATE EMPLOYEE SET IS_VERIFY='Yes' WHERE ID='"+ empID + "'");
            if(msg== "Success")
            {
                loadData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Verified Successfully');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Verify Again!');", true);
            }
        }
    }
}