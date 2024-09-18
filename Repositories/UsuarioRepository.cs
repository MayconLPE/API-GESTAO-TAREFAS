using System.Data.SqlClient;
using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using Dapper;

namespace API_GESTAO_TAREFAS.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public UsuarioRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration.GetConnectionString("SqlConnection");
    }

    public async Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios()
    {
        string sql = @"SELECT * FROM tb_usuario;";
        using var con = new SqlConnection(connectionString);
        return await con.QueryAsync<UsuarioModel>(sql);

    }

    public async Task<UsuarioModel> BuscarUserId(int idUsuario)
    {
        string sql = @"SELECT id, nome
                        FROM tb_usuario 
                        WHERE id = @Id;";
        using var con = new SqlConnection(connectionString);
        return await con.QueryFirstOrDefaultAsync<UsuarioModel>(sql, new { Id = idUsuario });
    }

    public async Task<bool> AdicionarUser(UsuarioModel request)
    {
        string sql = @"INSERT INTO tb_usuario (Nome)
                       VALUES (@Nome);";
        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, request) > 0;

    }

    public async Task<bool> AtualizarUser(UsuarioModel request, int idUsuario)
    {
         string sql = @"UPDATE tb_usuario SET
	                        nome = @Nome
                        WHERE IdUsuario = @IdUsuario;";
        var parametros = new DynamicParameters();
        parametros.Add("Nome", request.Nome);
        parametros.Add("IdUsuario", request.IdUsuario);

        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, parametros) > 0;
    }

    public async Task<bool> DeletarUser(int idUsuario)
    {
        string sql = @"DELETE FROM tb_usuario
                        WHERE IdUsuario = @IdUsuario;";

        using var con = new SqlConnection(connectionString);
        return await con.ExecuteAsync(sql, new { IdUsuario = idUsuario}) > 0;
    }
}
