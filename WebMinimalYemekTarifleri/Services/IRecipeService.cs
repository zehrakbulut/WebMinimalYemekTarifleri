using WebMinimalYemekTarifleri.Model;

namespace WebMinimalYemekTarifleri.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById(int id);
        Recipe Create(Recipe recipe);
        void Update(int id, Recipe recipe);
        void Delete(int id);
    }
}
