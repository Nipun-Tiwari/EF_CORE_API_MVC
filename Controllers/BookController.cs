using EF_CORE_EMPTY_CONTROLLER.Models;
using EF_CORE_EMPTY_CONTROLLER.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_EMPTY_CONTROLLER.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repo;
        private readonly AuthorRepository _authRepo;

        public BookController(BookRepository repo, AuthorRepository authrepo)
        {
            _repo = repo;
            _authRepo = authrepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> listBooks = await _repo.GetAll();
            return View(listBooks);
        }

        //Details
        [HttpGet("Books/Details/{BookId}")]
        public async Task<IActionResult> Details(int BookId)
        {
            var book = await _repo.GetById(BookId);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        //create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var author = await _authRepo.GetAll();
            ViewBag.AuthId = new SelectList(author,"AuthId", "AuthName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Book newBook)
        {
            var author = await _authRepo.GetAll();
            ViewData["AuthId"] = new SelectList(author, "AuthId", "AuthName", newBook.AuthId);
            await _repo.Add(newBook);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            var author = await _authRepo.GetAll();

            
            ViewBag.AuthId = new SelectList(author, "AuthId", "AuthName", book.AuthId);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Book updatedBook)
        {
            await _repo.Update(id, updatedBook);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
