
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartTrade.Views;


namespace SmartTrade.ViewModels
{
    internal class AgregarProductoViewModel
    {


        private String _nombreProducto;
        private String _descripcion;
        private Double _precio;
        private String _tipo;
        private List<String> _certificado;
        private List<String> _imagen;

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set
            {
                _nombreProducto = value;
                OnPropertyChanged(nameof(NombreProducto));
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

        public AgregarProductoViewModel()
        {
            // Inicialización del comando
            
        }

        [RelayCommand]
        public async Task CrearProducto()
        {


        }








    }
}
