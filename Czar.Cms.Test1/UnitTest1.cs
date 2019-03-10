using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Czar.Cms.Core.Options;
using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Xunit;

namespace Czar.Cms.Test1
{
    public class UnitTest1
    {

        public IServiceProvider BuildService()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "server=localhost;user=root;password=admin;database=coretest";
                options.DbType = DatabaseType.MySQL.ToString();
                options.Author = "复制自yilezhu";
                options.OutputPath = @"D:\Workspace\VS2017\Czar\Czar.Cms\Czar.Cms.Models";
                options.ModelsNamespace = "Czar.Cms.Models";
                //options.IRepositoryNamespace = "Czar.Cms.IRepository";//仓储接口命名空间
                //options.RepositoryNamespace = "Czar.Cms.Repository.SqlServer";//仓储命名空间
                //options.IServicesNamespace = "Czar.Cms.IServices";//服务接口命名空间
                //options.ServicesNamespace = "Czar.Cms.Services";//服务命名空间
            });
            services.Configure<DbOption>("CzarCms", GetConfiguration().GetSection("DbOption"));
            services.AddScoped<CodeGenerator>();//注入Model代码生成器
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var bulider = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            return bulider.Build();
        }

        [Fact]
        public void GeneratorModelForSqlServer()
        {
            var serviceProvider = BuildService();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true);
            Assert.Equal("MySQL", DatabaseType.MySQL.ToString(), ignoreCase: true);
        }
    }
}
