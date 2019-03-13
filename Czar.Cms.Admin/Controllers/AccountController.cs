using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Czar.Cms.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Czar.Cms.Admin.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// session中存储的验证码name
        /// </summary>
        private readonly string CaptchaCode = "CaptchaCode";

        private readonly string ManagerSignInErrorTimes = "ManagerSignInErrorTimes";

        private readonly int MaxErrorTimes = 3;

        private ImanagerService _servie;

        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="servie"></param>
        public AccountController(ImanagerService service)
        {
            _servie = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCatchaImage()
        {
            return null;
        }
    }
}