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

internal class ConfigurationSection : IConfigurationSection
{
    private readonly IConfiguration _configuration;
    private string _key;
    private string _parent;

    public ConfigurationSection(IConfiguration configuration, string parent)
    {
        _configuration = configuration;
        _parent = parent;
    }

    public string Parent => _parent;

    public string Key => _key ??= KeyUtil.GetLastSubKeyOrDefault(_parent);

    public string Value => _configuration[_parent];

    public string this[string key]
    {
        get => _configuration[_parent + ":" + key];
        set => _configuration[_parent + ":" + key] = value;
    }


}


