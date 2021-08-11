using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class index1 : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadJoining();
                loadEmpg();
                loadSal();
                loadpayroll();
            }
        }
        public void loadJoining()
        {
            DateTime d = DateTime.Now;
            string sql = "SELECT ISNULL(COUNT(ID),0) JO FROM EMPLOYEE WHERE MONTH(JOIN_DATE) = MONTH('" + d + "')";
            DataSet oDS = obj.getData(sql);
            if (oDS.Tables[0].Rows.Count > 0)
            {
                lblJoin.Text = oDS.Tables[0].Rows[0]["JO"].ToString();
            }
        }
        public void loadEmpg()
        {
            string sql = "SELECT ISNULL(COUNT(ID),0) TOT FROM EMPLOYEE WHERE STATUS='A'";
            DataSet oDS = obj.getData(sql);
            if (oDS.Tables[0].Rows.Count > 0)
            {
                lblEmp.Text = oDS.Tables[0].Rows[0]["TOT"].ToString();
            }
        }
        public void loadpayroll()
        {
            string sql = "SELECT ISNULL(COUNT(ID),0) TOT FROM EMPLOYEE WHERE IS_VERIFY='No'";
            DataSet oDS = obj.getData(sql);
            if (oDS.Tables[0].Rows.Count > 0)
            {
                lblPay.Text = oDS.Tables[0].Rows[0]["TOT"].ToString();
            }
        }
        public void loadSal()
        {
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            //string sql = "SELECT ISNULL(SUM(TOTAL_SALARY),0.0) TOT_SAL FROM MONTHLY_SALARY MS WHERE MONTH(MS.MONTH_ID)=MONTH('" + d + "')";
            string sql = "SELECT ISNULL(SUM(TOTAL_SALARY),0.0) TOT_SAL FROM MONTHLY_SALARY MS WHERE MS.MONTH_ID=MONTH('" + d + "')";
            DataSet oDS = obj.getData(sql);
            if (oDS.Tables[0].Rows.Count > 0)
            {
                lblSal.Text = oDS.Tables[0].Rows[0]["TOT_SAL"].ToString();
            }
        }
    }
}