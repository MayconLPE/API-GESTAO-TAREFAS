using API_GESTAO_TAREFAS.Models;

namespace API_GESTAO_TAREFAS.Services.Interfaces;

public interface ITarefaService
{
    Task<IEnumerable<TarefaModel>> BuscarTodasTarefas();
    Task<TarefaModel> BuscarTarefaId(int idTarefa);
    Task<bool> AdicionarTarefa(TarefaModel request);
    Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa);
    Task<bool> DeletarTarefa(int idTarefa);
}
