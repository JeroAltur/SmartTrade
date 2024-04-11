using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrade.Services;

namespace SmartTrade.Models
{
    internal class Producto
    {
        private static int contadorId = 1;

        public int idProducto { get; set; }
        public string nombre {  get; set; }
        public string descripcion {  get; set; }
        public double precio {  get; set; }
        public List<string> imagenes { get; set; }
        public List<string> certificadosMedioambientales { get; set; }
        public string fichaTecnica {  get; set; }
        public int id_valoracion {  get; set; }
        public double valor {  get; set; }

        public int ventas {  get; set; }

        public Producto() 
        {
            imagenes = new List<string>();
            certificadosMedioambientales = new List<string>();
            id_valoracion = 99999;
            valor = 0;

            idProducto = contadorId++;
        }

        public Producto(string nombre, string descripcion,double precio, List<string> imagenes, List<string> certificadosMedioambientales, string fichaTecnica): this()
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
            servicio.Actualizar(this, "idProducto");
        }

        public void ValoracionNueva(double v, ServicioBD servicio) 
        {
            if(this.id_valoracion == 99999) { 
                Valoracion val = new Valoracion(this);
                servicio.Insertar(val);
                id_valoracion = val.idValoracion;
            }
            Valoracion valoracion = servicio.BuscarPorIdValoracion<Valoracion>(this.id_valoracion);
            valoracion.valoracionNueva(v, servicio);
            this.valor = valoracion.valor;
            servicio.Actualizar(this, "idProducto");
        }

    }
    
}
