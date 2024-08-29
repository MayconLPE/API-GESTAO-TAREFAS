
using API_GESTAO_TAREFAS.Models;

namespace API_GESTAO_TAREFAS.Repositories.Interfaces;

    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarUserId(int id);
        Task<bool> AdicionarUser(UsuarioModel request);
        Task<bool> AtualizarUser(UsuarioModel request, int id);
        Task<bool> DeletarUser(int id);
    }
