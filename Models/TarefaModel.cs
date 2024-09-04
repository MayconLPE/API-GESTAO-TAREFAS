using API_GESTAO_TAREFAS.Models.Enums;

namespace API_GESTAO_TAREFAS.Models;

public class TarefaModel
{
    public int IdTarefa { get; set; }
    public int IdUsuario { get; set; }
    public string? TituloTarefa { get; set; }
    public string? Descricao { get; set; }
    public string? Categoria { get; set; }
    public StatusTarefa Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }

}
