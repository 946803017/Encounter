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
    public class get_login : JsonBase
    {
        public JngsDal tdal = null;
        public get_login(JsonData dta)
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
            string message = "";

            string token = "";
            try { token = (string)optdatas["token"]; }
            catch { token=""; }
            JsonData js = new JsonData();
            try
            {
                pwd = "666666";
                AddJsonProperty("userinfo", ref js); 
                var dt = tdal.public_user_login(account, BaseDal.MD5Encrype(pwd));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["DeleteMark"].ToString() == "1")
                    {
                        i = -2;
                        message = "此号被冻结";
                        js["userinfo"] = DataTableToJson(dt);
                    }
                    else {
                        i = 1;
                        message = "成功";
                        js["userinfo"] = DataTableToJson(dt);
                    }
                }
                else {
                    i = -1;
                    message = "账号或密码错误";
                    js["userinfo"] = DataTableToJson(dt);
                }

            }
            catch (Exception ex)
            {
                JngsDal.RecordError("get_code", ex.Message);
            }
            AddJsonProperty("id", ref js);
            AddJsonProperty("message", ref js);
            js["id"] = i;
            js["message"] = message;
            return js;
        }
    }
}
