using Czar.Cms.Core.Models;
using Czar.Cms.Core.Extensions;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Czar.Cms.Core.DbHelper
{
    /// <summary>
    /// 数据库连接工厂
    /// </summary>
    public class DbConnectionFactory
    {

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <returns></returns>
        public static IDbConnection CreateConnection(DatabaseType dbType, string connectionStr)
        {
            IDbConnection dbConnection = null;
            if (connectionStr.IsNullOrWhiteSpace())
                throw new ArgumentNullException("未指定连接字符串");
            switch (dbType)
            {
                case DatabaseType.MySQL:
                    //使用的Dapper.SimpleCRUD, 默认数据库格式是sqlserver
                    SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
                    dbConnection = new MySqlConnection(connectionStr);
                    break;
                default:
                    throw new ArgumentException($"不支持的数据库类型:{dbType.ToString()}");
            }
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            return dbConnection;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <returns></returns>
        public static IDbConnection CreateConnection(string dbType, string connectionStr)
        {
            if (dbType.IsNullOrWhiteSpace()|| connectionStr.IsNullOrWhiteSpace())
                throw new ArgumentException("无效的参数");
            var dbtype = getDatabaseType(dbType);
            return CreateConnection(dbtype, connectionStr);
        }

        /// <summary>
        /// 根据字符串获取数据库的类型
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        private static DatabaseType getDatabaseType(string dbType)
        {
            if (dbType.IsNullOrWhiteSpace())
                throw new ArgumentNullException("不支持的数据库类类型");
            DatabaseType result = DatabaseType.MySQL;
            foreach(DatabaseType dbtype in Enum.GetValues(typeof(DatabaseType)))
            {
                if (dbtype.ToString().Equals(dbType, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = dbtype;
                }
            }
            return result;
        }

    }
}
