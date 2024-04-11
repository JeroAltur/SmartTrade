using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartTrade.Models;
using SmartTrade.Services;
using System.Collections.ObjectModel;

namespace SmartTrade.ViewModels
{
    internal partial class PaginaPrincipalViewModel : ObservableObject
    {
        private readonly SmartTradeServices _dataService;

        public ObservableCollection<Producto> Tendencias { get; }
        public ObservableCollection<Producto> MejorValorados { get; }
        public ObservableCollection<Producto> CompradosPorIronMan { get; }






        public PaginaPrincipalViewModel(SmartTradeServices dataService)
        {
            _dataService = dataService;

            //Inicializamos las colecciones
            Tendencias = new ObservableCollection<Producto>();
            MejorValorados = new ObservableCollection<Producto>();
            CompradosPorIronMan = new ObservableCollection<Producto>();

        }

        [RelayCommand]
        public async Task ListarTerndencias()
        {
            var productos = _dataService.Tendencias();
            foreach (var producto in productos)
            {
                Tendencias.Add(producto);
            }

        }

        [RelayCommand]
        public async Task ListarMejorValorados()
        {
            var productos = _dataService.MejorValorado();
            foreach (var producto in productos)
            {
                MejorValorados.Add(producto);
            }

        }
        /*
                [RelayCommand]
                public async Task ListarCompradosPorIronMan()
                {
                    var productos = _dataService.ObtenerCompradosPorIronMan();
                    foreach (var producto in productos)
                    {
                        CompradosPorIronMan.Add(producto);
                    }

                }
        */

    }
}
