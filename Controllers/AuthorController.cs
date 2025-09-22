using EF_CORE_EMPTY_CONTROLLER.Models;
using EF_CORE_EMPTY_CONTROLLER.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_EMPTY_CONTROLLER.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorRepository _repo;

        public AuthorController(AuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Author> listAuthors = await _repo.GetAll();
            return View(listAuthors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _repo.GetById(id);
            if (author == null)
                throw new KeyNotFoundException("AuthorId not found");

            return View(author);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author newauth)
        {
            await _repo.Add(newauth);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _repo.GetById(id);
            if (author == null)
                throw new KeyNotFoundException("AuthorId not found");

            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Author newauth)
        {
            await _repo.Update(id, newauth);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _repo.GetById(id);
            if (author == null)
                throw new KeyNotFoundException("AuthorId not found");

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteById(id);
            return RedirectToAction("Index");
        }
    }



}

