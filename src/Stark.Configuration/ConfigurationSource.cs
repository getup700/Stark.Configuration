///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 11:32:26
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stark.Configuration;

public class ConfigurationSource : IConfigurationSource
{
    public ConfigurationSource(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public IConfigurationProvider Build(IConfigurationBuilder configurationBuilder)
    {
        var provider = new ConfigurationProvider(this);
        provider.Load();
        return provider;
    }
}


