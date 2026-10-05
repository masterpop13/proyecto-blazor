using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services
{
    public class CategoriaService
    {
        private readonly IDbContextFactory<NegocioContext> _contextFactory;

        public CategoriaService(IDbContextFactory<NegocioContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Categorias
                .OrderBy(c => c.Nombre)
                .ToListAsync();
        }
    }
}