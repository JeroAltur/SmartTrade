﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SmartTrade;
using SmartTrade.Services;
using SmartTrade.ViewModels;
using SmartTrade.Views;




namespace SmartTrade
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var conexion = new Conexion();
            SmartTradeServices service = new SmartTradeServices(new ServicioBD(conexion.GetConexion()));

            //Recordar borrar esto en cierto punto, ya que borra los datos i crea nuevos
            service.IniciarBD();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .UseMauiCommunityToolkit()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



            //Add ViewModels
            builder.Services.AddSingleton<PaginaPrincipalViewModel>();
            builder.Services.AddSingleton<AgregarProductoViewModel>();
            builder.Services.AddSingleton<PaginaListaDeDeseosViewModel>();
            builder.Services.AddSingleton<PaginaPerfilViewModel>();
            builder.Services.AddSingleton<PaginaBuscadorViewModel>();



            //AddViews
            builder.Services.AddSingleton<PaginaPrincipal>();
            builder.Services.AddSingleton<AgregarProducto>();
            builder.Services.AddSingleton<PaginaListaDeDeseos>();
            builder.Services.AddSingleton<PaginaPerfil>();
            builder.Services.AddSingleton<PaginaBuscador>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}