using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.ViewModels
{
    public class ClienteRegistroViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre y apellido")]
        [StringLength(100)]
        public string NombreApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese un correo electrónico")]
        [RegularExpression(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            ErrorMessage = "Correo electrónico inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese un teléfono")]
        [RegularExpression(
            @"^[0-9]{8,15}$",
            ErrorMessage = "Ingrese un teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione un producto")]
        public string ProductoInteres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Repita la contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPassword { get; set; } = string.Empty;
    }
}