///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 0:10:49
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Stark.Configuration
{
    internal class JsonConfigurationProvider : ConfigurationProvider
    {
        public JsonConfigurationProvider(string jsonPath) : base(jsonPath)
        {
        }

        public override void Load()
        {
            var content = File.ReadAllText(Source);
            IDictionary<string, string> data = null;
            try
            {
                data = JsonConvert.DeserializeObject<IDictionary<string, string>>(content);
            }
            catch (Exception e)
            {
#if Debug
                throw e;
#endif
            }

            if (data == null) return;

            _config = data;
        }
    }

}
