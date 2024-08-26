using System.Data.SqlClient;
using API_GESTAO_TAREFAS.Models;
using Dapper;

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
    
    public async Task<IEnumerable<TarefaResponse>> ExibirTodasTarefas()
    {
        string sql = @"EXEC consultarTodasTarefas";
        using (var con = new SqlConnection(connectionString))
        {
            return await con.QueryAsync<TarefaResponse>(sql);
        }

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
