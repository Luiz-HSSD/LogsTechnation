using AutoFixture;
using LogsTechnation.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Xunit;

namespace LogTest.Model
{
    public class LogContextTest
    {
        [Fact]
        public void TesteLogContext()
        {
            var log = new LogContext();
            Assert.NotNull(log);
        }


        public static LogContext RetornaMockLogContext()
        {
            var data = new List<LogAgora>
    {
        new LogAgora { IdLogAgora=1, log = "\"MINHA CDN\" GET /robots.txt HTTP/1.1 1002 312 HIT\r\n\"MINHA CDN\" POST /myImages HTTP/1.1 3194 101 MISS\r\n\"MINHA CDN\" GET /not-found HTTP/1.1 1429 199 MISS\r\n\"MINHA CDN\" GET /robots.txt HTTP/1.1 2451 312 INVALIDATE", data=DateTime.Now },
     
    };           
            var dataantes = new List<LogAgoraAntes>
    {
        new LogAgoraAntes { id=1, idAgora=1, log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n", data=DateTime.Now },
     
    };
            var dataMinhaCdn = new List<LogMinhaCdn>
    {
        new LogMinhaCdn { id=1, log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n", data=DateTime.Now },
     
    };
            
            var mockContext = new Mock<LogContext>();
            mockContext.Setup(m => m.LogsAgora).ReturnsDbSet(data);
            mockContext.Setup(m => m.LogsAgoraAntes).ReturnsDbSet(dataantes);
            mockContext.Setup(m => m.LogsMinhaCdn).ReturnsDbSet(dataMinhaCdn);
            //mockSet.Verify(m => m.Add(It.IsAny<LogAgora>()), Times.Once());
            //mockSetAntes.Verify(m => m.Add(It.IsAny<LogAgoraAntes>()), Times.Once());
            //mockSetMiinhaCdn.Verify(m => m.Add(It.IsAny<LogMinhaCdn>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
            return mockContext.Object;
        }
    }
}

