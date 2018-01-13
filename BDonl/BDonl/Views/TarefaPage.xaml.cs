using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDonl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TarefaPage : ContentPage
	{
		public TarefaPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModel.TarefaViewModel();
		}
	}
}