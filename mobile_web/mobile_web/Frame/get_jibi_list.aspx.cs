using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class get_jibi_list : System.Web.UI.Page
    {
        public string userid = "";
        public string code = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            code = Request["code"];

            switch (code)
            {
                   
                case "1": { this.title.InnerText="我的收藏";} break;
                case "2": { this.title.InnerText="我的提醒";} break;
                case "3": {this.title.InnerText="已删除"; } break;
                case "4": {this.title.InnerText="我的全部"; } break;
                case "5": { this.title.InnerText = "已完成"; } break;
            }
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();
            }
        }
    }
}