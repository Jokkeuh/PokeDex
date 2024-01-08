using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Pokedex.Services;
using Pokedex.util;

namespace Pokedex.Controllers
{
    public class LoginController : Controller
    {
        private IPokemonDB SQLPokemonDB;
        private PokeClient pokeclient;
        public LoginController(IPokemonDB sQLPokemonDB, PokeClient pokeclient)
        {
            SQLPokemonDB = sQLPokemonDB;
            this.pokeclient = pokeclient;
        }

        public IActionResult Index()
        {
            //var user1 = SQLPokemonDB.GetUser(1);
            return View(/*user1*/);
        }

        public IActionResult LoginUser(string username, string UserPassword)
        {

            //NEEDS AUTH!!!
            var user = SQLPokemonDB.GetUserByName(username);
            if (user != null)
            {
                var pw = user.UserPassword;
                if (pw != UserPassword)
                {
                    HttpContext.Session.SetString("IsLoggedIn", "false");
                    ViewBag.ErrorMessage = "password does not match username.";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("IsLoggedIn", "true");
                    HttpContext.Session.SetString("username", user.UserName.ToString());

                    return View(user);
                }
            }
            HttpContext.Session.SetString("IsLoggedIn", "false");
            return View();
        }

        public IActionResult Logout() 
        {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("IsLoggedIn", "false");
               return RedirectToAction("Index");
        }


        public IActionResult GetPokemonList(string username)
        {

            var pokemonList = SQLPokemonDB.GetPokemonForUser(username);
            
            if(pokemonList != null && pokemonList.Status != TaskStatus.Faulted)
            {
                return View(pokemonList);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
