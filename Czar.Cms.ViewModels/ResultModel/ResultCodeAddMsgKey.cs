using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    public class ResultCodeAddMsgKey
    {
        #region 通用 100
        /// <summary>
        /// 通用成功编码
        /// </summary>
        public const int CommonObjectSuccessCode = 0;
        /// <summary>
        /// 通用操作成功消息
        /// </summary>
        public const string CommonObjectSuccessMsg = "操作成功";
        /// <summary>
        /// 通用Form验证失败错误码
        /// </summary>
        public const int CommonModelStateInvalidCode = 101;
        /// <summary>
        /// 通用Form验证失败错误消息
        /// </summary>
        public const string CommonModelStateInvalidMsg = "请求数据校验失败";
        /// <summary>
        /// 数据为空代码
        /// </summary>
        public const int CommonFailNoDataCode = 102;
        /// <summary>
        /// 数据为空信息
        /// </summary>
        public const string CommonFailNoDataMsg = "数据不存在";
        /// <summary>
        /// 数据状态改变码
        /// </summary>
        public const int CommonDataStatusChangeCode = 103;
        /// <summary>
        /// 数据状态改变消息
        /// </summary>
        public const string CommonDataStatusChangeMsg = "数据状态发生改变，请刷新后重试";
        /// <summary>
        /// 通用系统错误
        /// </summary>
        public const int CommonExceptionCode = 106;
        /// <summary>
        /// 系统错误消息
        /// </summary>
        public const string CommonExceptionMsg = "系统异常";

        #endregion

        #region 用户登录 200
        /// <summary>
        /// 错误此时超限
        /// </summary>
        public const int SignInErrorTimesOverTimesCode = 201;
        public const string SignInErrorTimesOverTimesMsg = "错误次数过多,请重新打开浏览器尝试。";
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        public const int SignInPasswordOrUserNameErrorCode = 202;
        public const string SignInPasswordOrUserNameErrorMsg = "对不起，您输入的用户名或密码错误";
        /// <summary>
        /// 用户被锁定
        /// </summary>
        public const int SignInUserLockedCode = 203;
        public const string SignInUserLockedMsg = "该账户已被锁定，请联系管理员";
        /// <summary>
        /// 验证码错误
        /// </summary>
        public const int SignInCaptchaCodeErrorCode = 204;
        public const string SignInCaptchaCodeErrorMsg = "验证码输入有误";
        /// <summary>
        /// 未分配角色
        /// </summary>
        public const int SignInNoRoleErrorCode = 205;
        public const string SignInNoRoleErrorMsg = "暂未分配角色，不允许进行登录，请联系管理员";
        /// <summary>
        /// 旧密码输入错误
        /// </summary>
        public const int PasswordOldErrorCode = 206;
        public const string PasswordOldErrorMsg = "旧密码输入错误";

        #endregion
    }
}
