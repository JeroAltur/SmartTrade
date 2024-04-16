using Microsoft.Maui.Storage;
using CommunityToolkit.Mvvm.Input;
using SmartTrade.Models;
using SmartTrade.Services;
using System.ComponentModel;
using System.Windows.Input;


namespace SmartTrade.ViewModels
{
    internal partial class AgregarProductoViewModel
    {
        private readonly SmartTradeServices _dataService;

        private String _nombre;
        private String _descripcion ;
        private Double _precio;
        private String _ficha = null;
        private String _tipo;
        private Double _huellaAmbiental = 0.0;
        private String _imagen = null;

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

        public string Ficha
        {
            get { return _ficha; }
            set
            {
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

        public Double HuellaAmbiental
        {
            get { return _huellaAmbiental; }
            set
            {
                _huellaAmbiental = value;
                OnPropertyChanged(nameof(_huellaAmbiental));

            }


        }



        public String Imagen
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


        [RelayCommand]
        public async Task CrearProducto()
        {
            _dataService.AgregarProducto(_nombre, _descripcion, _precio, _imagen, _huellaAmbiental, _ficha, _tipo);
            LimpiarFormulario();




        }

        // Eto no se usa 
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
                _ficha = resultado.FileName; // Aquí puedes manejar el archivo como necesites
            }
        }


        [RelayCommand]
        public async Task<FileResult> SeleccionarYSubirHuellaAmbiental(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if(result != null)
                {
                    if(result.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }
                return result;
            } catch (Exception ex)
            {

            }

            return null;
            //var resultados = await FilePicker.PickMultipleAsync(new PickOptions
            //{
            //    PickerTitle = "Selecciona los certificados",
            //    // Ajusta los tipos de archivos según tus necesidades
            //    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            //    {
            //        { DevicePlatform.iOS, new[] { "public.item" } },
            //        { DevicePlatform.Android, new[] { "/" } },
            //    })
            //});

           /* HuellaAmbiental = new List<string>();
            foreach (var resultado in resultados)
            {
                using var stream = await resultado.OpenReadAsync();
                HuellaAmbiental.Add(resultado.FileName); // Aquí puedes manejar el archivo como necesites
            }*/
        }

        [RelayCommand]
        public async Task<FileResult> SeleccionarYSubirImagen(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
            //var resultado = await FilePicker.PickAsync(new PickOptions
            //{
            //    PickerTitle = "Selecciona una imagen",
            //    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            //    {
            //        { DevicePlatform.iOS, new[] { "public.image" } },
            //        { DevicePlatform.Android, new[] { "image/*" } },
            //    })
            //});

            /*  if (resultado != null)
              {
                  using var stream = await resultado.OpenReadAsync();
                  Imagen = new List<string> { resultado.FileName }; // Aquí puedes manejar el archivo como necesites
              }*/
        }





        private void LimpiarFormulario()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0.0;
            Ficha = string.Empty;
            Tipo = string.Empty;
            HuellaAmbiental = 0;
            Imagen = null;

        }

      



    }
}
