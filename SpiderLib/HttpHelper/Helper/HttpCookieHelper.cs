﻿using System;
using System.Collections.Generic;
using System.Net;

namespace Chat.Core.HttpHelper.Helper
{
    /// <summary>
    /// Cookie操作帮助类 
    /// </summary>
    internal static class HttpCookieHelper
    {
        /// <summary>
        /// 根据字符生成Cookie和精简串，将排除path,expires,domain以及重复项
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>精简串</returns>
        internal static string GetSmallCookie(string strcookie)
        {
            if (string.IsNullOrWhiteSpace(strcookie))
            {
                return string.Empty;
            }
            var cookielist = new List<string>();
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            var list = strcookie.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in list)
            {
                var itemcookie = item.ToLower().Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
                //排除空字符串
                if (string.IsNullOrWhiteSpace(itemcookie)) continue;
                //排除不存在=号的Cookie项
                if (!itemcookie.Contains("=")) continue;
                //排除path项
                if (itemcookie.Contains("path=")) continue;
                //排除expires项
                if (itemcookie.Contains("expires=")) continue;
                //排除domain项
                if (itemcookie.Contains("domain=")) continue;
                //排除重复项
                if (cookielist.Contains(item)) continue;

                //对接Cookie基本的Key和Value串
                cookielist.Add($"{item};");
            }
            return string.Join(";", cookielist);
        }

        /// <summary>
        /// 将字符串Cookie转为CookieCollection
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>List-CookieItem</returns>
        internal static CookieCollection StrCookieToCookieCollection(string strcookie)
        {
            //排除空字符串
            if (string.IsNullOrWhiteSpace(strcookie))
            {
                return null;
            }
            var cookielist = new CookieCollection();
            //先简化Cookie
            strcookie = GetSmallCookie(strcookie);
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            var list = strcookie.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in list)
            {
                var cookie = item.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (cookie.Length == 2)
                {
                    cookielist.Add(new Cookie() { Name = cookie[0].Trim(), Value = cookie[1].Trim() });
                }
            }
            return cookielist;
        }

        /// <summary>
        /// 将CookieCollection转为字符串Cookie
        /// </summary>
        /// <param name="cookie">Cookie字符串</param>
        /// <returns>strcookie</returns>
        internal static string CookieCollectionToStrCookie(CookieCollection cookie)
        {
            if (cookie == null)
            {
                return string.Empty;
            }
            var resultcookie = string.Empty;
            foreach (Cookie item in cookie)
            {
                resultcookie += $"{item.Name}={item.Value};";
            }
            return resultcookie;
        }
    }
}
