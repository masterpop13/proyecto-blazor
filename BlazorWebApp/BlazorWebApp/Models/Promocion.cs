using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebApp.Models
{
    public class Promocion
    {
        public int PromocionId { get; set; }

        [Required(ErrorMessage = "Ingrese el título de la promoción")]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una descripción")]
        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una imagen")]
        public string Imagen { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public int PorcentajeDescuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioPromocional { get; set; }

        public bool Activo { get; set; } = true;

        public int Orden { get; set; } = 1;
    }
}