﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Czar.Cms.Core.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// 获取当前用户的ip
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetClientUserIp(this HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }

        /// <summary>
        /// 判断是否是ajax请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException(nameof(request));
            }
            return request.Headers.ContainsKey("X-Requested-With") &&
                request.Headers["X-Requested-With"].Equals("XMLHttpRequest");
        }
    }
}
