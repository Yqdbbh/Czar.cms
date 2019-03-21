using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    public class ManagerListModel
    {
        public Int32 Id { get; set; }

        public Int32 RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Avator { get; set; }

        public string NickName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public Int32? LoginCount { get; set; }

        public string LoginLastIp { get; set; }

        public Boolean IsLock { get; set; }

        public string Remark { get; set; }
    }
}
