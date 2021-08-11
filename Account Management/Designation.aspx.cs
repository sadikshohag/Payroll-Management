using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.HtmlControls;

namespace Account_Management
{
    public partial class Designation : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    sdsGrade.DataBind();
                    loadDesignation();
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Login.aspx");
            }
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(designation.Value)))
            {
                obj.insertDesignation(ddlGrade.SelectedValue,designation.Value);
                loadDesignation();
            }
        }
        public void loadDesignation()
        {
            string sql = "SELECT * FROM GRADE G, DESIGNATION D WHERE G.GRD_ID = D.GRD_ID";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptDsg.DataSource = ds;
                rptDsg.DataBind();
            }
        }
    }
}