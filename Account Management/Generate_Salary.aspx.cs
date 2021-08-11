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
    public partial class Generate_Salary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadYrMonth();
                    LoadDate();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        public void loadYrMonth()
        {
            sdsHRYear.DataBind();
            ddlYear.DataBind();
            int month = DateTime.Now.Month;
            ddlMonth.SelectedIndex = month - 1;
            ddlMonth.DataBind();
        }
        public void LoadDate()
        {
            int index = 0;
            if (ddlMonth.SelectedIndex < 0) index = 0;
            else index = ddlMonth.SelectedIndex;
            int month = index + 1;
            int year = int.Parse(ddlYear.SelectedItem.ToString());
            int day = DateTime.DaysInMonth(year, month);
            DateTime frmDate = new DateTime(year, month, 1);
            DateTime toDate = new DateTime(year, month, day);
            cboFromDate.Value = frmDate.ToString("yyyy-MM-dd");
            cboTODate.Value = toDate.ToString("yyyy-MM-dd");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
                string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("stpMonthlySalary"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", int.Parse(ddlMonth.SelectedValue));
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('The month of "+ ddlMonth.SelectedItem+ " Salary Generated');", true);
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadYrMonth();
            LoadDate();
        }
    }
}