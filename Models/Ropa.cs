﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Ropa : Producto
    {

        public Ropa() { }
        public Ropa(Producto p) 
        {
            this.nombre = p.nombre;
            this.descripcion = p.descripcion;
            this.precio = p.precio;
            this.imagenes = p.imagenes;
            this.certificados = p.certificados;
            this.ficha = p.ficha;
        }
    }
}
