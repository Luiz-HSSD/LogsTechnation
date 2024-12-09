using LogsTechnation.Controllers;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using LogsTechnation.Model;
using LogsTechnation.Services.Interface;
using Moq;

namespace LogTest.Controllers
{
    public class LogMinhaCdnControllerTest
    {
                public ILogMinhaCdnService GerarMockMinhaCdnService()
        {
            var service = new Mock<ILogMinhaCdnService>();
            LogMinhaCdn log = new LogMinhaCdn()
            {
                id = 1,
                log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n",
                data = DateTime.Now,
            };
            List<LogMinhaCdn> logs = new List<LogMinhaCdn>();
            logs.Add(log);
            service.Setup(x => x.Salvar(It.IsAny<LogMinhaCdn>())).Returns(log);
            service.Setup(x => x.Listar()).Returns(logs);
            service.Setup(x => x.PegarLogPorId(It.IsAny<long>())).Returns(log);
            return service.Object;
        }
        [Fact]
        public void TesteLogMinhaCdnController()
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
            var massa = new LogMinhaCdnController();
            LogMinhaCdnController._service = GerarMockMinhaCdnService();
            //act
            var resultado = massa.Get(1);
            //assert
            Assert.NotNull(resultado.Value);
        }

        [Fact]
        public void TesteLogMinhaCdnControllergetlista()
        {
            //arrange
            var massa = new LogMinhaCdnController();
            LogMinhaCdnController._service = GerarMockMinhaCdnService();
            //act
            var resultado = massa.Get();
            //asert
            Assert.NotNull(resultado.Value);
        }


        [Fact]
        public void TesteLogMinhaCdnControllerSalvar()
        {
            //srrange
            if (!Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (!Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var content = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            var massa = new LogMinhaCdnController();
            LogMinhaCdnController._service = GerarMockMinhaCdnService();
            //act
            var resposta = massa.Post(file);
            //assert
            Assert.NotNull(resposta);

        }
    }
}
