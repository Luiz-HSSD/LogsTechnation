using LogsTechnation.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.IO;
using LogsTechnation.Model;
using LogTest.Model;

namespace LogTest.Service
{
    public class LogAgoraServiceTest
    {
        [Fact]
        public void TesteLogAgoraService()
        {
            //arrange
            var dbMock = LogContextTest.RetornaMockLogContext();
            var massa = new LogAgoraService();
            massa.setDbContext(dbMock);
            //act
            
            var lista = massa.Listar();
            //assert

            Assert.NotNull(lista);

        }

        [Fact]
        public void TesteLogAgoraServiceTranformar()
        {
            //arrange
            if (!Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (!Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var dbMock = LogContextTest.RetornaMockLogContext();
           var massa = new LogAgoraService();
            massa.setDbContext(dbMock);
            //act            
            var resposta = massa.Transformar("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n");
            //assert
            Assert.NotNull(resposta);
            Assert.Equal("\"MINHA CDN\" GET /robots.txt HTTP/1.1 100 312 HIT\r\n\"MINHA CDN\" POST /myImages HTTP/1.1 319 101 MISS\r\n\"MINHA CDN\" GET /not-found HTTP/1.1 143 199 MISS\r\n\"MINHA CDN\" GET /robots.txt HTTP/1.1 245 312 INVALIDATE\r\n", resposta.LogMudado);
        }

        [Fact]
        public void TesteLogAgoraServiceTranformarPorIdentificador()
        {
            //arrange
            if (!Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (!Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var dbMock = LogContextTest.RetornaMockLogContext();
           var massa = new LogAgoraService();
            massa.setDbContext(dbMock);
            //act
            var resposta = massa.Transformar(1);
            //assert
            Assert.NotNull(resposta);
        }


        [Fact]
        public void TesteLogAgoraServicePegarPorID()
        {
            //arrange
            var dbMock = LogContextTest.RetornaMockLogContext();
           var massa = new LogAgoraService();
            massa.setDbContext(dbMock);
            //act
            var resposta = massa.PegaLogPeloId(1);
            //assert
            Assert.NotNull(resposta);
        }
    }
}
