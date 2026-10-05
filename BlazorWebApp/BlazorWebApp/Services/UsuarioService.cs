using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services
{
    public class UsuarioService
    {
        private readonly IDbContextFactory<NegocioContext> _contextFactory;

        public UsuarioService(IDbContextFactory<NegocioContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Usuario?> ValidarLogin(string email, string password)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Email == email &&
                    u.Password == password &&
                    u.Activo);
        }

        public async Task<bool> ExisteEmail(string email)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Usuarios
                .AnyAsync(u => u.Email == email);
        }

        public async Task RegistrarUsuarioCliente(Usuario usuario)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Usuarios.Add(usuario);

            await context.SaveChangesAsync();
        }
    }
}