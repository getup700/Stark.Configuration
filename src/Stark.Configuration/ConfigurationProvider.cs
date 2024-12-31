///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 19:08:07
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Stark.Configuration;

/// <summary>
/// 通用类型文件配置构建者
/// </summary>
internal class ConfigurationProvider : IConfigurationProvider
{
    protected IDictionary<string, string> _config;

    public ConfigurationProvider(string jsonPath)
    {
        _config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var fileInfo = new FileInfo(jsonPath);
        if (fileInfo.Exists && fileInfo.Extension == "json")
        {
            Source = jsonPath;
        }
    }

    public string Source { get; }

    public virtual void Load()
    {

    }

    public bool TryGet(string key, out string value)
    {
        return _config.TryGetValue(key, out value);
    }

    public void Set(string key, string value)
    {
        _config[key] = value;
    }

    /// <summary>
    /// 从字典中获取以指定前缀（parentPath）为开头且后跟冒号的键，并提取出第一个子键。
    /// </summary>
    /// <param name="parentPath"></param>
    /// <returns></returns>
    public IEnumerable<string> GetKeys(string parentPath)
    {
        foreach (var item in _config)
        {
            //检查当前键是否以parentPath为前缀，且parentPath后紧跟冒号
            if (item.Key.Length > parentPath.Length &&
                item.Key.StartsWith(parentPath, StringComparison.OrdinalIgnoreCase) &&
                item.Key[parentPath.Length] == ':')
            {
                yield return KeyUtil.GetFirstSubKeyOrDefault(item.Key, parentPath.Length + 1);
            }
        }
    }
}
