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
  public  class isshoucang:JsonBase
    {
         public JngsDal tdal = null;
         public isshoucang(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
         {
             int i = -1;
             string id = "";
             try { id = (string)optdatas["id"]; }
             catch { id = ""; }
           
             JsonData js = new JsonData();
             try
             {
                 var dt = tdal.get_mydanci(" and a.id="+id+"","1");
                 if (dt.Rows.Count > 0)
                 {

                     if (dt.Rows[0]["shoucang"].ToString() == "0")
                     {
                         Dictionary<string, string> dic = new Dictionary<string, string>();
                         dic.Add("shoucang", "1");
                         BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                         i = 1;
                     }
                     else {
                         Dictionary<string, string> dic = new Dictionary<string, string>();
                         dic.Add("shoucang", "0");
                         BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                         i = 0;
                     }
                 }
             }
             catch (Exception ex)
             {
                 JngsDal.RecordError("isshoucang", ex.Message);
             }
             AddJsonProperty("id", ref js);
             js["id"] = i;
             return js;
         }
    }
}
