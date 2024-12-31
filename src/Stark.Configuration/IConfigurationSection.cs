///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 15:08:59
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
/// 一个配置树的节点
/// </summary>
public interface IConfigurationSection
{
    /// <summary>
    /// 节点的键
    /// </summary>
    string Key { get; }

    /// <summary>
    /// 值
    /// </summary>
    string Value { get; }

    /// <summary>
    /// 节点的完整路径
    /// </summary>
    string Parent { get; }

    /// <summary>
    /// 获取当前节点内的键值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string this[string key] { get; set; }
}
