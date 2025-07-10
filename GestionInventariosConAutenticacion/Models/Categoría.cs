namespace GestionInventariosConAutenticacion.Models
{
    public class Categoría
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripción { get; set; } = string.Empty;
        // Relación con Producto
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}

