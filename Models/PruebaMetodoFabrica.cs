using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class PruebaMetodoFabrica
    {
        static void Main(string[] args) {
            FabricaProducto fabrica = new FabricaProducto();
            Producto r = fabrica.crearProducto("ropa");
            Console.WriteLine("Se ha creado un nuevo producto ropa");
        }
    }
}
