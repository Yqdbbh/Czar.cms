/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：管理员                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 18:05:41                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.IRepository                                  
*│　接口名称：ImanagerRepository                                     
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Core.Repository;
using Czar.Cms.Models;
using System;
using System.Threading.Tasks;

namespace Czar.Cms.IRepository
{
	public interface ImanagerRepository:IBaseRepository<manager,Int32>
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
        /// 根据id获取锁定状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Boolean GetLockStatusById(Int32 id);
        Task<Boolean> GetLockStatusByIdAsync(Int32 id);
        /// <summary>
        /// 根据Id改变锁定状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Int32 ChangeLockStatusById(Int32 id, bool status);
        Task<Int32> ChangeLockStatusByIdAsync(Int32 id, bool status);
        /// <summary>
        /// 根据Id获取密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetPasswordById(Int32 id);
        Task<string> GetPasswordByIdAsync(Int32 id);
        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        int ChangePasswordById(Int32 id, string Password);

	}
}
