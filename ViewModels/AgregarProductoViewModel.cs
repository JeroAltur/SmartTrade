
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SmartTrade.Views;
using SmartTrade.Services;
using SmartTrade.Models;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace SmartTrade.ViewModels
{
    internal partial class AgregarProductoViewModel
    {
        private readonly SmartTradeServices _dataService;
        private readonly FabricaProducto _fabricaProducto;

        private String _nombre;
        private String _descripcion;
        private Double _precio;
        private String _ficha;
        private String _tipo;
        private List<String> _certificado;
        private List<String> _imagen;

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        public string Ficha { 
            get { return _ficha; }
            set { 
               _ficha = value;
                OnPropertyChanged(nameof(Ficha));            
            }

        
        
        }

        public String Tipo
        {
            get { return _tipo; }

            set
            {
                _tipo = value;
                OnPropertyChanged(nameof(Tipo));

            }
        }

        public List<String> Certificado
        {
            get { return _certificado; }
            set
            {
                _certificado = value;
                OnPropertyChanged(nameof(Certificado));

            }


        }



        public List<String> Imagen
        {
            get { return _imagen; }
            set
            {
                _imagen = value;
                OnPropertyChanged(nameof(Imagen));

            }
        }

        // Comando para guardar el producto
        public ICommand GuardarProductoCommand { protected set; get; }

        public AgregarProductoViewModel( SmartTradeServices dataService, FabricaProducto fabricaProducto)
        {
            _dataService = dataService;
           // _fabricaProducto = fabricaProducto;

            
        }

        [RelayCommand]
        public async Task CrearProducto()
        {

            Producto producto = new Producto(Nombre,Descripcion, Precio, Imagen,Certificado,Ficha);
            _dataService.AgregarProducto(Nombre, Descripcion, Precio, Imagen, Certificado, Ficha, Tipo);
            LimpiarFormulario();




        }

        private void LimpiarFormulario()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0.0;
            Ficha = string.Empty;
            Tipo = string.Empty;
            Certificado = null;
            Imagen = null;

        }

        private async Task MostrarMensajeConfirmacion(Producto producto)

        {
            MessagingCenter.Send(this, "ProductoCreado", producto);
        }



    }
}
