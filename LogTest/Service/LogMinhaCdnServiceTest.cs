using LogsTechnation.Model;
using LogsTechnation.Services;
using LogTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace LogTest.Service
{
    public class LogMinhaCdnServiceTest
    {

        [Fact]
        public void TesteLogAgoraServicePegarLogPorId()
        {
            //arrange
            var dbMock = LogContextTest.RetornaMockLogContext();
            var massa = new LogMinhaCdnService();
            massa.setDbContext(dbMock);
            //act
            var resposta = massa.PegarLogPorId(1);
            //assert
            Assert.NotNull(resposta);

        }

        [Fact]
        public void TesteLogAgoraServiceListar()
        {
            //arrange
            var dbMock = LogContextTest.RetornaMockLogContext();
            var massa = new LogMinhaCdnService();
            massa.setDbContext(dbMock);
            //act
            var resposta = massa.Listar();
            //asert
            Assert.NotNull(resposta);

        }
        [Fact]
        public void TesteLogAgoraService()
        {
            if (!Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (!Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var dbMock = LogContextTest.RetornaMockLogContext();            
            var massa = new LogMinhaCdnService();
            massa.setDbContext(dbMock);

            var massaParaSalvar = new LogMinhaCdn()
            {
                data = DateTime.Now,
                log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n"
            };
            var resposta = massa.Salvar(massaParaSalvar);
            Assert.NotNull(resposta);

        }
    }
}
