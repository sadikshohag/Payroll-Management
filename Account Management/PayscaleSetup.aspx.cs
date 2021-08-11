using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class PayscaleSetup : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            sdsGrade.DataBind();
            loadPayscale();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("PAYSCALE_SETUP"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GRD_ID", int.Parse(ddlGrade.SelectedValue));
                        cmd.Parameters.AddWithValue("@INCR_RATE", int.Parse(txtIncRate.Text));
                        cmd.Parameters.AddWithValue("@START_BASIC", int.Parse(txtStartBasic.Text));
                        cmd.Parameters.AddWithValue("@HOUSE_RENT", int.Parse(txthouseRent.Text));
                        cmd.Parameters.AddWithValue("@CONVEYANCE", int.Parse(txtConveyance.Text));
                        cmd.Parameters.AddWithValue("@MEDICAL", int.Parse(txtMedical.Text));
                        cmd.Parameters.AddWithValue("@TADA", int.Parse(txtTadaAllow.Text));
                        cmd.Parameters.AddWithValue("@OTHERS", int.Parse(txtOthers.Text));
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                loadPayscale();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Successfully Saved !');", true);

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please enter all data !');", true);

            }
        }
        public void loadPayscale()
        {
            string sql = "SELECT * FROM PAY_SCALE P, GRADE G WHERE P.GRD_ID=G.GRD_ID";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt.DataSource = ds;
                rpt.DataBind();
            }
        }
    }
}