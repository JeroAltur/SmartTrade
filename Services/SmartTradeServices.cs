﻿using SmartTrade.Models;
using System.Resources;

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
            List<Comida> comida = bd.TodoOrdenado<Comida, int>("ventas").Take(8).ToList();
            List<Electronica> electronica = bd.TodoOrdenado<Electronica, int>("ventas").Take(8).ToList();
            List<Ropa> ropa = bd.TodoOrdenado<Ropa, int>("ventas").Take(8).ToList();
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

            result = result.OrderBy(p => p.ventas).Take(8).ToList();

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
            List<Comida> comida = bd.Todo<Comida>().ToList();
            List<Electronica> electronica = bd.Todo<Electronica>().ToList();
            List<Ropa> ropa = bd.Todo<Ropa>().ToList();
            List<Producto> resultadoProvicional = new List<Producto>();

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


           resultadoProvicional = resultadoProvicional.OrderByDescending(p => p.valor).ToList();
           List<Producto> result = resultadoProvicional.Take(8).ToList();
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
            if (imagenes == null)
            {
                if (tipo == "electronica") { imagenes = "../Resources/Imgages/electronica.png"; }
                if (tipo == "comida") { imagenes = "../Resources/Imgages/comida.png"; }
                if (tipo == "ropa") { imagenes = "../Resources/Imgages/ropa.png"; }
            }
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

        public List<Producto> CompradosPorIronman()
        {
            List<Producto> resultadoProvicional = new List<Producto>();
            List<Producto> result = new List<Producto>();
            resultadoProvicional = Buscador("Iphone15");
            foreach (Producto p in resultadoProvicional)
            {
                result.Add(p);
            }
            resultadoProvicional = Buscador("Sudadera supreme");
            foreach (Producto p in resultadoProvicional)
            {
                result.Add(p);
            }
            resultadoProvicional = Buscador("teclado");
            foreach (Producto p in resultadoProvicional)
            {
                result.Add(p);
            }
            resultadoProvicional = Buscador("Manzana");
            foreach (Producto p in resultadoProvicional)
            {
                result.Add(p);
            }

            return result;
        }

        public void IniciarBD()
        {
            bd.BorrarTodo();

            Producto p1 = new Producto("teclado", "teclado con pad numerico", 20, "../Resources/Imgages/teclado.png", 0, null);
            AgregarProductoDirecto(p1, "electronica");


            Producto p2 = new Producto("Redmi15", "movil xiaomi de ultima generacion ", 300, "../Resources/Imgages/redmi15.png", 0, null);
            AgregarProductoDirecto(p2, "electronica");


            Producto p3 = new Producto("Manzana roja", "manzana roja cultivada en España", 20, "../Resources/Imgages/manzanaroja.png", 0, null);
            AgregarProductoDirecto(p3, "comida");


            Producto p4 = new Producto("Sudadera supreme", "sudadera de alta calidad", 20, "../Resources/Imgages/sudaderasupreme.png", 0, null);
            AgregarProductoDirecto(p4, "ropa");


            Producto p5 = new Producto("Redmi15Pro", "xiaomi Redmi15 con mejoras en el rendimiento y almacenamiento", 20, "../Resources/Imgages/redmi15.png", 0, null);
            AgregarProductoDirecto(p5, "electronica");


            Producto p6 = new Producto("Redmi14", "movil xiaomi de alta calidad", 275, "../Resources/Imgages/redmi14.png", 0, null);
            AgregarProductoDirecto(p6, "electronica");


            Producto p7 = new Producto("Redmi13", "movil xiaomi de alta calidad", 250, "../Resources/Imgages/redmi13.png", 0, null);
            AgregarProductoDirecto(p7, "electronica");


            Producto p8 = new Producto("Redmi12", "movil xiaomi de alta calidad", 225, "../Resources/Imgages/redmi12.png", 0, null);
            AgregarProductoDirecto(p8, "electronica");


            Producto p9 = new Producto("Redmi11", "movil xiaomi de alta calidad", 200, "../Resources/Imgages/redmi11.png", 0, null);
            AgregarProductoDirecto(p9, "electronica");


            Producto p10 = new Producto("Redmi10", "movil xiaomi de alta calidad", 150, "../Resources/Imgages/redmi11.png", 0, null);
            AgregarProductoDirecto(p10, "electronica");


            Producto p11 = new Producto("Redmia3", "movil xiaomi de alta calidad", 100, "../Resources/Imgages/redmia3.png", 0, null);
            AgregarProductoDirecto(p11, "electronica");


            Producto p12 = new Producto("Iphone15", "Movil iphone con cargador incluido", 999.99, "../Resources/Imgages/iphone.png", 0, null);
            AgregarProductoDirecto(p12, "electronica");

            Producto p13 = new Producto("Gafas de Sol", "Gafas para protejerse les sol", 999.99, "../Resources/Imgages/gafassol.png", 0, null);
            AgregarProductoDirecto(p13, "ropa");

            Producto p14 = new Producto("Disfraz Dinosaurio", "Disfraz de dinosaurio guay", 999.99, "../Resources/Imgages/disfrazdino.png", 0, null);
            AgregarProductoDirecto(p14, "ropa");

            Producto p15 = new Producto("AXE", "Desodorante", 999.99, "../Resources/Imgages/axe.png", 0, null);
            AgregarProductoDirecto(p15, "ropa");

        }
    }
}
