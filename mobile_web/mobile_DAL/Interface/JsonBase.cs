using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace mobile_DAL.Interface
{
    
      public abstract class JsonBase
        {
            public JsonData optdatas;
            public string strBaseUrl;
            public JsonBase()
            {
            }

            public JsonBase(JsonData dta)
            {
                optdatas = dta;
            }
            /// <summary>
            /// 将DataTable对象数据转换为Json对象数组格式
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static JsonData DataTableToJson(DataTable dt)
            {
                JsonData jsdata = new JsonData();
                try
                {
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jw = new JsonWriter(sb);
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
                    JsonWriter jw = new LitJson.JsonWriter(sb);
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
                    JsonWriter jw = new LitJson.JsonWriter(sb);
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

            public abstract object GetData();
        }
    }
