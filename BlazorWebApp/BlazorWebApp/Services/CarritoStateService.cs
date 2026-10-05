using BlazorWebApp.Models;

namespace BlazorWebApp.Services
{
    public class CarritoStateService
    {
        private readonly List<Producto> _productos = new();

        public IReadOnlyList<Producto> Productos => _productos;

        public int CantidadProductos => _productos.Count;

        public decimal Total => _productos.Sum(p => p.Precio);

        public event Action? OnChange;

        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
            NotificarCambio();
        }

        public void EliminarProducto(Producto producto)
        {
            _productos.Remove(producto);
            NotificarCambio();
        }

        public void VaciarCarrito()
        {
            _productos.Clear();
            NotificarCambio();
        }

        private void NotificarCambio()
        {
            OnChange?.Invoke();
        }
    }
}