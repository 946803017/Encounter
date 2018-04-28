
using mobile_DAL.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;

namespace mobile_DAL.Interface
{
    public partial class JngsDal : BaseDal
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public DataTable public_user_login(string account, string pass)
        {
            string strSql = " select * from  baseuser   where UserAccount=@account and Password=@pass ";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("account", account);
            dic.Add("pass", pass);
            return QueryDataTable(strSql, dic);
        }

    

        public DataTable get_baseuser(string userid)
        {
                string sql = "select *  from BaseUser where userid ='" + userid + " '";
                return QueryDataTable(sql);
        }
        public DataTable get_baseuser_where(string where)
        {
            string sql = "select *  from BaseUser where 1=1 "+where+"";
            return QueryDataTable(sql);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public DataTable get_text_code(string phone)
        {          
            string strSql = " select * from  txt_code   where phone=@phone ";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("phone", phone);                             
            return QueryDataTable(strSql, dic);
        }

        public void insert_text_code(string phone,string textcode)
        {
            var dt=get_text_code(phone);
            if(dt.Rows.Count<=0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("phone", phone);
                dic.Add("code", textcode);
                BaseDal.InsertToTables("txt_code", dic);

            }else{         
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("phone", phone);
                dic.Add("code", textcode);
                BaseDal.UpdateTables("txt_code", dic, "id=" + dt.Rows[0]["id"].ToString() + "");
            }
           
        }


        /// <summary>
        /// 笔记分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public DataTable get_mydanci(string where,string page)
        {
            Dictionary<string,string>dic=new Dictionary<string,string> ();
            DataTable dt = new DataTable();
            string sql = "select a.*,b.UserName,b.UserAccount  from danci_t a join BaseUser b on a.userid=b.UserId  where 1=1";

            sql += where;
            dt = BaseDal.QueryDataTableByPage("10", sql, dic, page, "id", "desc");
            return dt;
        }
        /// <summary>
        /// 图片 
        /// </summary>
        /// <param name="noteid"></param>
        /// <returns></returns>
        public DataTable get_pic(string noteid)
        {
            string sql = " select * from upfiles  where danciid="+noteid+"";
            return BaseDal.QueryDataTable(sql);
        }

        /// <summary>
        /// 已完成
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_bj_yiwancheng(string userid)
        {
            string sql = "select COUNT(id)as sums from danci_t where userid='" + userid + "' and status=2 ";
            return BaseDal.QueryDataTable(sql);
        }
        /// <summary>
        /// 已收藏
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_bj_yishoucang(string userid)
        {
            string sql = "select COUNT(id)as sums from danci_t where userid='" + userid + "' and shoucang=1 ";
            return BaseDal.QueryDataTable(sql);
        }

        /// <summary>
        /// 已删除
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_bj_yishanchu(string userid)
        {
            string sql = "select COUNT(id)as sums from danci_t where userid='" + userid + "' and dm=1 ";
            return BaseDal.QueryDataTable(sql);
        }

        /// <summary>
        /// 已提醒
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_bj_yitiying(string userid)
        {
            string sql = "select COUNT(id)as sums from danci_t where userid='" + userid + "' and status=1 ";
            return BaseDal.QueryDataTable(sql);
        }

        /// <summary>
        /// 全部笔记
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_bj_quanbu(string userid)
        {
            string sql = "select COUNT(id)as sums from danci_t where userid='" + userid + "' ";
            return BaseDal.QueryDataTable(sql);
        }

        /// <summary>
        /// 阅读top3
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable top3_yuedu(string userid)
        {
            string sql = "select  top (3)* from danci_t where userid='"+userid+"' and dm=0  order by liulancount desc ";
            return BaseDal.QueryDataTable(sql);
        }

        public DataTable top3_shoucang(string userid)
        {
            string sql = "select  top (3)* from danci_t where userid='" + userid + "' and dm=0 and shoucang=1 order by id desc ";
            return BaseDal.QueryDataTable(sql);
        }
    }
}
