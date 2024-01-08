using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.util;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PokeClient pokeClient;
        List<Pokemon> pokemons;

        public HomeController(ILogger<HomeController> logger, PokeClient client)
        {
            _logger = logger;
            pokeClient = client;
            
        }

        public async Task<IActionResult> Index()
        {
            List<Pokemon> pokemons = await pokeClient.GetNofPokemon(13);
            return View(pokemons);
        }
        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ZoekOpNummer(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Pokemon gevondenPoke = await pokeClient.GetPokemon(id.ToLower());
                if (gevondenPoke != null)
                {
                    List<Pokemon> gevondenPokes = new List<Pokemon>();
                    gevondenPokes.Add(gevondenPoke);

                    return View("ZoekOpNummer", gevondenPokes);
                }
                else
                {
                    return RedirectToAction("ErrorPage");
                }
                
            }
            return RedirectToAction("ErrorPage");
        }
        public async Task<IActionResult> GetMoveByNameorID(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var MoveData = await pokeClient.GetMoveWithNameOrId(id.ToLower());
                if (MoveData != null)
                {
                    return View(MoveData);
                }
                else
                {
                    return View();
                }
                
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> GetListOfPokemonByType(string type)
        {
            if (!string.IsNullOrWhiteSpace(type))
            {
                var TypeData = await pokeClient.GetPokemonAndInfoWithType(type.ToLower());

                return View(TypeData);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> ErrorPage()
        {
            return View();
        }
    }
}