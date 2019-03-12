using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Czar.Cms.Core.Options;
using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Xunit;

namespace Czar.Cms.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GeneratorModelForSqlServer()
        {
            var serviceProvider = Common.BuildService();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true); 
            Assert.Equal("MySQL", DatabaseType.MySQL.ToString(), ignoreCase: true);
        }

    }

}