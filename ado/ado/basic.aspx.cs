using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //sql .net provider
using System.Configuration; //for congfiguring the string of data
using System.Data; //for getting the dataseta as well as storeprocedure

namespace ado
{
    public partial class basic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getselectdata(); //show the select statement
        }

        string datastring = ConfigurationManager.ConnectionStrings["mydatabase"].ConnectionString; //string of connection
        //making sql statement select 
        public void getselectdata()
        {
            using (SqlConnection con = new SqlConnection(datastring))
            {
                SqlCommand cmd = new SqlCommand("select * from Persons", con);
                con.Open();
                grd_view.DataSource = cmd.ExecuteReader();
                grd_view.DataBind();

            }
        }
        //making  sql method for insert data in first gridview 
        public void getinsertdata()
        {
            using (SqlConnection con = new SqlConnection(datastring))
            {
                SqlCommand cmd = new SqlCommand("insert into Persons values (@firstname,@lastname,@address,@city)", con); //always use parametrized query or store procedure
                cmd.Parameters.AddWithValue("@firstname", txt_fname.Text);
                cmd.Parameters.AddWithValue("@lastname", txt_lastname.Text);
                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@city", drp_city.SelectedValue);
                con.Open();
                int value  = cmd.ExecuteNonQuery();
                if(value == 1)
                {
                    lbl.Text = "One row inserted";
                    txt_fname.Text = " ";
                    txt_lastname.Text = " ";
                    txt_address.Text = " ";
                }
            }
        }
        public void sqlupdate()
        {

            using (SqlConnection con = new SqlConnection(datastring))
            {

                SqlCommand cmd = new SqlCommand("spupdate", con); //always use parametrized query or store procedure
                cmd.CommandType = CommandType.StoredProcedure; //calling store procedure which in sytem.data 
                cmd.Parameters.AddWithValue("@firstname", txt_fname.Text);
                cmd.Parameters.AddWithValue("@lastname", txt_lastname.Text);
                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@city", drp_city.SelectedValue);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_id.Text));
                con.Open();
                int value = cmd.ExecuteNonQuery();
                if (value == 1)
                {
                    lbl.Text = "One row update";
                    txt_fname.Text = " ";
                    txt_lastname.Text = " ";
                    txt_address.Text = " ";
                }

            }
            
        }
        public void sqldelete()
        {

            using (SqlConnection con = new SqlConnection(datastring))
            {

                SqlCommand cmd = new SqlCommand("delete from Persons where PersonID = @id", con); //always use parametrized query or store procedure
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_id.Text));
                con.Open();
                int value = cmd.ExecuteNonQuery();
                if (value == 1)
                {
                    lbl.Text = "One row delete";
                    txt_fname.Text = " ";
                    txt_lastname.Text = " ";
                    txt_address.Text = " ";
                }

            }

        }
        //for search
        public void sqlsearch()
        {

            using (SqlConnection con = new SqlConnection(datastring))
            {

                SqlCommand cmd = new SqlCommand("spsearch", con); //always use parametrized query or store procedure
                cmd.CommandType = CommandType.StoredProcedure; //calling store procedure which in sytem.data 
                cmd.Parameters.AddWithValue("@firstname", txt_search.Text + "%");
                cmd.Parameters.AddWithValue("@lastname", txt_search.Text + "%");
                cmd.Parameters.AddWithValue("@address", txt_search.Text + "%");
                cmd.Parameters.AddWithValue("@city", txt_search.Text + "%");
                con.Open();
                grd_view.DataSource = cmd.ExecuteReader();
                grd_view.DataBind();
            }

        }
        //for insert
        protected void btn_save_Click(object sender, EventArgs e)
        {
            getinsertdata();//invoke method
            getselectdata(); //for refersh
        }
        //for update
        protected void btn_update_Click(object sender, EventArgs e)
        {
            sqlupdate();//invoke method
            getselectdata(); //for refersh
        }
        //for delete
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            sqldelete();
            getselectdata();
        }
        //for search
        protected void btn_search_Click(object sender, EventArgs e)
        {
            sqlsearch();
            btn_show.Visible = true;
        }
        //for all show
        protected void btn_show_Click(object sender, EventArgs e)
        {
            getselectdata();
            btn_show.Visible = false;
        }

        protected void btn_goto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/datareaderadapter.aspx");
        }
    }
}