using LogsTechnation.Model;
using LogsTechnation.Services;
using LogsTechnation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogsTechnation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAgoraController : ControllerBase
    {
        public static ILogAgoraService _service { get; set; } = new LogAgoraService();
        
       


        [HttpPost]
        public ActionResult<string> Post( IFormFile file, string retorno)
        {
            
            var ms = new MemoryStream();
            file.CopyTo(ms);
            var log = Encoding.UTF8.GetString(ms.ToArray());
            var response = _service.Transformar(log);
            if(retorno=="path")
            {
                return response.path;
            }
            else
            {
                return response.LogMudado;
            }
        }

        [HttpPost("{id}")]
        public ActionResult<string> Post(long id, [FromQuery] string retorno)
        {
            var response = _service.Transformar(id);
            if (retorno == "path")
            {
                return response.path;
            }
            else
            {
                return response.LogMudado;
            }
        }

        [HttpGet]
        public ActionResult<string> Get()
        {

            return _service.Listar();
        }


        [HttpGet("{id}")]
        public ActionResult<LogAgora> Get(long id)
        {

            return _service.PegaLogPeloId(id);
        }
    }
}
