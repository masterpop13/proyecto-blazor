using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services
{
    public class PromocionService
    {
        private readonly IDbContextFactory<NegocioContext> _contextFactory;

        public PromocionService(IDbContextFactory<NegocioContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Promocion>> ObtenerPromociones()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Promociones
                .OrderBy(p => p.Orden)
                .ToListAsync();
        }

        public async Task<List<Promocion>> ObtenerPromocionesActivas()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Promociones
                .Where(p => p.Activo)
                .OrderBy(p => p.Orden)
                .ToListAsync();
        }

        public async Task<Promocion?> ObtenerPromocionPorId(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Promociones
                .FirstOrDefaultAsync(p => p.PromocionId == id);
        }

        public async Task AgregarPromocion(Promocion promocion)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Promociones.Add(promocion);

            await context.SaveChangesAsync();
        }

        public async Task ModificarPromocion(Promocion promocion)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Promociones.Update(promocion);

            await context.SaveChangesAsync();
        }

        public async Task EliminarPromocion(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var promocion = await context.Promociones.FindAsync(id);

            if (promocion != null)
            {
                context.Promociones.Remove(promocion);
                await context.SaveChangesAsync();
            }
        }
    }
}