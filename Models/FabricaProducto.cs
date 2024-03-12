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
        public Producto crearProducto(string tipo) {
            Producto nuevoProducto = null;
            if (tipo == "ropa")
            {
                nuevoProducto = new Ropa();
            }
            else if (tipo == "comida")
            {
                nuevoProducto = new Comida();
            }
            else if (tipo == "electronica") { 
                nuevoProducto = new Electronica();
            }
            return nuevoProducto;
        }
    }
}
