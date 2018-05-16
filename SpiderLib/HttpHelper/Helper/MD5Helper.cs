﻿namespace Chat.Core.HttpHelper.Helper
{
    /// <summary>
    /// md5操作相关  
    /// </summary>
    internal class MD5Helper
    {
        /// <summary>
        /// 传入明文，返回用MD5加密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        internal static string ToMD5_32(string str)
        {
            var passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }

        /// <summary>
        /// 传入明文，返回用SHA1密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>SHA1加密后的字符串</returns>
        internal static string ToSHA1(string str)
        {
            var passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }
    }
}
