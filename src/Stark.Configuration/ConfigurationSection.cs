///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 18:50:12
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

/// <summary>
/// 允许
/// </summary>
internal class ConfigurationSection : IConfigurationSection
{
    private readonly IConfiguration _configuration;
    private string _key;
    private string _parent;

    public ConfigurationSection(IConfiguration configuration, string key)
    {
        _configuration = configuration;
        _key = KeyUtil.GetKeyAndParent(key, out _parent);
    }

    public string Parent => _parent;

    public string Key => _key;

    public string Value => _configuration[_key];

    public string this[string key]
    {
        get => _configuration[CombinePath()];
        set => _configuration[CombinePath()] = value;
    }

    private string CombinePath()
    {
        return _parent == null ? Key : _parent + ":" + Key;
    }


}


