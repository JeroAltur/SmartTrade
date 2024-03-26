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
        public List<string> imagenes { get; set; }
        public List<string> certificados { get; set; }
        public string ficha {  get; set; }


        public Producto()
        {

        }

        public Producto(string name, string dscription,double price, List<string> imagenes, List<string> certificados, string ficha)
        {
            this.nombre = name;
            this.descripcion = dscription;
            this.precio = price;
            this.imagenes = imagenes;
            this.certificados = certificados;
            this.ficha = ficha;
        }

    }
    
}
