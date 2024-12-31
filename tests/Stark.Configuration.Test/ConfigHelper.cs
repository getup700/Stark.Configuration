///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 14:16:11
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
    internal class ConfigHelper
    {
        public static IConfiguration InitialConfiguration()
        {
            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var dir = dirInfo.Parent.Parent.Parent.ToString();
            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings1.json");
           return builder.Build();
        }
    }

}
