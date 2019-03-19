using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    /// <summary>
    /// 分页相关实体
    /// </summary>
    public class PageModel
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public string Key { get; set; }

        public PageModel()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
