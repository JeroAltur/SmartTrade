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
            List<Comida> comida = bd.GetAllOrdered<Comida, int>("ventas").Take(10).ToList();
            List<Electronica> electronica = bd.GetAllOrdered<Electronica, int>("ventas").Take(10).ToList();
            List<Ropa> ropa = bd.GetAllOrdered<Ropa, int>("ventas").Take(10).ToList();
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

        public List<Producto> MejorValorado()
        {
            List<Comida> comida = bd.GetAllOrdered<Comida, double>("valor").Take(10).ToList();
            List<Electronica> electronica = bd.GetAllOrdered<Electronica, double>("valor").Take(10).ToList();
            List<Ropa> ropa = bd.GetAllOrdered<Ropa, double>("valor").Take(10).ToList();
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

        public void AgregarProducto(string name, string dscription, double price, List<string> imagenes, List<string> certificados, string ficha, string tipo)
        {
            Producto p = new Producto(name, dscription,price, imagenes, certificados, ficha);
            FabricaProducto fabricaProducto = new FabricaProducto();
            p = fabricaProducto.crearProducto(tipo, p);
            bd.Insert(p);
        }

        public void IniciarBD()
        {
            bd.RemoveAllData();
            AgregarProducto("teclado", "teclado con pad numerico", 20, null, null, null, "electronica");
            AgregarProducto("Redmi15", "movil xiaomi de ultima generacion ", 300, null, null, null, "electronica");
            AgregarProducto("Manzana roja", "Manzana roja cultivada en España", 20, null, null, null, "comida");
            AgregarProducto("Sudadera supreme", "sudadera de alta calidad", 20, null, null, null, "ropa");
            AgregarProducto("Redmi15Pro", "Redmi15 con mejoras en el rendimiento y almacenamiento", 20, null, null, null, "electronica");
            AgregarProducto("Redmi14", "movil xiaomi de alta calidad", 300, null, null, null, "electronica");
            AgregarProducto("Redmi13", "movil xiaomi de alta calidad", 300, null, null, null, "electronica");
            AgregarProducto("Redmi12", "movil xiaomi de alta calidad", 300, null, null, null, "electronica");
        }
    }
}
