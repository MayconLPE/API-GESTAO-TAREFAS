using System.Data.Common;
using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;

namespace API_GESTAO_TAREFAS.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public TarefaRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration.GetConnectionString("SqlConnection");
    }
    public Task<bool> AdicionarTarefa(TarefaModel request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa)
    {
        throw new NotImplementedException();
    }

    public Task<TarefaModel> BuscarTarefaId(int idTarefa)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TarefaModel>> BuscarTodasTarefas()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletarTarefa(int idTarefa)
    {
        throw new NotImplementedException();
    }
}
