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
                       Categoria , Status, IdUsuario)
                       VALUES (@TituloTarefa, @Descricao, 
                       @Categoria, @Status, @IdUsuario );";
        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, request) > 0;
    }

    public async Task<bool> AtualizarTarefa(TarefaModel request, int idTarefa)
    {
        string sql = @"UPDATE tb_tarefa SET
                        TituloTarefa = @TituloTarefa,
                        Descricao = @Descricao,
                        Categoria = @Categoria,
                        Status = @Status, 
                        IdUsuario = @IdUsuario
                       WHERE IdTarefa = @IdTarefa";

        var parametros = new DynamicParameters();
        parametros.Add("TituloTarefa", request.TituloTarefa);
        parametros.Add("Descricao", request.Descricao);
        parametros.Add("Categoria", request.Categoria);
        parametros.Add("Status", request.Status);
        parametros.Add("IdUsuario", request.IdUsuario);
        parametros.Add("IdTarefa", request.IdTarefa);

        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, parametros) > 0;
    }

    public Task<bool> DeletarTarefa(int idTarefa)
    {
        throw new NotImplementedException();
    }

}
