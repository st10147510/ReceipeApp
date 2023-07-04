using ReceipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceipeApp.Services
{
    class IngredientService
    {
        // A constant that represents the message for an invalid ingredient format
        private const string INVALID_INGREDIENT_FORMAT = "Invalid ingredient format: {0}";

        // A private field that holds a list of ingredients
        private readonly List<Ingredient> ingredientList;

        // A constructor that initializes the ingredientList field
        public IngredientService()
        {
            ingredientList = new List<Ingredient>();
        }

        // A method that creates a list of ingredients from a string input
        // The input format should be: "{amount} {ingredient name}, {amount} {ingredient name}, ..."
        // If an ingredient is in an invalid format, the method will print an error message and skip the ingredient
        public List<Ingredient> CreateIngredientsFromInput(string input)
        {
            // Split the input into an array of strings using comma as a separator
            string[] ingredientArray = input.Split(',');

            // Loop through each ingredient in the array
            foreach (string ingredientString in ingredientArray)
            {
                // Split the ingredient string into an array of strings using space as a separator
                string[] ingredientParts = ingredientString.Trim().Split(' ');

                // If the ingredient is not in a valid format, print an error message and skip the ingredient
                if (ingredientParts.Length != 5)
                {
                    Console.WriteLine(INVALID_INGREDIENT_FORMAT, ingredientString);
                    continue;
                }

                // Get the name and amount of the ingredient
                string ingredientName = ingredientParts[2];
                string ingredientUnit = ingredientParts[1];
                double ingredientAmount = double.Parse(ingredientParts[0]);
                string ingredientFoodGroup = ingredientParts[3];
                int ingredientCalories = int.Parse(ingredientParts[4]);

                // Create an Ingredient object and set its name and amount
                Ingredient ingredient = new Ingredient();
                ingredient.Name = ingredientName;
                ingredient.Unit = ingredientUnit;
                ingredient.Amount = ingredientAmount;
                ingredient.Calories = ingredientCalories;
                ingredient.FoodGroup = ingredientFoodGroup;

                // Add the ingredient to the list
                ingredientList.Add(ingredient);
            }

            // Return the list of ingredients
            return ingredientList;
        }

        // A method that returns the list of all ingredients
        public List<Ingredient> GetAllIngredients()
        {
            return ingredientList;
        }
    }
}
