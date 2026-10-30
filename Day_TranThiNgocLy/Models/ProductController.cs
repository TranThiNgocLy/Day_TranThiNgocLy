using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_TranThiNgocLy.Models
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0m, Description = "Description 1", CategoryId = 1 },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m, Description = "Description 2", CategoryId = 2 },
            new Product { Id = 3, Name = "Product 3", Price = 30.0m, Description = "Description 3", CategoryId = 3 }
        };
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                int newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            // If the model state is invalid, return the view with the product to display validation errors
            return View(product);


        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Product product)
        {
            var exsitingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (exsitingProduct != null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                exsitingProduct.Name = product.Name;
                exsitingProduct.Price = product.Price;
                exsitingProduct.Description = product.Description;
                exsitingProduct.CategoryId = product.CategoryId;
                return RedirectToAction(nameof(Index));
            }

            return View(product);


        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();


            }
            _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
