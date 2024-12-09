using AutoFixture;
using LogsTechnation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogTest.Model
{
    public class RetornoTransformaLogTest
    {
            
        [Fact]
        public void TesteRetornoTransformaLog()
        {
            //arrange
            var log = new RetornoTransformaLog()
            {
                LogMudado = "\"MINHA CDN\" GET /robots.txt HTTP/1.1 100 312 HIT\r\n",
                path =""
            };

            Fixture fixture = new Fixture();
            var massa = fixture.Create<RetornoTransformaLog>();
            //assert
            Assert.NotNull(log);
            Assert.NotNull(massa);
        }
    }
}
