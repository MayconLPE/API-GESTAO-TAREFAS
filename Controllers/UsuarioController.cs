using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_GESTAO_TAREFAS.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosUsuarios()
        {
            var usuarios = await _repository.BuscarTodosUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> BuscarUsuarioId(int id)
        {
            var usuario = await _repository.BuscarUserId(id);
            return usuario != null
                            ? Ok(usuario)
                            : NotFound("Usuario não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UsuarioModel usuarioModel)
        {
            if (string.IsNullOrEmpty(usuarioModel.Nome))
            {
                return BadRequest("Informações inválidas");
            }

            var adicionado = await _repository.AdicionarUser(usuarioModel);

            return adicionado
            ? Ok("Usuario Cadastrado com sucesso")
            : BadRequest("Erro: Usuario não adicionado");

        }

        [HttpPut("idUsuario")]
        public async Task<IActionResult> AtualizarUsuario(UsuarioModel request, int idUsuario)
        {
            if (idUsuario <= 0) return BadRequest("Usuario inválido");
            var usuario = await _repository.BuscarUserId(idUsuario);

            if (string.IsNullOrEmpty(request.Nome)) request.Nome = usuario.Nome;

            var atualizado = await _repository.AtualizarUser(request, idUsuario);

            return atualizado
                        ? Ok("Usuario atualizado com sucesso")
                        : BadRequest("Erro: Usuario não atualizado");
        }

        [HttpDelete("idUsuario")]
        public async Task<IActionResult> DeletarUsuario(int idUsuario)
        {
            if (idUsuario <= 0) return BadRequest("Usuario inválido");
            var usuario = await _repository.BuscarUserId(idUsuario);

            if (usuario == null) NotFound("Usuario não existe");

            var deletado = await _repository.DeletarUser(idUsuario);
            return deletado
                        ? Ok("Usuario deletado com sucesso")
                        : BadRequest("Erro: Usuario não deletado");

        }

    }
}