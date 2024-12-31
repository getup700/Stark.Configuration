///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 15:17:16
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stark.Configuration.Test
{
    internal class ProviderTest
    {
        private IConfigurationProvider _configurationProvider;

        [SetUp]
        public void SetUp()
        {
            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var basePath = dirInfo.Parent.Parent.Parent.ToString();
            var fullPath = Path.Combine(basePath, "appsettings.json");
            var source = new ConfigurationSource(fullPath);
            var builder = new ConfigurationBuilder();
            _configurationProvider = source.Build(builder);

        }

        [Test]
        public void GetKes()
        {
            var keys = _configurationProvider.GetKeys("company").ToList();


        }
    }

}
