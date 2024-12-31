///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 15:03:56
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
/// 通用配置构建器，一个IConfigurationBuilder对应多个配置源
/// </summary>
public interface IConfigurationBuilder
{
    IDictionary<string, object> Configurations { get; }

    IList<IConfigurationSource> Sources { get; }

    IConfiguration Build();

    IConfigurationBuilder SetBasePath(string basePath);

    IConfigurationBuilder Add(IConfigurationSource configurationSource);

}
