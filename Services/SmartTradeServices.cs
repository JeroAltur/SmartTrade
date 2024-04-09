using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrade.Models;
using SmartTrade.Views;

namespace SmartTrade.Services
{
    internal class SmartTradeServices: ISmartTradeServices
    {
        private readonly BD bd;

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

            var todosLosProductos = bd.Todo<Producto>();
            var ProductosDeseados = new List<Producto>();

            return ProductosDeseados;
        
        
        
        }

        public List<Producto> ObtenerTendencias()
        {
            
            return bd.TodoOrdenado<Producto, int>("ventas").Take(10).ToList();
        }

        public List<Producto> ObtenerMejorValorados()
        {
            return bd.TodoOrdenado<Producto, double>("valor").Take(10).ToList();
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

            foreach(Producto p in resultadoProvicional)
            {
                if(p.nombre.Contains(valor) || p.descripcion.Contains(valor))
                { 
                    result.Add(p);
                }
            }

            return result;
        }

      




        public void AgregarProducto(string name, string description, double price, List<string> imagenes, List<string> certificados, string ficha, string tipo)
        {
            Producto p = new Producto(name, description,price, imagenes, certificados, ficha);
            FabricaProducto fabricaProducto = new FabricaProducto();
            p = fabricaProducto.crearProducto(tipo, p);
            bd.Insertar(p);
        }

        public void AgregarProductoDirecto(Producto p, string tipo)
        {
            Producto product = new Producto();
            FabricaProducto fabricaProducto = new FabricaProducto();
            p = fabricaProducto.crearProducto(tipo, p);
            bd.Insertar(p.valoraciones);
            bd.Insertar(p);
        }

        public void AñadirListaDeseos(ListaDeseos ld, Producto p)
        {
            ld.añadirProducto(p);
        }

        public void EliminarListaDeseos(ListaDeseos ld, Producto p)
        {
            ld.eliminarProducto(p);
        }

        public void IniciarBD()
        {
            bd.BorrarTodo();

            Producto p1 = new Producto("teclado", "teclado con pad numerico", 20, null, null, null);
            p1.ValoracionNueva(5); p1.ValoracionNueva(4);
            AgregarProductoDirecto(p1, "electronica");

            Producto p2 = new Producto("Redmi15", "movil xiaomi de ultima generacion ", 300, null, null, null);
            p2.ValoracionNueva(5); p2.ValoracionNueva(4);
            AgregarProductoDirecto(p2, "electronica");

            Producto p3 = new Producto("Manzana roja", "Manzana roja cultivada en España", 20, null, null, null);
            p3.ValoracionNueva(5); p3.ValoracionNueva(5);
            AgregarProductoDirecto(p3, "comida");

            Producto p4 = new Producto("Sudadera supreme", "sudadera de alta calidad", 20, null, null, null);
            p4.ValoracionNueva(3); p4.ValoracionNueva(4);
            AgregarProductoDirecto(p4, "ropa");

            Producto p5 = new Producto("Redmi15Pro", "Redmi15 con mejoras en el rendimiento y almacenamiento", 20, null, null, null);
            p5.ValoracionNueva(5); p5.ValoracionNueva(5);
            AgregarProductoDirecto(p5, "electronica");

            Producto p6 = new Producto("Redmi14", "movil xiaomi de alta calidad", 275, null, null, null);
            p6.ValoracionNueva(4); p6.ValoracionNueva(4);
            AgregarProductoDirecto(p6, "electronica");

            Producto p7 = new Producto("Redmi13", "movil xiaomi de alta calidad", 250, null, null, null);
            p7.ValoracionNueva(4); p7.ValoracionNueva(4);
            AgregarProductoDirecto(p7, "electronica");

            Producto p8 = new Producto("Redmi12", "movil xiaomi de alta calidad", 225, null, null, null);
            p8.ValoracionNueva(4); p8.ValoracionNueva(4);
            AgregarProductoDirecto(p8, "electronica");

            Producto p9 = new Producto("Redmi11", "movil xiaomi de alta calidad", 200, null, null, null);
            p9.ValoracionNueva(4); p9.ValoracionNueva(3);
            AgregarProductoDirecto(p9, "electronica");

            Producto p10 = new Producto("Redmi10", "movil xiaomi de alta calidad", 150, null, null, null);
            p10.ValoracionNueva(3); p10.ValoracionNueva(3);
            AgregarProductoDirecto(p10, "electronica");

            Producto p11 = new Producto("Redmi9", "movil xiaomi de alta calidad", 100, null, null, null);
            p11.ValoracionNueva(3); p11.ValoracionNueva(2);
            AgregarProductoDirecto(p11, "electronica");

            Producto p12 = new Producto("Iphone15", "Movil Iphone con cargador incluido", 999.99, null, null, null);
            p12.ValoracionNueva(5); p12.ValoracionNueva(4);
            AgregarProductoDirecto(p12, "electronica");
        }
    }
}
