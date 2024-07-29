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

        public TrainerDAO(PokemonDbContext context)
        {
            _context = context;
        }

        public List<Trainer> GetAllTrainers()
        {
            return _context.Trainers.ToList();
        }

        public void AddTrainer()
        {
            Console.Write("Enter Trainer Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // Create new Trainer instance and add to DbSet
            var trainer = new Trainer { TrainerName = name };
            _context.Trainers.Add(trainer);
            _context.SaveChanges();

            Console.WriteLine("Trainer added successfully.");
        }

        public void DeleteTrainerByID(int trainerID)
        {
            var trainer = _context.Trainers.Find(trainerID);
            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
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