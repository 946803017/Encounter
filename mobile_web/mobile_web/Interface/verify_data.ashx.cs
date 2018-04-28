using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
namespace mobile_web.Interface
{
    /// <summary>
    /// verify_data 的摘要说明
    /// </summary>
    public class verify_data : IHttpHandler, IRequiresSessionState
    {
        JngsDal dal = new JngsDal();
        ip_rsa_mac ip_rsa = new ip_rsa_mac();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string account = "";
            try
            {
                account = context.Request.Params["account"].ToString().Trim();
            }
            catch { account = ""; }
            string pwd = "";
            try { pwd = context.Request.Params["pwd"].ToString().Trim(); }

            catch { pwd = ""; }
            string datatype = "";
            try
            {
            datatype=    context.Request.Params["type"].ToString().Trim();
            }
            catch { datatype = ""; }
            string result = "";

            if (datatype != "login")
            {
                if (isok() == false)
                {
                    result = "0x11"; //错误访问
                    context.Response.Write(result);
                    return;
                }              
            }
                switch (datatype)
                {
                    case "login":
                        {
                            if (account != "" && pwd != "")
                            {
                                var dt = dal.public_user_login(account, BaseDal.MD5Encrype(pwd));
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["DeleteMark"].ToString() == "1")
                                    {
                                        result = "-2";
                                    }
                                    else
                                    {
                                        context.Session.Add("account", account);
                                        context.Session["ip"] = ip_rsa.IPAddress();
                                        context.Session["mac"] = ip_rsa.GetMacAddress();
                                        context.Session["rsa"] = ip_rsa.Rsa(BaseDal.MD5Encrype(pwd));
                                        context.Session["pwd"] = BaseDal.MD5Encrype(pwd);
                                        context.Session["userid"] = dt.Rows[0]["userid"].ToString();
                                        result = "1";
                                    }
                                }
                                else
                                {
                                    result = "-1";
                                }
                            }
                        } break;

                    case "sel":
                        {
                        } break;
                
            }
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public bool isok()
        {
            if (HttpContext.Current.Session["ip"] != null && HttpContext.Current.Session["mac"] != null && HttpContext.Current.Session["rsa"] != null && HttpContext.Current.Session["pwd"] != null)
            {


            }
            else {
                return false;
            }
            bool isok = true;          
            string ip = HttpContext.Current.Session["ip"].ToString();
            string mac = HttpContext.Current.Session["mac"].ToString();
            string rsa = HttpContext.Current.Session["rsa"].ToString();
            string pwds = HttpContext.Current.Session["pwd"].ToString();
            if (ip == ip_rsa.IPAddress() && mac == ip_rsa.GetMacAddress() && ip_rsa.UnRsa(rsa) == pwds)
            {
               
            }
            else
            {
                return isok=false;
            }
            return isok;
        }
    }
}