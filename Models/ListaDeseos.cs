using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class ListaDeseos
    {
        public List<Producto> productos { get; set; }
        public ListaDeseos() 
        { 
            productos = new List<Producto>();
        }

        public void añadirProducto(Producto p)
        {
            productos.Add(p);
        }

        public void eliminarProducto(Producto p)
        {
            productos.Remove(p);
        }
    }
}
