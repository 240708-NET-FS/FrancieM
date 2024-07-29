using pokedex.Entities;

namespace pokedex.DAO;

public interface IDAO<T>
{
    // CRUD

    // Create
    public void CreatePokemon(T Pokemon);

    // Read
    public T GetByDexnum(int Dexnum);

    public ICollection<T> GetAll();

    // Update
    public void Update(T newPokemon);

    // Delete

    public void Delete(T Pokemon);

}
