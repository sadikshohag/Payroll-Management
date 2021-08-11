using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Account_Management
{
    public class account
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1UR8C01\SQLEXPRESS;Initial Catalog=ACCOUNT;Integrated Security=True");
        
        public DataSet getData(string sql)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds, "DATA");
            con.Close();
            //con = null;
            return ds;

        }
        public string updateData(string sql)
        {
            string strReturn = "";
            try
            {
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                con.Open();
                command = new SqlCommand(sql, con);

                adapter.InsertCommand = new SqlCommand(sql, con);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                con.Close();
                strReturn = "Success";
            }
            catch (Exception ex)
            {
                strReturn = ex.Message.ToString();
            }
            return strReturn;
        }
        public void userRegister(string uName, string email, string mobile, string password)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO USERS (USER_NAME, EMAIL, MOBILE, PASSWORD,STATUS) VALUES(@USER_NAME, @EMAIL, @MOBILE, @PASSWORD, @STATUS)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@USER_NAME", uName);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@MOBILE", mobile);
            cmd.Parameters.AddWithValue("@PASSWORD", password);
            cmd.Parameters.AddWithValue("@STATUS", "P");

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
                //Console.ReadKey();
            }
        }
        public void insertGrade(string grade)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO GRADE (GRD_NM) VALUES(@GRD_NM)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@GRD_NM", grade);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void insertDesignation(string grade, string dsg)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO DESIGNATION (GRD_ID,DSG_NM) VALUES(@GRD_ID,@DSG_NM)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@GRD_ID", grade);
            cmd.Parameters.AddWithValue("@DSG_NM", dsg);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void insertEmployee(string ename, string fname, string mname, string joinDt, string empType, string grdId, string dsgid, string mobile)
        {
            //Replaced Parameters with Value
            string query = "INSERT INTO EMPLOYEE (EMP_NAME,FATHER_NAME,MOTHER_NAME,EMP_TYPE,JOIN_DATE,GRD_ID,DSG_ID,MOBILE) " +
                "VALUES(@EMP_NAME,@FATHER_NAME,@MOTHER_NAME,@EMP_TYPE,@JOIN_DATE, @GRD_ID, @DSG_ID,@MOBILE)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@EMP_NAME", ename);
            cmd.Parameters.AddWithValue("@FATHER_NAME", fname);
            cmd.Parameters.AddWithValue("@MOTHER_NAME", mname);
            cmd.Parameters.AddWithValue("@JOIN_DATE", joinDt);
            cmd.Parameters.AddWithValue("@EMP_TYPE", empType);
            cmd.Parameters.AddWithValue("@GRD_ID", grdId);
            cmd.Parameters.AddWithValue("@DSG_ID", dsgid);
            cmd.Parameters.AddWithValue("@MOBILE", mobile);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}