namespace SmartTrade.Models
{
    internal class Comida : Producto
    {
        public Comida() { }

        public Comida(Producto p)
        {
            this.idProducto = p.idProducto;
            this.nombre = p.nombre;
            this.descripcion = p.descripcion;
            this.precio = p.precio;
            this.imagenes = p.imagenes;
            this.certificadosMedioambientales = p.certificadosMedioambientales;
            this.fichaTecnica = p.fichaTecnica;
            this.id_valoracion = p.id_valoracion;
            this.valor = p.valor;
            this.ventas = p.ventas;
        }
    }
}
