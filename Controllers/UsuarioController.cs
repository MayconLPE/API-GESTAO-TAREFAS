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



    }
}