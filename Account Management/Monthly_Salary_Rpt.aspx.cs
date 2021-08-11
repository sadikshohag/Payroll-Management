using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account_Management
{
    public partial class Monthly_Salary_Rpt : System.Web.UI.Page
    {
        account obj = new account();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadYrMonth();
                    LoadDate();
                    LoadReport();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }            
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadYrMonth();
            LoadDate();
            LoadReport();
        }
        public string LoadReport()
        {
            string strHTML = "";
            #region Header 
            strHTML = strHTML + "<table width=\"100%\">";
            strHTML = strHTML + "<tr><td style=\"background-color:#FFFFF; color:black;\" COLSPAN=9 align=center><b> Month Salary of "+ ddlMonth.SelectedItem +"  From " + cboFromDate.Value + " to " + cboTODate.Value + "</b></td></tr>";
            strHTML = strHTML + "</table>";

            //strHTML = strHTML + "<table style=\"background-color:#e6e6e6; color:black;\" border=\"1\" width=\"100%\">";
            strHTML = strHTML + "<table class=\"table table-striped table-bordered table-hover\"  border=\"1\" width=\"100%\">";
            strHTML = strHTML + "<TR>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>SN</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Name</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Basic</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>House Rent</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Convenience</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Medical</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>TADA</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Others</b></td>";
            strHTML = strHTML + "<td style=\"background-color:#dfff80;\" align=center><b>Total</b></td>";


            strHTML = strHTML + "</TR>";
            #endregion
            double grandtotal = 0;
            DataSet oDS1 = new DataSet();
            oDS1 = obj.getData("SELECT * FROM EMPLOYEE E, MONTHLY_SALARY MS WHERE MS.MONTH_ID='"+ ddlMonth.SelectedValue +"' AND EMP_ID=E.ID ORDER BY GRD_ID");
            if (oDS1.Tables[0].Rows.Count > 0)
            {
                int SerialNo = 0;
                foreach (DataRow qrow in oDS1.Tables["DATA"].Rows)
                {
                    //string joinedate = prow["EMP_JOINING_DATE"].ToString().Trim() == "" ? "" : String.Format("{0:dd-MMM-yyyy}", DateTime.Parse(prow["EMP_JOINING_DATE"].ToString()));
                    SerialNo = SerialNo + 1;
                    strHTML = strHTML + "<tr><td align=center>" + SerialNo.ToString() + "</td>";
                    strHTML = strHTML + " <td>" + qrow["EMP_NAME"].ToString() + " </td>";

                    strHTML = strHTML + " <td align=center>" + qrow["START_BASIC"].ToString() + "</td>";
                    strHTML = strHTML + " <td align=center> " + qrow["HOUSE_RENT"].ToString() + " </td>";

                    strHTML = strHTML + " <td align=center> " + qrow["CONVEYANCE"].ToString() + " </td>";
                    strHTML = strHTML + " <td align=center> " + qrow["MEDICAL"].ToString() + " </td>";
                    strHTML = strHTML + " <td align=center> " + qrow["TADA"].ToString() + " </td>";
                    strHTML = strHTML + " <td align=center> " + qrow["OTHERS"].ToString() + " </td>";
                    strHTML = strHTML + " <td align=center> " + qrow["TOTAL_SALARY"].ToString() + " </td>";
                    //strHTML = strHTML + " <td align=center> " + qrow["MEDICAL"].ToString() + " </td>";
                    //if (string.IsNullOrEmpty(qrow["PUR_AREA"].ToString()))
                    //{
                    //    strHTML = strHTML + " <td align=center> " + qrow["CANDIV_NAME"].ToString() + " </td>";
                    //}
                    //else
                    //{
                    //    strHTML = strHTML + " <td align=center> " + qrow["PUR_AREA"].ToString() + " </td>";
                    //}
                    if (qrow["TOTAL_SALARY"].ToString() != "")
                    {
                        grandtotal = grandtotal + Convert.ToDouble(qrow["TOTAL_SALARY"].ToString());
                    }
                    else
                    {
                        grandtotal = grandtotal + 0;
                    }
                    strHTML = strHTML + " </tr>";
                }
            }
            strHTML = strHTML + "<tr><td colspan=8><b> Grand Total :</b></td><td align=center><b>" + grandtotal + "</b></td></tr>";
            strHTML = strHTML + " </table>";
            requiView.InnerHtml = strHTML;
            //clsGridExport.ExportToMSExcel(filename, "msexcel", strHTML, "landscape");
            return strHTML;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "Monthly_Salary_rpt";
            string strHTML = LoadReport();
            ExportToMSExcel(filename, "msexcel", strHTML, "landscape");
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
        public void ExportToMSExcel(string fileName, string strType, string strContent, string strPageOrientation)
        {
            fileName = fileName + "_" + string.Format("{0:ddmmyy_hhmmss}", DateTime.Now);
            if (strType.ToLower().Equals("msexcel"))
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "application/msexcel";
                fileName = fileName + ".xls";
                HttpContext.Current.Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.Write("<html>");
                HttpContext.Current.Response.Write("<head>");
                HttpContext.Current.Response.Write("<META HTTP-EQUIV=\" Content-Type\" CONTENT=\" text/html; charset=UTF-8\">");
                HttpContext.Current.Response.Write("<meta name=ProgId content=Word.Document>");
                HttpContext.Current.Response.Write("<meta name=Generator content=\"Microsoft Word 9\">");
                HttpContext.Current.Response.Write("<meta name=Originator content=\"Microsoft Word 9\">");
                HttpContext.Current.Response.Write("<style>");

                //HttpContext.Current.Response.Write("@page Section1 {size:595.45pt 841.7pt; margin:1.0in 1.25in 1.0in 1.25in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}");
                //HttpContext.Current.Response.Write("div.Section1 {page:Section1;}");
                //HttpContext.Current.Response.Write("@page Section2 {size:841.7pt 595.45pt;mso-page-orientation:" + strPageOrientation + ";margin:1.25in 1.0in 1.25in 1.0in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}");
                //HttpContext.Current.Response.Write("div.Section2 {page:Section2;}");

                //HttpContext.Current.Response.Write("@page Section1 {size:595.45pt 841.7pt; margin:1.0in 1.25in 1.0in 1.25in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}");
                //HttpContext.Current.Response.Write("div.Section1 {page:Section1;}");
                //HttpContext.Current.Response.Write("@page Section2 {size:841.7pt 595.45pt;mso-page-orientation:" + strPageOrientation + ";margin:1.25in 1.0in 1.25in 1.0in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}");
                //HttpContext.Current.Response.Write("@page Section2 {size:595.45pt 841.7pt;mso-page-orientation:" + strPageOrientation + ";margin:1.0in 1.0in 1.0in 1.0in;mso-paper-source:0;}");
                //HttpContext.Current.Response.Write("div.Section2 {page:Section2;}");
                HttpContext.Current.Response.Write("</style>");
                HttpContext.Current.Response.Write("</head>");
            }
            else
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "application/pdf";
                fileName = fileName + ".pdf";
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.Write("<html>");
                HttpContext.Current.Response.Write("<head>");
                HttpContext.Current.Response.Write("</head>");
            }


            HttpContext.Current.Response.Write("<body>");
            HttpContext.Current.Response.Write("<div class=Section2>");

            HttpContext.Current.Response.Write(strContent);
            HttpContext.Current.Response.Write("</div>");
            HttpContext.Current.Response.Write("</body>");
            HttpContext.Current.Response.Write("</html>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }

}