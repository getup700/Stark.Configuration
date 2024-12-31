///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 19:59:00
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

namespace Stark.Configuration;

public static class JsonConfigurationProviderExtension
{
    public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder configurationBuilder, string path)
    {
        var jsonBuilder = new JsonConfigurationProvider(path);
        var d = configurationBuilder.Build();
        return configurationBuilder;
    }
}


