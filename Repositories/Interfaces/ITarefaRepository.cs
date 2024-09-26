using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Models.Dtos;

namespace API_GESTAO_TAREFAS.Repositories.Interfaces;

public interface ITarefaRepository
{
    Task<IEnumerable<TarefaModel>> BuscarTodasTarefas();
    Task<TarefaModel> BuscarTarefaId(int idTarefa);
    Task<bool> AdicionarTarefa(TarefaModel request);
    Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa);
    Task<bool> DeletarTarefa(int idTarefa);

    Task<IEnumerable<TarefaDto>> BuscarTodasTarefasDto();


}
