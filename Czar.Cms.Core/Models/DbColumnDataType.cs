﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Core.Models
{
    public class DbColumnDataType
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// 数据库中对应的类型
        /// </summary>
        public string ColumnTypes { get; set; }

        /// <summary>
        /// C#对应的类型
        /// </summary>
        public string CSharpType { get; set; }
    }
}
