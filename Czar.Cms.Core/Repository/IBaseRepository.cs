using System;
using System.Collections.Generic;
using System.Data;
//using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Czar.Cms.Core.Repository
{
    /// <summary>
    /// 定义增删改查方法的同步、异步接口、包含分页的实现
    /// IDisposable：GC释放资源的时机不确定，对于一些非托管资源，比如数据库连接对象，需要实现IDisposable接口来手动释放资源
    /// </summary>
    public interface IBaseRepository<T, Tkey> : IDisposable where T : class
    {
        #region 同步
        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(Tkey id);
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetList();
        /// <summary>
        /// 根据指定查询条件进行查询
        /// </summary>
        /// <param name="whereCondition">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetList(object whereCondition);
        /// <summary>
        /// 带参数的查询条件
        /// </summary>
        /// <param name="conditions">条件</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<T> GetList(string conditions, object parameters = null);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="rowPerPage">每页大小</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<T> GetListPaged(int pageNumber, int rowPerPage, string conditions, string orderby, object parameters = null);
        /// <summary>
        /// 插入记录并返回主键值(非自增类型主键返回null)
        /// </summary>
        /// <param name="entity">要插入的数据</param>
        /// <returns></returns>
        int? Insert(T entity);
        /// <summary>
        /// 更新数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>受影响行数</returns>
        int Update(T entity);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>受影响行数</returns>
        int Delete(Tkey id);
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>受影响的行数</returns>
        int Delete(T entity);
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="whereConditions">条件</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>受影响的行数</returns>
        int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="conditions">where子句</param>
        /// <param name="parameters">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns></returns>
        int DeleteList(string conditions, object parameters, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// 查询满足条件的数据
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int RecordCount(string conditions="", object parameters=null);
        #endregion

        #region 异步
        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> GetAsync(Tkey id);
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync();
        /// <summary>
        /// 根据指定查询条件进行查询
        /// </summary>
        /// <param name="whereCondition">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync(object whereCondition);
        /// <summary>
        /// 带参数的查询条件
        /// </summary>
        /// <param name="conditions">条件</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync(string conditions, object parameters = null);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="rowPerPage">每页大小</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowPerPage, string conditions, string orderby, object parameters = null);
        /// <summary>
        /// 插入记录并返回主键值(非自增类型主键返回null)
        /// </summary>
        /// <param name="entity">要插入的数据</param>
        /// <returns></returns>
        Task<int?> InsertAsync(T entity);
        /// <summary>
        /// 更新数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>受影响行数</returns>
        Task<int> UpdateAsync(T entity);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>受影响行数</returns>
        Task<int> DeleteAsync(Tkey id);
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>受影响的行数</returns>
        Task<int> DeleteAsync(T entity);
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="whereConditions">条件</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>受影响的行数</returns>
        Task<int> DeleteListAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="conditions">where子句</param>
        /// <param name="parameters">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns></returns>
        Task<int> DeleteListAsync(string conditions, object parameters, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// 查询满足条件的数据
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<int> RecordCountAsync(string conditions="", object parameters=null);


        #endregion
    }
}