using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace BDonl.Model
{
    [DataTable("Tarefas")]
    public class Tarefa : BDBase
    {
        [JsonProperty("Nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonProperty("Concluida")]
        public bool Concluido { get; set; } = false;

        [JsonProperty("Criacao")]
        public DateTime Criacao { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public string ExibirCriacao
        {
            get { return Criacao.ToLocalTime().ToString(ViewModel.BaseViewModel.culture); }
        }
    }
}
