using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services
{
    public class ProductoService
    {
        private readonly IDbContextFactory<NegocioContext> _contextFactory;

        public ProductoService(IDbContextFactory<NegocioContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Obtener todos los productos
        public async Task<List<Producto>> ObtenerProductos()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Productos
                .Include(p => p.Categoria)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        // Obtener un producto por Id
        public async Task<Producto?> ObtenerProductoPorId(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        // Agregar un producto
        public async Task AgregarProducto(Producto producto)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Productos.Add(producto);

            await context.SaveChangesAsync();
        }

        // Modificar un producto
        public async Task ModificarProducto(Producto producto)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Productos.Update(producto);

            await context.SaveChangesAsync();
        }

        // Eliminar un producto
        public async Task EliminarProducto(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var producto = await context.Productos.FindAsync(id);

            if (producto != null)
            {
                context.Productos.Remove(producto);
                await context.SaveChangesAsync();
            }
        }
    }
}