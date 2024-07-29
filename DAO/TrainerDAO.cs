using System;
using System.Collections.Generic;
using System.Linq;
using pokedex.Entities;
using pokedex.DAO;

namespace pokedex.DAO
{
    public class TrainerDAO
    {
        private readonly PokemonDbContext _context;

        public string? TrainerName { get; private set; }

        public TrainerDAO(PokemonDbContext context)
        {
            _context = context;
        }

        public List<Trainer> GetAllTrainers()
        {
            return _context.Trainer.ToList();
        }

    public void AddTrainer()    
        {   
            Console.Write("Enter Trainer Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string name = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Console.Write("Enter Trainer ID: ");
                string id = Console.ReadLine();

             if (int.TryParse(id, out int trainerId))
                 {
                    // Create new Trainer instance and add to DbSet
                 Trainer newTrainer = new Trainer { TrainerID = trainerId, TrainerName = name };

                 _context.Trainer.Add(newTrainer); // Ensure DbSet property is named 'Trainers'
                    _context.SaveChanges();

        Console.WriteLine("Trainer added successfully.");
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer for the Trainer ID.");
    }
}

        public void DeleteTrainerByID(int trainerID)
        {
            var trainer = _context.Trainer.Find(trainerID);
            if (trainer != null)
            {
                _context.Trainer.Remove(trainer);
                _context.SaveChanges();
                Console.WriteLine($"Trainer with ID {trainerID} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Trainer with ID {trainerID} not found.");
            }
        }
    }
}