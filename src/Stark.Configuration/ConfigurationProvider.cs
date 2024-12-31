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
public class ConfigurationProvider : IConfigurationProvider
{
    protected IDictionary<string, object> _config = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    private readonly IConfigurationSource _source;

    public ConfigurationProvider(ConfigurationSource source)
    {
        _source = source;
    }

    public virtual void Load()
    {
        var fileInfo = new FileInfo(_source.Path);
        if (!fileInfo.Exists)
        {
            return;
        }
        var content = File.ReadAllText(_source.Path);
        try
        {
            //反序列化的结果是带有层级的键值对
            _config = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
        }
        catch (Exception e)
        {
#if Debug
           throw e;
#endif
        }
    }

    public bool TryGet(string key, out string value)
    {
        if (_config.TryGetValue(key, out var  obj))
        {
            value = obj.ToString();
            return true;
        }

        value = null;
        return false;
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
