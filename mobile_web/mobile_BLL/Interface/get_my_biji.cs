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
   public class get_my_biji:JsonBase
    {

        public JngsDal tdal = null;
        public get_my_biji(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
        {
           
            string page = "";
            try { page = (string)optdatas["page"]; }
            catch { page = ""; }
            string uid = "";
            try { uid = (string)optdatas["uid"]; }
            catch { uid = ""; }
            string code = "";
            try { code = (string)optdatas["code"]; }
            catch { code = ""; }
            string titile = "";
            try { titile = (string)optdatas["title"]; }
            catch { titile = ""; }
            JsonData js = new JsonData();
             DataTable dt = new DataTable();
            try
            {
                string where = "";
                if (titile != "")
                {
                    where += " and a.title like '%"+titile+"%'";
                }
                switch (code)
                {
                   
                    case "1": { where += " and a.shoucang=1 "; } break; //收藏的
                    case "2": { where += " and a.status=1 "; } break;  //提醒的
                    case "3": { where += " and a.dm=1 "; } break; //已删除的
                    case "4": { where += " and a.dm= 0"; } break;     //未删除的    
                    case "5": { where += " and a.status= 2"; } break;//完成的
                }
                where += " and a.userid='"+uid+"' ";
                dt = tdal.get_mydanci(where, page);
                 js = DataTableToJson(dt);
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("complain_dispose", ex.Message);
            }
          
            return js;
        }
    }
}
