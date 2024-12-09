using AutoFixture;
using LogsTechnation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogTest.Model
{
    public class LogAgoraTest
    {
        [Fact]
        public void TesteLogAgora()
        {
            //arrange
            var log = new LogAgora()
            {
                data = DateTime.Now,
                log = "",
                IdLogAgora = 1,
            };
            Fixture fixture = new Fixture();
            var massa = fixture.Create<LogAgora>();
            //act
            var logConvertido = massa.ConverteProAtual("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2");
            //assert
            Assert.NotNull(log);
            Assert.NotNull(massa);
            Assert.Equal(logConvertido, "\"MINHA CDN\" GET /robots.txt HTTP/1.1 100 312 HIT\r\n");
        }
    }
}
