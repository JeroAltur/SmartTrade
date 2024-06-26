﻿using Microsoft.Maui.ApplicationModel;
using SmartTrade.Services;
using SQLite;
using System;

namespace SmartTrade.Models
{
    internal class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string imagenes { get; set; }
        public double HuellaAmbiental { get; set; }
        public string fichaTecnica { get; set; }
        //public Valoracion valoracion { get; set; }
        public double valor {  get; set; }

        public int ventas { get; set; }

        public Producto()
        {
            imagenes = "";
            HuellaAmbiental = 0;
            Random rnd = new Random();
            valor = rnd.Next(0, 5);
            ventas = rnd.Next(0, 9999);
        }

        public Producto(string nombre, string descripcion, double precio, string imagenes, double huellaAmbiental, string fichaTecnica) : this()
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.imagenes = imagenes;
            this.HuellaAmbiental = huellaAmbiental;
            this.fichaTecnica = fichaTecnica;
        }

        public void venta(ServicioBD servicio)
        {
            this.ventas++;
            servicio.Actualizar(this);
        }

        /*public void ValoracionNueva(double v, ServicioBD servicio)
        {
            valoracion.valoracionNueva(v, servicio);
            valor = valoracion.valor;
            servicio.Actualizar(this);
        }*/

    }

}
