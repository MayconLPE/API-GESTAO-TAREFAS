namespace API_GESTAO_TAREFAS.Models;

public class TarefaRequest
{
    public string Usuario { get; set; }
    public string TituloTarefa { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }

}
