///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 0:39:48
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

internal static class KeyUtil
{
    /// <summary>
    /// 从prefixLength开始检索第一个:，
    /// 如果路径不包含，返回prefixLength之后所有字符串；
    /// 如果路径包含，返回prefixLength之后到第一个:之间的字符串
    /// </summary>
    /// <param name="key"></param>
    /// <param name="prefixLength"></param>
    /// <returns></returns>
    public static string GetFirstSubKeyOrDefault(string key, int prefixLength)
    {
        var indexOf = key.IndexOf(':', prefixLength);
        return indexOf < 0
            ? key.Substring(prefixLength) //找不到冒号，返回从prefixLength到最后的字符串
            : key.Substring(prefixLength, indexOf - prefixLength);//找到冒号，返回从prefixLength到冒号前的字符串
    }


    /// <summary>
    /// 如果路径不包含:返回整个path;否则返回最后一个:之后的所有字符串
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetLastSubKeyOrDefault(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return path;
        }

        var lastDelimiterIndex = path.LastIndexOf(':');
        return lastDelimiterIndex < 0 ? path : path.Substring(lastDelimiterIndex + 1);
    }

    /// <summary>
    /// 从字典中获取以指定前缀（parentPath）为开头且后跟冒号的键，并提取出第一个子键。
    /// </summary>
    /// <param name="config"></param>
    /// <param name="parentPath"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetKeys(IDictionary<string, string> config, string parentPath)
    {
        foreach (var item in config)
        {
            //检查当前键是否以parentPath为前缀，且parentPath后紧跟冒号
            if (item.Key.Length > parentPath.Length &&
                item.Key.StartsWith(parentPath, StringComparison.OrdinalIgnoreCase) &&
                item.Key[parentPath.Length] == ':')
            {
                yield return GetFirstSubKeyOrDefault(item.Key, parentPath.Length + 1);
            }
        }
    }
}


