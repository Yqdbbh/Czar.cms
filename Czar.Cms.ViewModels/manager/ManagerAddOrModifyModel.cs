using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{ 
    /// <summary>
    /// Manager新增或修改实体
    /// </summary>
    public class ManagerAddOrModifyModel
    {
        public Int32 Id { get; set; }

        public Int32 RoleId { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }

        public string NickName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public Boolean IsLock { get; set; }

        public string Remark { get; set; }
    }
}
