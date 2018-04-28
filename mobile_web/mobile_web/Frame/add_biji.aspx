<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_biji.aspx.cs" Inherits="mobile_web.Frame.add_biji" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">

	
    <link href="../css/mui.min.css" rel="stylesheet" />
    <title>添加笔记</title>
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
<body>
		
		<div class="mui-content">
			<div class="mui-content-padded" style="margin: 5px;">
			
				<form class="mui-input-group">
					
					<div class="mui-input-row">
						<label>标题</label>
						<input type="text" id="titles" class="mui-input-clear" placeholder="输入标题">
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
	
		
	</body>
</html>
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

        if ($("#titles").val() == "" || $("#infos").val() == "")
        {
            mui.toast("请输入标题或内容");
            return;
        }
        tijioabiji($("#titles").val(), $("#infos").val(), imgUrl, '<%=this.userid%>');

    }
 </script>