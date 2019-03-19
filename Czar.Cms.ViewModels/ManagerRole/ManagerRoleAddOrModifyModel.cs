using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    public class ManagerRoleAddOrModifyModel
    {
        public Int32 Id { get; set; }
        
        public string RoleName { get; set; }

        public Int32 RoleType { get; set; }

        public string Remark { get; set; }

        public Boolean IsSystem { get; set; }

        public int[] MenuIds { get; set; }
    }
}
