﻿using SmartTrade.Services;
using SQLite;

namespace SmartTrade.Models
{
    internal class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public List<string> imagenes { get; set; }
        public List<string> certificadosMedioambientales { get; set; }
        public string fichaTecnica { get; set; }
        public Valoracion valoracion { get; set; }
        public double valor {  get; set; }

        public int ventas { get; set; }

        public Producto()
        {
            imagenes = new List<string>();
            certificadosMedioambientales = new List<string>();
            Valoracion val = new Valoracion(this);
            valor = 0;
            ventas = 0;
        }

        public Producto(string nombre, string descripcion, double precio, List<string> imagenes, List<string> certificadosMedioambientales, string fichaTecnica) : this()
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.imagenes = imagenes;
            this.certificadosMedioambientales = certificadosMedioambientales;
            this.fichaTecnica = fichaTecnica;
        }

        public void venta(ServicioBD servicio)
        {
            this.ventas++;
            servicio.Actualizar(this);
        }

        public void ValoracionNueva(double v, ServicioBD servicio)
        {
            valoracion.valoracionNueva(v, servicio);
            valor = valoracion.valor;
            servicio.Actualizar(this);
        }

    }

}
