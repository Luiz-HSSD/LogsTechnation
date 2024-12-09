using LogsTechnation.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LogsTechnation.Services;
using Microsoft.AspNetCore.Http;
using System.Text;
using LogsTechnation.Services.Interface;
namespace LogsTechnation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMinhaCdnController : ControllerBase
    {
        public static ILogMinhaCdnService _service { private get; set; } = new LogMinhaCdnService();

        [HttpGet]
        public ActionResult<IEnumerable<LogMinhaCdn>> Get()
        {

            return _service.Listar();
        }


        [HttpGet("{id}")]
        public ActionResult<LogMinhaCdn> Get(long id)
        {
            return _service.PegarLogPorId(id);
        }

        [HttpPost]
        public ActionResult<LogMinhaCdn> Post(IFormFile file)
        {
            LogMinhaCdn log =new LogMinhaCdn();
            var ms = new MemoryStream();
            file.CopyTo(ms);
            log.log = Encoding.UTF8.GetString(ms.ToArray());
            return _service.Salvar(log);
        }
    }
}
