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
    public partial class userVerify : System.Web.UI.Page
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
                    //loadDsg();
                    loadData();
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Login.aspx");
            }

        }
        //public void loadDsg()
        //{
        //    string strSql = "";
        //    strSql = "SELECT DSG_ID, DSG_NM FROM DESIGNATION WHERE GRD_ID='"+ ddlGrade.SelectedValue + "'";
        //    sdsDsg.SelectCommand = strSql;
        //    sdsDsg.DataBind();
        //    ddlDesignation.DataBind();

        //    strSql = "SELECT DSG_ID, DSG_NM FROM DESIGNATION";
        //    sdsDsgR.SelectCommand = strSql;
        //    sdsDsgR.DataBind();


        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (!(string.IsNullOrEmpty(txtName.Value)))
            //{
            //    //obj.insertEmployee(txtName.Value, txtFather.Value, txtMother.Value,txtJoin.Value, ddlEmpType.SelectedValue, ddlGrade.SelectedValue, ddlDesignation.SelectedValue, txtMobile.Value);
            //    loadData();
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Saved Successfully');", true);

            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Save again !');", true);
            //}
        }
        public void loadData()
        {
            string sql = "SELECT * FROM USERS ORDER BY ID DESC";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptDsg.DataSource = ds;
                rptDsg.DataBind();
            }
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadDsg();
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
            item.FindControl("lblEmail").Visible = !isEdit;
            item.FindControl("lblMob").Visible = !isEdit;
            //item.FindControl("lblJoin").Visible = !isEdit;
            item.FindControl("lblPass").Visible = !isEdit;
            item.FindControl("lblType").Visible = !isEdit;
            item.FindControl("lblStatus").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtName").Visible = isEdit;
            item.FindControl("txtEmail").Visible = isEdit;
            item.FindControl("txtMob").Visible = isEdit;
            //item.FindControl("txtJoin").Visible = isEdit;
            item.FindControl("txtPass").Visible = isEdit;
            item.FindControl("ddlType").Visible = isEdit;
            item.FindControl("ddlStatus").Visible = isEdit;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int lblEmpId = int.Parse((item.FindControl("lblEmpId") as Label).Text);
            string name = (item.FindControl("txtName") as TextBox).Text.Trim();
            string txtEmail = (item.FindControl("txtEmail") as TextBox).Text.Trim();
            string mobile = (item.FindControl("txtMob") as TextBox).Text.Trim();
            string txtPass = (item.FindControl("txtPass") as TextBox).Text.Trim();
            DropDownList ddlType = item.FindControl("ddlType") as DropDownList;
            DropDownList ddlStatus = item.FindControl("ddlStatus") as DropDownList;
            //DropDownList ddlType = item.FindControl("ddlType") as DropDownList;

            string msg = obj.updateData("UPDATE USERS SET USER_NAME='"+ name + "',EMAIL='" + txtEmail + "',MOBILE='" + mobile + "',PASSWORD='" + txtPass + "',USER_TYPE='" + ddlType.SelectedValue + "',STATUS='" + ddlStatus.SelectedValue + "' WHERE ID='" + lblEmpId + "'");
            if (msg == "Success")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Updated Successfully');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Verify Again!');", true);
            }
            //string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("EMPLOYEE_EDIT"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Action", "UPDATE");
            //        cmd.Parameters.AddWithValue("@ID", lblEmpId);
            //        cmd.Parameters.AddWithValue("@EMP_NAME", name);
            //        cmd.Parameters.AddWithValue("@FATHER_NAME", father);
            //        cmd.Parameters.AddWithValue("@MOBILE", mobile);
            //        cmd.Parameters.AddWithValue("@GRD_ID", int.Parse(ddlGrd.SelectedValue));
            //        cmd.Parameters.AddWithValue("@DSG_ID", int.Parse(ddlDsg.SelectedValue));
            //        cmd.Parameters.AddWithValue("@EMP_TYPE", ddlType.SelectedValue);
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
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
            string msg = obj.updateData("DELETE FROM USERS WHERE ID='" + lblEmpId + "'");
            if (msg == "Success")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Deleted Successfully');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('Please Delete Again!');", true);
            }
            //string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("EMPLOYEE_EDIT"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Action", "DELETE");
            //        cmd.Parameters.AddWithValue("@ID", lblEmpId);
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            this.loadData();
        }

    }
}