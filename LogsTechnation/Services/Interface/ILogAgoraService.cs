using LogsTechnation.Model;

namespace LogsTechnation.Services.Interface
{
    public interface ILogAgoraService
    {
        RetornoTransformaLog Transformar(string log);

        RetornoTransformaLog Transformar(long id);

        string Listar();

        LogAgora PegaLogPeloId(long id);
    }
}
