using LogsTechnation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogTest.Model
{
    public class LogMinhaCdnTest
    {
        [Fact]
        public void TesteLogMinhaCdn()
        {
            var log = new LogMinhaCdn()
            {
                data = DateTime.Now,
                log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2",
                id = 1,
            };
            Assert.NotNull(log);
        }
    }
}
