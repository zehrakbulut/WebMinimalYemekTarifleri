using WebMinimalYemekTarifleri.Model;

namespace WebMinimalYemekTarifleri.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly List<Recipe> _recipeList;

        public RecipeService()
        {
            _recipeList = new List<Recipe>();
        }

        public Recipe Create(Recipe recipe)
        {
            recipe.Id = GenerateNewId();
            _recipeList.Add(recipe);
            return recipe;
        }

        public void Delete(int id)
        {
            var todoItem=_recipeList.FirstOrDefault(item =>item.Id == id);
            if(todoItem != null)
            {
                _recipeList.Remove(todoItem);
            }
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _recipeList;
        }

        public Recipe GetById(int id)
        {
            return _recipeList.FirstOrDefault(item => item.Id == id);
        }

        public void Update(int id, Recipe recipe)
        {
            var existingToDoItem=_recipeList.FirstOrDefault(item=>item.Id == id);   
            if(existingToDoItem != null)
            {
                existingToDoItem.Name = recipe.Name;
                existingToDoItem.Ingredients = recipe.Ingredients;
                existingToDoItem.Instructions = recipe.Instructions;
            }
        }


        private int GenerateNewId()
        {
            if(_recipeList.Count > 0)
            {
                return _recipeList.Max(item => item.Id) + 1;
            }
            return 1;
        }
    }
}
