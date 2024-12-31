///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/30 星期一 15:10:59
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

namespace Stark.Configuration
{
    /// <summary>
    /// 一个配置文件的源
    /// </summary>
    public interface IConfigurationSource
    {
        /// <summary>
        /// 当前配置的路径
        /// </summary>
        string Path { get; }

        /// <summary>
        /// 构建当前配置文件
        /// </summary>
        IConfigurationProvider Build(IConfigurationBuilder configurationBuilder);
    }

}
