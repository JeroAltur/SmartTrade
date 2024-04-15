namespace SmartTrade.Services
{
    internal interface BD
    {
        public void Insertar<T>(T entity) where T : class;
        public void Borrar<T>(T entity) where T : class;
        public void Limpiar<T>() where T : class;
        public List<T> Todo<T>() where T : new();
        public void Crear<T>() where T : class;
        public List<T> TodoOrdenado<T, U>(string orderByColumn) where T : new();
        public void BorrarTodo();

    }
}
