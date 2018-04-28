using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.IO;
using LitJson;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///Tools 的摘要说明
/// </summary>
public class Tools
{
    public Tools()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string MD5Encrype(string str)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bytes = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
        return BitConverter.ToString(bytes);
    }


    public static string SHA1(string text)
    {
        byte[] cleanBytes = Encoding.Default.GetBytes(text);
        byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
        return BitConverter.ToString(hashedBytes).Replace("-", "");
    }

    public static string GetImagePathHeader(string path)
    {
        path = path.Remove(path.LastIndexOf('/'));
        path = path.Remove(path.LastIndexOf('/'));
        return path + "/";
    }

    public static DataTable AddDTHeader(string value, string text, DataTable dt)
    {
        DataRow dr = dt.NewRow();
        dr[0] = value;
        dr[1] = text;
        dt.Rows.InsertAt(dr, 0);
        return dt;
    }

   

    
    

    /// <summary>
    /// 获取指定文件的内容并存入数组
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public static byte[] GetFileBuffer(string filepath)
    {
        if (File.Exists(filepath))
        {
            FileStream fs = new FileInfo(filepath).OpenRead();
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return buf;
        }
        return new byte[0];
    }
    /// <summary>
    /// 限制图片大小
    /// </summary>
    /// <param name="imgwidth">数值 图片宽度</param>
    /// <param name="imgheight">数值 图片高度</param>
    /// <param name="imgurl">图片路径</param>
    /// <returns></returns>
    public static bool ImageSize(int imgwidth, int imgheight, string imgurl)
    {

        System.Drawing.Image _image = System.Drawing.Image.FromFile(imgurl); //获取图片
        if (_image.Width > imgwidth || _image.Height > imgheight)
        {
            return false;
        }
        return true;
    }
    public static void SendResponse(System.Web.HttpResponse response, string data)
    {
        response.Clear();
        response.Cache.SetCacheability(HttpCacheability.NoCache);
        response.Buffer = true;
        response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        response.Expires = 0;
        response.CacheControl = "no-cache";
        response.Cache.SetNoStore();
        response.Write(data);
        response.Flush();
        response.End();
    }

    /// <summary>
    /// 过滤文件名字符串中的非法字符串
    /// </summary>
    /// <param name="strpath"></param>
    /// <returns></returns>
    public static string FilterPathStr(string strpath)
    {
        string rPath = strpath;
        StringBuilder rBuilder = new StringBuilder(rPath);
        foreach (char rInvalidChar in Path.GetInvalidPathChars())
            rBuilder.Replace(rInvalidChar.ToString(), string.Empty);
        return rBuilder.ToString();
    }

    /// <summary>
    /// 发送短信 
    /// </summary>
    /// <param name="mobile">手机号</param>
    /// <param name="templateid">模板id</param>
    /// <param name="smscontent">内容</param>
    /// <returns></returns>
    public static Boolean sendSMS(string mobile, string templateid, string smscontent)
    {
        Boolean bRet = false;
        string retdata = "";
        try
        {
            string key = "47b517e614344e64b7febe928550dd33";
            try
            {
                if (mobile.Length == 11)
                {
                    string url = "http://v1.avatardata.cn/Sms/Send?key=" + key + "&mobile=" + mobile +
                        "&templateId=" + templateid + "&param=" + smscontent;
                    string ret = "";
                    WebClient client = new WebClient();
                    client.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    // "geotable_id=98210&coord_type=3&ak=FT5VAs2fqymIEYoGBv0wqfOG";
                    string postString = url;
                    //string postString = "geotable_id=97335&coord_type=3&ak=yxdgG3XAEYdL2tva5CBbh7wC"; 
                    byte[] postData = Encoding.Default.GetBytes(postString);
                    byte[] responseData = client.UploadData(url, "POST", postData);
                    ret = Encoding.Default.GetString(responseData);
                    JObject jo = (JObject)JsonConvert.DeserializeObject(ret);
                    string ss = jo["success"].ToString();
                    if (ss == "True")
                    {
                        bRet = true;                       
                    }
                    else
                    {
                        bRet = false;
                        retdata = "error:" + jo["reason"].ToString();                       
                    }
                }
                else
                {
                    retdata = "error:客户电话不是手机号，不能发送短信！";
                    
                }
            }
            catch (Exception ex)
            {
                bRet = false;
               
            }          
        }
        catch
        {

        }
        return bRet;
    }

    public static JsonData DataTableToJson(DataTable dt)
    {
        JsonData jsdata = new JsonData();
        try
        {
            StringBuilder sb = new StringBuilder();
            LitJson.JsonWriter jw = new LitJson.JsonWriter(sb);
            jw.WriteArrayStart();
            foreach (DataRow dr in dt.Rows)
            {
                jw.WriteObjectStart();
                foreach (DataColumn dc in dt.Columns)
                {
                    jw.WritePropertyName(dc.ColumnName);
                    jw.Write(dr[dc.ColumnName].ToString());
                }
                jw.WriteObjectEnd();
            }
            jw.WriteArrayEnd();
            jsdata = JsonMapper.ToObject(sb.ToString());
        }
        catch (System.Exception ex)
        {

        }

        return jsdata;
    }
    public static string ToJson(DataTable dt)
    {
        StringBuilder jsonString = new StringBuilder();
        jsonString.Append("[");
        DataRowCollection drc = dt.Rows;
        for (int i = 0; i < drc.Count; i++)
        {
            jsonString.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string strKey = dt.Columns[j].ColumnName;
                string strValue = drc[i][j].ToString();
                Type type = dt.Columns[j].DataType;
                jsonString.Append("\"" + strKey + "\":");
                strValue = String.Format(strValue, type);
                if (j < dt.Columns.Count - 1)
                {
                    jsonString.Append(strValue + ",");
                }
                else
                {
                    jsonString.Append(strValue);
                }
            }
            jsonString.Append("},");
        }
        jsonString.Remove(jsonString.Length - 1, 1);
        jsonString.Append("]");
        return jsonString.ToString();
    }
    public static Boolean AddJsonProperty(string name, ref JsonData targetjsondata)
    {
        Boolean bRet = false;
        if (targetjsondata != null)
        {
            StringBuilder sb = new StringBuilder(targetjsondata.ToJson());
            LitJson.JsonWriter jw = new LitJson.JsonWriter(sb);
            jw.WriteObjectStart();
            jw.WritePropertyName(name);
            jw.Write("");
            jw.WriteObjectEnd();
            targetjsondata = JsonMapper.ToObject(sb.ToString());
            bRet = true;
        }
        return bRet;
    }
    public static Boolean AddJsonArray(string name, ref JsonData targetjsondata)
    {
        Boolean bRet = false;
        if (targetjsondata != null)
        {
            StringBuilder sb = new StringBuilder(targetjsondata.ToJson());
            LitJson.JsonWriter jw = new LitJson.JsonWriter(sb);
            jw.WriteArrayStart();
            //jw.Write("{}");
            jw.WriteArrayEnd();
            targetjsondata[name] = JsonMapper.ToObject(sb.ToString());
            targetjsondata[name].SetJsonType(JsonType.Array);
            bRet = true;
        }
        return bRet;
    }


    /// <summary>
    /// 向Json对象中追加不存在的属性及值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="targetJsonObject"></param>
    /// <returns></returns>
    public static Boolean AddKeyValueToJsonObject(string key, string value, ref JsonData targetJsonObject)
    {
        if (AddJsonProperty(key, ref targetJsonObject))
        {
            targetJsonObject[key] = value;
            return true;
        }
        else
        {
            return false;
        }
    }


}
