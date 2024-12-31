///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2024/12/31 星期二 14:15:37
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

namespace Stark.Configuration.Test
{
    internal class SectionTest
    {
        private  IConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
           _configuration = ConfigHelper.InitialConfiguration();
        }

        [Test]
        public void Key()
        {
            var value = _configuration.GetSection("appname").Key;

            Assert.That(value,Is.EqualTo("appname"));
        }

        [Test]
        public void Value()
        {
            var value = _configuration.GetSection("appname").Value;

            Assert.That(value, Is.EqualTo("stark"));
        }

        [Test]
        public void Parent_ShouldBe_Null()
        {
            var value = _configuration.GetSection("appname").Parent;

            Assert.That(value,Is.Null);
        }

        [Test]
        public void Parent_HasValue()
        {
            var value = _configuration.GetSection("details:company");

            Assert.That(value.Parent, Is.EqualTo("details"));
        }
    }

}
