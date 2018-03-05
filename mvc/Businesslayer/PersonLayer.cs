using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Businesslayer
{
    public class PersonLayer
    {
        public IEnumerable<PersonProperties> person_layer
        {
            get
            {
                string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                List<PersonProperties> personProperties = new List<PersonProperties>();
                using (SqlConnection con = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spGetPerson", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PersonProperties personProperties_insider = new PersonProperties();
                        personProperties_insider.ID = Convert.ToInt32(rd["PersonID"]);
                        personProperties_insider.Name = rd["FirstName"].ToString();
                        personProperties_insider.City = rd["City"].ToString();
                        personProperties_insider.Address = rd["Address"].ToString();
                        //  personProperties_insider.date = Convert.ToDateTime(rd["date"]);
                        personProperties.Add(personProperties_insider);
                    }

                }
                return personProperties;
            }
        }
        //create
        public void AddPerson(PersonProperties personproperties)
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spCreatePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", personproperties.Name);
                cmd.Parameters.AddWithValue("@City", personproperties.City);
                cmd.Parameters.AddWithValue("@address", personproperties.Address);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //edit update
        public void Editperson(PersonProperties personProperties)
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", personProperties.Name);
                cmd.Parameters.AddWithValue("@personid", personProperties.ID);
                cmd.Parameters.AddWithValue("@city", personProperties.City);
                cmd.Parameters.AddWithValue("@address", personProperties.Address);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spDeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@personid", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}
