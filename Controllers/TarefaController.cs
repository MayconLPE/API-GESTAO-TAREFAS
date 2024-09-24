using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using API_GESTAO_TAREFAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_GESTAO_TAREFAS.Controllers
{
    [Route("tarefa/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;
        public TarefaController(ITarefaService service)
        {
            _service = service;
        }

        [HttpGet("BuscarTodasTarefas")]
        public async Task<IActionResult> BuscarTodasTarefas()
        {
            var tarefa = await _service.BuscarTodasTarefas();
            return tarefa.Any() ? Ok(tarefa) : NoContent();
        }
        [HttpGet("BuscarTarefaId")]
        public async Task<IActionResult> BuscarTarefaId(int idTarefa)
        {
            var tarefa = await _service.BuscarTarefaId(idTarefa);
            return tarefa != null
                            ? Ok(tarefa)
                            : NotFound("Usuario não encontrado");
        }

        [HttpPost("CadastrarTarefa")]
        public async Task<IActionResult> CadastrarTarefa(TarefaModel tarefaModel)
        {
            if (string.IsNullOrEmpty(tarefaModel.TituloTarefa))
            {
                return BadRequest("Informações inválidas");
            }

            var adicionado = await _service.AdicionarTarefa(tarefaModel);

            return adicionado
            ? Ok("Usuario Cadastrado com sucesso")
            : BadRequest("Erro: Usuario não adicionado");

        }

    }

}


