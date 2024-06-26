﻿using SmartTrade.Services;
using SQLite;

namespace SmartTrade.Models
{
    internal class Valoracion
    {
        [PrimaryKey, AutoIncrement]
        public int idValoracion { get; private set; }
        public double valoraciones { get; set; }
        public double total { get; set; }
        public double valor { get; set; }
        public int id_prod { get; set; }

        public Valoracion()
        {
            this.valor = 0;
            this.valoraciones = 0;
            this.total = 0;
            this.id_prod = 0;
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
            servicio.Actualizar(this);

        }


    }
}
