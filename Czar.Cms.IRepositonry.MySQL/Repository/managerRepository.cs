/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：接口实现                                                    
*│　作    者：复制自yilezhu                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-12 21:42:14                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Repository.SqlServer                                  
*│　类    名： managerRepository                                      
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
using System.Threading.Tasks;

namespace Czar.Cms.Repository.SqlServer
{
    public class managerRepository:BaseRepository<manager,Int32>, ImanagerRepository
    {
        public managerRepository(IOptionsSnapshot<DbOption> options)
        {
            _dbOption =options.Get("CzarCms");
            if (_dbOption == null)
            {
                throw new ArgumentNullException(nameof(DbOption));
            }
            _dbConnection = DbConnectionFactory.CreateConnection(_dbOption.DbType, _dbOption.ConnectionString);
        }

        public int ChangeLockStatusById(int id, bool status)
        {
            string sql = "update manager set IsLock=@IsLock where Id=@Id";
            return _dbConnection.Execute(sql, new
            {
                IsLock = status ? 1 : 0,
                Id = id,
            });
        }

        public async Task<int> ChangeLockStatusByIdAsync(int id, bool status)
        {
            string sql = "update manager set IsLock=@IsLock where id=@Id";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                IsLock = status ? 1 : 0,
                Id = id,
            });
        }

        public int ChangePasswordById(int id, string Password)
        {
            string sql = "update manager set Password=@Password where Id=@Id and IsDelete=0";
            return _dbConnection.Execute(sql, new { Password = Password, Id = id });
        }

        public int DeleteLogical(int[] ids)
        {
            string sql = "update manager set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update manager set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

        public bool GetLockStatusById(int id)
        {
            string sql = "select IsLock from manager where Id=@Id and IsDelete=0";
            return _dbConnection.QueryFirstOrDefault<bool>(sql, new { Id = id });
        }

        public async Task<bool> GetLockStatusByIdAsync(int id)
        {
            string sql = "select IsLock from manager where Id=@Id and isDelete=0 ";
            return await _dbConnection.QueryFirstOrDefaultAsync<bool>(sql, new { Id = id });
        }

        public string GetPasswordById(int id)
        {
            string sql = "select Password from manager where Id=@Id and IsDelete=0 ";
            return _dbConnection.QueryFirstOrDefault<string>(sql, new { Id = id });
        }

        public async Task<string> GetPasswordByIdAsync(int id)
        {
            string sql = "select Password from manager where Id=@Id and IsDelete=0 ";
            return await _dbConnection.QueryFirstOrDefaultAsync<string>(sql, new { Id = id });
        }
    }
}