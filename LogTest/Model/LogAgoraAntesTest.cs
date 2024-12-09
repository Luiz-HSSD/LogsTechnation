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
            var log = new LogAgoraAntes()
            {
                data=DateTime.Now,
                log= "",
                id =1,
            };
            //assert
            Assert.NotNull(log);
        }
    }
}
