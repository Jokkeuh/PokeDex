using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        private IPokemonDB sQLPokemonDB;
        public UserController(IPokemonDB sQLPokemonDB)
        {
            this.sQLPokemonDB= sQLPokemonDB;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User currentUser)
        {
            bool succes = this.sQLPokemonDB.AddUser(currentUser);
            if (succes)
            {
                return RedirectToAction("Index", "Login");
            }

            return View("index");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
        [HttpPost]
        
        public async Task<ActionResult> AddPokemonOnUser(string username, string pokeInt)
        {
            await sQLPokemonDB.AddPokemonToUser(username, pokeInt);
            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> RemovePokemonFromUser(string username, string pokeInt)
        {
            await sQLPokemonDB.RemovePokemonFromUser(username, pokeInt);
            return RedirectToAction($"GetPokemonList", "Login", new {username});
        }
    }
}
