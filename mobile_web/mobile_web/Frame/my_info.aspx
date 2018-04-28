<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_info.aspx.cs" Inherits="mobile_web.Frame.my_info" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>我的资料</title>
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
    <script type="text/javascript" src="js/menu.js" ></script>
    <link rel="stylesheet" href="css/mui.min1.css">
	<link rel="stylesheet" type="text/css" href="css/app.css" />
	<link rel="stylesheet" type="text/css" href="css/mui.picker.min.css" />
	<link href="css/mui.picker.css" rel="stylesheet" />
	<link href="css/mui.poppicker.css" rel="stylesheet" />

	<script type="text/javascript">
	    $(window).load(function () {
	        $(".loading").addClass("loader-chanage")
	        $(".loading").fadeOut(300)
	    })
	</script>

    <style type="text/css">
        .con4
        {
            width: 300px;
            height: auto;
            overflow: hidden;
            margin: 20px auto;
            color: #FFFFFF;
        }
        .con4 .btnwww
        {
            width: 100%;
            height: 40px;
            line-height: 40px;
            text-align: center;
            background: #d8b49c;
            display: block;
            font-size: 16px;
            border-radius: 5px;
        }
        .upload
        {
            float: left;
            position: relative;
        }
        .upload_pic
        {
            display: block;
            width: 100%;
            height: 40px;
            position: absolute;
            left: 0;
            top: 0;
            opacity: 0;
            border-radius: 5px;
        }
        #cvs
        {
            margin: 10px 0 20px 50px;
            border:1px solid #e4d2d2
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

        
		<div class="headertwo clearfloat" id="header">
			<a href="javascript:history.go(-1)" class="fl box-s"><i class="iconfont icon-arrow-l fl"></i></a>
			<p class="fl bt" style="margin-left:5%">我的资料</p>	
		</div>      
		<div class="clearfloat" id="main">
			<div class="lease clearfloat">
				
         <div class="con4">
      
        <div  style= "margin-left:18%">
           <img id="imgs" runat="server" src="img/people.png" style="width:200px;height:200px;border-radius:130px" />
        </div>
    </div>
				
				<div class="land-ctent land-ctenttwo clearfloat">
					<ul>
						<li class="box-s clearfloat">
							<p class="tit fl" ">昵称</p>
							<input type="text" name="" disabled="true" id="nicheng" runat="server"  placeholder="" class="fl" />
						</li>
						<li class="box-s clearfloat">
							<p class="tit fl">用户名</p>
							<input type="text" name="" disabled="true" id="yonghuming" value="" runat="server" placeholder="" class="fl" />
						</li>
					
						<li class="box-s clearfloat">
							<p class="tit fl">个人说明</p>
                            
							<input type="text" name="" disabled="true"  placeholder="" id="shuoming" runat="server"   class="fl" />
						</li>
						
					</ul>					
				</div>
				
				
			</div>
		</div>
		</form>
	</body>

	<script type="text/javascript" src="js/jquery-1.8.3.min.js" ></script>
	<script type="text/javascript" src="slick/slick.min.js" ></script>
	<script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
	<script type="text/javascript" src="js/tchuang.js" ></script>
	<script type="text/javascript" src="js/hmt.js" ></script>
	<script src="js/mui.min.js"></script>
	<script src="js/mui.picker.min.js"></script>
	<script src="js/mui.picker.js"></script>
	<script src="js/mui.poppicker.js"></script>
	<script src="js/city.data.js" type="text/javascript" charset="utf-8"></script>
	<script src="js/city.data-3.js" type="text/javascript" charset="utf-8"></script>    
</html>