
using System.ComponentModel;

namespace API_GESTAO_TAREFAS.Models.Enums;

    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
        
    }
