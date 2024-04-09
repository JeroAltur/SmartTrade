using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SmartTrade.Services;

namespace SmartTrade.Models
{
    internal class FabricaProducto
    {
        private readonly ServicioBD bd;
        public FabricaProducto(ServicioBD servicio)
        {
            bd = servicio;
        }
        public void crearProducto(string tipo, Producto p) {
            
            if (tipo == "ropa")
            {
                Ropa nuevoProducto = null;
                nuevoProducto = new Ropa(p);
                bd.Insertar(nuevoProducto);
            }
            if (tipo == "comida")
            {
                Comida nuevoProducto = null;
                nuevoProducto = new Comida(p);
                bd.Insertar(nuevoProducto);
            }
            if (tipo == "electronica") {
                Electronica nuevoProducto = null;
                nuevoProducto = new Electronica(p);
                bd.Insertar(nuevoProducto);
            }
        }

        public FabricaProducto() { }
    }
}
