using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ado
{
    public partial class datareader_adapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            
        }
        string datastring = ConfigurationManager.ConnectionStrings["mydatabase"].ConnectionString;
        //datareader
        public void getselectdatard()
        {
            using (SqlConnection con = new SqlConnection(datastring))
            {
                SqlCommand cmd = new SqlCommand("select * from Persons select * from PersonDetails", con);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader()) //always need to close this 
                {
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    while (rd.NextResult())//for next result
                    {   
                        GridView2.DataSource = rd;
                        GridView2.DataBind();
                    }
                }
                    

            }
        }
        //sqldataadapter using 
        public void getselectdataadp()
        {
            SqlConnection con = new SqlConnection(datastring);
            SqlDataAdapter ad  = new SqlDataAdapter("select * from Persons select * from PersonDetails", con); //it need not open the connection
            DataSet ds = new DataSet(); //which uses disconnected and in memory data
            ad.Fill(ds);
            ds.Tables[0].TableName = "p";
            ds.Tables[1].TableName = "d";
            GridView1.DataSource = ds.Tables["p"];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables["d"];
            GridView2.DataBind();
        }

        protected void btn_go_tobasic_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/basic.aspx");
        }

        protected void btn_show_sqlrdr_Click(object sender, EventArgs e)
        {
            getselectdatard();
            lblr.Text = "This result uses the sqldatareader";
            lblr.BackColor = System.Drawing.Color.Green;
        }

        protected void btn_showdad_Click(object sender, EventArgs e)
        {
            getselectdataadp();
            lblr.Text = "This result uses the sqldata adapter";
            lblr.BackColor = System.Drawing.Color.Red;
        }

        protected void btn_go_toanother_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/more.aspx");
        }
    }
}