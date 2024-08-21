using API_GESTAO_TAREFAS.Models;

namespace API_GESTAO_TAREFAS.Repositories;

public class TarefaRepository : ITarefaRepository
{
    public Task<IEnumerable<TarefaResponse>> ExibirTodasTarefas()
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TarefaResponse>> BuscarTarefaId()
    {
        throw new NotImplementedException();
    }
    public Task<bool> AdicionarTarefa(TarefaRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarTarefa(TarefaRequest request, int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletarTarefa(int id)
    {
        throw new NotImplementedException();
    }

}
