using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SmartTrade.Models;
using SmartTrade.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SmartTrade.ViewModels
{
    internal class PaginaPrincipalViewModel : ObservableObject
    {
        private readonly SmartTradeServices _dataService;

        public ObservableCollection<Producto> Tendencias { get;  }
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
            var productos = _dataService.ObtenerTendencias();
            foreach (var producto in productos)
            {
                Tendencias.Add(producto);                
            }

        }

        [RelayCommand]
        public async Task ListarMejorValorados()
        {
            var productos = _dataService.ObtenerMejorValorados();
            foreach (var producto in productos)
            {
                Tendencias.Add(producto);
            }

        }

        [RelayCommand]
        public async Task ListarCompradosPorIronMan()
        {
            var productos = _dataService.ObtenerCompradosPorIronMan();
            foreach (var producto in productos)
            {
                Tendencias.Add(producto);
            }

        }


    }
}
