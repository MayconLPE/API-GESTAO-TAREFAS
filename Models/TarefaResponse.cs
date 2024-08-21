namespace API_GESTAO_TAREFAS.Models;

public class TarefaResponse
{
    public int Id { get; set; }
    public string Usuario { get; set; }
    public string TituloTarefa { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }

}
