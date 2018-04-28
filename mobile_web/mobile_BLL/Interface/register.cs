using LitJson;
using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSoft.Base.Common.BaseCode;


namespace mobile_BLL.Interface
{
  public  class register:JsonBase
    {

          public JngsDal tdal = null;
          public register(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
       {
           
            int i = 0;
            string account = "";
            try { account = (string)optdatas["account"]; }
            catch { account = ""; }
            string pwd = "";
            try { pwd = (string)optdatas["pwd"]; }
            catch { pwd = ""; }
            string textcode = "";
            try { textcode = (string)optdatas["textcode"]; }
            catch { textcode = ""; }
            
            JsonData js = new JsonData();
            string message = "";
            AddJsonProperty("userinfo", ref js); 
            try
            {
                pwd = "666666";
                var dt = tdal.get_text_code(account);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["code"].ToString() == textcode)
                    {                                          
                              var dt_user = tdal.get_baseuser_where(" and UserAccount='" + account + "' ");
                              if (dt_user.Rows.Count <= 0)
                              {
                                  Dictionary<string, string> dic = new Dictionary<string, string>();
                                  dic.Add("UserAccount", account);
                                  dic.Add("Password", BaseDal.MD5Encrype(pwd));
                                  dic.Add("UserId", DateTime.Now.ToFileTime().ToString());
                                  int useid= BaseDal.InsertToTables("BaseUser", dic);
                                  string token= CommonHelper.GetGuid;
                                  Dictionary<string, string> dic1 = new Dictionary<string, string>();
                                  dic1.Add("userid", useid.ToString());
                                  dic1.Add("accesstoken", token);
                                  BaseDal.InsertToTables("user_accesstoken", dic1);
                                  var dt_user2 = tdal.get_baseuser_where(" and UserAccount='" + account + "' ");
                                  dt_user2.Columns.Add("token");
                                  dt_user2.Rows[0]["token"] = token;
                                  i = 1;
                                  message = "登录成功";
                                  js["userinfo"] = DataTableToJson(dt_user2);
                              }
                              else {
                                  i = 1;
                                  string token = CommonHelper.GetGuid;
                                  Dictionary<string, string> dic1 = new Dictionary<string, string>();
                                  dic1.Add("userid", dt_user.Rows[0]["id"].ToString());
                                  dic1.Add("accesstoken", token);
                                  BaseDal.InsertToTables("user_accesstoken", dic1);
                                  dt_user.Columns.Add("token");
                                  dt_user.Rows[0]["token"] = token;
                                  js["userinfo"] = DataTableToJson(dt_user);
                                  message = "登录成功";
                              }                                       
                    }
                    else
                    {
                        i = -2;
                        message = "验证码错误";
                    }
                }
                else {
                    message = "验证码错误";
                    i = -1;
                }
                 
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("register", ex.Message);
            } 
            AddJsonProperty("id", ref js);
            AddJsonProperty("message", ref js);
            js["id"] = i;
            js["message"] = message; 
            return js;
        }
    }
}
