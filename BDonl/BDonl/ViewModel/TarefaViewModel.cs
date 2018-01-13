using BDonl.Model;
using BDonl.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BDonl.ViewModel
{
    public class TarefaViewModel: BaseViewModel
    {
        private string _item;

        public string Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged(); }
        }

        public Command AddCommand { get; }
        public Command CarregaCommand { get; }

        public ObservableCollection<Tarefa> Tarefas { get; set; }

        AzureService<Tarefa> Servico;

        public TarefaViewModel()
        {
            AddCommand = new Command(ExecuteAddCommand);
            CarregaCommand = new Command(ExecuteCarregaCommand);
            Tarefas = new ObservableCollection<Tarefa>();
            Servico = new AzureService<Tarefa>();
        }

        async void ExecuteCarregaCommand() => await Atualizar();

        async void ExecuteAddCommand()
        {
            await Servico.Enviar(new Tarefa { Nome = Item });
            await Atualizar();
        }

        async Task Atualizar()
        {
            Tarefas.Clear();
            var resposta = await Servico.ObterTarefasAsync();
            foreach (var tarefa in resposta)
            {
                Tarefas.Add(tarefa);
            }
        }
    }
}
