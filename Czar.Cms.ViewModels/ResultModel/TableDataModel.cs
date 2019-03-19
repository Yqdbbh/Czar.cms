using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    /// <summary>
    /// LayUi表返回的数据
    /// </summary>
    public class TableDataModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 操作消息
        /// </summary>
        public string msg { get; set; } = "操作成功";
        /// <summary>
        /// 总记录条数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic data { get; set; }
    }
}
