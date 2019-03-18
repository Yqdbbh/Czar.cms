using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.ViewModels
{
    /// <summary>
    /// 结果基类
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// 返回结果编码
        /// </summary>
        public int ResultCode { get; set; } = ResultCodeAddMsgKey.CommonObjectSuccessCode;
        /// <summary>
        /// 返回结果消息
        /// </summary>
        public string ResultMsg { get; set; } = ResultCodeAddMsgKey.CommonObjectSuccessMsg;

        public BaseResult() { }


        public BaseResult(int resultCode,string resultMsg)
        {
            ResultCode = resultCode;
            ResultMsg = resultMsg;
        }



    }
}
