/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：管理员角色表                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 18:05:41                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.IRepository                                  
*│　接口名称：ImanagerroleRepository                                     
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Core.Repository;
using Czar.Cms.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Czar.Cms.IRepository
{
	public interface ImanagerroleRepository:IBaseRepository<managerrole,Int32>
	{
		/// <summary>
        /// 逻辑删除返回影响的行数
        /// </summary>
        /// <param name="ids">需要删除的主键数组</param>
        /// <returns>影响的行数</returns>
        Int32 DeleteLogical(Int32[] ids);
        /// <summary>
        /// 逻辑删除返回影响的行数（异步操作）
        /// </summary>
        /// <param name="ids">需要删除的主键数组</param>
        /// <returns>影响的行数</returns>
        Task<Int32> DeleteLogicalAsync(Int32[] ids);

        /// <summary>
        /// 根据主键获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetNameById(int id);
        Task<string> GetNameByIdAsync(int id);
        /// <summary>
        /// 事务新增，并保存关联数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int? InsertByTrans(managerrole model);
        /// <summary>
        /// 事务修改，并保存关联数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateByTrans(managerrole model);
        /// <summary>
        /// 通过角色权限获取权限菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<menu> GetMenusByRoleId(int roleId);
	}
}
