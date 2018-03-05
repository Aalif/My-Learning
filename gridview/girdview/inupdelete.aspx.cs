using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace girdview
{
    public partial class inupdelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
          
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["higesteducation"].DefaultValue = ((TextBox)GridView2.FooterRow.FindControl("TextBox5")).Text;
            SqlDataSource1.InsertParameters["age"].DefaultValue = ((TextBox)GridView2.FooterRow.FindControl("TextBox6")).Text;
            SqlDataSource1.InsertParameters["name"].DefaultValue = ((TextBox)GridView2.FooterRow.FindControl("TextBox7")).Text;
            SqlDataSource1.InsertParameters["status"].DefaultValue = ((DropDownList)GridView2.FooterRow.FindControl("DropDownList2")).SelectedValue;
            SqlDataSource1.Insert();
        }

        protected void btn_source_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
        }

        protected void btn_object_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridView1.Visible = true;
        }
        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if(e.AffectedRows> 0)
            {
                Label1.Text = "Row is deleted";
            }
            else
            {
                Label1.Text = "Try Again";
                Label1.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void ObjectDataSource2_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if(e.ReturnValue is int && (int)e.ReturnValue > 0)
            {
                e.AffectedRows =(int) e.ReturnValue;
            }
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.AffectedRows < 1)
            {
                Label1.Text = "try again and the update is fail " + e.Keys[0].ToString();
            }
            else
            {
                Label1.Text = "the update is successful " + e.Keys[0].ToString();
            }
        }
    }
}