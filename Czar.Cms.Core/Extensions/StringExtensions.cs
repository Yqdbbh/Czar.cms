using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Czar.Cms.Core.Extensions
{
    /// <summary>
    /// String类扩展方法
    /// </summary>
    public static class StringExtensions
    {
        [DebuggerStepThrough] //???什么意思
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
