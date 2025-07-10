using System.ComponentModel.DataAnnotations.Schema;

namespace GestionInventariosConAutenticacion.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripción { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        // Relación con Categoría
        public int CategoríaId { get; set; }
        public Categoría? Categoría { get; set; }
    }
}
