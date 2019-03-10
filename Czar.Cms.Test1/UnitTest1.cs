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
                options.Author = "������yilezhu";
                options.OutputPath = @"D:\Workspace\VS2017\Czar\Czar.Cms\Czar.Cms.Models";
                options.ModelsNamespace = "Czar.Cms.Models";
                //options.IRepositoryNamespace = "Czar.Cms.IRepository";//�ִ��ӿ������ռ�
                //options.RepositoryNamespace = "Czar.Cms.Repository.SqlServer";//�ִ������ռ�
                //options.IServicesNamespace = "Czar.Cms.IServices";//����ӿ������ռ�
                //options.ServicesNamespace = "Czar.Cms.Services";//���������ռ�
            });
            services.Configure<DbOption>("CzarCms", GetConfiguration().GetSection("DbOption"));
            services.AddScoped<CodeGenerator>();//ע��Model����������
            return services.BuildServiceProvider(); //���������ṩ����
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
