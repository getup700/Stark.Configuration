///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 14:50:47
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

public class ConfigurationBuilder : IConfigurationBuilder
{
    public IDictionary<string, object> SharedData { get; } = new Dictionary<string, object>();

    public IList<IConfigurationSource> Sources { get; } = [];

    public IConfigurationBuilder Add(IConfigurationSource configurationSource)
    {
        if (configurationSource == null) throw new ArgumentNullException(nameof(configurationSource));
        Sources.Add(configurationSource);
        return this;
    }

    public IConfiguration Build()
    {
        var providers = Sources
            .Select(source => source.Build(this))
            .ToList();
        return new Configuration(providers);
    }

}
