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
  public  class shoucang :JsonBase
    {

       public JngsDal tdal = null;
       public shoucang(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
        {
            int i = 0;
            string id = "";
            try { id = (string)optdatas["id"]; }
            catch { id = ""; }
            JsonData js = new JsonData();          
            try
            {
                 
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("shoucang", ex.Message);
            }
            AddJsonProperty("id", ref js);
            js["id"] = i;
            return js;
        }
    }
}
