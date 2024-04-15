using SmartTrade.ViewModels;
using SmartTrade.Services;

namespace SmartTrade.Views;

public partial class PaginaPrincipal : ContentPage
{
	public PaginaPrincipal()
	{
		InitializeComponent();
		var viewModel = new PaginaPrincipalViewModel(new SmartTradeServices(new ServicioBD(InicializacionServicioBD.GetDatabasePath())), Navigation);
		BindingContext = viewModel;
	}
}