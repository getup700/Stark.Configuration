///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 18:48:16
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
/// 一个配置文件的结构
/// </summary>
public interface IConfiguration
{
    /// <summary>
    /// 获取当前层级配置项
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string this[string key] { get; set; }

    /// <summary>
    /// 获取当前层级配置项
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    IConfigurationSection GetSection(string key);

    /// <summary>
    /// 获取子配置项
    /// </summary>
    /// <returns></returns>
    IEnumerable<IConfigurationSection> GetChildren();
}
