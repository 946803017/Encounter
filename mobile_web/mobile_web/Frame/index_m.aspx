<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_m.aspx.cs" Inherits="mobile_web.Frame.index_m" %>

<!DOCTYPE html>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <title>首页</title>
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
		<!--header star-->
		<div class="header clearfloat">
			<div class="tu clearfloat">
				<img src="img/index-banner.jpg"/>
			</div>
			<header class="mui-bar mui-bar-nav">
				
		        <div class="top-sch-box flex-col">
		            <div class="centerflex">
		                <i class="fdj iconfont icon-sousuo"></i>
		                <div class="sch-txt">请输入您要搜索的内容</div>
		            </div>
		        </div>
		    </header>
            <form runat="server">
		    <div class="header-tit clearfloat">
		    	<p class="header-num">已经记了<span id="qunbu_biji" runat="server">0</span>个笔记！</p>
		    	<p class="header-da">Little Rain Note  </p>
		    </div>
                </form>
		</div>
		<!--header end-->
		<div id="main" class="mui-clearfix">
		 	<!-- 搜索层 -->
		    <div class="pop-schwrap">
		        <div class="ui-scrollview">
		        	<div class="poo-mui clearfloat box-s">
		        		<div class="mui-bar mui-bar-nav clone poo-muitwo">
			                <div class="top-sch-box flex-col">
			                    <div class="centerflex">
			                    	<i class="fdj iconfont icon-sousuo"></i>
			                        <input class="sch-input mui-input-clear" type="text" name="" id="" placeholder="请输入您要搜索的内容" />
			                    </div>
			                </div>			                
			            </div>
			            <a href="javascript:;" class="mui-btn mui-btn-primary btn-back" href="#">确定</a>
		        	</div>		            
		            
		        </div>
		    </div>
		    
		    <div class="cation clearfloat">
		    	<ul class="clearfloat">
		    		<li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
		    		<li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
                    <li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
                    <li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
                    <li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>

                    	<li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
		    		<li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
                    <li>
		    			<a href="#">
			    			<img src="img/self.png" />
			    			<p>功能建设中...</p>
		    			</a>
		    		</li>
                  
		    	</ul>
		    </div>
		    
		    <div class="recom clearfloat">
		    	<div class="recom-tit clearfloat box-s">
		    		<p>阅读 Top3  </p>
		    	</div>
		    	<div class="content clearfloat box-s">
		    		<%=this.yuedustr %>
		    	</div>
		    </div>

            <div class="recom clearfloat">
		    	<div class="recom-tit clearfloat box-s">
		    		<p>近期收藏                        <a href="get_jibi_list.aspx?code=1" style="margin-left:60%;color:#f58611; font-weight:600" >查看更多</a></p> 
		    	</div>
		    	<div class="content clearfloat box-s">
		    		<%=this.shoucangstr %>
                                       
		    	</div>
		    </div>
	   </div>
	   
	   <footer class="page-footer fixed-footer" id="footer">
			<ul>
				<li class="active">
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
				<li>
					<a href="my_center.aspx">
						<i class="iconfont icon-gerenzhongxin"></i>
						<p>个人中心</p>
					</a>
				</li>
			</ul>
		</footer>
	</body>
	<script type="text/javascript" src="js/jquery-1.8.3.min.js" ></script>
	<script src="js/fastclick.js"></script>
	<script src="js/mui.min.js"></script>
	<script type="text/javascript" src="js/hmt.js" ></script>
	<!--插件-->
	<link rel="stylesheet" href="css/swiper.min.css">
	<script src="js/swiper.jquery.min.js"></script>
	<!--插件-->

	<!--搜索点击效果-->
	<script >
	    $(function () {
	        var banner = new Swiper('.banner', {
	            autoplay: 5000,
	            pagination: '.swiper-pagination',
	            paginationClickable: true,
	            lazyLoading: true,
	            loop: true
	        });

	        mui('.pop-schwrap .sch-input').input();
	        var deceleration = mui.os.ios ? 0.003 : 0.0009;
	        mui('.pop-schwrap .scroll-wrap').scroll({
	            bounce: true,
	            indicators: true,
	            deceleration: deceleration
	        });
	        $('.top-sch-box .fdj,.top-sch-box .sch-txt,.pop-schwrap .btn-back').on('click', function () {
	            $('html,body').toggleClass('holding');
	            $('.pop-schwrap').toggleClass('on');
	            if ($('.pop-schwrap').hasClass('on')) {;
	                $('.pop-schwrap .sch-input').focus();
	            }
	        });

	    });
	</script>
</html>