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

public partial class ysmzadmin_article_updatearticle : System.Web.UI.Page
{
    protected string pagetitle;
    oledata o = new oledata();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack== false)
        {
      
            string strsql = "select * from baseinfo";
            OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            ll.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(strsql, ll);
            DataSet dw = new DataSet();
            da.Fill(dw, "baseinfo");
            DataRowView view = dw.Tables["baseinfo"].DefaultView[0];
            pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
            ll.Close();

            OleDbConnection ole = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            ole.Open();
            OleDbDataAdapter db = new OleDbDataAdapter("select * from newscolumn order by columnid desc", ole);
            DataSet ds = new DataSet();
            db.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "columntitle";
            DropDownList1.DataValueField = "columnid";
            DropDownList1.DataBind();
            ole.Close();
            OleDbConnection ol = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            ol.Open();
            OleDbDataAdapter oledb = new OleDbDataAdapter("select * from newsarticle where articleid=" + Request["articleid"], ol);
            DataSet dst = new DataSet();
            oledb.Fill(dst,"newsarticle");
            DataRowView row = dst.Tables["newsarticle"].DefaultView[0];
            TextBox1.Text = Convert.ToString(row["articletitle"]);
            TextBox2.Text = Convert.ToString(row["articleauthor"]);
            TextBox3.Text = Convert.ToString(row["articlefrom"]);
            TextBox4.Text = Convert.ToString(row["articlecontent"]);
            Label7.Text = Convert.ToString(row["articletime"]);
            Label9.Text = Convert.ToString(row["articlepic"]);
            ol.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("articlemanager.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(CheckBox1.Checked==true)   //判断删除原来图片是否选定
        {
            if(Label9.Text=="")    //判断删除原来图片是否显示
            {
                Response.Write("<script language=javascript> alert('不能给删除原来图片复选框打勾！');location='javascript:history.go(-1)'</script>");
            }
            else if(File2.PostedFile.FileName=="")
            {
                FileInfo info = new FileInfo(Server.MapPath(Label9.Text.ToString()));
                info.Delete();     //删除原来图片
                string st = "update newsarticle set articlecolumn='" + DropDownList1.Text + "',articletitle='" + TextBox1.Text + "',articleauthor='" + TextBox2.Text + "',articlefrom='" + TextBox3.Text + "',articletime='" + DateTime.Now + "',articlecontent='" + TextBox4.Text + "',articlepic='" + null + "' where articleid=" + Request["articleid"];
                o.excutesql(st);    //更新数据库
                Response.Write("<script language=javascript> alert('更新文章成功！');location='articlemanager.aspx'</script>");
                 
            }
            else
            {
                Response.Write("<script language=javascript> alert('删除原来图片复选框打勾后，不能插入图片！');location='javascript:history.go(-1)'</script>");   
            }            
        }
        else
        {
            if(File2.PostedFile.FileName=="")     //判断插入图片是否有路径
            {
                string st = "update newsarticle set articlecolumn='" + DropDownList1.Text + "',articletitle='" + TextBox1.Text + "',articleauthor='" + TextBox2.Text + "',articlefrom='" + TextBox3.Text + "',articletime='" + DateTime.Now + "',articlecontent='" + TextBox4.Text + "' where articleid=" + Request["articleid"];
                o.excutesql(st);    //更新数据库
                Response.Write("<script language=javascript> alert('更新文章成功！');location='articlemanager.aspx'</script>");
            }
            else
            {
                if(Label9.Text=="")      //判断删除原来图片是否显示
                {
                    string p_filename = "", p_fileexename = "", m_filename, m_filepath;
                    p_filename = this.File2.PostedFile.FileName;
                    p_fileexename = p_filename.Substring(p_filename.LastIndexOf(".") + 1);
                    try
                    {
                        m_filepath = Server.MapPath("../updateimage/");
                        m_filename = p_filename.Substring(p_filename.LastIndexOf("\\") + 1);
                        File2.PostedFile.SaveAs(m_filepath + m_filename);    //插入图片
                        Label9.Text = "../updateimage/" + m_filename;
                     }
                     catch (Exception err)
                     {
                        Response.Write(err.ToString());
                     }
                     string st = "update newsarticle set articlecolumn='" + DropDownList1.Text + "',articletitle='" + TextBox1.Text + "',articleauthor='" + TextBox2.Text + "',articlefrom='" + TextBox3.Text + "',articletime='" + DateTime.Now + "',articlecontent='" + TextBox4.Text + "',articlepic='" + Label9.Text + "' where articleid=" + Request["articleid"];
                     o.excutesql(st);    //更新数据库
                     Response.Write("<script language=javascript> alert('更新文章成功！');location='articlemanager.aspx'</script>");
               }
                else
                {
                    FileInfo info = new FileInfo(Server.MapPath(Label9.Text.ToString()));
                    info.Delete();    //删除原来图片
                    string p_filename = "", p_fileexename = "", m_filename, m_filepath;
                    p_filename = this.File2.PostedFile.FileName;
                    p_fileexename = p_filename.Substring(p_filename.LastIndexOf(".") + 1);
                    try
                      {
                        m_filepath = Server.MapPath("../updateimage/");
                        m_filename = p_filename.Substring(p_filename.LastIndexOf("\\") + 1);
                        File2.PostedFile.SaveAs(m_filepath + m_filename);   //插入图片
                        Label9.Text = "../updateimage/" + m_filename;
                      }
                   catch (Exception err)
                      {
                        Response.Write(err.ToString());
                      }
                      string st = "update newsarticle set articlecolumn='" + DropDownList1.Text + "',articletitle='" + TextBox1.Text + "',articleauthor='" + TextBox2.Text + "',articlefrom='" + TextBox3.Text + "',articletime='" + DateTime.Now + "',articlecontent='" + TextBox4.Text + "',articlepic='" + Label9.Text + "' where articleid=" + Request["articleid"];
                      o.excutesql(st);    //更新数据库
                      Response.Write("<script language=javascript> alert('更新文章成功！');location='articlemanager.aspx'</script>");
                }
            }
        }
    }
}
