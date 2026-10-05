using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreApellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Rol { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}