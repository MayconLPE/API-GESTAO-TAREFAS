using API_GESTAO_TAREFAS.Models;
using API_GESTAO_TAREFAS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_GESTAO_TAREFAS.Controllers
{
    [Route("tarefa/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _repository;
        public TarefaController(ITarefaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasTarefas()
        {
            var tarefa = await _repository.BuscarTodasTarefas();
            return tarefa.Any() ? Ok(tarefa) : NoContent();
        }
        [HttpGet("idTarefa")]
        public async Task<IActionResult> BuscarTarefaId(int idTarefa)
        {
            var tarefa = await _repository.BuscarTarefaId(idTarefa);
            return tarefa != null
                            ? Ok(tarefa)
                            : NotFound("Usuario não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTarefa(TarefaModel tarefaModel)
        {
            if (string.IsNullOrEmpty(tarefaModel.TituloTarefa))
            {
                return BadRequest("Informações inválidas");
            }

            var adicionado = await _repository.AdicionarTarefa(tarefaModel);

            return adicionado
            ? Ok("Tarefa Cadastrada com sucesso")
            : BadRequest("Erro: Tarefa não adicionado");

        }

        [HttpPut("idTarefa")]
        public async Task<IActionResult> AtualizarTarefa(TarefaModel request, int idTarefa)
        {
            if(idTarefa <= 0) return BadRequest("Tarefa Inválida");

            var tarefa = await _repository.BuscarTarefaId(idTarefa);

            if(tarefa == null) NotFound("Tarefa ainda não criada");

            if(string.IsNullOrEmpty(request.TituloTarefa)) request.TituloTarefa = tarefa.TituloTarefa;

            var atualizado = await _repository.AtualizarTarefa(request, idTarefa);
            return atualizado
            ? Ok("Tarefa Cadastrada com sucesso")
            : BadRequest("Erro: Tarefa não adicionada");

        }

    }

}


