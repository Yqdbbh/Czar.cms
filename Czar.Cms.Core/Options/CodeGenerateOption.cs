﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Core.Options
{
    /// <summary>
    /// 代码生成选项
    /// </summary>
    public class CodeGenerateOption:DbOption
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public string GenerateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

        /// <summary>
        /// 输出路径
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// 实体命名空间
        /// </summary>
        public string ModelsNamespace { get; set; }
    }
}
