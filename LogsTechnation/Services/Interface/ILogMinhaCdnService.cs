using LogsTechnation.Model;
using System.Collections.Generic;

namespace LogsTechnation.Services.Interface
{
    public interface ILogMinhaCdnService
    {
        List<LogMinhaCdn> Listar();
        LogMinhaCdn Salvar(LogMinhaCdn log);
        LogMinhaCdn PegarLogPorId(long id);
    }
}
