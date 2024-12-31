///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 15:13:02
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
/// 配置文件的提供者，每种配置源都有一个对应的<see cref="IConfigurationProvider"/>实现
/// </summary>
public interface IConfigurationProvider
{
    /// <summary>
    /// 尝试获取键的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool TryGet(string key, out string value);

    /// <summary>
    /// 设置一个键值对。如果已经包含该键，则覆盖值。
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, string value);

    /// <summary>
    /// 加载当前配置文件
    /// </summary>
    void Load();

    /// <summary>
    /// 获取子键
    /// </summary>
    /// <para name="parentPath">父级键值对</para>
    /// <returns></returns>
    IEnumerable<string> GetKeys(string parentPath);
}
