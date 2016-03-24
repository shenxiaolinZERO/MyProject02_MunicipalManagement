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

public partial class ysmzadmin_pictures_addpicture : System.Web.UI.Page
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

        this.btnupdate.Enabled = false;
        string str = "select * from picture order by picid desc";
        ta.executegridview(pic_GridView, str, "picid");
        this.pic_GridView.Enabled = false;
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string filepath = "";
        string fileexename = "";
        string mfilename, mpath;
        if (""!=this.upimage.PostedFile.FileName)
        {
            filepath = upimage.PostedFile.FileName;
            fileexename = filepath.Substring(filepath.LastIndexOf(".") + 1);
            try
            {
                mpath = Server.MapPath("../updateimage/");
                mfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                upimage.PostedFile.SaveAs(mpath + mfilename);
                this.pictxt.Text = "../updateimage/" + mfilename;
                this.pictxt.Visible = true;
            }
            catch (Exception err)
            {
                Response.Write(err.ToString());
            }
            string xx = "insert into picture(picurl)values('" + pictxt.Text + "')";
            OleDbConnection cx = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            cx.Open();
            OleDbCommand com = new OleDbCommand(xx, cx);
            try
            {
                com.ExecuteNonQuery();
            }
            finally
            {
                cx.Close();
            }
            Response.Write("<script language=javascript> alert('提交图片成功！');location='picturemanager.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript> alert('请选择上传的图片！');location='javascript:history.go(-1)'</script>");
        }

    }
    protected void backet_Click(object sender, EventArgs e)
    {
        Response.Redirect("picturemanager.aspx");
    }
    protected void pic_View_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
