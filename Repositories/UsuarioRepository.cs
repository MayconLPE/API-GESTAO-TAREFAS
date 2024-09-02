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
        return await con.QueryFirstOrDefaultAsync<UsuarioModel>(sql, new { Id = idUsuario});
    }

    public Task<bool> AdicionarUser(UsuarioModel request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarUser(UsuarioModel request, int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletarUser(int id)
    {
        throw new NotImplementedException();
    }
}
