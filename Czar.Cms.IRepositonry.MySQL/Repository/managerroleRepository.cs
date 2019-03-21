/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：接口实现                                                    
*│　作    者：复制自yilezhu                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-12 21:42:14                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Repository.SqlServer                                  
*│　类    名： managerroleRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Core.DbHelper;
using Czar.Cms.Core.Options;
using Czar.Cms.Core.Repository;
using Czar.Cms.IRepository;
using Czar.Cms.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Czar.Cms.Repository.SqlServer
{
    public class managerroleRepository:BaseRepository<managerrole,Int32>, ImanagerroleRepository
    {
        public managerroleRepository(IOptionsSnapshot<DbOption> options)
        {
            _dbOption =options.Get("CzarCms");
            if (_dbOption == null)
            {
                throw new ArgumentNullException(nameof(DbOption));
            }
            _dbConnection = DbConnectionFactory.CreateConnection(_dbOption.DbType, _dbOption.ConnectionString);
        }

		public int DeleteLogical(int[] ids)
        {
            string sql = "update managerrole set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update managerrole set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

        public List<menu> GetMenusByRoleId(int roleId)
        {
            string sql = @"SELECT   m.Id, m.ParentId, m.Name, m.DisplayName, m.IconUrl, m.LinkUrl, m.Sort, rp.Permission, m.IsDisplay, m.IsSystem, 
                m.AddManagerId, m.AddTime, m.ModifyManagerId, m.ModifyTime, m.IsDelete
FROM      RolePermission AS rp INNER JOIN
                Menu AS m ON rp.MenuId = m.Id
WHERE   (rp.RoleId = @RoleId) AND (m.IsDelete = 0)";
            return _dbConnection.Query<menu>(sql, new
            {
                RoleId = roleId,
            }).ToList();
        }

        public string GetNameById(int id)
        {
            var item = Get(id);
            return item == null ? "角色不存在" : item.ROLENAME;
        }

        public async Task<string> GetNameByIdAsync(int id)
        {
            var item = await GetAsync(id);
            return item == null ? "角色不存在" : item.ROLENAME;
        }

        public int? InsertByTrans(managerrole model)
        {
            int? roleId = 0;
            string insertSql = @"insert into RolePermission Values(@RoleId,@MenuId,'')";
            using(var tran = _dbConnection.BeginTransaction())
            {
                try
                {
                    roleId = _dbConnection.Insert(model, tran);
                    if (roleId >= 0 && model.MenuIds?.Count() > 0)
                    {
                        foreach(var item in model.MenuIds)
                        {
                            _dbConnection.Execute(insertSql, new
                            {
                                RoleId = roleId,
                                MenuId = item
                            });
                        }
                    }
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            return roleId;
        }

        public int UpdateByTrans(managerrole model)
        {
            int result = 0;
            string insertPermissionSql = @"insert into RolePermission (RoleId,MenuId,Permission) values(@RoleId,@MenuId,'')";
            string deletePermissionSql = "delete from RolePermission where RoleId=@RoleId";
            using(var tran = _dbConnection.BeginTransaction())
            {
                try
                {
                    result = _dbConnection.Update(model, tran);
                    if (result > 0 && model.MenuIds?.Count() > 0)
                    {
                        _dbConnection.Execute(deletePermissionSql, new { RoleId = model.Id }, tran);
                        foreach(var item in model.MenuIds)
                        {
                            _dbConnection.Execute(insertPermissionSql, new { RoleId = model.Id, MenuId = item }, tran);
                        }
                    }
                    tran.Commit();
                }catch(Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            return result;
        }
    }
}