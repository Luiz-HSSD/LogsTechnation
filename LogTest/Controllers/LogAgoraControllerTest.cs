using LogsTechnation.Controllers;
using LogsTechnation.Model;
using LogsTechnation.Services;
using LogsTechnation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace LogTest.Controllers
{
    public class LogAgoraControllerTest
    {
        public ILogAgoraService GerarMockAgoraService()
        {
            var service = new Mock<ILogAgoraService>();
            LogAgora log = new LogAgora()
            {
                IdLogAgora = 1,
                log= "\"MINHA CDN\" GET /robots.txt HTTP/1.1 1002 312 HIT\r\n\"MINHA CDN\" POST /myImages HTTP/1.1 3194 101 MISS\r\n\"MINHA CDN\" GET /not-found HTTP/1.1 1429 199 MISS\r\n\"MINHA CDN\" GET /robots.txt HTTP/1.1 2451 312 INVALIDATE", 
                data=DateTime.Now,
            };
            List<LogAgora> logs = new List<LogAgora>();
            logs.Add(log);
            var retorno = new RetornoTransformaLog()
            {
                LogMudado=log.log,
                path=".\\wwwroot\\logs\\"+Guid.NewGuid()+".txt",
            };
            service.Setup(x => x.PegaLogPeloId(It.IsAny<long>())).Returns(log);
            service.Setup(x => x.Listar()).Returns(log.log);
            service.Setup(x => x.Transformar(It.IsAny<string>())).Returns(retorno);
            service.Setup(x => x.Transformar(It.IsAny<long>())).Returns(retorno);
            return service.Object;
        }
        [Fact]
        public async void TesteLogAgoraControllerListar()
        {
            //assert
            var massa = new LogAgoraController();
            LogAgoraController._service = GerarMockAgoraService();
            //act
            var resultado =  massa.Get();
            //assert
            Assert.NotNull(resultado.Value);
        }

        [Fact]
        public async void TesteLogAgoraServiceGetbyid()
        {
            //arrange
            var massa = new LogAgoraController();
            LogAgoraController._service = GerarMockAgoraService();
            //act
            var resultado = massa.Get(1);
            //assert
            Assert.NotNull(resultado.Value);
        }

        [Fact]
        public async void TesteLogAgoraServicepostid()
        {
            //arrange
            if (Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var massa = new LogAgoraController();
            LogAgoraController._service = GerarMockAgoraService();
            //act
            var resultado = massa.Post(1,"");
            var resultado2 = massa.Post(1, "path");
            Assert.NotNull(resultado.Value);
            Assert.NotNull(resultado.Value);
        }

        [Fact]
        public async void TesteLogAgoraServicePost()
        {
            if (Directory.Exists(".\\wwwroot"))
            {
                Directory.CreateDirectory(".\\wwwroot");
            }
            if (Directory.Exists(".\\wwwroot\\logs"))
            {
                Directory.CreateDirectory(".\\wwwroot\\logs");
            }
            var massa = new LogAgoraController();
            LogAgoraController._service = GerarMockAgoraService();
            var content = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\r\n101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\r\n199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\r\n312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1\r\n";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            var resultado = massa.Post(file,"");
            Assert.NotNull(resultado.Value);
            resultado = massa.Post(file, "path");
            Assert.NotNull(resultado.Value);
        }

    }
}
