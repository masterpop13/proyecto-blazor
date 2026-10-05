using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre y apellido")]
        [StringLength(100)]
        public string NombreApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese un correo electrónico")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese un teléfono")]
        [RegularExpression(@"^[0-9]{8,15}$",
            ErrorMessage = "Solo números, entre 8 y 15 dígitos")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione un producto de interés")]
        [StringLength(50)]
        public string ProductoInteres { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;
    }
}