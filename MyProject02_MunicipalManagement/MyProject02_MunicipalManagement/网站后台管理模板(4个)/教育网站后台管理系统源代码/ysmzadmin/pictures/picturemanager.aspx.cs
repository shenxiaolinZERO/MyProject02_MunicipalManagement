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
using System.IO;

public partial class ysmzadmin_pictures_picturemanager : System.Web.UI.Page
{
    protected string pagetitle;
    oledata ta = new oledata();
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

        string str = "select * from picture order by picid desc";
        ta.executegridview(pic_GridView, str, "picid");
    }
    protected void pic_GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        pic_GridView.PageIndex = e.NewPageIndex;
        pic_GridView.DataBind();
    }
    protected void pic_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        OleDbConnection ole = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        ole.Open();
        string ting = this.pic_GridView.DataKeys[e.RowIndex].Value.ToString();
        OleDbDataAdapter db = new OleDbDataAdapter("select * from picture where picid="+ting, ole);
        DataSet ds = new DataSet();
        db.Fill(ds, "picture");
        DataRow[] row = ds.Tables[0].Select();
        foreach (DataRow r in row)
        {
            if (r["picurl"].ToString() != "")
            {
                FileInfo fi=new FileInfo(Server.MapPath("../updateimage/"+r["picurl"].ToString()));
                fi.Delete();
            }
        }
        ole.Close();
        OleDbConnection oledb=new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        oledb.Open();
        OleDbCommand cmd=new OleDbCommand("delete from picture where picid="+ting,oledb);
        cmd.ExecuteNonQuery();
        OleDbDataAdapter dba=new OleDbDataAdapter("select * from picture order by picid desc",oledb);
        DataSet dst=new DataSet();
        dba.Fill(dst);
        this.pic_GridView.DataSource=dst;
        this.pic_GridView.DataBind();
        oledb.Close();
    }
    protected void pic_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)(e.Row.Cells[3].Controls[0])).Attributes.Add("onclick", "return confirm('您确定删除吗？')");
        }
    }
}
