using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;
using ProductoApp.Data;
using ProductoApp.Models;
using ProductoApp.ViewModel;

namespace ProductoApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ProductIndex(string searchText)
        {
            var products = _context.Products.Include(c => c.Categories).Include(p => p.Proveeder).ToList();
            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(p => p.Nombre.Contains(searchText)).ToList();
            }

            var productViewModel = new ProductViewModel();
            productViewModel.Products = products;
            productViewModel.SearchText = searchText;

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct([Bind("Id,Nombre,Descripcion,Precio,CategoryId,ProveederId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductIndex));
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();
            return View(product);
        }

        [HttpGet]

        public IActionResult EditProducto(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(Id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProducto(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductIndex));
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductDB = _context.Products.
                Include(c => c.Categories).
                Include(p => p.Proveeder).
                FirstOrDefault(pl => pl.Id == id);

            if (ProductDB == null)
            {
                return NoContent();
            }
            return View(ProductDB);
        }
        [HttpGet]
        public IActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Find(Id);

            if (product == null) 
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product) 
        {
            if (product == null) 
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Proveeder = _context.Proveeders.ToList();
            return RedirectToAction(nameof(ProductIndex));
        }
    }
}
