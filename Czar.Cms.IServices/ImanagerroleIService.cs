/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-13 22:12:48                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.IServices                                   
*│　接口名称： ImanagerroleRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Models;
using Czar.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.IServices
{
    public interface ImanagerroleService
    {
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="model">查询实体</param>
        /// <returns>table数据</returns>
        TableDataModel LoadData(ManagerRoleRequestModel model);
        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="item">新增或修改视图实体</param>
        /// <returns>结果实体</returns>
        BaseResult AddOrModify(ManagerRoleAddOrModifyModel item);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns></returns>
        BaseResult DeleteIds(string[] ids);
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="model">查询实体</param>
        /// <returns>table数据</returns>
        List<managerrole> GetListByCondition(ManagerRoleRequestModel model);
        /// <summary>
        /// 通过角色ID获取角色分配的菜单列表
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <returns></returns>
        List<MenuNavView> GetMenusByRoleId(int roleId);
    }
}