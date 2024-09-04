using Microsoft.AspNetCore.Mvc;


namespace API_GESTAO_TAREFAS.Controllers
{
    [Route("tarefa/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Controller tarefa");
        }
  
    }

}

   
