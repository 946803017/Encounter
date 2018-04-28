<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noet_info.aspx.cs" Inherits="mobile_web.Frame.noet_info" %>

<!DOCTYPE html>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>笔记详情</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <link href="../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/rem.js"></script>   
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/base.css"/>
    <link rel="stylesheet" type="text/css" href="css/page.css"/>
    <link rel="stylesheet" type="text/css" href="css/all.css"/>
    <link rel="stylesheet" type="text/css" href="css/mui.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/loaders.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/loading.css"/>
    <link rel="stylesheet" type="text/css" href="slick/slick.css"/>

    <link href="../css/mui.picker.min.css" rel="stylesheet" />
	<script type="text/javascript">
	    $(window).load(function () {
	        $(".loading").addClass("loader-chanage")
	        $(".loading").fadeOut(300)
	    })
	</script><style>
			html,
			body,
			.mui-content {
				height: 0px;
				margin: 0px;
				background-color: #efeff4;
			}
			h5.mui-content-padded {
				margin-left: 3px;
				margin-top: 20px !important;
			}
			h5.mui-content-padded:first-child {
				margin-top: 12px !important;
			}
			.mui-btn {
				font-size: 16px;
				padding: 8px;
				margin: 0px;
              
                background-color:#45b1d4;
               color:#fff;
               border-radius:5px
			}
			.ui-alert {
				text-align: center;
				padding: 20px 10px;
				font-size: 16px;
			}
			* {
				-webkit-touch-callout: none;
				-webkit-user-select: none;
			}
	             btn {
                   
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
			<p class="fl">笔记详情</p>	
		</div>		
		<!--分享内容-->
			
		<div class="clearfloat" id="main">		
			<%=this.readdata %>
						
		</div>	
 
	

    


    </body>
	<script type="text/javascript" src="js/jquery-1.8.3.min.js" ></script>
	<script type="text/javascript" src="slick/slick.min.js" ></script>
	<script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
	<script type="text/javascript" src="js/tchuang.js" ></script>
	<script type="text/javascript" src="js/hmt.js" ></script>
<script src="js/mui.min.js"></script>
<script src="../js/mui.picker.min.js"></script>
     <script src="../Interface/WeChatConnection.js"></script>
	<script type="text/javascript">
	    $('.one-time').slick({
	        dots: true,
	        infinite: false,
	        speed: 300,
	        slidesToShow: 1,
	        touchMove: false,
	        slidesToScroll: 1
	    });

	    mui('.mui-scroll-wrapper').scroll();
	    mui('body').on('shown', '.mui-popover', function (e) {
	        //console.log('shown', e.detail.id);//detail为当前popover元素
	    });
	    mui('body').on('hidden', '.mui-popover', function (e) {
	        //console.log('hidden', e.detail.id);//detail为当前popover元素
	    });

	    (function ($) {
	        $.init();
	        var result = $('#demo1')[0];           
	        var btns = $('#demo1');
	        btns.each(function (i, btn) {
	            btn.addEventListener('tap', function () {
	                var optionsJson = this.getAttribute('data-options') || '{}';
	                var options = JSON.parse(optionsJson);
	                var id = this.getAttribute('id');	               
	                var picker = new $.DtPicker(options);
	                picker.show(function (rs) {	                   
	                    result.innerText = rs.text;
	                 
	                    istixing('<%=this.ids%>', rs.text);
	                    picker.dispose();
	                });
	            }, false);
	        });
	    })(mui);

	    function ischoucang()
	    {
	        ishoucang('<%=this.ids%>');  
            
	    }

	    function isdms()
	    {
	        isdm('<%=this.ids%>');
	    }

	    function iswanchengs()
	    {
	        iswancheng('<%=this.ids%>');
	    }

	    function istixings()
	    {
	        istixing('<%=this.ids%>');
	    }
	</script>
	
	
</html>
