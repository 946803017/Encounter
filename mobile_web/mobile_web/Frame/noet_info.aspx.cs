using mobile_DAL.DBHelper;
using mobile_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile_web.Frame
{
    public partial class noet_info : System.Web.UI.Page
    {
        public string ids = "";
        public string readdata = "";
        JngsDal dal= new  JngsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            ids = Request["ids"];

            readdata += "  <div class='service clearfloat'>";
            readdata += "		<div class='slider one-time'>";
            var dt_files = dal.get_pic("12");
       
   
            if (dt_files.Rows.Count > 0)
            {
                for (int i = 0; i < dt_files.Rows.Count; i++)
                {
                    readdata += "			<div>			";
                    readdata += "                <img src='../fileimg/"+ dt_files.Rows[i]["picurl"] + "' />";
                    readdata += "			</div>";
                }
            }
            else
            {
                readdata += "			<div>			";
                readdata += "                <img src='../images/yuantiao.jpg' />";
                readdata += "			</div>";
                readdata += "			<div>           ";
                readdata += "               <img src='../images/muwu.jpg' />";
                readdata += "			</div>";
                readdata += "			<div>";
                readdata += "               <img src='../images/shuijiao.jpg' />";
                readdata += "			</div>";
            }
            readdata += "		</div>";
            readdata += "	</div>	";

            var dt = dal.get_mydanci(" and id=12", "1");
            string dsa = DateTime.Now.ToString("yyyy-MM-dd-HH");
            string dassa = Convert.ToDateTime(dt.Rows[0]["tixingtim"].ToString()).ToString("yyyy-MM-dd-HH");
            if (dsa == dassa)
            { 
            
            }
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            int ssd = Convert.ToInt32(dt.Rows[0]["liulancount"]);
            ssd+=1;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("liulancount",ssd.ToString());
            BaseDal.UpdateTables("danci_t", dic, " id=" + ids + "");
            readdata += "     <div class='service-top clearfloat box-s'>";
            readdata += "		<div class='left fl clearfloat box-s' style=' width:100%;border:none'>";
            readdata += "			<p class='tit titwo'>" + dt.Rows[0]["titile"].ToString() + "</p>";

            if (dt.Rows[0]["zhouqi"].ToString() != "0")
            { readdata += "			<p class='fu-tit'>提醒阶段：" + dt.Rows[0]["zhouqi"].ToString() + "</p>"; }

            if (dt.Rows[0]["tixingtim"].ToString() != "" && dt.Rows[0]["status"].ToString()=="1")
            { readdata += "			<p class='fu-tit'>提醒时间：" + dt.Rows[0]["tixingtim"].ToString() + "</p>"; }
         

            readdata += "       <p class='fu-tit'>" + dt.Rows[0]["ct"].ToString() + "</p>";
            readdata += "		</div>	";
            readdata += "	</div>	";
            readdata += "	<div class='service-top clearfloat box-s'>		";
            readdata += "	<div class='right fl clearfloat ' style='border-right:1px solid #cbc4c4;width:25%'>";
            readdata += "		<i class=' fa fa-bell-o fa-lg  '></i>";
            if (dt.Rows[0]["status"].ToString() == "0")
            {
                readdata += "		<p style='margin-top:8%' id='tx' onclick='istixings();'>自动提醒</p>";
            }
            else if (dt.Rows[0]["status"].ToString() == "1")
            {
                readdata += "		<p style='margin-top:8%' id='tx'  onclick='istixings();'>已提醒</p>";
            }
            else if (dt.Rows[0]["status"].ToString() == "2")
            { readdata += "		<p style='margin-top:8%'>已完成</p>"; }
            readdata += "		</div>";
            readdata += "      <div class='right fl clearfloat 'style='border-right:1px solid #cbc4c4;width:25%'>";
            readdata += "		<i class='fa fa-star-o  fa-lg'></i>";
            if (dt.Rows[0]["shoucang"].ToString() != "0")
            {
                readdata += "		<p style='margin-top:7%' id='sc' onclick='ischoucang();'>已收藏</p>";
            }
            else {
                readdata += "		<p style='margin-top:7%' id='sc'  onclick='ischoucang();'>点击收藏</p>";
            }

            readdata += "	</div>";
            readdata += "     <div class='right fl clearfloat 'style='border-right:1px solid #cbc4c4;width:25%'>";
            readdata += "	<i class='fa fa-child fa-lg'></i>";
            if (dt.Rows[0]["status"].ToString() != "2")
            {
                readdata += "		<p style='margin-top:8%' id='wc' onclick='iswanchengs();' >点击完成</p>";
            }
            else {
                readdata += "		<p style='margin-top:8%' id='wc' onclick='iswanchengs();' >已完成</p>";
            }
            readdata += "	</div>";
            readdata += "    <div class='right fl clearfloat 'style='width:25%'>";
            readdata += "		<i class=' fa fa-trash fa-la'></i>";
            if (dt.Rows[0]["dm"].ToString() == "0")
            {
                readdata += "		<p style='margin-top:3%' id='dm' onclick='isdms()'>点击删除</p>";
            }
            else {
                readdata += "		<p style='margin-top:3%' >已删除</p>";
            }
            readdata += "	</div>";
            readdata += "	</div>        <button style='' id='demo1' data-options='{}' class='btn mui-btn mui-btn-block'>选择提醒日期时间</button> 	";
            readdata += "	<div class='service-ctent clearfloat'>";
            readdata += "	<div class='recom-tit clearfloat box-s'>";
            readdata += "		<p>笔记内容</p>";
            readdata += "  	</div>";
            readdata += "  	<p class='tit box-s' style='font-size:16px'>";
            readdata += " 		" + dt.Rows[0]["content"].ToString() + " ";

            readdata += "  	</p>";
            readdata += "	</div><br/><br/><br/><br/>";

        }
    }
}