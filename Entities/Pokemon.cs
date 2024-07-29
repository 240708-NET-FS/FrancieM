
namespace pokedex.Entities;

public class Pokemon{
    public int Dexnum {get; set;}//Primary Key
    public required string Name {get; set;}
    public required string Type {get; set;}
    public int TrainerID {get; set;} //Foreign Key

    public Trainer Trainer {get; set;}

    public override string ToString()
    {
        return $"{Dexnum} {Name} {Type} {TrainerID} " + Trainer.TrainerName;
    }
}
