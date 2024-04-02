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

        public Valoracion(Producto p)
        {
            this.p = p;
            p.valoracion(this);
        }


        public void valoracionNueva(int v)
        {
            this.valoraciones.Add(v);
            valoracionProducto(valoraciones);
        }

        public void valoracionProducto(List<double> valoraciones)
        {
            double valorProvisional = 0, contador = 0;
            foreach (var v in valoraciones)
            {
                valorProvisional += v;
                contador++;
            }

            valorProvisional = valorProvisional / contador;

            this.valor = valorProvisional;
        }

    }
}
