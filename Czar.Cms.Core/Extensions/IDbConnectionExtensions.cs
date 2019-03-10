using Czar.Cms.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;
using System.Linq;
using System.Data.SqlTypes;

namespace Czar.Cms.Core.Extensions
{
    /// <summary>
    /// IDbConnection扩展
    /// </summary>
    public static class IDbConnectionExtensions
    {
        /// <summary>
        /// 根据数据库类型，获得数据库的完整信息
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static List<DbTable> GetCurrentDatabaseTableList(this IDbConnection dbConnection, DatabaseType dbType)
        {
            List<DbTable> tables = dbConnection.GetCurrentDatabaseAllTable(dbType);
            tables.ForEach(item =>
            {
                item.Columns = dbConnection.GetColumnsByTableName(dbType, item.TableName);
                item.Columns.ForEach(x=> {
                    var csharpType = DbColumnTypeCollection.DbColumnDataTypes.
                        FirstOrDefault(t => 
                        t.DatabaseType == dbType && 
                        t.ColumnTypes.Split(",").Any(p => p.Trim().Equals(x.ColumnType, StringComparison.OrdinalIgnoreCase)))?.CSharpType;
                    if (string.IsNullOrEmpty(csharpType))
                    {
                        throw new SqlTypeException($"未从字典中找到\"{x.ColumnType}\"对应的C#数据类型，请更新DbColumnTypeCollection类型映射字典。");
                    }
                    x.CSharpType = csharpType;
                });

            });
            return tables;
        }

        /// <summary>
        /// 跟据数据库类型，获取数据库中的所有表
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private static List<DbTable> GetCurrentDatabaseAllTable(this IDbConnection dbConnection,  DatabaseType dbType)
        {
            if (dbConnection == null) throw new ArgumentNullException(nameof(dbConnection));
            if (dbConnection.State == ConnectionState.Closed) dbConnection.Open();
            return dbConnection.Query<DbTable>(dbConnection.strGetAllTableSql(dbType)).ToList();
        }

        /// <summary>
        /// 数据库中的所有表
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private static string strGetAllTableSql(this IDbConnection dbConnection,DatabaseType dbType)
        {
            string strGetAllTable = string.Empty;
            switch (dbType)
            {
                case DatabaseType.MySQL:
                    strGetAllTable = "SELECT TABLE_NAME as TableName," +
                    " Table_Comment as TableComment" +
                    " FROM INFORMATION_SCHEMA.TABLES" +
                    $" where TABLE_SCHEMA = '{dbConnection.Database}'";
                    break;
                default:
                    throw new ArgumentException("不支持的数据库类型");
            }
            return strGetAllTable;
        }

        private static List<DbTableColumn> GetColumnsByTableName(this IDbConnection dbConnection,DatabaseType dbType,string tableName)
        {
            if (dbConnection == null) throw new ArgumentException(nameof(dbConnection));
            if (dbConnection.State == ConnectionState.Closed) dbConnection.Open();
            return dbConnection.Query<DbTableColumn>(dbConnection.strGetAllColumnsSQL(dbType, tableName)).ToList();
        }


        /// <summary>
        /// 获取当前表的列属性
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbType"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static string strGetAllColumnsSQL(this IDbConnection dbConnection,DatabaseType dbType,string tableName)
        {
            string strGetAllColumns = string.Empty;
            switch (dbType)
            {
                case DatabaseType.MySQL:
                    strGetAllColumns = 
                    "select column_name as ColName, " +
                   " column_default as DefaultValue," +
                   " IF(extra = 'auto_increment','TRUE','FALSE') as IsIdentity," +
                   " IF(is_nullable = 'YES','TRUE','FALSE') as IsNullable," +
                   " DATA_TYPE as ColumnType," +
                   " CHARACTER_MAXIMUM_LENGTH as ColumnLength," +
                   " IF(COLUMN_KEY = 'PRI','TRUE','FALSE') as IsPrimaryKey," +
                   " COLUMN_COMMENT as Comment " +
                   $" from information_schema.columns where table_schema = '{dbConnection.Database}' and table_name = '{tableName}'";
                    break;
                default:
                    throw new ArgumentException("不支持的数据库类型");
            }
            return strGetAllColumns;
        }

    }
}
