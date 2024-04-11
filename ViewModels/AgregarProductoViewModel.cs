
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
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;


namespace SmartTrade.ViewModels
{
    internal partial class AgregarProductoViewModel
    {
        private readonly SmartTradeServices _dataService;

        private String _nombre;
        private String _descripcion;
        private Double _precio;
        private String _ficha;
        private String _tipo;
        private List<String> _certificado;
        private List<String> _imagen;

        public AgregarProductoViewModel(SmartTradeServices servicio)
        {
            _dataService = servicio;
        }



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

        [RelayCommand]
        public async Task SeleccionarYSubirFicha()
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona la ficha técnica",
                // Ajusta los tipos de archivos según tus necesidades
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.item" } },
                    { DevicePlatform.Android, new[] { "*/*" } },
                })
            });

            if (resultado != null)
            {
                using var stream = await resultado.OpenReadAsync();
                Ficha = resultado.FileName; // Aquí puedes manejar el archivo como necesites
            }
        }

        [RelayCommand]
        public async Task SeleccionarYSubirCertificados()
        {
            var resultados = await FilePicker.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Selecciona los certificados",
                // Ajusta los tipos de archivos según tus necesidades
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.item" } },
                    { DevicePlatform.Android, new[] { "*/*" } },
                })
            });

            Certificado = new List<string>();
            foreach (var resultado in resultados)
            {
                using var stream = await resultado.OpenReadAsync();
                Certificado.Add(resultado.FileName); // Aquí puedes manejar el archivo como necesites
            }
        }

        [RelayCommand]
        public async Task SeleccionarYSubirImagen()
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.image" } },
                    { DevicePlatform.Android, new[] { "image/*" } },
                })
            });

            if (resultado != null)
            {
                using var stream = await resultado.OpenReadAsync();
                Imagen = new List<string> { resultado.FileName }; // Aquí puedes manejar el archivo como necesites
            }
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
