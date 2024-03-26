using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Producto
    {
        public string nombre {  get; set; }
        public string descripcion {  get; set; }
        public double precio {  get; set; }

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
