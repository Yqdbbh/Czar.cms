using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    /// <summary>
    /// 导航加载视图
    /// </summary>
    public class MenuNavView
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string IconUrl { get; set; }

        public string LinkUrl { get; set; }
        /// <summary>
        /// 是否折叠
        /// </summary>
        public bool Spread { get; set; } = false;
        /// <summary>
        /// 是否新开窗口
        /// </summary>
        public string Target { get; set; }

    }
}
