using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;//here dataset namesapce

namespace ado
{
    public partial class more : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_go_tobasic_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/basic.aspx");
        }

        protected void btn_go_toanother_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/datareaderadapter.aspx");
        }
        string datastring = ConfigurationManager.ConnectionStrings["mydatabase"].ConnectionString;
        protected void btn_show_sqlrdr_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(datastring))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/data.xml"));//reading the xml data
                ds.Tables[0].TableName = "p";
                ds.Tables[1].TableName = "d";
                GridView1.DataSource = ds.Tables["p"];
                GridView1.DataBind();
                GridView2.DataSource = ds.Tables["d"];
                GridView2.DataBind();
                lbl.Text = "XML data ";
            }
        }
        //using bulcopy and transaction 
        protected void btn_showdad_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(datastring))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/data.xml"));//reading the xml data
                DataTable tblperson = ds.Tables["Person"];
                DataTable tblpersondetails = ds.Tables["PersonDetails"];
                con.Open();
                SqlTransaction tr = con.BeginTransaction();//using transiction to use two data copy same time
                using (SqlBulkCopy bulkcpy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tr))
                {
                    try
                    {

                        bulkcpy.DestinationTableName = "Persons";
                        bulkcpy.ColumnMappings.Add("Last", "LastName");
                        bulkcpy.ColumnMappings.Add("FirstName", "FirstName");
                        bulkcpy.ColumnMappings.Add("Address", "Address");
                        bulkcpy.ColumnMappings.Add("City", "City");
                        bulkcpy.WriteToServer(tblperson);
                        SqlBulkCopy bulkcpy2 = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tr);
                        bulkcpy2.DestinationTableName = "PersonDetails";
                        bulkcpy2.ColumnMappings.Add("education", "higesteducation");
                        bulkcpy2.ColumnMappings.Add("status", "status");
                        bulkcpy2.ColumnMappings.Add("age", "age");
                        bulkcpy2.WriteToServer(tblpersondetails);
                        tr.Commit();
                        lbl.Text = "Bulkcopy Succesful";
                        getselectdataadp();
                    
                        
                    }
                    catch
                    {
                        tr.Rollback();
                        lbl.Text = "Unseccessful";
                        getselectdataadp();
                        lbl.BackColor = System.Drawing.Color.Red;
                    }
                }

            }
        }
        //using get the data from databse
        public void getselectdataadp()
        {
            SqlConnection con = new SqlConnection(datastring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Persons select * from PersonDetails", con); //it need not open the connection
            DataSet ds = new DataSet(); //which uses disconnected and in memory data
            ad.Fill(ds);
            ds.Tables[0].TableName = "p";
            ds.Tables[1].TableName = "d";
            GridView1.DataSource = ds.Tables["p"];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables["d"];
            GridView2.DataBind();
        }
    }
}