using System.ComponentModel.DataAnnotations.Schema;

namespace ProductoApp.Models
{
    public class Product
    {
        public  int Id { get; set; }
        public  string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoryId { get; set; }
        public int ProveederId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories? Categories { get; set; }

        [ForeignKey("ProveederId")]
        public Proveeder? Proveeder { get; set; }
    }
}
