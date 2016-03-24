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

public partial class ysmzadmin_article_articleadd : System.Web.UI.Page
{
    protected string pagetitle;
    protected void Page_Load(object sender, EventArgs e)
    {
             
        if (Page.IsPostBack == false)
        {
            //显示标题
            string strsql = "select * from baseinfo";
            OleDbConnection ll = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            ll.Open();
            OleDbDataAdapter de = new OleDbDataAdapter(strsql, ll);
            DataSet ds = new DataSet();
            de.Fill(ds, "baseinfo");
            DataRowView view = ds.Tables["baseinfo"].DefaultView[0];
            pagetitle = Convert.ToString(view["sitename"]) + Convert.ToString(view["programer"]);
            ll.Close();
            //初始化数据
            OleDbConnection oledb = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
            oledb.Open();
            OleDbDataAdapter dbd = new OleDbDataAdapter("select * from newscolumn order by columnid desc", oledb);
            DataSet da = new DataSet();
            dbd.Fill(da);
            DropDownList1.DataSource = da;
            DropDownList1.DataTextField = "columntitle";
            DropDownList1.DataValueField = "columnid";
            DropDownList1.DataBind();
            oledb.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("articlemanager.aspx");
    }
    protected void add_save_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "" && add_title.Text != "" && add_content.Text != "" && add_from.Text != "" && add_author.Text != "")
        {
            //保存图片
            string myfilepath = "", myexefile = "", m_myfilepath, m_myexefile;
            if ("" != this.File1.PostedFile.FileName)
            {
                myfilepath = File1.PostedFile.FileName;
                myexefile = myfilepath.Substring(myfilepath.LastIndexOf(".") + 1);
                try
                {
                    m_myfilepath = Server.MapPath("../updateimage/");
                    m_myexefile = myfilepath.Substring(myfilepath.LastIndexOf("\\") + 1);
                    File1.PostedFile.SaveAs(m_myfilepath + m_myexefile);
                    TextBox1.Text ="../updateimage/"+ m_myexefile;
                    TextBox1.Visible = true;

                }
                catch (Exception err)
                {
                    Response.Write(err.ToString());
                }
            }
            //保存数据
                string stre = "insert into newsarticle(articlecolumn,articletitle,articlecontent,articlefrom,articleauthor,articletime,articlepic) values('" + DropDownList1.Text + "','" + add_title.Text + "','" + add_content.Text + "','" + add_from.Text + "','" + add_author.Text + "','" + DateTime.Now + "','" + TextBox1.Text + "')";
                OleDbConnection ole = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
                ole.Open();
                OleDbCommand com = new OleDbCommand(stre, ole);
                com.ExecuteNonQuery();                
                ole.Close();
                Response.Write("<script language=javascript>alert('恭喜恭喜！你添加成功！');location='articlemanager.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('对不起！请将数据输入完整！');location='javascript:history.go(-1)'</script>");
        }
    }
}
