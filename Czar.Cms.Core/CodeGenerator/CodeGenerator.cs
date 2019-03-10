using Czar.Cms.Core.Models;
using Czar.Cms.Core.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Czar.Cms.Core.Extensions;
using Czar.Cms.Core.DbHelper;

namespace Czar.Cms.Core.CodeGenerator
{
    public class CodeGenerator
    {
        //默认分割符
        private readonly string Delimiter = "\\";

        private static CodeGenerateOption _option;

        public CodeGenerator(IOptions<CodeGenerateOption> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            _option = options.Value;
            if (_option.ConnectionString.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库连接串未指定");
            if (_option.DbType.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库类型未指定");
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (_option.OutputPath.IsNullOrWhiteSpace())
                _option.OutputPath = path;
            var flag = path.IndexOf("/bin");
            if (flag > 0)
                Delimiter = "/";//如果可以取到值，修改分割符
        }


        /// <summary>
        /// 根据数据库连接字符串生成数据库表对应的模板代码
        /// </summary>
        /// <param name="coveredExsited">是否覆盖已经存在的代码</param>
        public void GenerateTemplateCodesFromDatabase(bool coveredExsited = true)
        {
            DatabaseType dbType = DatabaseType.MySQL;
            List<DbTable> tables = new List<DbTable>();
            using (var conn = DbConnectionFactory.CreateConnection(dbType, _option.ConnectionString))
            {
                tables = conn.GetCurrentDatabaseTableList(dbType);
            }
            if (tables != null && tables.Any())
            {
                foreach(var table in tables)
                {
                    GenerateEntity(table, coveredExsited);
                }
            }
        }

        /// <summary>
        /// 创建实体类
        /// </summary>
        /// <param name="dbTable"></param>
        /// <param name="coverdExsited"></param>
        private void GenerateEntity(DbTable dbTable, bool coverdExsited = true)
        {
            //文件夹路径
            var modelPath = _option.OutputPath + Delimiter + "Models";
            if (!Directory.Exists(modelPath))
            {
                Directory.CreateDirectory(modelPath);
            }

            //实体全路径
            var fullPath = modelPath + Delimiter + dbTable.TableName + ".cs";
            if (File.Exists(fullPath) && !coverdExsited)
                return;

            //主键类型
            //下面好像没用到，而且测试结果不通过
            //string pkTypeName = dbTable.Columns.FirstOrDefault(m => m.PrimaryKey).CSharpType;
            var sb = new StringBuilder();
            foreach (var col in dbTable.Columns)
            {
                var tmp = GeneratorEntityProperty(dbTable.TableName, col);
                sb.AppendLine(tmp);
            }

            //读取模板
            var content = ReadTemplate("ModelTemplate.txt");
            content = content.Replace("{GeneratorTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("{ModelsNamespace}", _option.ModelsNamespace)
                .Replace("{Author}", _option.Author)
                .Replace("{Comment}", dbTable.TableComment)
                .Replace("{ModelName}", dbTable.TableName)
                .Replace("{ModelProperties}", sb.ToString());
            WriteAndSave(fullPath, content);
        }

        /// <summary>
        /// 生成实体的属性
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="column">列</param>
        /// <returns></returns>
        private static string GeneratorEntityProperty(string tableName, DbTableColumn column)
        {
            var sb = new StringBuilder();

            //属性注释
            if (!string.IsNullOrEmpty(column.Comment))
            {
                sb.AppendLine("\t\t/// <summary>");
                sb.AppendLine("\t\t/// " + column.Comment);
                sb.AppendLine("\t\t/// <summary>");
            }

            //判断是否是主键
            if (column.PrimaryKey)
            {
                sb.AppendLine("\t\t[Key]");
                sb.AppendLine($"\t\tpublic {column.CSharpType} Id" + "{ get; set;}");
            }
            else
            {
                if (!column.Nullable)
                {
                    sb.AppendLine("\t\t[Required]");
                }
                if (column.ColumnLength.HasValue && column.ColumnLength > 0)
                {
                    sb.AppendLine($"\t\t[MaxLength({column.ColumnLength.Value})]");
                }
                var colType = column.ColumnType;
                if (colType.ToLower() != "string" && colType.ToLower() != "byte[]" && colType.ToLower() != "object" && column.Nullable)
                {
                    colType += "?";
                }
                sb.AppendLine($"\t\tpublic {colType} {column.ColName}" + " { get; set;}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 读取模板文件
        /// </summary>
        /// <param name="templateName">模板名称，包括扩展名</param>
        /// <returns></returns>
        private static string ReadTemplate(string templateName)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var content = string.Empty;
            using (var stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.CodeTemplate.{templateName}"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }
            return content;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        /// <param name="content">文件内容</param>
        private static void WriteAndSave(string fileName, string content)
        {
            //实例化一个文件流，与写文件相关联
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                //实例化一个StreamWriter ，与fs相关联
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}
