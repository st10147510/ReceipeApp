using ReceipeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceipeApp.Services
{
    class ReceipeService
    {

        // A private field that holds a list of recipes
        public static ObservableCollection<Receipe> recipeList;

        // Constructor initializes an empty list to hold recipes
        public ReceipeService()
        {
            recipeList = new ObservableCollection<Receipe>() { new Receipe() { Name = "Pasta", CookTime = "10 minutes", Serves = "5" } };
        }

        // Adds a new recipe to the list
        public void CreateReceipe(Receipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            recipeList.Add(recipe);
        }

        // Retrieves a specific recipe from the list by name
        public Receipe GetRecipe(Receipe payload)
        {
            return recipeList.FirstOrDefault(recipe => recipe.Name == payload.Name);
        }

        // Returns all recipes in the list
        public ObservableCollection<Receipe> GetAllRecipes()
        {
            return recipeList;
        }

        public Receipe SelectRecipe()
        {
            Console.WriteLine("Enter the name of the recipe:");
            string recipeName = Console.ReadLine();

            Receipe recipe = recipeList.FirstOrDefault(r => r.Name == recipeName);
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found!\n");
            }

            return recipe;
        }

        public void DisplayRecipeList()
        {
            Console.WriteLine("Recipe List:");

            foreach (Receipe recipe in recipeList.OrderBy(r => r.Name))
            {
                Console.WriteLine($"- {recipe.Name}");
            }
        }

        // Updates an existing recipe with new information
        public void UpdateRecipe(Receipe payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            var recipe = recipeList.FirstOrDefault(recipe => recipe.Name == payload.Name);
            if (recipe == null)
            {
                throw new ArgumentException($"Recipe {payload.Name} not found.");
            }

            recipe.Name = payload.Name;
            //recipe.Ingredients = payload.Ingredients;
           // recipe.Steps = payload.Steps;
        }

        // Deletes a recipe from the list
        public void DeleteRecipe(Receipe payload)
        {
            var recipe = recipeList.FirstOrDefault(recipe => recipe.Name == payload.Name);
            if (recipe == null)
            {
                throw new ArgumentException($"Recipe {payload.Name} not found.");
            }

            recipeList.Remove(recipe);
        }
    }
}
