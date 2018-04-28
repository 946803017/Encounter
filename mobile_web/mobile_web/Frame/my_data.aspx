<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_data.aspx.cs" Inherits="mobile_web.Frame.my_data" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>修改资料</title>
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
		<div class="headertwo clearfloat" id="header">
			<a href="javascript:history.go(-1)" class="fl box-s"><i class="iconfont icon-arrow-l fl"></i></a>
			<p class="fl bt" style="margin-left:5%">修改资料</p>
		
		</div>	
		
        
		<div class="clearfloat" id="main">
			<div class="lease clearfloat">
				<div class="top clearfloat box-s">
					<i class="iconfont icon-gonggao fl"></i>
					<span class="fl box-s">请修改你的信息！</span>
				</div>
         <div class="con4">
        <canvas id="cvs" width="200" height="200" style="border-radius:130px"></canvas>
        <span class="btnwww upload">选择头像<input type="file" class="upload_pic" id="upload"></span>
    </div>
				
				<div class="land-ctent land-ctenttwo clearfloat">
					<ul>
						<li class="box-s clearfloat">
							<p class="tit fl">昵称</p>
							<input type="text" name="" id="nicheng" value="" placeholder="昵称" class="fl" />
						</li>
						
					
						<li class="box-s clearfloat">
							<p class="tit fl">个人说明</p>
                            
							<input type="text" name=""  placeholder="个人说明" id="shuoming" value=""  class="fl" />
						</li>
						
					</ul>					
				</div>
				
				<a href="#" id="">
					<input type="button" name="" id="" onclick="tijiao();" value="确认" class="btn" />
				</a>
			</div>
		</div>
		
		
		
		
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
<script src="../Interface/WeChatConnection.js"></script>
	<script src="js/city.data.js" type="text/javascript" charset="utf-8"></script>
	<script src="js/city.data-3.js" type="text/javascript" charset="utf-8"></script>


  <script>
      //获取上传按钮
      var input1 = document.getElementById("upload");
      var imgUrl = "";
      if (typeof FileReader === 'undefined') {
          //result.innerHTML = "抱歉，你的浏览器不支持 FileReader"; 
          input1.setAttribute('disabled', 'disabled');
      } else {
          input1.addEventListener('change', readFile, false);
          input1.addEventListener('change', function (e) {
              console.log(this.files); //上传的文件列表
          }, false);
      }
      function readFile() {
          var file = this.files[0]; //获取上传文件列表中第一个文件
          if (!/image\/\w+/.test(file.type)) {
              //图片文件的type值为image/png或image/jpg
              alert("文件必须为图片！");
              return false;
          }
          
          // console.log(file);
          var reader = new FileReader(); //实例一个文件对象
          reader.readAsDataURL(file); //把上传的文件转换成url
          //当文件读取成功便可以调取上传的接口
          reader.onload = function (e) {
              console.log(this.result); //文件路径
              console.log(e.target.result); //文件路径
              var data = e.target.result.split(',');
              var tp = (file.type == 'image/png') ? 'png' : 'jpg';
               imgUrl = data[1]; //图片的url，去掉(data:image/png;base64,)
              //需要上传到服务器的在这里可以进行ajax请求
             
           //  console.log(imgUrl);
              // 创建一个 Image 对象 
          //  var image = new Image();
              // 创建一个 Image 对象
            //  image.src = imgUrl;           
            //  image.src = e.target.result;            
             // image.onload = function () {
              //    document.body.appendChild(image);
             // }
              var image = new Image();
              // 设置src属性 
              image.src = e.target.result;            
              var max = 200;
              // 绑定load事件处理器，加载完成后执行，避免同步问题
              image.onload = function () {
                  // 获取 canvas DOM 对象 
                  var canvas = document.getElementById("cvs");
                  // 如果高度超标 宽度等比例缩放 *= 
                  /*if(image.height > max) {
                  image.width *= max / image.height; 
                  image.height = max;
                  } */
                  // 获取 canvas的 2d 环境对象, 
                  var ctx = canvas.getContext("2d");
                  // canvas清屏 
                  ctx.clearRect(0, 0, canvas.width, canvas.height);
                  // 重置canvas宽高
                  /*canvas.width = image.width;
                  canvas.height = image.height;
                  if (canvas.width>max) {canvas.width = max;}*/
                  // 将图像绘制到canvas上
                  // ctx.drawImage(image, 0, 0, image.width, image.height);
                  ctx.drawImage(image, 0, 0, 200, 200);
                  // 注意，此时image没有加入到dom之中
              };
          }
      };


      function tijiao()
      {
          xiugaiziliao($("#nicheng").val(), $("#shuoming").val(), imgUrl, '<%=this.userid%>');

       }
</script>
	  



    
</html>