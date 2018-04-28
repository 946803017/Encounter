using LitJson;
using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace mobile_web.Interface
{
    /// <summary>
    /// get_data 的摘要说明
    /// </summary>
    public class get_data : IHttpHandler, IRequiresSessionState
    {

        ip_rsa_mac ip_rsa = new ip_rsa_mac();
        #region 私有方法
        private void SendResponse(System.Web.HttpResponse response, string data)
        {
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Buffer = true;
            response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            response.Expires = 0;
            response.CacheControl = "no-cache";
            response.Cache.SetNoStore();
            response.Write(data);
            response.Flush();
            response.End();
        }
        public void ProcessRequest(HttpContext context)
        {
            //if (isok() != true)
            //{
            //    context.Response.Write("0x11");
            //    return;
            //}
           
            SendResponse(context.Response, GetData(context.Request.InputStream));
        }


        private string GetData(Stream stream)
        {
            string retdata = "";
            try
            {
                StreamReader sr = new System.IO.StreamReader(stream, Encoding.UTF8);
                string data = sr.ReadToEnd();
                BaseDal.RecordError("发送接口参数", data);
                if (data != null && data.Length > 0)
                {
                    JsonData jsobj = JsonMapper.ToObject(data);
                    JsonData retJson = null;

                    switch ((string)jsobj["appid"])
                    {
                        case "A00002":
                            retJson = JngsSgyParser(jsobj);
                            break;
                    }
                    if (retJson != null)
                    {
                        retdata = retJson.ToJson();
                    }
                    else
                    {
                        retdata = "error:获取数据错误";
                    }
                }
            }
            catch (Exception ex)
            {
                retdata = "error:解析数据出现错误";
            }
            return retdata;
        }
        #endregion

        private JsonData JngsSgyParser(JsonData jsobj)
        {
            JsonData jret = null;
            JsonBase jbr = null;
            if (jsobj != null)
            {
                #region 统一代码
                try
                {
                    if (jsobj != null)
                    {
                        string optaction = "mobile_BLL.Interface." + jsobj["optstring"].ToString() + ",mobile_BLL";
                        Type type = Type.GetType(optaction);
                        jbr = (JsonBase)Activator.CreateInstance(type, jsobj["optdata"]);
                    }
                    if (jbr != null)
                    {
                        jbr.strBaseUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                        jbr.strBaseUrl = jbr.strBaseUrl.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
                        jbr.strBaseUrl += HttpContext.Current.Request.ApplicationPath;
                        StringBuilder sb = new StringBuilder();
                        LitJson.JsonWriter jw = new LitJson.JsonWriter(sb);
                        jw.WriteObjectStart();
                        jw.WritePropertyName("result");
                        jw.Write("");
                        jw.WriteObjectEnd();
                        jret = JsonMapper.ToObject(sb.ToString());
                        jret["result"] = (JsonData)jbr.GetData();
                    }
                }
                catch (Exception ex)
                {
                    BaseDal.RecordError("json数据返回出错_get_data.ashx", ex.ToString());
                }
                #endregion
            }

            return jret;
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
            else
            {
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
                return isok = false;
            }
            return isok;
        }
    }
}