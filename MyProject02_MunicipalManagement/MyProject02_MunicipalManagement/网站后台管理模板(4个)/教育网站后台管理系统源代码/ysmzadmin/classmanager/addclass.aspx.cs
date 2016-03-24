using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class ysmzadmin_article_addclass : System.Web.UI.Page
{
    protected string pagetitle;
    oledata ole = new oledata();
    protected void Page_Load(object sender, EventArgs e)
    {
   
        string strsql = "select * from baseinfo";
        OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ll.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(strsql, ll);
        DataSet ds = new DataSet();
        da.Fill(ds, "baseinfo");
        DataRowView view = ds.Tables["baseinfo"].DefaultView[0];
        pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
        ll.Close();

        this.class_edit.Enabled = false;
        ole.executegridview(GridView1, "select * from newscolumn", "columnid");
        this.GridView1.Enabled = false;
    }
    protected void class_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("classmanager.aspx");
    }
    protected void class_add_Click(object sender, EventArgs e)
    {
        if (""!=this.class_text.Text)
        {
            string strin = "insert into newscolumn(columntitle,columntime)values('" + class_text.Text + "','" + DateTime.Now + "')";
            OleDbConnection ode = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            ode.Open();
            OleDbCommand cmd = new OleDbCommand(strin, ode);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                ode.Close();
            }
            Response.Write("<script language=javascript>alert('添加类别成功！');location='addclass.aspx'</script>");
            
               
        }
        else
       {
           Response.Write("<script language=javascript>alert('添加类别文本框不能空！');location='javascript:history.go(-1)'</script>"); 
       }
    }
}
