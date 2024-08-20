
using Microsoft.AspNetCore.Mvc;

namespace API_GESTAO_TAREFAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{

    [HttpGet]
    public IActionResult ExibirUmaMensagem()
    {
        return Ok("Olá, a API esta funcionando");
    }

}
