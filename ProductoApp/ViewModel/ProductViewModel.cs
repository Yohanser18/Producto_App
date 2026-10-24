using ProductoApp.Models;

namespace ProductoApp.ViewModel
{
    public class ProductViewModel
    {
        // Aqui estamos pasando una lista de productos desde el modelos a la viewmodel//
        public List<Product> Products { get; set; } = new List<Product>();
        //este es la propiedad que vamos a usa para hacer la busqueda//
        public string SearchText { get; set; } = string.Empty;
    }
}
