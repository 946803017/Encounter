<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="get_jibi_list.aspx.cs" Inherits="mobile_web.Frame.get_jibi_list" %>

<!DOCTYPE html>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title></title>
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
    <script type="text/javascript">
        $(window).load(function () {
            $(".loading").addClass("loader-chanage")
            $(".loading").fadeOut(300)
        })
    </script>
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
        
         <form runat="server">
      <a href="javascript:history.go(-1)" style="margin-left:2%" class="fl box-s"><i class="iconfont icon-arrow-l fl"></i></a>
        <p class="fl bt" style="margin-left:10%" id="title" runat="server"></p>
      </form>
    </div>

    <div class="clearfloat" id="main">
        <div class="schedule clearfloat">
            <div class="notice">
               
                <div class="tab-bd clearfloat">
                    <div class="tab-pal" id="readdata">
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="mui-content-padded" id="pagess" style=" margin-bottom:20%">
            <ul class="mui-pager">
                <li class="mui-previous">
                    <a href="#" onclick="shangyiye()">上一页
                    </a>
                </li>
                <li class="mui-next" onclick="xiayiye()">
                    <a href="#">下一页
                    </a>
                </li>
            </ul>
        </div>
    <br />
    
</body>
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="js/jquery.SuperSlide.2.1.js"></script>
<script type="text/javascript" src="slick/slick.min.js"></script>
<script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
<script type="text/javascript" src="js/tchuang.js"></script>
<script type="text/javascript" src="js/hmt.js"></script>
<script src="../Interface/WeChatConnection.js"></script>
<script type="text/javascript">
    jQuery(".notice").slide({ titCell: ".tab-hd li", mainCell: ".tab-bd", trigger: "click", delayTime: 0 });
    var page = 1;


    get_my_biji('<%=this.userid%>', '<%=this.code%>', page.toString());
    
    function shangyiye() {
        if (page <= 0) {
            page = 2;
        }
        var val = page -= 1;
        get_my_biji('<%=this.userid%>', '<%=this.code%>', val.toString());
    }
    function xiayiye() {
        var val = page += 1;

        get_my_biji('<%=this.userid%>', '<%=this.code%>', val.toString());
     }
</script>
</html>