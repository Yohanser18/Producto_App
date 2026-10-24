namespace ProductoApp.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Product> Products { get; set; }
    }
}
