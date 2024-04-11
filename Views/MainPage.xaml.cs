namespace SmartTrade.Views;

public partial class MainPage : Shell
{

    int count = 0;

    public MainPage()
    {

        try
        {
            InitializeComponent();
            this.Navigated += OnNavigated;

            Routing.RegisterRoute(typeof(AgregarProducto).Name, typeof(AgregarProducto));
            Routing.RegisterRoute(typeof(PaginaListaDeDeseos).Name, typeof(PaginaListaDeDeseos));
            Routing.RegisterRoute(typeof(PaginaPerfil).Name, typeof(PaginaPerfil));
            Routing.RegisterRoute(typeof(MainPage).Name, typeof(MainPage));



        }
        catch (Exception e)
        {


        }


    }

    private void OnNavigated(Object sender, ShellNavigatedEventArgs e)
    {
        var currentRoute = e.Current.Location.OriginalString;
        Console.WriteLine(currentRoute);




    }



}