using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private ProductsCRUD db;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
            db = new ProductsCRUD(_configuration);
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var list = db.GetProducts();
            return View(list);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            try
            {
                int result = db.AddProduct(product);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);

        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products product)
        {
            try
            {
                int result = db.EditProduct(product);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);

        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletefrom(int id)
        {
            try
            {
                int result = db.DeleteProduct(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }
    }
}
