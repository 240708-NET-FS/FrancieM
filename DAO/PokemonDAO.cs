using System.Collections.Generic;
using System.Linq;
using pokedex.Entities; // Ensure correct namespace
using Microsoft.EntityFrameworkCore;

namespace pokedex.DAO
{public class PokemonDAO : IDAO<Pokemon>
{
    private readonly PokemonDbContext _context;

    public PokemonDAO(PokemonDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(int dexnum, string name, string type, int trainerID)
    {
        try
        {
            // Check if the Trainer exists
            var trainerExists = _context.Trainer.Any(t => t.TrainerID == trainerID);
            if (!trainerExists)
            {
                Console.WriteLine("Trainer not found.");
                return;
            }

            // Create a new Pokemon
            var pokemon = new Pokemon
            {
                Dexnum = dexnum,
                Name = name,
                Type = type,
                TrainerID = trainerID
            };

            // Add the Pokémon to the context
            _context.Pokemon.Add(pokemon);

            // Save changes to the database
            _context.SaveChanges();

            Console.WriteLine("Pokémon created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
        public void CreatePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

       public void DeleteByDexnum(int dexNum, int trainerId)
        {
            try
        {
            // Find the Pokémon by Dexnum and TrainerId
            var pokemon = _context.Pokemon
                .FirstOrDefault(p => p.Dexnum == dexNum && p.TrainerID == trainerId);

            if (pokemon != null)
            {
                // Remove Pokémon from the context
                _context.Pokemon.Remove(pokemon);

                // Save changes to the database
                _context.SaveChanges();

                Console.WriteLine("Pokémon released successfully.");
            }
            else
            {
                Console.WriteLine("No Pokémon found with the provided Dexnum and Trainer ID.");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        }

        public ICollection<Pokemon> GetAllPokemons()
        {
            List<Pokemon> pokemons = _context.Pokemon.ToList();
            return pokemons;
        }

        public Pokemon GetByDexnum(int dexnum)
        {
            Pokemon pokemon = _context.Pokemon.FirstOrDefault(u => u.Dexnum == dexnum);
            return pokemon;
        }

        public void Update(Pokemon newPokemon)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
