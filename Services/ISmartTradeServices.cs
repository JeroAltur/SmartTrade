using SmartTrade.Models;

namespace SmartTrade.Services
{
    internal interface ISmartTradeServices
    {
        public List<Producto> Tendencias();
        public List<Producto> MejorValorado();
        public void AgregarProducto(string name, string description, double price, string imagenes, double huella, string ficha, string tipo);
        public void IniciarBD();
        public List<Producto> ObtenerListaDeseos();
        public List<Producto> Buscador(String valor);
        public void AñadirListaDeseos(ListaDeseos ld, Producto p);
        public void EliminarListaDeseos(ListaDeseos ld, Producto p);
    }
}
