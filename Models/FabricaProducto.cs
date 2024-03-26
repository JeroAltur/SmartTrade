using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class FabricaProducto
    {
        public Producto crearProducto(string tipo, Producto p) {
            Producto nuevoProducto = null;
            if (tipo == "ropa")
            {
                nuevoProducto = new Ropa(p);
            }
            else if (tipo == "comida")
            {
                nuevoProducto = new Comida(p);
            }
            else if (tipo == "electronica") { 
                nuevoProducto = new Electronica(p);
            }
            return nuevoProducto;
        }

        public FabricaProducto() { }
    }
}
