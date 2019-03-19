/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-13 22:12:48                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.IServices                                   
*│　接口名称： ImanagerRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Models;
using Czar.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.IServices
{
    public interface ImanagerService
    {
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="model">查询实体</param>
        /// <returns>table数据</returns>
        TableDataModel LoadData(ManagerRequestModel model);
        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="item">新增或修改视图实体</param>
        /// <returns>结果实体</returns>
        BaseResult AddOrModify(ManagerAddOrModifyModel item);

        BaseResult DeleteIds(int[] Ids);

        //BaseResult ChangeLockStatus()

        manager SignIn(LoginModel model);
    }
}