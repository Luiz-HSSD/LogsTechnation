using LogsTechnation.Model;
using LogsTechnation.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsTechnation.Services
{
    public class LogMinhaCdnService : ILogMinhaCdnService
    {
        private static LogContext db = new LogContext();
        private string path = ".\\wwwroot\\logs\\";

        public void setDbContext(LogContext bancoMock)
        {
            db = bancoMock;
        }

        public List<LogMinhaCdn> Listar()
        {
            return db.LogsMinhaCdn.ToList();
        }

        public LogMinhaCdn PegarLogPorId(long id)
        {
            return db.LogsMinhaCdn.FirstOrDefault(x => x.id == id);
        }

        public LogMinhaCdn Salvar(LogMinhaCdn log)
         {
            log.data = DateTime.Now;
            System.IO.File.WriteAllText(path + Guid.NewGuid() + ".txt", log.log);
            db.LogsMinhaCdn.Add(log);
            db.SaveChanges();
            return log;
        }
}
}
