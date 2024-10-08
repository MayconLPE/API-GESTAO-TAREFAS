using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Models.Dtos;
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

        [HttpPut("AtualizarTarefa")]
        public async Task<IActionResult> AtualizarTarefa(TarefaModel request, int idTarefa)
        {
            TarefaModel registro = await _service.BuscarTarefaId(request.IdTarefa);
            if (registro == null)
            {
                return NotFound("Id não localizado");
            }

            //  if (idTarefa <= 0) return BadRequest("Tarefa invalida");
            //  var tarefa = await _service.BuscarTarefaId(idTarefa);

            //  if (tarefa == null) return NotFound("Tarefa não existe");

            var atualizar = await _service.AtualizarTarefa(request, idTarefa);

            return atualizar
                ? Ok("Tarefa atualizada")
                : BadRequest("Erro ao atualizar");
        }

        [HttpDelete("DeletarTarefa")]
        public async Task<IActionResult> DeletarTarefa(int idTarefa)
        {
            if (idTarefa <= 0) return BadRequest("Tarefa invalida");
            var tarefa = await _service.BuscarTarefaId(idTarefa);

            if (tarefa == null) return NotFound("Tarefa não existe");

            var deletar = await _service.DeletarTarefa(idTarefa);

            return deletar
                ? Ok("Tarefa deletada")
                : BadRequest("Erro ao deletar");

        }

        [HttpGet("BuscarIdTarefaDto")]
        public async Task<IActionResult> BuscarIdTarefasDto(int idTarefa)
        {
            var tarefa = await _service.BuscarTarefaId(idTarefa);

            var tarefaRetono = new TarefaDto
            {
                IdTarefa = tarefa.IdTarefa,
                TituloTarefa = tarefa.TituloTarefa,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };
            return tarefaRetono != null
                ? Ok(tarefaRetono)
                : BadRequest("Tarefa não encontrada");
        }

        [HttpGet("BuscaTodasTarefasDto")]
        public async Task<IActionResult> BuscaTodasTarefasDto()
        {
            var tarefa = await _service.BuscarTodasTarefasDto();
            return tarefa.Any() ? Ok(tarefa) : NoContent();
        }
    }

}


