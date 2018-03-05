using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace girdview
{
    public class propertiesperson
    {
        public string education { get; set; }
        public string status { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public int getid { get; set; }
    }
    public class getpersondetailsd2
    {
        //select method
        public static List<propertiesperson> getmethod()
        {
            List<propertiesperson> lProp = new List<propertiesperson>();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from PersonDetails", con);
                con.Open();
                using(SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        propertiesperson obj = new propertiesperson();
                        obj.education = rd["higesteducation"].ToString();
                        obj.status = rd["status"].ToString();
                        obj.getid = Convert.ToInt32(rd["id"]);
                        obj.age =Convert.ToInt32 (rd["age"]);
                        obj.name = rd["name"].ToString();

                        lProp.Add(obj);
                    }
                }
            }
            return lProp;
        }
        //delete method
        public static void mDelete(int getid)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from PersonDetails where id = @id ", con);
                cmd.Parameters.AddWithValue("@id", getid);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //conflict delete method
        public static void mDeleteconfilct(int orginal_getid, string orginal_name, string orginal_education, string orginal_status, int orginal_age)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from PersonDetails where id = @id and status = @status and higesteducation= @education and name =@name and age = @age", con);
                cmd.Parameters.AddWithValue("@id", orginal_getid);
                cmd.Parameters.AddWithValue("@status", orginal_status);
                cmd.Parameters.AddWithValue("@education", orginal_education);
                cmd.Parameters.AddWithValue("@name", orginal_name);
                cmd.Parameters.AddWithValue("@age", orginal_age);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //update method
        public static int mUpdtae(string name, string education, string status, int age, int orginal_getid, string orginal_name, string orginal_education, string orginal_status, int orginal_age)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("update PersonDetails set status = @status, higesteducation= @education, name =@name , age = @age where id = @orginal_getid and status = @orginal_status and higesteducation= @orginal_education and name =@orginal_name and age = @orginal_age", con);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@education", education);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@orginal_getid", orginal_getid);
                cmd.Parameters.AddWithValue("@orginal_status", orginal_status);
                cmd.Parameters.AddWithValue("@orginal_education", orginal_education);
                cmd.Parameters.AddWithValue("@orginal_name", orginal_name);
                cmd.Parameters.AddWithValue("@orginal_age", orginal_age);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}