namespace SmartTrade.Views;

public partial class PaginaPrincipal : ContentPage
{
    public PaginaPrincipal()
    {
        InitializeComponent();
    }

    private async void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchBarText = searchBar.Text;
        await Navigation.PushAsync(new PaginaBuscador(searchBarText));
    }
}