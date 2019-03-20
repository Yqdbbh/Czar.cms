using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    public class ChangePasswordModel
    {
        /// <summary>
        /// 管理员id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 原密码
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// 重复新密码
        /// </summary>
        public string NewPasswordRe { get; set; }
    }
}
