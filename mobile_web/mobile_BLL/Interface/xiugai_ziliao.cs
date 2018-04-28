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
  public   class xiugai_ziliao:JsonBase
    {

       public JngsDal tdal = null;
       public xiugai_ziliao(JsonData dta)
            : base(dta)
        {
         tdal = new JngsDal();
        }

        public override object GetData()
        {
            int i = 0; 
            string nicheng = "";
            try { nicheng = (string)optdatas["nicheng"]; }
            catch { nicheng = ""; }

           

            string shuoming = "";
            try { shuoming = (string)optdatas["shuoming"]; }
            catch { shuoming = ""; }

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

                if (baseimg != "")
                {
                    string ss = baseimg;
                    byte[] bt = Convert.FromBase64String(ss);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
                    Bitmap bitmap = new Bitmap(stream);
                    string filesname = DateTime.Now.ToFileTime() + ".jpg";
                    bitmap.Save(@"C:\Web\笔记系统\fileimg\" + filesname + "", System.Drawing.Imaging.ImageFormat.Jpeg);
                    dic.Add("picurl", "../fileimg/" + filesname);
                }

                dic.Add("UserName", nicheng);
                dic.Add("jieshao", shuoming);
                i = 1;
                BaseDal.UpdateTables("baseuser",dic,"userid='"+userid+"'");
                
            }
            catch (Exception ex)
            {
                JngsDal.RecordError("xiugai_ziliao", ex.Message);
            }
            AddJsonProperty("id", ref js);
            js["id"] = i;
            return js;
        }
    }
}
