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
  public  class istixing:JsonBase
    {

          public JngsDal tdal = null;
          public istixing(JsonData dta)
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
             string datetime = "";
             try { datetime = (string)optdatas["date"]; }
             catch { datetime = ""; }
             JsonData js = new JsonData();
             try
             {
                 var dt = tdal.get_mydanci(" and a.id="+id+" and a.dm=0 ","1");
                 if (dt.Rows.Count > 0)
                 {

                     if (datetime != "" && dt.Rows[0]["status"].ToString() == "1")
                     {
                         i = 3; 
                         AddJsonProperty("id", ref js);
                         js["id"] = i;
                         return js;
                     }

                     if (datetime != "" && dt.Rows[0]["status"].ToString() == "0")
                     {

                         Dictionary<string, string> dic = new Dictionary<string, string>();
                         dic.Add("status", "1");
                         dic.Add("tixingtim", datetime);
                         BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                         i = 1;
                         AddJsonProperty("id", ref js);
                         js["id"] = i;
                         return js;
                     }
                         if (dt.Rows[0]["status"].ToString() == "0")
                         {
                             Dictionary<string, string> dic = new Dictionary<string, string>();
                             dic.Add("status", "1");
                             dic.Add("zhouqi", "1");
                             BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                             i = 1;
                         }
                         else if (dt.Rows[0]["status"].ToString() == "1")
                         {
                             Dictionary<string, string> dic = new Dictionary<string, string>();
                             dic.Add("status", "0");
                             dic.Add("zhouqi", "0");
                             dic.Add("tixingtim", "");
                             BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                             i = 0;
                         }
                         else if (dt.Rows[0]["status"].ToString() == "2")
                         {
                             i = 2;
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
