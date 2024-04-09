using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Valoracion
    {
        public double valoraciones { get; set; }
        public double total { get; set; }   
        public double valor { get; set; }
        public Producto p {  get; set; }

        public Valoracion() 
        {
            this.valor = 0;
            this.valoraciones = 0;
        }

        public Valoracion(Producto p) : this()
        {
            this.p = p;
        }


        public void valoracionNueva(double v)
        {
            this.valoraciones++;
            this.total += v;
            this.valor = this.total / this.valoraciones;
        }

    }
}
