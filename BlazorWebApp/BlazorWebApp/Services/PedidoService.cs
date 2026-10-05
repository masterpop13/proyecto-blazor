using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services;

public class PedidoService
{
    private readonly IDbContextFactory<NegocioContext> _contextFactory;

    public PedidoService(IDbContextFactory<NegocioContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    // 1. Método para procesar la compra (Checkout)
    public async Task<int> CrearPedidoAsync(int clienteId, List<DetallePedido> itemsCarrito)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var pedido = new Pedido
            {
                ClienteId = clienteId,
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                Total = itemsCarrito.Sum(i => i.PrecioUnitario * i.Cantidad)
            };

            foreach (var item in itemsCarrito)
            {
                var producto = await context.Productos.FindAsync(item.ProductoId);
                if (producto == null || producto.Stock < item.Cantidad)
                {
                    throw new InvalidOperationException($"Stock insuficiente para el producto ID: {item.ProductoId}");
                }

                producto.Stock -= item.Cantidad;

                pedido.Detalles.Add(new DetallePedido
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario
                });
            }

            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return pedido.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    // 2. Método para ver el detalle de UN pedido (PedidoExitoso)
    public async Task<Pedido?> ObtenerPedidoPorIdAsync(int pedidoId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Pedidos
            .Include(p => p.Detalles)
            .FirstOrDefaultAsync(p => p.Id == pedidoId);
    }

    // 3. EL MÉTODO QUE FALTABA: Para listar el historial (MisPedidos)
    public async Task<List<Pedido>> ObtenerPedidosPorClienteAsync(int clienteId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Pedidos
            .Include(p => p.Detalles)
            .Where(p => p.ClienteId == clienteId)
            .OrderByDescending(p => p.Fecha)
            .ToListAsync();
    }
    // 4. Método para el Administrador: Ver TODOS los pedidos del sistema
    public async Task<List<Pedido>> ObtenerTodosLosPedidosAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Pedidos
            .Include(p => p.Detalles)
            .OrderByDescending(p => p.Fecha)
            .ToListAsync();
    }

    // 5. Método para el Administrador: Cambiar el estado de un pedido
    public async Task ActualizarEstadoPedidoAsync(int pedidoId, string nuevoEstado)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var pedido = await context.Pedidos.FindAsync(pedidoId);
        if (pedido != null)
        {
            pedido.Estado = nuevoEstado;
            await context.SaveChangesAsync();
        }
    }
}