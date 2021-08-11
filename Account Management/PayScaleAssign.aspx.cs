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
    public partial class PayScaleAssign : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //sdsGrade.DataBind();
                    //ddlGrade.DataBind();
                    loadCanList();
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Login.aspx");
            }
        }
        public void loadCanList()
        {
            string strSql = "";
            strSql = "SELECT ID, GRD_ID, CONCAT(ID,' - ',EMP_NAME) AS ENAME,PAYROLL_ASSIGN FROM EMPLOYEE";
            sdsCanList.SelectCommand = strSql;
            sdsCanList.DataBind();
            rpt.DataSource = sdsCanList;
            rpt.DataBind();
        }
        protected void Repeater1_Command(object source, RepeaterCommandEventArgs e)
        {
            HiddenField t = e.Item.FindControl("canID") as HiddenField;
            HiddenField grd = e.Item.FindControl("grd") as HiddenField;
            txtSearch.Text = t.Value;
            ddlGrade.SelectedValue = grd.Value;
            searchEmp();
        }
        protected void btnSearch_CLick(object sender, EventArgs e)
        {
            searchEmp();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlApplicantN.SelectedValue != "")
            {
                //string name = txtName.Text;
                //string country = txtCountry.Text;
                string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("PAYSCALE"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EMP_ID", int.Parse(ddlApplicantN.SelectedValue));
                        cmd.Parameters.AddWithValue("@START_BASIC", int.Parse(txtStartBasic.Text));
                        cmd.Parameters.AddWithValue("@HOUSE_RENT", int.Parse(txthouseRent.Text));
                        cmd.Parameters.AddWithValue("@CONVEYANCE", int.Parse(txtConveyance.Text));
                        cmd.Parameters.AddWithValue("@MEDICAL", int.Parse(txtMedical.Text));
                        cmd.Parameters.AddWithValue("@TADA", int.Parse(txtTadaAllow.Text));
                        cmd.Parameters.AddWithValue("@OTHERS", int.Parse(txtOthers.Text));
                        cmd.Parameters.AddWithValue("@PAYMENT_TYPE", ddlPayType.SelectedValue);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                this.loadCanList();
            }
            else
            {
                //lblMessage.Text = "Please select a Candidate";
            }
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPayScale();
            loadField();
        }
        public void searchEmp()
        {
            string id = txtSearch.Text.Trim();
            if (id != "")
            {
                string strSql = "SELECT * FROM EMPLOYEE WHERE ID = '" + id + "'";
                sdsEmp.SelectCommand = strSql;
                sdsEmp.DataBind();
                ddlApplicantN.DataBind();
                loadPayScale();
            }
        }
        public void loadPayScale()
        {
            string sql = "SELECT * FROM PAY_SCALE WHERE GRD_ID = '" + ddlGrade.SelectedValue + "'";
            DataSet oDS = obj.getData(sql);
            if (oDS.Tables[0].Rows.Count > 0)
            {
                txtStartBasic.Text = oDS.Tables[0].Rows[0]["START_BASIC"].ToString();
                //txt = oDS.Tables[0].Rows[0]["PSC_INCR_RATE"].ToString();
                txthouseRent.Text = oDS.Tables[0].Rows[0]["HOUSE_RENT"].ToString();
                txtConveyance.Text = oDS.Tables[0].Rows[0]["CONVEYANCE"].ToString();
                txtMedical.Text = oDS.Tables[0].Rows[0]["MEDICAL"].ToString();
                txtOthers.Text = oDS.Tables[0].Rows[0]["OTHERS"].ToString();
                txtTadaAllow.Text = oDS.Tables[0].Rows[0]["TADA"].ToString();
            }
            else
            {
                txtStartBasic.Text = "";
                txthouseRent.Text = "";
                txtConveyance.Text = "";
                txtMedical.Text = "";
                txtOthers.Text = "";
                txtTadaAllow.Text = "";                 
            }
            loadField();
        }

        protected void ddlPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadField();
        }
        public void loadField()
        {
            if (ddlPayType.SelectedValue == "NS")
            {
                txtStartBasic.Enabled = true;
                txthouseRent.Enabled = true;
                txtConveyance.Enabled = true;
                txtMedical.Enabled = true;
                txtOthers.Enabled = true;
                txtTadaAllow.Enabled = true;
            }
            else
            {
                txtStartBasic.Enabled = false;
                txthouseRent.Enabled = false;
                txtConveyance.Enabled = false;
                txtMedical.Enabled = false;
                txtOthers.Enabled = false;
                txtTadaAllow.Enabled = false;
            }
        }
    }
}