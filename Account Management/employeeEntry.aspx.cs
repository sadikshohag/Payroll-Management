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
    public partial class employeeEntry : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    sdsGrade.DataBind();
                    ddlGrade.DataBind();
                    loadDsg();
                    loadData();
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Login.aspx");
            }

        }
        public void loadDsg()
        {
            string strSql = "";
            strSql = "SELECT DSG_ID, DSG_NM FROM DESIGNATION WHERE GRD_ID='"+ ddlGrade.SelectedValue + "'";
            sdsDsg.SelectCommand = strSql;
            sdsDsg.DataBind();
            ddlDesignation.DataBind();

            strSql = "SELECT DSG_ID, DSG_NM FROM DESIGNATION";
            sdsDsgR.SelectCommand = strSql;
            sdsDsgR.DataBind();


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtName.Value)))
            {
                obj.insertEmployee(txtName.Value, txtFather.Value, txtMother.Value,txtJoin.Value, ddlEmpType.SelectedValue, ddlGrade.SelectedValue, ddlDesignation.SelectedValue, txtMobile.Value);
                loadData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Saved Successfully');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Save again !');", true);
            }
        }
        public void loadData()
        {
            string sql = "SELECT * FROM EMPLOYEE E, GRADE G, DESIGNATION D WHERE E.GRD_ID = G.GRD_ID AND E.DSG_ID=D.DSG_ID";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptDsg.DataSource = ds;
                rptDsg.DataBind();
            }
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDsg();
            //loadData();
        }
        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("lnkEdit").Visible = !isEdit;
            item.FindControl("lnkUpdate").Visible = isEdit;
            item.FindControl("lnkCancel").Visible = isEdit;
            item.FindControl("lnkDelete").Visible = !isEdit;

            //Toggle Labels.
            //item.FindControl("lblEduLevel").Visible = !isEdit;
            item.FindControl("lblName").Visible = !isEdit;
            item.FindControl("lblFather").Visible = !isEdit;
            item.FindControl("lblMob").Visible = !isEdit;
            //item.FindControl("lblJoin").Visible = !isEdit;
            item.FindControl("lblGrd").Visible = !isEdit;
            item.FindControl("lblDsg").Visible = !isEdit;
            item.FindControl("lblType").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtName").Visible = isEdit;
            item.FindControl("txtFather").Visible = isEdit;
            item.FindControl("txtMob").Visible = isEdit;
            //item.FindControl("txtJoin").Visible = isEdit;
            item.FindControl("ddlGrade").Visible = isEdit;
            item.FindControl("ddlDsg").Visible = isEdit;
            item.FindControl("ddlType").Visible = isEdit;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int lblEmpId = int.Parse((item.FindControl("lblEmpId") as Label).Text);
            string name = (item.FindControl("txtName") as TextBox).Text.Trim();
            string father = (item.FindControl("txtFather") as TextBox).Text.Trim();
            string mobile = (item.FindControl("txtMob") as TextBox).Text.Trim();
            DropDownList ddlGrd = item.FindControl("ddlGrade") as DropDownList;
            DropDownList ddlDsg = item.FindControl("ddlDsg") as DropDownList;
            DropDownList ddlType = item.FindControl("ddlType") as DropDownList;

            string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EMPLOYEE_EDIT"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@ID", lblEmpId);
                    cmd.Parameters.AddWithValue("@EMP_NAME", name);
                    cmd.Parameters.AddWithValue("@FATHER_NAME", father);
                    cmd.Parameters.AddWithValue("@MOBILE", mobile);
                    cmd.Parameters.AddWithValue("@GRD_ID", int.Parse(ddlGrd.SelectedValue));
                    cmd.Parameters.AddWithValue("@DSG_ID", int.Parse(ddlDsg.SelectedValue));
                    cmd.Parameters.AddWithValue("@EMP_TYPE", ddlType.SelectedValue);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.loadData();
        }

        

        protected void OnCancel(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, false);
        }


        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int lblEmpId = int.Parse((item.FindControl("lblEmpId") as Label).Text);

            string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EMPLOYEE_EDIT"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@ID", lblEmpId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.loadData();
        }

    }
}