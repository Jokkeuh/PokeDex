using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Pokedex.util;

namespace Pokedex.Services
{
    public class SQLPokemonDB : IPokemonDB
    {
        private PokemonDbContext context;
        private PokeClient pokeClient;
        public SQLPokemonDB(PokemonDbContext context,PokeClient pokeClient)
        {
            this.context = context;
            this.pokeClient = pokeClient;
        }


       

        public async Task AddPokemonToUser(string username, string id)
        {
            bool flag = true;
            int strId = Convert.ToInt32(id);
            var curruser = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
            var pokemonlist = await context.UserPokemon.Where(x => x.USERID == curruser.UserID).ToListAsync();
            foreach (var item in pokemonlist)
            {
                if (item.PokemonID == strId)
                {
                    flag = false;
                }
                
            }

            if (curruser != null && flag == true)
            {
                var userpokemon = new Userpokemon()
                {
                    PokemonID = Convert.ToInt32(id),
                    USERID = curruser.UserID,
                };

                context.UserPokemon.Add(userpokemon);
                await context.SaveChangesAsync();

            }
        }
        public async Task RemovePokemonFromUser(string username, string pokeInt)
        {
            var curruser = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
            if (curruser != null)
            {
                var pokemonlist = await context.UserPokemon.Where(x => x.USERID == curruser.UserID).ToListAsync();
                var pokemonToRemove = pokemonlist.FirstOrDefault(x => x.PokemonID == Convert.ToInt32(pokeInt));
                if (pokemonToRemove != null)
                {
                    context.UserPokemon.Remove(pokemonToRemove);
                    await context.SaveChangesAsync();
                }
            }


        }


        public bool AddUser(User currentUser)
        {
            var namecheck = context.Users.Where(x => x.UserName == currentUser.UserName).FirstOrDefault();
            if (currentUser.UserName == null || currentUser.UserPassword == null/* auth needed here*/) 
            {
                return false;
            }
            if (namecheck == null) 
            {
                if (true /*auth needed*/)
                {
                    context.Users.Add(currentUser);
                    context.SaveChanges();
                    return true;
                }
                    
            }
            else
            {
                return false;
            }
        }


        public string GetPasswordForUserWithId(int id)
        {
            var user = context.Users.Where(x => x.UserID== id).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user.UserPassword;
        }

        public async Task<List<Pokemon>> GetPokemonForUser(string username)
        {
            User? currentUser = context.Users.Where(x => x.UserName == username).FirstOrDefault();
            List<Pokemon> userPokemons = new List<Pokemon>();

            var currentUserPokemons = context.UserPokemon
                .Where(x => x.USERID == currentUser.UserID)
                .Select(x => x.PokemonID)
                .ToList();
            if (currentUserPokemons.Count == 0)
            {
                return null;
            }
            foreach (var pokemonID in currentUserPokemons)
            {
                string id = Convert.ToString(pokemonID);
                Pokemon? currPokemon = await pokeClient.GetPokemon(id);
                if (currPokemon != null)
                {
                    userPokemons.Add(currPokemon);
                }
            }
            return userPokemons;
        }
        
        public User GetUser(int id)
        {
            var user = context.Users.FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public User GetUserByName(string name)
        {
            var user = context.Users.Where(u => u.UserName == name)
                                    
                                    .FirstOrDefault();
            
            if (user == null)
            {
                return null;
            }
            return user;
        }

       
    }
}
