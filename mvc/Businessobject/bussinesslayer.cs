using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Businessobject
{
    public class bussinesslayer
    {
        public IEnumerable<employee> bemployee {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<employee> emp = new List<employee>();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("select * from Myemployee", con);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while(rd.Read())
                    {
                        employee inneremp = new employee();
                        inneremp.ID = Convert.ToInt32(rd["Id"]);
                        inneremp.Name = rd["Name"].ToString();
                        inneremp.Gender = rd["Gender"].ToString();
                        inneremp.City = rd["City"].ToString();
                        emp.Add(inneremp);
                    }
                }
                return emp;
            }
        }
        public void addemployee(employee emp)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void updateemployee(employee emp)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emp.ID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void deleteemploye(int ID)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
