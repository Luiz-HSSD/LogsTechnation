using AutoFixture;
using LogsTechnation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogTest.Model
{
    public class LogAgoraAntesTest
    {
        [Fact]
        public void TesteLogAgoraAntes()
        {
            //arrange
            Fixture fixture = new Fixture();
            LogAgoraAntes massa = fixture.Create<LogAgoraAntes>();
            var log = new LogAgoraAntes()
            {
                data=DateTime.Now,
                log= "",
                id =1,
            };

            //assert
            Assert.NotNull(log);
            Assert.NotNull(massa);
        }
    }
}
