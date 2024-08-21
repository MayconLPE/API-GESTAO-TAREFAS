
using API_GESTAO_TAREFAS.Models;

namespace API_GESTAO_TAREFAS.Repositories;

public interface ITarefaRepository
{
    Task<IEnumerable<TarefaResponse>> ExibirTodasTarefas();
    Task<IEnumerable<TarefaResponse>> BuscarTarefaId();
    Task<bool> AdicionarTarefa(TarefaRequest request);
    Task<bool> AtualizarTarefa(TarefaRequest request, int id);
    Task<bool> DeletarTarefa(int id);

}
