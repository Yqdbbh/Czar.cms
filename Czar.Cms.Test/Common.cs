using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Czar.Cms.Core.Options;
using Czar.Cms.IRepository;
using Czar.Cms.Repository.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Test
{
    public class Common
    {
        public static IServiceProvider BuildService()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "server=localhost;user=root;password=toor;database=coretest";
                options.DbType = DatabaseType.MySQL.ToString();
                options.Author = "复制自yilezhu";
                options.OutputPath = @"E:\Workspace\VSStudio\CodeGenrate";
                options.ModelsNamespace = "Czar.Cms.Models";
                options.IRepositoryNamespace = "Czar.Cms.IRepository";//仓储接口命名空间
                options.RepositoryNamespace = "Czar.Cms.Repository.SqlServer";//仓储命名空间
                //options.IServicesNamespace = "Czar.Cms.IServices";//服务接口命名空间
                //options.ServicesNamespace = "Czar.Cms.Services";//服务命名空间
            });
            //services.Configure<CodeGenerateOption>(options => GetConfiguration().GetSection("CodeGenerateOption").Bind(options));
            //services.Configure<CodeGenerateOption>("CodeGenerateOption", GetConfiguration().GetSection("CodeGenerateOption"));
            // CzarCms：option的名字，后面根据CzarCms获取Options的值
            services.Configure<DbOption>("CzarCms", GetConfiguration().GetSection("DbOption"));
            //services.Configure<DbOption>("CzarCms", GetConfiguration().GetSection("DbOption"));
            services.AddScoped<CodeGenerator>();//注入Model代码生成器
            services.AddScoped<IarticlecategoryRepository, articlecategoryRepository>();
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
    }
}
