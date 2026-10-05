using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Producto>? Productos { get; set; }
    }
}