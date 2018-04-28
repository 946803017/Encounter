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
    public class isdm : JsonBase
    {
        public JngsDal tdal = null;
        public isdm(JsonData dta)
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
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("dm", "1");
                BaseDal.UpdateTables("danci_t", dic, "id=" + id + "");
                i = 1;
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
