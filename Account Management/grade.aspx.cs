using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class grade : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadGrade();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtGrade.Value)))
            {
                obj.insertGrade(txtGrade.Value);
                loadGrade();
            }
        }
        public void loadGrade()
        {
            string sql = "SELECT * FROM GRADE";
            DataSet ds = obj.getData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptGrade.DataSource = ds;
                rptGrade.DataBind();
            }
        }
    }
}