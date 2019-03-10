using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Core.Models
{
    /// <summary>
    /// 数据库中对应的表
    /// </summary>
    [Serializable]
    public class DbTable
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 数据库表注释
        /// </summary>
        public string TableComment { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public virtual List<DbTableColumn> Columns { get; set; } = new List<DbTableColumn>();
    }
}
