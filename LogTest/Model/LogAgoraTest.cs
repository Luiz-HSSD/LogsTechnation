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
            //assert
            Assert.NotNull(log);
        }
    }
}
