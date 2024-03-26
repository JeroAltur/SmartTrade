using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Producto
    {
        string nombre;
        string descripcion;
        double precio;

        public Producto()
        {

        }

        public Producto(string name, string dscription,double price)
        {
            this.nombre = name;
            this.descripcion = dscription;
            this.precio = price;
        }
    }
    
}
