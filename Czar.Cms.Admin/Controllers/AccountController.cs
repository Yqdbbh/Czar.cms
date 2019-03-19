using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Czar.Cms.Admin.Validation;
using Czar.Cms.Core.Extensions;
using Czar.Cms.Core.Helper;
using Czar.Cms.IServices;
using Czar.Cms.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        private readonly string CaptchaCodeName = "CaptchaCode";

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

        public async Task<string> SignInAsync(LoginModel model)
        {
            BaseResult result = new BaseResult();

            #region 判断验证码
            if (!ValidateCaptchaCode(model.CaptchaCode)){
                result.ResultCode = ResultCodeAddMsgKey.SignInCaptchaCodeErrorCode;
                result.ResultMsg = ResultCodeAddMsgKey.SignInCaptchaCodeErrorMsg;
                return JsonHepler.ObjectToJSON(result);
            }
            #endregion
            #region 判断错误次数
            var ErrorTimes = HttpContext.Session.GetInt32(ManagerSignInErrorTimes);
            if (ErrorTimes == null)
            {
                HttpContext.Session.SetInt32(ManagerSignInErrorTimes, 1);
                ErrorTimes = 1;
            }
            else
            {
                HttpContext.Session.SetInt32(ManagerSignInErrorTimes, ErrorTimes.Value + 1);
            }
            if (ErrorTimes > MaxErrorTimes)
            {
                result.ResultCode = ResultCodeAddMsgKey.SignInErrorTimesOverTimesCode;
                result.ResultMsg = ResultCodeAddMsgKey.SignInErrorTimesOverTimesMsg;
                return JsonHepler.ObjectToJSON(result);
            }
            #endregion
            #region 再次属性判断
            LoginModelValidation validation = new LoginModelValidation();
            ValidationResult results = validation.Validate(model);
            if (!results.IsValid)
            {
                result.ResultCode = ResultCodeAddMsgKey.CommonModelStateInvalidCode;
                result.ResultMsg = results.ToString("||");
            }
            #endregion

            model.Ip = HttpContext.GetClientUserIp();
            var manager = _servie.SignIn(model);

            return null;
        }



        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCatchaImage()
        {
            //验证码
            string captchaCode = CaptchaHelper.GenerateCaptchaCode();
            //图片
            var result = CaptchaHelper.GetImage(116,36,captchaCode);
            //存储验证码
            HttpContext.Session.SetString(CaptchaCodeName, captchaCode);
            //返回图片
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "img/png");
        }

        private bool ValidateCaptchaCode(string userInputCaptchaCode)
        {
            var valid = userInputCaptchaCode.Equals(HttpContext.Session.GetString(CaptchaCodeName), StringComparison.OrdinalIgnoreCase);
            HttpContext.Session.Remove(CaptchaCodeName);
            return valid;
        }
    }
}