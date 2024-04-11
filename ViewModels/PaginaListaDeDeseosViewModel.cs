using CommunityToolkit.Mvvm.Input;
using SmartTrade.Models;
using SmartTrade.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SmartTrade.ViewModels
{
    internal partial class PaginaListaDeDeseosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Deseados { get; set; }

        private readonly SmartTradeServices _dataService;

        public PaginaListaDeDeseosViewModel(SmartTradeServices dataService)
        {

            _dataService = dataService;
            Deseados = new ObservableCollection<Producto>();
        }

        [RelayCommand]
        public async Task ListarDeseos()
        {
            List<Producto> productos = _dataService.ObtenerListaDeseos();
            foreach (var producto in productos)
            {

                Deseados.Add(producto);
            }




        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }

}
