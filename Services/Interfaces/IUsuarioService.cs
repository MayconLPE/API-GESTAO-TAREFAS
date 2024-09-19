using API_GESTAO_TAREFAS.Models;

namespace API_GESTAO_TAREFAS.Services.Interfaces;

    public interface IUsuarioService
    {
    Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios();
    Task<UsuarioModel> BuscarUserId(int idUsuario);
    Task<bool> AdicionarUser(UsuarioModel request);
    Task<bool> AtualizarUser(UsuarioModel request, int idUsuario);
    Task<bool> DeletarUser(int idUsuario);
    
    }
