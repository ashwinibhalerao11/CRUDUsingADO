using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class BooksController : Controller
    {
        private readonly IConfiguration _configuration;
        private BooksCRUD db;
        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
            db = new BooksCRUD(_configuration);
        }

        // GET: BooksController
        public ActionResult Index()
        {

            var list = db.GetBooks();
            return View(list);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            var bk=db.GetBookById(id);
            return View(bk);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books book)
        {
            try
            {
                int result = db.AddBook(book);
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

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            var bk = db.GetBookById(id);
            return View(bk);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Books book)
        {
            try
            {
              int result=db.EditBook(book);
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

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            var bk = db.GetBookById(id);
            return View(bk);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletefrom(int id)
        {
            try
            {
                int result=db.DeleteBook(id);
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
