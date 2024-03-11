using Microsoft.Extensions.Logging;
using SmartTrade;
using SmartTrade.ViewModels;
using SmartTrade.Views;




namespace SmartTrade
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



            //Add ViewModels
            builder.Services.AddSingleton<PaginaPrincipalViewModel>();


            //AddViews
            builder.Services.AddSingleton<PaginaPrincipal>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}