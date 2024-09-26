using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Models.Dtos;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using API_GESTAO_TAREFAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_GESTAO_TAREFAS.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("BuscarTodosUsuarios")]
        public async Task<IActionResult> BuscarTodosUsuarios()
        {
            var usuarios = await _service.BuscarTodosUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("BuscarUsuarioId")]
        public async Task<IActionResult> BuscarUsuarioId(int id)
        {
            var usuario = await _service.BuscarUserId(id);
            return usuario != null
                            ? Ok(usuario)
                            : NotFound("Usuario não encontrado");
        }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(UsuarioModel usuarioModel)
        {
            if (string.IsNullOrEmpty(usuarioModel.Nome))
            {
                return BadRequest("Informações inválidas");
            }

            var adicionado = await _service.AdicionarUser(usuarioModel);

            return adicionado
            ? Ok("Usuario Cadastrado com sucesso")
            : BadRequest("Erro: Usuario não adicionado");

        }

        [HttpPut("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario(UsuarioModel request, int idUsuario)
        {
            if (idUsuario <= 0) return BadRequest("Usuario inválido");
            
            var usuario = await _service.BuscarUserId(idUsuario);

            if (string.IsNullOrEmpty(request.Nome)) request.Nome = usuario.Nome;

            var atualizado = await _service.AtualizarUser(request, idUsuario);

            return atualizado
                        ? Ok("Usuario atualizado com sucesso")
                        : BadRequest("Erro: Usuario não atualizado");
        }

        [HttpDelete("DeletarUsuiario")]
        public async Task<IActionResult> DeletarUsuario(int idUsuario)
        {
            if (idUsuario <= 0) return BadRequest("Usuario inválido");
            var usuario = await _service.BuscarUserId(idUsuario);

            if (usuario == null) NotFound("Usuario não existe");

            var deletado = await _service.DeletarUser(idUsuario);
            return deletado
                        ? Ok("Usuario deletado com sucesso")
                        : BadRequest("Erro: Usuario não deletado");

        }

        [HttpGet("ExibirTodosNomesUsuarios")]
        public async Task<IActionResult> ExibirTodosNomesUsuarios()
        {
            var usuarios = await _service.BuscarTodosUsuarios();
            List<UsuarioDto> usuariosRetorno = new List<UsuarioDto>();

            foreach (var usuario in usuarios)
            {
                usuariosRetorno.Add(new UsuarioDto{Nome = usuario.Nome});
            }

            return usuariosRetorno.Any()
                ? Ok(usuariosRetorno)
                : BadRequest("Usuarios não encontrado");
        }

    }
}