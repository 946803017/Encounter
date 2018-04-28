using LitJson;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_BLL.Interface
{
  public  class get_code:JsonBase
    {
      public JngsDal tdal = null;
          public get_code(JsonData dta)
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
            string status = "";
            try { status = (string)optdatas["status"]; }
            catch { status = ""; }
            JsonData js = new JsonData();
            string message = "";
            try
            {
                string str = "";
                if (status == "0")
                { str = "注册"; }
                else { str = "重置密码的"; }
               
                Random rad = new Random();//实例化随机数产生器rad；
                int value_code = rad.Next(1000, 10000);//用rad生成大于等于1000，小于等于999搜索9的随机数；
                bool s = Tools.sendSMS(account, "1e469859e14047078420cc05a96f19c1", "您的" + str + "验证码是：" + value_code.ToString() + "");
                if (s)
                {
                    tdal.insert_text_code(account, value_code.ToString());
                    i = 1;
                    message = "成功";
                }
                else {
                    i = -1;
                    message = "失败";
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
