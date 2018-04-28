using LitJson;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_BLL.Interface
{
  public  class test:JsonBase
    {
       public JngsDal tdal = null;
       public test(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
       {
           
            int i = 123456; 
            string page = "";
            try { page = (string)optdatas["page"]; }
            catch { page = ""; }
            JsonData js = new JsonData();
             DataTable dt = new DataTable();
            try
            {
                 js = DataTableToJson(dt);
                 bool s = Tools.sendSMS("13606379420", "", "");
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("complain_dispose", ex.Message);
            }                 
            return js;
        }
    }
}
