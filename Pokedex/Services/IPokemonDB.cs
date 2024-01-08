using Pokedex.Models;

namespace Pokedex.Services
{
    public interface IPokemonDB
    {
        public User GetUser(int id);
        public User GetUserByName(string name);
        public string GetPasswordForUserWithId(int id);


        public Task<List<Pokemon>> GetPokemonForUser(string username);
        public Task AddPokemonToUser(string username, string pokeInt);
        public Task RemovePokemonFromUser(string username, string pokeInt);
        public bool AddUser(User currentUser);
        
        
    }
}
