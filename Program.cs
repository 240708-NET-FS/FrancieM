using Microsoft.Identity.Client;
using pokedex.DAO;
using pokedex.Entities;
// Ensure the database is created within the same scope
using (var context = new PokemonDbContext())
{
    context.Database.EnsureCreated();

    Console.WriteLine("Welcome to the Pokemon Storage System!");
    Console.WriteLine("Please choose from the following options: ");
    Console.WriteLine("1. Register a new trainer! ");
    Console.WriteLine("2. View all trainers");
    Console.WriteLine("3. Add new Pokemon ");
    Console.WriteLine("4. View all Pokemon");
    Console.WriteLine("5. Release a pokemon (note: this is permanent) ");
    Console.WriteLine("6. Delete a trainer (note: this is permanent) ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    string userInput = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

    // Pass the context to the DAOs
    PokemonDAO pokemonDAO = new(context);
    TrainerDAO trainerDAO = new(context);

    switch (userInput)
    {
        case "1":
            // Add a trainer!
            Console.WriteLine("Add a new Trainer:");
            trainerDAO.AddTrainer();
            break;
        case "2":
            Console.WriteLine("\nTrainers:");
            try
            {
                List<Trainer> trainers = trainerDAO.GetAllTrainers();
                foreach (var trainer in trainers)
                {
                    Console.WriteLine($"Name: {trainer.TrainerName}, Trainer Number: {trainer.TrainerID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            break;
        case "3":
            // Caught new pokemon!
            Console.Write("Enter Dexnum: ");
            if (int.TryParse(Console.ReadLine(), out int dexnum))
            {
                Console.Write("Enter Pokemon Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Pokemon Type: ");
                string type = Console.ReadLine();
                Console.Write("Enter Trainer ID: ");
                if (int.TryParse(Console.ReadLine(), out int trainerId))
                {
                    // Call the method to create the Pokémon
                    pokemonDAO.CreatePokemon(dexnum, name, type, trainerId);
                }
                else
                {
                    Console.WriteLine("Invalid Trainer ID format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Dexnum format.");
            }
            break;
        case "4":
            Console.WriteLine("Getting all Pokemon...");
            try
            {
                List<Pokemon> pokemons = (List<Pokemon>)pokemonDAO.GetAllPokemons();
                foreach (var pokemon in pokemons)
                {
                    Console.WriteLine($"Name: {pokemon.Name}, Dex Number: {pokemon.Dexnum}, Trainer ID: {pokemon.TrainerID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            break;
        case "5":
            Console.Write("Enter the Pokedex number: ");
            if (int.TryParse(Console.ReadLine(), out int Dexnum))
            {
                Console.Write("Enter your Trainer ID: ");
                if (int.TryParse(Console.ReadLine(), out int trainerId))
                {
                    // Call the method to delete the Pokémon
                    pokemonDAO.DeleteByDexnum(Dexnum, trainerId);
                }
                else
                {
                    Console.WriteLine("Invalid Trainer ID format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Dexnum format.");
            }
            break;
        case "6":
            // Get the Trainer ID from the user
            Console.Write("Enter Trainer ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int trainerID))
            {
                // Call the method to delete the Trainer
                trainerDAO.DeleteTrainerByID(trainerID);
            }
            else
            {
                Console.WriteLine("Invalid Trainer ID format.");
            }
            break;
        default:
            Console.WriteLine("Please make a valid selection.");
            break;

    }

}
