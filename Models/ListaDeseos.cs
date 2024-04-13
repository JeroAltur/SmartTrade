using SmartTrade.Services;

namespace SmartTrade.Models
{
    internal class ListaDeseos
    {
        public int idDeseos {  get; set; }
        public List<int> id_prod { get; set; }
        public ListaDeseos()
        {
            id_prod = new List<int>();
        }

        public ListaDeseos(List<int> lista)
        {
            id_prod = lista;
        }

        public void añadirProducto(int p, ServicioBD servicio)
        {
            id_prod.Add(p);
            servicio.Actualizar<ListaDeseos>(this, "idDeseos");

        }

        public void eliminarProducto(int p, ServicioBD servicio)
        {
            id_prod.Remove(p);
            servicio.Actualizar<ListaDeseos>(this, "idDeseos");
        }
    }
}
