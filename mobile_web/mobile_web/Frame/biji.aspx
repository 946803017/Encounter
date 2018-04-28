<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="biji.aspx.cs" Inherits="mobile_web.Frame.biji" %>

<!DOCTYPE html>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>我的笔记</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <script src="js/rem.js"></script>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <link rel="stylesheet" type="text/css" href="css/page.css" />
    <link rel="stylesheet" type="text/css" href="css/all.css" />
    <link rel="stylesheet" type="text/css" href="css/mui.min.css" />
    <link rel="stylesheet" type="text/css" href="css/loaders.min.css" />
    <link rel="stylesheet" type="text/css" href="css/loading.css" />
    <link rel="stylesheet" type="text/css" href="slick/slick.css" />
    <link href="../css/mui.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(window).load(function () {
            $(".loading").addClass("loader-chanage")
            $(".loading").fadeOut(300)
        })
    </script>
    <style type="text/css">
        .con4 {
            width: 300px;
            height: auto;
            overflow: hidden;
            margin: 20px auto;
            color: #FFFFFF;
        }

            .con4 .btnwww {
                width: 100%;
                height: 40px;
                line-height: 40px;
                text-align: center;
                background: #d8b49c;
                display: block;
                font-size: 16px;
                border-radius: 5px;
            }

        .upload {
            float: left;
            position: relative;
        }

        .upload_pic {
            display: block;
            width: 100%;
            height: 40px;
            position: absolute;
            left: 0;
            top: 0;
            opacity: 0;
            border-radius: 5px;
        }

        #cvs {
            margin: 10px 0 20px 50px;
          
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
    <div class="headertwo clearfloat" id="header" style="height:7%"> 
       
        <p class="fl bt" style="margin-left:10%">记笔记</p>
       
    </div>

    <div class="clearfloat" id="main" style="margin-top:15%">

       
			<div class="mui-content-padded" style="margin: 5px;">
			
				<form class="mui-input-group">
					
					<div class="mui-input-row">
						<label style="width:70px">标题</label>
						<input type="text" id="titles" class="mui-input-clear" style="margin-top:-2%" placeholder="输入标题">
					</div>

				
					
				</form>
                <div class="mui-input-row">
                    <label>内容</label>
				<div class="mui-input-row" style="margin: 10px 5px;">
					<textarea  id="infos" rows="5" placeholder="输入内容"></textarea>
				</div>
                    </div>


                 <div class="con4" style="margin-top:-6%">
                    
        <canvas id="cvs" width="400" height="150" style="border-radius:30px"></canvas>
        <span class="btnwww upload">上传图片<input type="file" class="upload_pic" id="upload"></span>
    </div>

                <div class="mui-button-row">
						<button type="button" class="mui-btn mui-btn-primary" onclick="tijiao();">确认</button>&nbsp;&nbsp;
						<button type="button" class="mui-btn mui-btn-danger" onclick="return false;">取消</button>
				 </div>
			</div>
		


    </div>
  
    <footer class="page-footer fixed-footer" id="footer" style="margin-top:-30%">
        <ul>
            <li>
                <a href="index_m.aspx">
                    <i class="iconfont icon-shouyev1"></i>
                    <p>动态</p>
                </a>
            </li>
            <li class="active">
                <a href="biji.aspx">
                    <i class="iconfont icon-chuzuwo"></i>
                    <p>记笔记</p>
                </a>
            </li>
            <li >
                <a href="danci_my.aspx">
                    <i class="iconfont icon-richengbiao"></i>
                    <p>我的笔记</p>
                </a>
            </li>
            <li>
                <a href="my_center.aspx">
                    <i class="iconfont icon-gerenzhongxin"></i>
                    <p>个人中心</p>
                </a>
            </li>
        </ul>
    </footer>
</body>
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.js"></script>
<script type="text/javascript" src="slick/slick.min.js"></script>
<script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
<script type="text/javascript" src="js/tchuang.js"></script>
<script type="text/javascript" src="js/hmt.js"></script>

    <script src="../js/jquery-1.8.3.js"></script>
<script src="../js/mui.min.js"></script>
<script src="../Interface/WeChatConnection.js"></script>
<script type="text/javascript">

    var input1 = document.getElementById("upload");
    var imgUrl = "";
    if (typeof FileReader === 'undefined') {

        input1.setAttribute('disabled', 'disabled');
    } else {
        input1.addEventListener('change', readFile, false);
        input1.addEventListener('change', function (e) {
            console.log(this.files);
        }, false);
    }
    function readFile() {
        var file = this.files[0];
        if (!/image\/\w+/.test(file.type)) {

            alert("文件必须为图片！");
            return false;
        }


        var reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = function (e) {
            console.log(this.result);
            console.log(e.target.result);
            var data = e.target.result.split(',');
            var tp = (file.type == 'image/png') ? 'png' : 'jpg';
            imgUrl = data[1];

            var image = new Image();

            image.src = e.target.result;
            var max = 200;

            image.onload = function () {

                var canvas = document.getElementById("cvs");

                var ctx = canvas.getContext("2d");

                ctx.clearRect(0, 0, canvas.width, canvas.height);

                ctx.drawImage(image, 0, 0, 200, 200);

            };
        }
    };


    function tijiao() {

        if ($("#titles").val() == "" || $("#infos").val() == "") {
            mui.toast("请输入标题或内容");
            return;
        }
        tijioabiji($("#titles").val(), $("#infos").val(), imgUrl, '<%=this.userid%>');

    }
 </script>
</html>