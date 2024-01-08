using Microsoft.EntityFrameworkCore;

namespace Pokedex.Models
{
    public class PokemonDbContext : DbContext
    {

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Userpokemon> UserPokemon { get; set; }
        
        
    }





}
