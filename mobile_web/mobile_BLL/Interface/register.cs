using LitJson;
using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            catch { account = ""; }
            string textcode = "";
            try { textcode = (string)optdatas["textcode"]; }
            catch { textcode = ""; }
            string status = "";
            try { status = (string)optdatas["status"]; }
            catch { status = ""; }
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
                      
                        if (status == "0")
                        { 
                              var dt_user = tdal.get_baseuser_where(" and UserAccount='" + account + "' ");
                              if (dt_user.Rows.Count <= 0)
                              {

                                  Dictionary<string, string> dic = new Dictionary<string, string>();
                                  dic.Add("UserAccount", account);
                                  dic.Add("Password", BaseDal.MD5Encrype(pwd));
                                  dic.Add("UserId", DateTime.Now.ToFileTime().ToString());
                                 int useid= BaseDal.InsertToTables("BaseUser", dic);
                                  i = 1;
                                  message = "注册成功";

                                  js["userinfo"] = DataTableToJson(dt_user);
                              }
                              else {
                                  i = 1;
                                  message = "此手机已被注册";
                              }
                        }
                        else {
                            Dictionary<string, string> dic = new Dictionary<string, string>(); 
                            dic.Add("Password", BaseDal.MD5Encrype(pwd));
                            BaseDal.UpdateTables("BaseUser", dic, "UserAccount='"+account+"'");
                            i = 1;
                            message = "修改成功";
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
