<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_center.aspx.cs" Inherits="mobile_web.Frame.my_center" %>

<!DOCTYPE html>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>个人中心</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <script src="js/rem.js"></script> 
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/base.css"/>
    <link rel="stylesheet" type="text/css" href="css/page.css"/>
    <link rel="stylesheet" type="text/css" href="css/all.css"/>
    <link rel="stylesheet" type="text/css" href="css/mui.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/loaders.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/loading.css"/>
    <link rel="stylesheet" type="text/css" href="slick/slick.css"/>
	<script type="text/javascript">
	    $(window).load(function () {
	        $(".loading").addClass("loader-chanage")
	        $(".loading").fadeOut(300)
	    })
	</script>
    <style>
        .pifu {
           /*background-color:#55b6e6*/
           background-image:url(../images/timg4.jpg);
            background-repeat:no-repeat; background-size:100% 100%;-moz-background-size:100% 100%;
        }
    </style>
</head>
<!--loading页开始-->
<div class="loading">
	<div class="loader">
        <div class="loader-inner pacman">
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
        </div>
	</div>
</div>
<!--loading页结束-->
	<body>
        <form runat="server">
		<div class="center-header clearfloat  pifu"  id="header"    style=" ">
		<a href="my_data.aspx" class="fr shezhi" >修改</a>
			<div class="top fl clearfloat box-s" style="margin-bottom:6%">
				<a href="my_info.aspx">
					<div class="tu fl">
						<span></span>
                    <img src="img/people.png"  id="headimg" runat="server" />
					</div>
					<p class="tit fl" style=""><b style="color:#fff" id="nicheng" runat="server">您还没有昵称哦</b></p>
					<i class="iconfont icon-arrowright fr"></i>
				</a>
			</div>
			<div class="bottom clearfloat"  >
				<ul>
					<li>
						<a href="#"  class="clearfloat">
							<p style=" font-weight:600" id="yitiying" runat="server" >0</p>
							<p style=" font-weight:600">已提醒</p>
						</a>
					</li>
					<li>
						<a href="#" class="clearfloat">
							<p style=" font-weight:600" id="yishoucang" runat="server">0</p>
							<p style=" font-weight:600">已收藏</p>
						</a>
					</li>
				
                    <li>
						<a href="#" class="clearfloat">
							<p style=" font-weight:600" >0</p>
							<p style=" font-weight:600">功能待定</p>
						</a>
					</li>

                    <li>
						<a href="#" class="clearfloat">
							<p style=" font-weight:600" >0</p>
							<p style=" font-weight:600">功能待定</p>
						</a>
					</li>
				</ul>
			</div>
		</div>
		
		<div class="clearfloat pcenter" id="main" >
			<div class="p-list clearfloat box-s">				
				<i class="iconfont icon-caifu fl ben"></i>
				<span class="fl">我的笔记</span>
			</div>
			<div class="p-fenlei clearfloat">
				<ul>
					<li>
						<a href="get_jibi_list.aspx?code=4" class="clearfloat">
							<p id="qunbu_biji" runat="server">0</p>
							<p>全部</p>
						</a>
					</li>
					<li>
						<a href="get_jibi_list.aspx?code=5" class="clearfloat">
							<p id="yiwancheng" runat="server">0</p>
							<p>已完成</p>
						</a>
					</li>
					<li>
						<a href="get_jibi_list.aspx?code=3" class="clearfloat">
							<p id="yishanchu" runat="server">0</p>
							<p>已删除</p>
						</a>
					</li>
				</ul>
			</div>
          
			<div class="p-list p-listwo clearfloat box-s">
				<a href="get_jibi_list.aspx?code=1" class="clearfloat">
					<i class="iconfont icon-favorite fl xing"></i>
					<span class="fl">我的收藏</span>
					<i class="iconfont icon-arrowright fr you"></i>
				</a>            
			</div>
            <div class="p-list p-listwo clearfloat box-s">
				<a href="get_jibi_list.aspx?code=2" class="clearfloat">
					<i class="iconfont icon-gonggao fl gonggao"></i>
					<span class="fl">我的提醒</span>
					<i class="iconfont icon-arrowright fr you"></i>
				</a>            
			</div>
            
			
	    	
          
			<div class="p-list p-listwo clearfloat box-s">
				<a href="#" class="clearfloat">
					<i class="iconfont icon-gerenzhongxin fl gerenzhongxin"></i>
					<span class="fl">关于 Little Rain Note</span>
					<i class="iconfont icon-arrowright fr you"></i>
				</a>
			</div>
			<div class="p-list p-listhree clearfloat box-s">
				<a href="../Account/retrieve_pwd.html" class="clearfloat">
					<i class="iconfont icon-lock fl lock"></i>
					<span class="fl">修改密码</span>
					<i class="iconfont icon-arrowright fr you"></i>
				</a>
			</div>
              <div class="p-list p-listwo clearfloat box-s" style="">
				<a href="#" onclick="tuichu();" class="clearfloat" onmousemove="">
					<i class=""></i>
					<span class="fl">退出登录</span>
					<i class="iconfont icon-arrowright fr you"></i>
				</a>            
			</div>
		</div>
             <asp:Button ID="Button1" style="display:none" runat="server" Text="Button" OnClick="Button1_Click" />
		</form>
		<footer class="page-footer fixed-footer" id="footer">
			<ul>
				<li>
					<a href="index_m.aspx">
						<i class="iconfont icon-shouyev1"></i>
						<p>动态</p>
					</a>
				</li>
				<li>
					<a href="biji.aspx">
						<i class="iconfont icon-chuzuwo"></i>
						<p>记笔记</p>
					</a>
				</li>
				<li>
					<a href="danci_my.aspx">
						<i class="iconfont icon-richengbiao"></i>
						<p>我的笔记</p>
					</a>
				</li>
				<li class="active">
					<a href="my_center.aspx">
						<i class="iconfont icon-gerenzhongxin"></i>
						<p>个人中心</p>
					</a>
				</li>
			</ul>
		</footer>
      
       
	
            </body>
	<script type="text/javascript" src="js/jquery-1.8.3.min.js" ></script>
	<script type="text/javascript" src="slick/slick.min.js" ></script>
	<script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
	<script type="text/javascript" src="js/tchuang.js" ></script>
	<script type="text/javascript" src="js/hmt.js" ></script>
    <script>

        function tuichu() {
            document.getElementById("Button1").click();
           
        }
    </script>
   
</html>