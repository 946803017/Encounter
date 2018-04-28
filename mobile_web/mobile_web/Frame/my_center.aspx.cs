using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class my_center : System.Web.UI.Page
    {
        JngsDal dal = new JngsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                var dt_quanbu = dal.get_bj_quanbu(Session["userid"].ToString());
                this.qunbu_biji.InnerText = dt_quanbu.Rows[0]["sums"].ToString();

                var dt_shanchu = dal.get_bj_yishanchu(Session["userid"].ToString());
                this.yishanchu.InnerText = dt_shanchu.Rows[0]["sums"].ToString();

                var dt_wancheng= dal.get_bj_yiwancheng(Session["userid"].ToString());
                this.yiwancheng.InnerText = dt_wancheng.Rows[0]["sums"].ToString();

                var dt_tixing = dal.get_bj_yitiying(Session["userid"].ToString());
                this.yitiying.InnerText = dt_tixing.Rows[0]["sums"].ToString();

                var dt_shoucang= dal.get_bj_yishoucang(Session["userid"].ToString());
                this.yishoucang.InnerText = dt_shoucang.Rows[0]["sums"].ToString();

                var dt = dal.get_baseuser(Session["userid"].ToString());
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["picurl"].ToString() != "")
                    {
                        this.headimg.Src = dt.Rows[0]["picurl"].ToString();
                    }
                    if (dt.Rows[0]["UserName"].ToString() != "")
                    {
                        this.nicheng.InnerText = dt.Rows[0]["UserName"].ToString();
                    }
                   
                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script > location.href = '../Account/Login.html';</script>"); 
        }
    }
}