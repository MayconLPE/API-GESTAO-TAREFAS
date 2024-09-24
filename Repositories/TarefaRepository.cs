using System.Data.SqlClient;
using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
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
    public async Task<IEnumerable<TarefaModel>> BuscarTodasTarefas()
    {
        string sql = @"SELECT * FROM tb_tarefa WITH (NOLOCK);";
        using var con = new SqlConnection(connectionString);
        return await con.QueryAsync<TarefaModel>(sql);
    }
    public async Task<TarefaModel> BuscarTarefaId(int idTarefa)
    {
        string sql = @"SELECT *
                    FROM tb_tarefa WITH (NOLOCK)
                    WHERE IdTarefa = @IdTarefa;";
        using var con = new SqlConnection(connectionString);
        return await con.QueryFirstOrDefaultAsync<TarefaModel>(sql, new { IdTarefa = idTarefa });

    }
    public async Task<bool> AdicionarTarefa(TarefaModel request)
    {
        string sql = @"INSERT INTO tb_tarefa (TituloTarefa, Descricao, 
                       Categoria , Status)
                       VALUES (@TituloTarefa, @Descricao, 
                       @Categoria, @Status);";
        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, request) > 0;
    }

    public Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletarTarefa(int idTarefa)
    {
        throw new NotImplementedException();
    }
}
