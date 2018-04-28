
//数据请求接口.js 

var datainfo = [];

//第一种请求方式
function send_data_requestnew(data, func) {

    $.ajax({
        type: "post",
        url: "../Interface/get_data.ashx",
        data: JSON.stringify(data),
        dataType: "text",
        success: function (data, textStatus) {
            if (data == "0x11") {
                mui.toast('非法访问,网络请求失败');
                window.location.href = "../error.html";
            }
            else if (data.indexOf("error:") > -1) {

            } else {
                data = JSON.parse(data);
                func(data);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("网络请求失败！");
        }
    });
};

//注册验证码
function get_zhuce_code(account) {

    var datareq = {
        appid: "A00002",
        optdata: {
            account: account,
            status: "0"
        },
        optstring: "get_code"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1" || tmp.id == "0") {
            mui.toast('验证码发送失败');

        } else {
            mui.toast('发送成功,请注意短信提醒');
        }

    });
};

//重置密码 验证码
function get_chongzhi_code(account) {

    var datareq = {
        appid: "A00002",
        optdata: {
            account: account,
            status: "1"
        },
        optstring: "get_code"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1" || tmp.id == "0") {
            mui.toast('验证码发送失败');

        } else {
            mui.toast('发送成功,请注意短信提醒');
        }

    });
};


//注册or 修改
function get_zhuce_zhongzhi(account, pwd, code, status) {

    var datareq = {
        appid: "A00002",
        optdata: {
            account: account,
            pwd: pwd,
            textcode: code,
            status: status
        },
        optstring: "register"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1" || tmp.id == "2") {
            mui.toast('验证码错误');

        }
        else if (tmp.id == "-3")
        { mui.toast('此用户已被注册'); }
        else {
            if (status == "0") {
                mui.toast('注册成功');
                //  window.location.href = "Login.html";
            } else {
                mui.toast('重置密码成功');
                //  window.location.href = "Login.html";
            }
        }

    });
};


function SetRemainTime() {
    if (curCount == 0) {
        window.clearInterval(InterValObj);//停止计时器 
        $("#codess").removeAttr("disabled");//启用按钮 
        $("#codess").html("重新发送验证码");
    }
    else {
        curCount--;
        $("#codess").html(curCount + "秒后可重新发送");
    }
}

//我的笔记
function get_my_biji(uid, code, page) {
    var datareq = {
        appid: "A00002",
        optdata: {
            uid: uid,
            code: code,
            page: page
        },
        optstring: "get_my_biji"
    };
    send_data_requestnew(datareq, function (data) {

        var ids = [];
        var title = [];
        var content = [];
        var ct = [];
        var status = [];
        var liulancount = [];
        var zhouqi = [];
        var userid = [];
        var shoucang = [];
        var readdata = "";
        for (var i = 0; i < data.result.length; i++) {
            tmp = data.result[i];
            ids.push(tmp.id);
            title.push(tmp.titile);
            content.push(tmp.content);
            ct.push(tmp.ct);
            status.push(tmp.status);
            liulancount.push(tmp.liulancount);
            zhouqi.push(tmp.zhouqi);
            userid.push(tmp.userid);
            shoucang.push(tmp.shoucang);

            var zqstr = "";
            if (zhouqi[i] != "0") {
                zqstr = '<p class="tit fr"> 当前记忆为:第 ' + zhouqi[i] + '周期</p>'
            }
            readdata += '    <div class="content clearfloat box-s">';
            readdata += '                 <div class="topsche-top box-s clearfloat">';
            readdata += '                     <p class="fl time">';
            readdata += '                        <i class="iconfont icon-time"></i>';
            readdata += '   ' + ct[i] + '';
            readdata += '    </p>';

            readdata += '       ' + zqstr + '';

            readdata += '    </div>';
            readdata += '   <div class="list clearfloat fl box-s">';
            readdata += '  <a href="noet_info.aspx?ids=' + ids[i] + '">		';
            readdata += '   <div class=" clearfloat">';
            readdata += '     <div class="tit clearfloat">';
            readdata += '        <p class="fl">' + title[i] + '</p>';
            //readdata+='        <span class="fr" style="color:#808080;font-size:14px">2017-10-29 16:21:43</span>	';				
            readdata += '       </div>';
            readdata += '       <p class="recom-jianjie">' + content[i] + '</p>';
            readdata += '      <div class="recom-bottom clearfloat">';
            if (shoucang[i] != "0") {
                readdata += '         <span><i class="iconfont icon-duihao"></i>已收藏</span>';
            }
            if (status[i] == "1") {
                readdata += '       <span><i class="iconfont icon-duihao"></i>已提醒</span>';
            }
            readdata += '     				</div>';
            readdata += '      			</div>';
            readdata += '  		</a>';
            readdata += '  		</div>';
            readdata += '              </div>';


        }

        if (data.result.length <= 0) {

            $("#pagess").css("display", "none");
            readdata = "<div   ><a style='text-align:center;color:#808080; margin-left:36%'>没有更多数据。。。</a></div> <br>";
        } else if (data.result.length < 10) {


            readdata += " <br/><div><a style='text-align:center;color:#808080; margin-left:36%'>没有更多数据。。。</a></div><br>";
        }

        $('#readdata').html(readdata);

    });
};

//修改资料
function xiugaiziliao(nicheng, shuoming, img, userid) {

    var datareq = {
        appid: "A00002",
        optdata: {
            nicheng: nicheng,
            shuoming: shuoming,
            userid: userid,
            baseimg: img
        },
        optstring: "xiugai_ziliao"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "1") {
            mui.toast('成功');

        } else {

            mui.toast('失败');

        }

    });
};

//提交笔记
function tijioabiji(titile, content, img, userid) {

    var datareq = {
        appid: "A00002",
        optdata: {
            titile: titile,
            content: content,
            userid: userid,
            baseimg: img
        },
        optstring: "tijiaobiji"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "1") {
            mui.toast('成功');
            window.location.href = "danci_my.aspx";
        } else {

            mui.toast('失败');

        }

    });
};


//收藏
function ishoucang(id) {

    var datareq = {
        appid: "A00002",
        optdata: {
            id: id
            
        },
        optstring: "isshoucang"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1") {
            mui.toast('收藏失败');           
        } else if (tmp.id == "0") {           
            mui.toast('已取消收藏');
            $("#sc").html("点击收藏");           
        } else if (tmp.id == "1")
        {
            mui.toast('已收藏');
            $("#sc").html("取消收藏");
        }

    });
};

//已删除
function isdm(id) {

    var datareq = {
        appid: "A00002",
        optdata: {
            id: id

        },
        optstring: "isdm"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1") {
            mui.toast('删除失败');
        } else if (tmp.id == "1") {
            mui.toast('已删除');
            $("#dm").html("已删除");
        }

    });
};
//已完成
function iswancheng(id) {

    var datareq = {
        appid: "A00002",
        optdata: {
            id: id
        },
        optstring: "iswancheng"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1") {
            mui.toast('失败');
        } else if (tmp.id == "1") {
            mui.toast('已完成');
            $("#wc").html("已完成");
        }

    });
};


function istixing(id,date) {

    var datareq = {
        appid: "A00002",
        optdata: {
            id: id,
            date:date
        },
        optstring: "istixing"
    };
    send_data_requestnew(datareq, function (data) {

        tmp = data.result;
        if (tmp.id == "-1") {
            mui.toast('提醒失败');
        } else if (tmp.id == "0") {
            mui.toast('已关闭提醒');
            $("#tx").html("点击提醒");
        }
        else if (tmp.id == "1") {
            mui.toast('已提醒');
            $("#tx").html("已提醒");
        }
        else if (tmp.id == "2") {
            mui.toast('此笔记已完成');        
        }
        else if (tmp.id == "3") {
            mui.toast('请先关闭自动提醒');
        }
    });
};