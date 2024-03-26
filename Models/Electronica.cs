﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Electronica : Producto
    {
        public Electronica() { }
        public Electronica(Producto p) 
        {
            this.nombre = p.nombre;
            this.descripcion = p.descripcion;
            this.precio = p.precio;
        }
    }
}
