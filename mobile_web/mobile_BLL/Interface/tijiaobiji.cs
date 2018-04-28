using LitJson;
using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_BLL.Interface
{
   public class tijiaobiji:JsonBase
    {  public JngsDal tdal = null;
    public tijiaobiji(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
        {
            int i = 0;
            string titile = "";
            try { titile = (string)optdatas["titile"]; }
            catch { titile = ""; }



            string content = "";
            try { content = (string)optdatas["content"]; }
            catch { content = ""; }

            string userid = "";
            try { userid = (string)optdatas["userid"]; }
            catch { userid = ""; }

            string baseimg = "";
            try { baseimg = (string)optdatas["baseimg"]; }
            catch { baseimg = ""; }
            JsonData js = new JsonData();
          
            try
            {

                Dictionary<string, string> dic = new Dictionary<string, string>();
                string filesname = "";
                if (baseimg != "")
                {
                    string ss = baseimg;
                    byte[] bt = Convert.FromBase64String(ss);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
                    Bitmap bitmap = new Bitmap(stream);
                     filesname = DateTime.Now.ToFileTime() + ".jpg";
                     bitmap.Save(@"C:\Web\笔记系统\fileimg\" + filesname + "", System.Drawing.Imaging.ImageFormat.Jpeg);
                  
                }
                dic.Add("titile", titile);
                dic.Add("content", content);
                dic.Add("userid", userid);
                i = 1;
              int ii=  BaseDal.InsertToTables("danci_t", dic);

                if (filesname != "")
                {
                    Dictionary<string, string> dic2 = new Dictionary<string, string>();
                    dic2.Add("danciid", ii.ToString());
                    dic2.Add("picurl", "../fileimg/" + filesname);
                    BaseDal.InsertToTables("upfiles", dic2);
                }
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("tijiaobiji", ex.Message);
            }
            AddJsonProperty("id", ref js);
            js["id"] = i;
            return js;
        }
    }
}
