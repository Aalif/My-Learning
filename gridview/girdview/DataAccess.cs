using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace girdview
{
    public class propforgridview
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string city { get; set; }

    }
    public class search
    {
        public static List<propforgridview> getsearchperson(string fn)
        {
            List<propforgridview> propobj = new List<propforgridview>();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sePersonsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", fn);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        propforgridview inobj = new propforgridview();
                        inobj.fname = rd["FirstName"].ToString();
                        inobj.lname = rd["LastName"].ToString();
                        inobj.address = rd["Address"].ToString();
                        inobj.city = rd["City"].ToString();
                        propobj.Add(inobj);
                    }
                }
            }
            return propobj;
         }
    }

    //without store procedure
    public class DataAccess
    {
       
        public static List<propforgridview> getperson()
        {
            List<propforgridview> propobj = new List<propforgridview>();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from persons", con);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        propforgridview inobj = new propforgridview();
                        inobj.fname = rd["FirstName"].ToString();
                        inobj.lname = rd["LastName"].ToString();
                        inobj.address = rd["Address"].ToString();
                        inobj.city = rd["City"].ToString();
                        propobj.Add(inobj);
                    }
                }
            }
            return propobj;
        }
    }
}