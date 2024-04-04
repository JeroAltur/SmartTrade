using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Models
{
    internal class Producto
    {
        public string nombre {  get; set; }
        public string descripcion {  get; set; }
        public double precio {  get; set; }
        public List<string> imagenes { get; set; }
        public List<string> certificadosMedioambientales { get; set; }
        public string fichaTecnica {  get; set; }
        public Valoracion valor {  get; set; }

        public int ventas {  get; set; }

        public Producto() 
        {
            imagenes = new List<string>();
            certificadosMedioambientales = new List<string>();
            valor = new Valoracion(this);
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

        public void venta()
        {
            this.ventas++;
        }

        public void valoracion(Valoracion v) 
        {
            this.valor = v;
        }

    }
    
}
