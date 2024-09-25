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
        string sql = @"EXEC BuscarTodasTarefas";
        using var con = new SqlConnection(connectionString);
        return await con.QueryAsync<TarefaModel>(sql);
    }
    public async Task<TarefaModel> BuscarTarefaId(int idTarefa)
    {
        string sql = @"EXEC BuscarPorID @IdTarefa = @IdTarefa";
        using var con = new SqlConnection(connectionString);
        return await con.QueryFirstOrDefaultAsync<TarefaModel>(sql, new { IdTarefa = idTarefa });

    }
    public async Task<bool> AdicionarTarefa(TarefaModel request)
    {
        string sql = @"EXEC AdiconarTarefa 
                        @TituloTarefa,
                        @Descricao,
                        @Categoria,
                        @Status";
        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, request) > 0;
    }

    public async Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa)
    {
        string sql = @"UPDATE tb_tarefa SET
	                    TituloTarefa = @TituloTarefa,
                        Descricao = @Descricao,
                        Categoria = @Categoria,
                        Status = @Status
                        WHERE IdTarefa = @IdTarefa";

        var parametros = new DynamicParameters();
        parametros.Add("TituloTarefa", request.TituloTarefa);
        parametros.Add("Descricao", request.Descricao); 
        parametros.Add("Categoria", request.Categoria); 
        parametros.Add("Status", request.Status);
        parametros.Add("IdTarefa", request.IdTarefa);    

        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, parametros) > 0;
    }

    public async Task<bool> DeletarTarefa(int idTarefa)
    {
                string sql = @"DELETE FROM tb_tarefa
                                WHERE idTarefa = @IdTarefa";

        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, new { idTarefa = idTarefa}) > 0;
    }
}
