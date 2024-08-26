
using API_GESTAO_TAREFAS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_GESTAO_TAREFAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaRepository _repository;
    public TarefasController(ITarefaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> ExibirTodasTarefas()
    {
        var tarefas = await _repository.ExibirTodasTarefas();

        return tarefas.Any() ? Ok(tarefas) : NoContent();
    }

    // [HttpGet]
    // public IActionResult ExibirUmaMensagem()
    // {
    //     return Ok("Olá, a API esta funcionando");
    // }

}
