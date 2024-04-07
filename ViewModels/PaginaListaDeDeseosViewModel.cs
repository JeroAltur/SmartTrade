using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmartTrade.Models;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using SmartTrade.Services;


namespace SmartTrade.ViewModels
{
    internal partial class PaginaListaDeDeseosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Deseados { get; set; }

        private readonly SmartTradeServices _dataService;

        public PaginaListaDeDeseosViewModel(SmartTradeServices dataService ){
            
            _dataService = dataService;
            Deseados = new ObservableCollection<Producto>();
        }

        [RelayCommand]
       public async Task ListarDeseos() {
            List<Producto>productos =  _dataService.ObtenerListaDeseos();
            foreach (var producto in productos) { 
            
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
