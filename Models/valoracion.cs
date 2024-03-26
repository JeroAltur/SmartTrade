using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Valoracion
    {
        public List<double> valoraciones { get; set; }
        public double valor { get; set; }
        public Producto p {  get; set; }

        public Valoracion() 
        {
            this.valor = 0;
        }


        public void valoracionNueva(int v)
        {
            this.valoraciones.Add(v);
        }

        public void valoracionProducto(List<double> valoraciones)
        {

        }

    }
}
