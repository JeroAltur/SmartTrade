using SmartTrade.Services;
using SmartTrade.ViewModels;

namespace SmartTrade.Views;

public partial class PaginaBuscador : ContentPage
{
	public PaginaBuscador(string textoBusqueda)
	{

		InitializeComponent();
		var viewModel = new PaginaBuscadorViewModel(new SmartTradeServices(new ServicioBD(InicializacionServicioBD.GetDatabasePath())), Navigation, textoBusqueda); ;
		BindingContext = viewModel;
	}
	
}