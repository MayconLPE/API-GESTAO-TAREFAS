namespace API_GESTAO_TAREFAS.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string? TituloTarefa { get; set; }
    public string? Descricao { get; set; }
    public int Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }

}
