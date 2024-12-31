///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 18:49:20
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:source=>[provider]=>[builder]=>config
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stark.Configuration;

public class Configuration : IConfiguration
{
    private readonly IList<IConfigurationProvider> _providers;

    public Configuration(IList<IConfigurationProvider> providers)
    {
        if (providers == null) throw new ArgumentNullException(nameof(providers));
        _providers = providers;
    }

    public string this[string key]
    {
        get => GetConfiguration(key);
        set => SetConfiguration(key, value);
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return GetChildren(null);
    }

    public IConfigurationSection GetSection(string key)
    {
        return new ConfigurationSection(this, key);
    }

    private string GetConfiguration(string key)
    {
        //倒序提供键的值
        for (var i = _providers.Count - 1; i >= 0; i--)
        {
            var provider = _providers[i];
            if (provider.TryGet(key, out var value))
            {
                return value;
            }
        }
        return null;
    }

    private void SetConfiguration(string key, string value)
    {
        foreach (var configurationProvider in _providers)
        {
            configurationProvider.Set(key, value);
        }
    }

    private IEnumerable<IConfigurationSection> GetChildren(string parent)
    {
        var result = _providers
            .Aggregate(Enumerable.Empty<string>(), (seed, source) => source.GetKeys(parent))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Select(key => GetSection(parent == null ? key : parent + ":" + key));
        return result;
    }
}