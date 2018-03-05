using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace girdview
{
    public partial class datasource_dobject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Select", "0", true));
            }
            
        }

        protected void btn_sqldatasource_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
        }

        protected void btn_sqldataobj_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView3.Visible = false;

        }
        //using to row design and so on 
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)//check is it datarow or header or footer
            {
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                int age = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,"age"));//Evaluates data-binding expressions at run time
                if (age >= 25 && status == "Married")
                {
                    
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                }
            }
        }
        //when select then gridview show 
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridView1.Visible = false;
            GridView3.Visible = true;
        }
    }
}