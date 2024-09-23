using System.Data.SqlClient;
using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using API_GESTAO_TAREFAS.Services.Interfaces;

namespace API_GESTAO_TAREFAS.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _repository.BuscarTodosUsuarios();
    }

    public async Task<UsuarioModel> BuscarUserId(int idUsuario)
    {
        return await _repository.BuscarUserId(idUsuario);
    }
    public async Task<bool> AdicionarUser(UsuarioModel request)
    {
        return await _repository.AdicionarUser(request);
    }

    public async Task<bool> AtualizarUser(UsuarioModel request, int idUsuario)
    {
        return await _repository.AtualizarUser(request, idUsuario);
    }

    public async Task<bool> DeletarUser(int idUsuario)
    {
        return await _repository.DeletarUser(idUsuario);
    }

}
