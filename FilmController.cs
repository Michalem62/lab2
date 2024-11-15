using Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film() {Id = 1, Name = "Film1", Description = "opis1", Price = 4 },
            new Film() {Id = 2, Name = "Film2", Description = "opis2", Price = 5 },
            new Film() {Id = 3, Name = "Film3", Description = "opis3", Price = 6 }
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            films.Add(film);
            film.Id = films.Count + 1;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film findFilm = films.FirstOrDefault(x => x.Id == id);
            findFilm.Name = film.Name;
            findFilm.Description = film.Description;
            findFilm.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            Film deleteFilm = films.FirstOrDefault(x => x.Id == id);
            films.Remove(deleteFilm);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
