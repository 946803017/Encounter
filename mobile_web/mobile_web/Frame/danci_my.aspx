<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="danci_my.aspx.cs" Inherits="mobile_web.Frame.danci_my" %>

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
       
        <p class="fl bt" style="margin-left:10%">我的笔记</p>
      
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
    <footer class="page-footer fixed-footer" id="footer" style="margin-top:-30%">
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
            <li class="active">
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
<script src="../Interface/WeChatConnection.js"></script>
<script type="text/javascript">
    jQuery(".notice").slide({ titCell: ".tab-hd li", mainCell: ".tab-bd", trigger: "click", delayTime: 0 });
    var page = 1;
    get_my_biji('<%=this.userid%>', "4", page.toString());

    function shangyiye() {
        if (page <= 0) {
            page = 2;
        }
        var val = page -= 1;
        get_my_biji('<%=this.userid%>', "4", val.toString());
    }
    function xiayiye() {
         var val = page += 1;

         get_my_biji('<%=this.userid%>', "4", val.toString());
    }
</script>
</html>
