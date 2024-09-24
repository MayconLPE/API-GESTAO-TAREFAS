using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using API_GESTAO_TAREFAS.Services.Interfaces;

namespace API_GESTAO_TAREFAS.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<TarefaModel>> BuscarTodasTarefas()
    {
        return await _repository.BuscarTodasTarefas();
    }
    public async Task<TarefaModel> BuscarTarefaId(int idTarefa)
    {
        return await _repository.BuscarTarefaId(idTarefa);
    }
    public async Task<bool> AdicionarTarefa(TarefaModel request)
    {
        return await _repository.AdicionarTarefa(request);
    }

    public async Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> DeletarTarefa(int idTarefa)
    {
        throw new NotImplementedException();
    }
}
