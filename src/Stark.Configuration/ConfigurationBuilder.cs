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
    private readonly IList<IConfigurationSource> _source = [];
    private string _basePath;

    public IDictionary<string, object> Configurations => throw new NotImplementedException();

    public IList<IConfigurationSource> Sources => _source;

    public IConfigurationBuilder Add(IConfigurationSource configurationSource)
    {
        if (configurationSource == null) throw new ArgumentNullException(nameof(configurationSource));
        _source.Add(configurationSource);
        return this;
    }

    public IConfigurationBuilder SetBasePath(string basePath)
    {
        _basePath = basePath;
        return this;
    }

    public IConfiguration Build()
    {
        var providers = _source
            .Select(source => source.Build(this));
        return new Configuration(providers.ToList());
    }

}
