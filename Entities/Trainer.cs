using pokedex.Entities;

namespace pokedex.Entities;

public class Trainer
{
    public int TrainerID {get; set;}
     public string TrainerName { get; set; }

    public ICollection<Pokemon> Pokemons { get; set; }

     public override string ToString()
    {
        return $"{TrainerID} {TrainerName}";
    }
}