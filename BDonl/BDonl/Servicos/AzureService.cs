using BDonl.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDonl.Servicos
{
    public class AzureService<T> where T : IRegra
    {
        IMobileServiceClient Cliente;
        IMobileServiceTable<T> Tabela;

        public AzureService()
        {
            Cliente = new MobileServiceClient(Const.Url);
            Tabela = Cliente.GetTable<T>();
        }

        public async Task<IEnumerable<T>> ObterTarefasAsync() => await Tabela.ToEnumerableAsync();

        public async Task Enviar(T item) => await Tabela.InsertAsync(item);
    }
}
