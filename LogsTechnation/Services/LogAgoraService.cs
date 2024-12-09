using LogsTechnation.Model;
using LogsTechnation.Services.Interface;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LogsTechnation.Services
{
    public class LogAgoraService: ILogAgoraService
    {
        private static LogContext db = new LogContext();
        private string path = ".\\wwwroot\\logs\\";

        public void setDbContext(LogContext bancoMock)
        {
            db = bancoMock;
        }
        public RetornoTransformaLog Transformar(string log)
        {
            var entradas = log.Split(Environment.NewLine);
            var logConvertido= "";
            var logAgora =new LogAgora();
            for (int i = 0; i < entradas.Length; i++)
            {
                if (!string.IsNullOrEmpty(entradas[i]))
                {
                    logConvertido += logAgora.ConverteProAtual(entradas[i]);
                }
            }
            logAgora.data = DateTime.Now;
            logAgora.log = logConvertido;
            db.LogsAgora.Add(logAgora);
            db.SaveChanges();
            var logAntes = new LogAgoraAntes();
            logAntes.data = logAgora.data;
            logAntes.log = log;
            logAntes.idAgora = logAgora.IdLogAgora;
            db.LogsAgoraAntes.Add(logAntes);
            db.SaveChanges();
            string pathCompleto = path + Guid.NewGuid() + ".txt";
            System.IO.File.WriteAllText(pathCompleto, logAgora.log);

            return new RetornoTransformaLog() { 
                LogMudado =logAgora.log,
                path=pathCompleto,
            };
        }


        public RetornoTransformaLog Transformar(long id)
        {
           var logMinhaCdn = db.LogsMinhaCdn.FirstOrDefault(x => x.id == id);
           return Transformar(logMinhaCdn.log);
        }

        public string Listar()
        {
            var retorno = new StringBuilder();
            var listaLogAntes = db.LogsAgoraAntes.ToList();
            for (int i = 0; i < listaLogAntes.Count; i++)
            {
                retorno.Append(listaLogAntes[i].log);
            }
            retorno.Append(Environment.NewLine);
            var listaLogAgora = db.LogsAgora.ToList();
            for (int i = 0; i < listaLogAgora.Count; i++)
            {
                retorno.Append(listaLogAgora[i].log);
            }
            return retorno.ToString();
        }

        public LogAgora PegaLogPeloId(long id)
        {
            return db.LogsAgora.FirstOrDefault(x => x.IdLogAgora == id);
        }

    }
}
