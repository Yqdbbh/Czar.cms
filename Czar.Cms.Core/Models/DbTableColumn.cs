using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Core.Models
{
    /// <summary>
    /// 列属性
    /// </summary>
    [Serializable]
    public class DbTableColumn
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string ColName { get; set; }

        /// <summary>
        /// 是否自增
        /// </summary>
        public bool Identity { get; set; }

        /// <summary>
        /// 主键标识
        /// </summary>
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public long? ColumnLength { get; set; }

        /// <summary>
        /// 可空
        /// </summary>
        public bool Nullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 字段注释
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// C#类型
        /// </summary>
        public string CSharpType { get; set; }
    }
}
