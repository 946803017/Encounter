using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class index_m : System.Web.UI.Page
    {
        public string yuedustr = "";

        public string shoucangstr = "";
        JngsDal dal = new JngsDal();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["userid"] == null)
            {
                return;
            }

            var dt_quanbu = dal.get_bj_quanbu(Session["userid"].ToString());
            this.qunbu_biji.InnerText = dt_quanbu.Rows[0]["sums"].ToString();

            var dt_liulnatop3 = dal.top3_yuedu(Session["userid"].ToString());
            for (int i = 0; i < dt_liulnatop3.Rows.Count; i++)
            {
                yuedustr += "   <div class='list clearfloat fl box-s'>";
                yuedustr += "  			<a href='noet_info.aspx?ids=" + dt_liulnatop3.Rows[i]["id"] + "'>		";
                yuedustr += "     			<div class=' clearfloat'>";
                yuedustr += " 	    				<div class='tit clearfloat'>";
                yuedustr += "     					<p class='fl'>" + dt_liulnatop3.Rows[i]["titile"] + "</p>";
                yuedustr += "     					<span class='fr' style='color:#f58611;font-size:14px'>浏览次数：" + dt_liulnatop3.Rows[i]["liulancount"] + "</span>";
                yuedustr += "    				</div>";
                yuedustr += " 	    				<p class='recom-jianjie'>" + dt_liulnatop3.Rows[i]["content"] + "</p>";
                yuedustr += " 	    				<div class='recom-bottom clearfloat'>";
                if (dt_liulnatop3.Rows[i]["shoucang"].ToString() == "1")
                {
                    yuedustr += " 	    					<span><i class='iconfont icon-duihao'></i>已收藏</span>";
                }
                if (dt_liulnatop3.Rows[i]["status"].ToString() == "1")
                {
                    yuedustr += "     					<span><i class='iconfont icon-duihao'></i>已提醒</span>";
                }
                yuedustr += "     				</div>";
                yuedustr += " 	    			</div>";
                yuedustr += " 			</a>";
                yuedustr += " 		</div>";
            }





            var dt_shoucangtop3 = dal.top3_shoucang(Session["userid"].ToString());
            for (int i = 0; i < dt_shoucangtop3.Rows.Count; i++)
            {
                shoucangstr += "   <div class='list clearfloat fl box-s'>";
                shoucangstr += "  			<a href='noet_info.aspx?ids=" + dt_liulnatop3.Rows[i]["id"] + "'>	";
                shoucangstr += "     			<div class=' clearfloat'>";
                shoucangstr += " 	    				<div class='tit clearfloat'>";
                shoucangstr += "     					<p class='fl'>" + dt_shoucangtop3.Rows[i]["titile"] + "</p>";
                shoucangstr += "     					<span class='fr' style='color:#f58611;font-size:14px'>浏览次数：" + dt_shoucangtop3.Rows[i]["liulancount"] + "</span>";
                shoucangstr += "    				</div>";
                shoucangstr += " 	    				<p class='recom-jianjie'>" + dt_shoucangtop3.Rows[i]["content"] + "</p>";
                shoucangstr += " 	    				<div class='recom-bottom clearfloat'>";
                if (dt_shoucangtop3.Rows[i]["shoucang"].ToString() == "1")
                {
                    shoucangstr += " 	    					<span><i class='iconfont icon-duihao'></i>已收藏</span>";
                }
                if (dt_shoucangtop3.Rows[i]["status"].ToString() == "1")
                {
                    shoucangstr += "     					<span><i class='iconfont icon-duihao'></i>已提醒</span>";
                }
                shoucangstr += "     				</div>";
                shoucangstr += " 	    			</div>";
                shoucangstr += " 			</a>";
                shoucangstr += " 		</div>";
            }

        }
    }
}