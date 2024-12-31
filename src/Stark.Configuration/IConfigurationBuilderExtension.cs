///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 11:10:32
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

public static class IConfigurationBuilderExtension
{
    public static IConfigurationBuilder SetBasePath(this IConfigurationBuilder builder, string basePath)
    {
        builder.SharedData.Add("basePath",basePath);
        return builder;
    }

}


