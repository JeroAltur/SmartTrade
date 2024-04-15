using SmartTrade.Models;

namespace SmartTrade.Services
{
    internal class SmartTradeServices : ISmartTradeServices
    {
        private readonly ServicioBD bd;

        public SmartTradeServices(ServicioBD servicio)
        {
            this.bd = servicio;
        }

        public List<Producto> Tendencias()
        {
            List<Comida> comida = bd.TodoOrdenado<Comida, int>("ventas").Take(10).ToList();
            List<Electronica> electronica = bd.TodoOrdenado<Electronica, int>("ventas").Take(10).ToList();
            List<Ropa> ropa = bd.TodoOrdenado<Ropa, int>("ventas").Take(10).ToList();
            List<Producto> result = new List<Producto>();

            foreach (Comida p in comida)
            {
                result.Add(p);
            }
            foreach (Electronica p in electronica)
            {
                result.Add(p);
            }
            foreach (Ropa p in ropa)
            {
                result.Add(p);
            }

            result = result.OrderBy(p => p.ventas).Take(10).ToList();

            return result;
        }

        public List<Producto> ObtenerListaDeseos()
        {
            List<Producto> ProductosDeseados = new List<Producto>();
            List<ListaDeseos> listasDeseos = bd.Todo<ListaDeseos>();
            List<Producto> lista = listasDeseos[0].prod;

            foreach (Producto p in lista)
            {
                ProductosDeseados.Add(p);
            }

            return ProductosDeseados;
        }

        public Producto ProductoPorId(int id)
        {
            Producto producto = new Producto();
            producto = bd.BuscarPorID<Producto>(id);
            return producto;
        }

        public List<Producto> MejorValorado()
        {
            List<Comida> comida = bd.TodoOrdenado<Comida, double>("valor").Take(10).ToList();
            List<Electronica> electronica = bd.TodoOrdenado<Electronica, double>("valor").Take(10).ToList();
            List<Ropa> ropa = bd.TodoOrdenado<Ropa, double>("valor").Take(10).ToList();
            List<Producto> result = new List<Producto>();

            foreach (Comida p in comida)
            {
                result.Add(p);
            }
            foreach (Electronica p in electronica)
            {
                result.Add(p);
            }
            foreach (Ropa p in ropa)
            {
                result.Add(p);
            }

            result = result.OrderBy(p => p.valor).Take(10).ToList();
            
            return result;
        }

        public List<Producto> Buscador(String valor)
        {
            List<Comida> comida = bd.Todo<Comida>().ToList();
            List<Electronica> electronica = bd.Todo<Electronica>().ToList();
            List<Ropa> ropa = bd.Todo<Ropa>().ToList();
            List<Producto> resultadoProvicional = new List<Producto>();
            List<Producto> result = new List<Producto>();

            foreach (Comida p in comida)
            {
                resultadoProvicional.Add(p);
            }
            foreach (Electronica p in electronica)
            {
                resultadoProvicional.Add(p);
            }
            foreach (Ropa p in ropa)
            {
                resultadoProvicional.Add(p);
            }

            foreach (Producto p in resultadoProvicional)
            {
                if (p.nombre.Contains(valor) || p.descripcion.Contains(valor))
                {
                    result.Add(p);
                }
            }

            return result;
        }




        public void AgregarProducto(string name, string description, double price, string imagenes, double huella, string ficha, string tipo)
        {
            Producto p = new Producto(name, description, price, imagenes, huella, ficha);
            FabricaProducto fabricaProducto = new FabricaProducto(bd);
            fabricaProducto.crearProducto(tipo, p);
        }

        public void AgregarProductoDirecto(Producto p, string tipo)
        {
            Producto product = new Producto();
            FabricaProducto fabricaProducto = new FabricaProducto(bd);
            fabricaProducto.crearProducto(tipo, p);
        }

        public void AñadirListaDeseos(ListaDeseos ld, Producto p)
        {
            ld.añadirProducto(p, bd);
        }

        public void EliminarListaDeseos(ListaDeseos ld, Producto p)
        {
            ld.eliminarProducto(p, bd);
        }

        public void IniciarBD()
        {
            bd.BorrarTodo();

            Producto p1 = new Producto("teclado", "teclado con pad numerico", 20, null, 0, null);
            AgregarProductoDirecto(p1, "electronica");
            //p1.ValoracionNueva(5, bd); p1.ValoracionNueva(4, bd);


            Producto p2 = new Producto("Redmi15", "movil xiaomi de ultima generacion ", 300, null, 0, null);
            AgregarProductoDirecto(p2, "electronica");
            //p2.ValoracionNueva(5, bd); p2.ValoracionNueva(4, bd);


            Producto p3 = new Producto("Manzana roja", "Manzana roja cultivada en España", 20, null, 0, null);
            AgregarProductoDirecto(p3, "comida");
            //p3.ValoracionNueva(5, bd); p3.ValoracionNueva(5, bd);


            Producto p4 = new Producto("Sudadera supreme", "sudadera de alta calidad", 20, null, 0, null);
            AgregarProductoDirecto(p4, "ropa");
            //p4.ValoracionNueva(3, bd); p4.ValoracionNueva(4, bd);


            Producto p5 = new Producto("Redmi15Pro", "Redmi15 con mejoras en el rendimiento y almacenamiento", 20, null, 0, null);
            AgregarProductoDirecto(p5, "electronica");
            //p5.ValoracionNueva(5, bd); p5.ValoracionNueva(5, bd);


            Producto p6 = new Producto("Redmi14", "movil xiaomi de alta calidad", 275, null, 0, null);
            AgregarProductoDirecto(p6, "electronica");
            //p6.ValoracionNueva(4, bd); p6.ValoracionNueva(4, bd);


            Producto p7 = new Producto("Redmi13", "movil xiaomi de alta calidad", 250, null, 0, null);
            AgregarProductoDirecto(p7, "electronica");
            //p7.ValoracionNueva(4, bd); p7.ValoracionNueva(4, bd);


            Producto p8 = new Producto("Redmi12", "movil xiaomi de alta calidad", 225, null, 0, null);
            AgregarProductoDirecto(p8, "electronica");
            //p8.ValoracionNueva(4, bd); p8.ValoracionNueva(4, bd);


            Producto p9 = new Producto("Redmi11", "movil xiaomi de alta calidad", 200, null, 0, null);
            AgregarProductoDirecto(p9, "electronica");
            //p9.ValoracionNueva(4, bd); p9.ValoracionNueva(3, bd);


            Producto p10 = new Producto("Redmi10", "movil xiaomi de alta calidad", 150, null, 0, null);
            AgregarProductoDirecto(p10, "electronica");
            //p10.ValoracionNueva(3, bd); p10.ValoracionNueva(3, bd);


            Producto p11 = new Producto("Redmi9", "movil xiaomi de alta calidad", 100, null, 0, null);
            AgregarProductoDirecto(p11, "electronica");
            //p11.ValoracionNueva(3, bd); p11.ValoracionNueva(2, bd);


            Producto p12 = new Producto("Iphone15", "Movil Iphone con cargador incluido", 999.99, null, 0, null);
            AgregarProductoDirecto(p12, "electronica");
            //p12.ValoracionNueva(5, bd); p12.ValoracionNueva(4, bd);

        }
    }
}
