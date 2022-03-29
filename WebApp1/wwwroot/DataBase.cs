using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebApplication3.App_Code
{
    public class DataBase
    {

        public SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS;Database=Site;Trusted_Connection=true;");
            con.Open();
            return con;
        }

        public int Command(string myCommand)
        {
            int res = 0;
            SqlConnection con = this.Connect();
            SqlCommand cmd = new SqlCommand(myCommand, con);
            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return res;
        }

        public DataTable GetTable(string myCommand)
        {
            SqlConnection con = this.Connect();
            SqlDataAdapter da = new SqlDataAdapter(myCommand, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            da.Dispose();
            con.Close();
            con.Dispose();
            return dt;
        }

        public DataRow GetRow(string myCommand)
        {
            DataTable dt = GetTable(myCommand);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        public string GetCell(string myCommand)
        {
            DataTable dt = GetTable(myCommand);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0][0].ToString();
        }
    }
}