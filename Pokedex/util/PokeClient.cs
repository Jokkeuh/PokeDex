using Microsoft.AspNetCore.Http;
using Pokedex.Models;
using System.Text.Json;

namespace Pokedex.util
{
    public class PokeClient
    {
        private HttpClient Client { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PokeClient(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            Client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Move?> GetMoveWithNameOrId(string id)
        {
            var responseInt = await this.Client.GetAsync($"https://pokeapi.co/api/v2/move/{id}");
            if (responseInt != null && responseInt.IsSuccessStatusCode)
            {
                var content = await responseInt.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Move>(content);
            }
            else
            {
                return null;
            }
        }


        public async Task<Pokemon?> GetPokemon(string id)
        {
            //bool intIDSuccess = int.TryParse(id, out var intID);
            //if (intIDSuccess) 
            //{
               
                var responseInt = await this.Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
                if (responseInt != null && responseInt.IsSuccessStatusCode)
                {
                    var content = await responseInt.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Pokemon>(content);
                }
            else { return null; }
            //}
            //else if (intID > 899)
            //{
            //    var responseStr = await this.Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}/");
            //    if (responseStr.IsSuccessStatusCode)
            //    {
            //        var content = await responseStr.Content.ReadAsStringAsync();
            //        return JsonSerializer.Deserialize<Pokemon>(content);
            //    }
            //    else { return null; }
            //}
            //else { return null; }
        }

        public async Task<Models.Type> GetPokemonAndInfoWithType(string typeUrl)
        {
            HttpResponseMessage? response;
            
            if (typeUrl.StartsWith("http"))
            {
                response = await this.Client.GetAsync($"{typeUrl}");
            }
            else
            {
                response = await this.Client.GetAsync($"https://pokeapi.co/api/v2/type/{typeUrl}");
            }
            
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Models.Type>(content);
            }
            else { throw new Exception("Null"); }
        } 


        public async Task<List<Pokemon>?> GetNofPokemon(int aantal)
        {
            var pokelist = new List<Pokemon>();

            for (int i = 1; i < aantal; i++)
            {
                int ran = new Random().Next(1, 898);
                var response = await this.Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{ran}/");
                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonSerializer.Deserialize<Pokemon>(content);
                pokelist.Add(pokemon!);
            }
            return pokelist;

        }

    }
}
