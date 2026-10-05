using BlazorWebApp.Models;

namespace BlazorWebApp.Services
{
    public class SesionUsuarioService
    {
        public Usuario? UsuarioActual { get; private set; }

        public bool EstaLogueado => UsuarioActual != null;

        public bool EsAdministrador => UsuarioActual?.Rol == "Administrador";

        public bool EsCliente => UsuarioActual?.Rol == "Cliente";

        public event Action? OnChange;

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
            NotificarCambio();
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
            NotificarCambio();
        }

        private void NotificarCambio()
        {
            OnChange?.Invoke();
        }
    }
}