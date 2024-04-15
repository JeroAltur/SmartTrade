using CommunityToolkit.Mvvm.ComponentModel;
using SmartTrade.Services;
using SmartTrade.Models;
using SmartTrade.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SmartTrade.ViewModels
{
    internal class PaginaBuscadorViewModel : ObservableObject
    {
        private readonly SmartTradeServices dataService;
        private readonly INavigation navigation;

        public string textoBusqueda;
        public ObservableCollection<Producto> productosBuscados {  get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand PresionBtnPrincipal { get; set; }
        public ICommand PresionBtnPerfil { get; set; }
        public ICommand PresionBtnNotificaciones { get; set; }
        public ICommand PresionBtnOpciones { get; set; }

        public PaginaBuscadorViewModel(SmartTradeServices dataService, INavigation navigation, string textoBusqueda)
        {
            this.dataService = dataService;
            this.navigation = navigation;
            this.textoBusqueda = textoBusqueda;
            productosBuscados = new ObservableCollection<Producto>(dataService.Buscador(textoBusqueda));
            SearchCommand = new RelayCommand(ExecuteSearch);
            PresionBtnPrincipal = new RelayCommand(ExecutePrincipal);
            PresionBtnPerfil = new RelayCommand(ExecutePerfil);
            PresionBtnNotificaciones = new RelayCommand(ExecuteNotificaciones);
            PresionBtnOpciones = new RelayCommand(ExecuteOpciones);
        }

        public string SearchText
        {
            get { return textoBusqueda; }
            set { SetProperty(ref textoBusqueda, value); }
        }

        private async void ExecuteSearch()
        {
            string searchTerm = SearchText;
            await navigation.PushAsync(new PaginaBuscador(searchTerm));
        }
        private async void ExecutePrincipal()
        {
            await navigation.PushAsync(new PaginaPrincipal());
        }
        private async void ExecutePerfil()
        {
            string searchTerm = SearchText;
            await navigation.PushAsync(new PaginaPerfil());
        }
        private async void ExecuteNotificaciones()
        {
            string searchTerm = SearchText;
            await navigation.PushAsync(new PaginaListaDeDeseos());
        }
        private async void ExecuteOpciones()
        {
            string searchTerm = SearchText;
            await navigation.PushAsync(new AgregarProducto());
        }

    }
}
