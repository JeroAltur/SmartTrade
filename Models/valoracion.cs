using SmartTrade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Valoracion
    {
        private static int contadorId = 1;

        public int idValoracion { get; private set; }
        public double valoraciones { get; set; }
        public double total { get; set; }   
        public double valor { get; set; }
        public int id_prod {  get; set; }

        public Valoracion() 
        {
            this.valor = 0;
            this.valoraciones = 0;
            this.total = 0;

            idValoracion = contadorId++;
        }

        public Valoracion(Producto p) : this()
        {
            this.id_prod = p.idProducto;
        }


        public void valoracionNueva(double v, ServicioBD servicio)
        {
            this.valoraciones++;
            this.total += v;
            this.valor = this.total / this.valoraciones;
            servicio.ActualizarValoracion(this);
        }

    }
}
