using Czar.Cms.Core.Models;
using Czar.Cms.Core.Extensions;
using System;
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

        public static IDbConnection CreateConnection(DatabaseType dbType, string connectionStr)
        {
            IDbConnection dbConnection = null;
            if (connectionStr.IsNullOrWhiteSpace())
                throw new ArgumentNullException("未指定连接字符串");
            switch (dbType)
            {
                case DatabaseType.MySQL:
                    dbConnection= new MySqlConnection(connectionStr);
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


    }
}
