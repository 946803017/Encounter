using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class my_info : System.Web.UI.Page
    {

        JngsDal dal = new JngsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                var dt = dal.get_baseuser(Session["userid"].ToString());
                this.nicheng.Value = dt.Rows[0]["UserName"].ToString();
                this.shuoming.Value = dt.Rows[0]["jieshao"].ToString();
                this.yonghuming.Value = dt.Rows[0]["UserAccount"].ToString();
               
                if (dt.Rows[0]["picurl"].ToString() != "")
                {
                    this.imgs.Src =  dt.Rows[0]["picurl"].ToString();
                }


            }            
        }
    }
}