using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TBSoft.Base.Common.BaseEncrypt;
using TBSoft.Base.Common.BaseConfig;
using mobile_DAL.DBHelper;

namespace mobile_DAL.DBHelper
{
    public class BaseDal
    {
        public BaseDal()
        {
        }
        public static string MD5Encrype(string str)
        {
            return Md5Helper.MD5(str, 32);            
        }
        /// <summary>
        /// 向指定表格中插入数据
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="fieldlist"></param>
        /// <returns>插入后返回的记录ID</returns>
        public static int InsertToTables(string strTableName, Dictionary<string, string> fieldlist)
        {
            string strSql = "insert into " + strTableName + " ({0}) values ({1});select @@IDENTITY";

            string fields = "";
            string parms = "";
            int belen = fieldlist.Count;

            SqlParameter[] parameters = new SqlParameter[belen];
            int i = 0;
            foreach (string key in fieldlist.Keys)
            {
                fields += key + ",";
                parms += "@" + key + ",";
                parameters[i] = new SqlParameter("@" + key, fieldlist[key]);
                i++;
            }
            fields = fields.Remove(fields.LastIndexOf(','));
            parms = parms.Remove(parms.LastIndexOf(','));
            strSql = string.Format(strSql, fields, parms);

            object obj = DbHelperSQL.GetSingle(strSql, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToInt32(obj);
                }
                catch (Exception ex)
                {
                    DbHelperSQL.RecordError("BaseDal", ex.Message + " /r/n " + ex.Source);
                    return 1;
                }
            }
           
        }

        /// <summary>
        /// 根据SQL语句获取相应数据，并返回Datatable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(string strSql)
        {
            try
            {
                DataSet ds = DbHelperSQL.Query(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                DbHelperSQL.RecordError("BaseDal", ex.Message + " /r/n " + ex.Source);
                throw ex;
            }
        }
        /// <summary>
        /// 使用带参数的SQL语句进行数据查询（推荐使用本方式）
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(string strSql,Dictionary<string, string> conditions)
        {
            try
            {
                int belen = conditions.Count;
                SqlParameter[] parameters = new SqlParameter[belen];
                int i = 0;
                foreach (string key in conditions.Keys)
                {
                    parameters[i] = new SqlParameter("@" + key, conditions[key]);
                    i++;
                }

                DataSet ds = DbHelperSQL.Query(strSql, parameters);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                DbHelperSQL.RecordError("QueryDataTable", ex.Message + " /r/n " + ex.Source);
                throw ex;
            }
        }
        /// <summary>
        /// 基于参数的分页查询方式，防止恶意Sql注入（推荐使用）
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="conditions"></param>
        /// <param name="page"></param>
        /// <param name="orderby"></param>
        /// <param name="sort_order"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByPage(string top,string strSql,Dictionary<string, string> conditions,  string page, string orderby, string sort_order)
        {
            try
            {
                int curentpage = int.Parse(page);
                StringBuilder sqlsb = new StringBuilder();
                sqlsb.Append(" SELECT top " + top + " * FROM ( SELECT ROW_NUMBER() OVER (order by T1." + orderby + " " + sort_order + ")AS Row,");
                sqlsb.Append("T1.* from ( ");
                sqlsb.Append(strSql);
                sqlsb.Append(" ) T1) TT ");
                sqlsb.AppendFormat(" WHERE TT.Row > {0} ", (curentpage - 1) * int.Parse(top));
                int belen=conditions.Count;
                SqlParameter[] parameters = new SqlParameter[belen];
                int i = 0;
                foreach (string key in conditions.Keys)
                {
                    parameters[i] = new SqlParameter("@" + key, conditions[key]);
                    i++;
                }

                DataSet ds = DbHelperSQL.Query(sqlsb.ToString(), parameters);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                DbHelperSQL.RecordError(ex.Source, ex.Message);
                throw ex;
            }

        }
        
        public static void InsertToTablesWithNoReturn(string strTableName, Dictionary<string, string> fieldlist)
        {
            string strSql = "insert into " + strTableName + " ({0}) values ({1})";

            string fields = "";
            string parms = "";
            int belen = fieldlist.Count;

            SqlParameter[] parameters = new SqlParameter[belen];
            int i = 0;
            foreach (string key in fieldlist.Keys)
            {
                fields += key + ",";
                parms += "@" + key + ",";
                parameters[i] = new SqlParameter("@" + key, fieldlist[key]);
                i++;
            }
            fields = fields.Remove(fields.LastIndexOf(','));
            parms = parms.Remove(parms.LastIndexOf(','));
            strSql = string.Format(strSql, fields, parms);

            object obj = DbHelperSQL.GetSingle(strSql, parameters);
            
            //int rows = DbHelperSQL.ExecuteSql(strSql, parameters);
        }

        /// <summary>
        /// 更新指定表
        /// </summary>
        /// <param name="strTableName">需要更新的表名</param>
        /// <param name="fieldlist">需要更新的字段名称及值</param>
        /// <param name="conditions">更新条件</param>
        /// <returns>更新成功的数据数量</returns>
        public static int UpdateTables(string strTableName, Dictionary<string, string> fieldlist, string conditions)
        {
            string strSql = "update " + strTableName + " set ";
            int belen = fieldlist.Count;
            SqlParameter[] parameters = new SqlParameter[belen];
            int i = 0;
            foreach (string key in fieldlist.Keys)
            {
                strSql += key + "=@" + key + ",";
                parameters[i] = new SqlParameter("@" + key, fieldlist[key]);
                i++;
            }
            strSql = strSql.Remove(strSql.LastIndexOf(','));
            strSql += " where 1=1 ";
            if (!string.IsNullOrEmpty(conditions))
            {
                strSql += " and " + conditions;
            }
            int rows = DbHelperSQL.ExecuteSql(strSql, parameters);
            return rows;
        }
        //---执行函数
        public static int ExecuteSql(string strSql)
        {
            

            try
            {
                return DbHelperSQL.ExecuteSql(strSql);
            }
            catch (Exception ex)
            {
                DbHelperSQL.RecordError("BaseDal", ex.Message + " /r/n " + ex.Source);
                return 0;
            }

        }
        public static void RecordError(string ename, string emessage)
        {
            DbHelperSQL.RecordError(ename, emessage);
        }

    }
}
