using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services
{
    public class ClienteService
    {
        private readonly IDbContextFactory<NegocioContext> _contextFactory;

        public ClienteService(IDbContextFactory<NegocioContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Obtener todos los clientes
        public async Task<List<Cliente>> ObtenerClientes()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Clientes
                .OrderBy(c => c.NombreApellido)
                .ToListAsync();
        }

        // Obtener un cliente por Id
        public async Task<Cliente?> ObtenerClientePorId(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        // Agregar un cliente
        public async Task AgregarCliente(Cliente cliente)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Clientes.Add(cliente);

            await context.SaveChangesAsync();
        }

        // Modificar un cliente
        public async Task ModificarCliente(Cliente cliente)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Clientes.Update(cliente);

            await context.SaveChangesAsync();
        }

        // Eliminar un cliente
        public async Task EliminarCliente(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var cliente = await context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
            }
        }
    }
}