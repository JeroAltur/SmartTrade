using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartTrade.Models;
using SmartTrade.Views;
using SmartTrade.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
//using UIKit;

namespace SmartTrade.ViewModels
{
    internal partial class PaginaPrincipalViewModel : ObservableObject
    {
        private readonly SmartTradeServices _dataService;
        private readonly INavigation _navigation;

        public ObservableCollection<Producto> Tendencias { get; }
        public ObservableCollection<Producto> MejorValorados { get; }
        public ObservableCollection<Producto> CompradosPorIronMan { get; }
        public ICommand SearchCommand { get; private set; }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public PaginaPrincipalViewModel() { 
        }


        public PaginaPrincipalViewModel(SmartTradeServices dataService, INavigation navigation)
        {
            _dataService = dataService;
            _navigation = navigation;

            //Inicializamos las colecciones
            Tendencias = new ObservableCollection<Producto>(dataService.Tendencias());
            MejorValorados = new ObservableCollection<Producto>(dataService.MejorValorado());
            CompradosPorIronMan = new ObservableCollection<Producto>(dataService.CompradosPorIronman());

            SearchCommand = new RelayCommand(ExecuteSearch);

        }

        private async void ExecuteSearch()
        {
            string searchTerm = SearchText;
            await _navigation.PushAsync(new PaginaBuscador(searchTerm));
        }
/*
        [RelayCommand]
        public async Task ListarTendencias()
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

        */
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
