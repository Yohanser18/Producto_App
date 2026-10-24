namespace ProductoApp.Models
{
    public class Proveeder
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Product> Products { get; set; }
    }
}
