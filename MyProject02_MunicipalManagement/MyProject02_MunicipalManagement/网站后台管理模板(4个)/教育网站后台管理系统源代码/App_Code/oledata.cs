using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class oledata
{
    #region 全局变量
    /// <summary>
    /// 创建时间：2008.1.15
    /// 创建人：史纯武
    /// 用来定义全局变量
    /// </summary>
    private OleDbConnection con;
    private OleDbCommand com;
    #endregion

    #region 构造函数
    /// <summary>
    /// 创建时间：2008.1.15
    /// 创建人：史纯武
    /// 初始化时用来连接数据库
    /// </summary>
    public oledata()
	{
        con = new OleDbConnection(ConfigurationManager.AppSettings["constr"]);
        con.Open();
    }
    #endregion

    #region 返回oleDataReader类型的数据
    /// <summary>
    /// 创建人：史纯武
    /// 创建时间：2008.1.15
    /// 此方法用于返回SqlDataReader类型的数据
    /// </summary>
    /// <param name="olecom"></param>
    /// <returns></returns>
    public OleDbDataReader executeread(string olecom)
    {
        OleDbCommand com = new OleDbCommand(olecom,con);
        OleDbDataReader dr = com.ExecuteReader();
        return dr;
    }
    #endregion

    #region 执行sql语句
    /// <summary>
    /// 创建时间：2008.1.15
    /// 创建人：史纯武
    /// 此方法用来执行sql语句
    /// </summary>
    /// <param name="strsql"></param>
    /// <returns></returns>
    public bool excutesql(string strsql)
    {
        com = new OleDbCommand(strsql,con);
        try
        {
            com.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region 执行gridview的数据邦定
    /// <summary>
    /// 创建时间：2008.1.15
    /// 创建人：史纯武
    /// 此方法用来邦定数据
    /// </summary>
    /// <returns></returns>
    public bool executegridview(GridView gridviewn, string str,string sdk)
    {
        OleDbDataAdapter myad = new OleDbDataAdapter(str, con);
        DataSet ds = new DataSet();
        myad.Fill(ds);
        gridviewn.DataSource = ds;
        gridviewn.DataKeyNames = new string[] { sdk };
        try
        {
            gridviewn.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region 执行gridviewbind数据绑定
    public void executedatabind(GridView GridviewN, string str)
    {
        OleDbDataAdapter ole = new OleDbDataAdapter(str, con);
        DataSet ds = new DataSet();
        ole.Fill(ds);
        GridviewN.DataSource = ds;
        try
        {
            GridviewN.DataBind();
           
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region 用来填充数据集
    public DataSet getdataset(string str, string picname)
    {
        OleDbDataAdapter odb = new OleDbDataAdapter(str, con);
        DataSet myds = new DataSet();
        odb.Fill(myds,picname);
        return myds;
    }
    #endregion
}
