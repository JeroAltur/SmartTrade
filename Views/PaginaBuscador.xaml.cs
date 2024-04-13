using SmartTrade.Services;
using SmartTrade.ViewModels;

namespace SmartTrade.Views;

public partial class PaginaBuscador : ContentPage
{
	public PaginaBuscador(string textoBusqueda)
	{

		InitializeComponent();
		var viewModel = new PaginaBuscadorViewModel(new SmartTradeServices(new ServicioBD(new Conexion().GetConexion())), Navigation, textoBusqueda); ;
		BindingContext = viewModel;
		scrollView.HeightRequest = ScrollViewHeigth();
	}

	public double ScrollViewHeigth()
	{
		double screenHeight = DeviceDisplay.MainDisplayInfo.Height;
		return DeviceDisplay.MainDisplayInfo.Height - searchBar.Height;

    }

}