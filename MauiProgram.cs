using SmartTrade.ViewModels;
using SmartTrade.Views;

using Microsoft.Extensions.Logging;

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

            //AddViews


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}