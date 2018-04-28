using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace mobile_web.Interface
{
    public class ip_rsa_mac
    {

        #region  获取客户请求的ip

        /// <summary> 
        /// 取得客户端真实IP。如果有代理则取第一个非内网地址 
        /// </summary> 
        public string IPAddress()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1)    //没有“.”肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];    //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null;    //代理中的内容 非IP，取IP 
                }
            }

            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;

            return result;

        }

        //// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        #endregion

        #region  获取 mac 地址
        /// <summary>  
        /// 获取网卡地址信息  
        /// </summary>  
        /// <returns></returns>  
        public string GetMacAddress()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return mac;
            }
            catch
            {
                return "unknow";
            }
        }
        #endregion

        #region RSA 密钥
        private const string PublicRsaKey = @"<RSAKeyValue>
  <Modulus>8Yvf/LjXRhCuOREk2CuSYvbD/RadwJ4sjHREIpQVKwkTlG3BtRgpnaMcoeLAesmwvpBWnqK4hBkYLxhRj+NEKnlGrJ+LkNMnZr0/4CMuulZFAnx7iQYaSq7Eh7kBKGLofc05CjZguYpnPNxHIv4VNx+a9tIh+hnhjrmkJLUm3l0=</Modulus>
  <Exponent>AQAB</Exponent>
</RSAKeyValue>";
        private const string PrivateRsaKey = @"<RSAKeyValue>
  <Modulus>8Yvf/LjXRhCuOREk2CuSYvbD/RadwJ4sjHREIpQVKwkTlG3BtRgpnaMcoeLAesmwvpBWnqK4hBkYLxhRj+NEKnlGrJ+LkNMnZr0/4CMuulZFAnx7iQYaSq7Eh7kBKGLofc05CjZguYpnPNxHIv4VNx+a9tIh+hnhjrmkJLUm3l0=</Modulus>
  <Exponent>AQAB</Exponent>
  <P>/xAaa/4dtDxcEAk5koSZBPjuxqvKJikpwLA1nCm3xxAUMDVxSwQyr+SHFaCnBN9kqaNkQCY6kDCfJXFWPOj0Bw==</P>
  <Q>8m8PFVA4sO0oEKMVQxt+ivDTHFuk/W154UL3IgC9Y6bzlvYewXZSzZHmxZXXM1lFtwoYG/k+focXBITsiJepew==</Q>
  <DP>ONVSvdt6rO2CKgSUMoSfQA9jzRr8STKE3i2lVG2rSIzZosBVxTxjOvQ18WjBroFEgdQpg23BQN3EqGgvqhTSQw==</DP>
  <DQ>gfp7SsEM9AbioTDemHEoQlPly+FyrxE/9D8UAt4ErGX5WamxSaYntOGRqcOxcm1djEpULMNP90R0Wc7uhjlR+w==</DQ>
  <InverseQ>C0eBsp2iMOxWwKo+EzkHOP0H+YOitUVgjekGXmSt9a3TvikQNaJ5ATlqKsZaMGsnB6UIHei+kUaCusVX0HgQ2A==</InverseQ>
  <D>tPYxEfo9Nb3LeO+SJe3G1yO+w37NIwCdqYB1h15f2YUMSThNVmpKy1HnYpUp1RQDuVETw/duu3C9gJL8kAsZBjBrVZ0zC/JZsgvSNprfUK3Asc4FgFsGfQGKW1nvvgdMbvqr4ClB0R8czkki+f9Oc5ea/RMqXxlI+XjzMYDEknU=</D>
</RSAKeyValue>";

        #endregion

        #region RSA 加密
        /// <summary>
        /// RSA 加密
        /// </summary>
        public string Rsa(string source)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PublicRsaKey);
            var cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(source), true);
            return Convert.ToBase64String(cipherbytes);
        }
        #endregion

        #region 解密
         /// <summary>
        /// RSA解密
        /// </summary>
        public  string UnRsa( string source)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PrivateRsaKey);
            var cipherbytes = rsa.Decrypt(Convert.FromBase64String(source), true);
            return Encoding.UTF8.GetString(cipherbytes);
        }
        #endregion

       
    }
}