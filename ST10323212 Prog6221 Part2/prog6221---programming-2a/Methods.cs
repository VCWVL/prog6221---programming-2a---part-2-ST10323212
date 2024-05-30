using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221___programming_2a
{
	public delegate void CalorieMessage(double totalCalories);

	public class Methods
	{
		public static List<Recipe> FullRecipe = new List<Recipe>();
		public static void EnterRecipe()
		{
			// Create lists to store recipe information
			List<string> ingredientName = new List<string>(); // List to store ingredient names
			List<double> ingredientQuantity = new List<double>(); // List to store ingredient quantities
			List<string> ingredientUnit = new List<string>(); // List to store ingredient units
			List<int> ingredientCalories = new List<int>(); // List to store ingredient calories
			List<string> ingredientFoodGroup = new List<string>(); // List to store ingredient food groups
			List<string> steps = new List<string>(); // List to store recipe steps
			int DEFAULTSCALE = 1; // Default scale for the recipe

			Console.WriteLine("Enter the name of the recipe:");
			string name = Console.ReadLine(); // Read the recipe name from the user

			int numIngredients = 0; // Variable to store the number of ingredients
			bool isNumIngredientsValid = false; // Flag to validate the number of ingredients

			while (!isNumIngredientsValid)
			{
				Console.WriteLine("How many ingredients are needed for this recipe?");
				bool isValidInput = Int32.TryParse(Console.ReadLine(), out numIngredients); // Read the number of ingredients from the user

				if (isValidInput && numIngredients >= 1) // Check if the input is a valid positive number
				{
					isNumIngredientsValid = true; // Set the flag to exit the loop

					for (int i = 0; i < numIngredients; i++)
					{
						Console.WriteLine("Enter the name of ingredient " + (i + 1));
						ingredientName.Add(Console.ReadLine()); // Read the name of the ingredient from the user and add it to the list

						double quantity = 0; // Variable to store the quantity of the ingredient
						bool isQuantityValid = false; // Flag to validate the quantity

						while (!isQuantityValid)
						{
							Console.WriteLine("Enter the quantity of ingredient " + (i + 1));
							isValidInput = Double.TryParse(Console.ReadLine(), out quantity); // Read the quantity from the user

							if (isValidInput && quantity >= 0) // Check if the input is a valid non-negative number
							{
								isQuantityValid = true; // Set the flag to exit the loop
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Invalid input. Please enter a valid ingredient quantity.");
								Console.ResetColor();
							}
						}

						ingredientQuantity.Add(quantity); // Add the quantity to the list

						Console.WriteLine("Enter the unit of ingredient " + (i + 1));
						Console.WriteLine("Metric Units of Measurement for Cooking:");
						Console.WriteLine("1. Gram (g)");
						Console.WriteLine("2. Kilogram (kg)");
						Console.WriteLine("3. Milliliter (ml)");
						Console.WriteLine("4. Liter (L)");
						Console.WriteLine("5. Teaspoon (tsp)");
						Console.WriteLine("6. Tablespoon (tbsp)");
						Console.WriteLine("7. Cup (c)");
						Console.WriteLine("8. Unit");

						// Convert user input to the corresponding unit
						switch (int.TryParse(Console.ReadLine(), out int unit) ? unit : -1)
						{
							case 1:
								ingredientUnit.Add("g");
								break;
							case 2:
								ingredientUnit.Add("kg");
								break;
							case 3:
								ingredientUnit.Add("ml");
								break;
							case 4:
								ingredientUnit.Add("L");
								break;
							case 5:
								ingredientUnit.Add("tsp");
								break;
							case 6:
								ingredientUnit.Add("tbsp");
								break;
							case 7:
								ingredientUnit.Add("c");
								break;
							default:
								ingredientUnit.Add("Unit");
								break;
						}

						int calories = 0; // Variable to store the calories of the ingredient
						bool isCaloriesValid = false; // Flag to validate the calories

						while (!isCaloriesValid)
						{
							Console.WriteLine("Enter the calories of ingredient " + (i + 1));
							isValidInput = Int32.TryParse(Console.ReadLine(), out calories); // Read the calories from the user

							if (isValidInput && calories >= 0) // Check if the input is a valid non-negative number
							{
								isCaloriesValid = true; // Set the flag to exit the loop
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Invalid input. Please enter a valid ingredient calories. \n");
								Console.ResetColor();
							}
						}

						ingredientCalories.Add(calories); // Add the calories to the list

						Console.WriteLine("Enter the food group of ingredient " + (i + 1));
						Console.WriteLine("2. Vegetables");
						Console.WriteLine("3. Grain");
						Console.WriteLine("4. Protein");
						Console.WriteLine("5. Dairy");
						Console.WriteLine("6. Fat");
						Console.WriteLine("7. Other");

						int userInput = 0; // Variable to store the user's food group choice
						bool isUserInputValid = false; // Flag to validate the user's input

						while (!isUserInputValid)
						{
							isValidInput = Int32.TryParse(Console.ReadLine(), out userInput); // Read the user's input

							if (isValidInput && userInput >= 1 && userInput <= 7) // Check if the input is a valid food group option
							{
								isUserInputValid = true; // Set the flag to exit the loop

								switch (userInput)
								{
									case 1:
										ingredientFoodGroup.Add("Fruit");
										break;
									case 2:
										ingredientFoodGroup.Add("Vegetable");
										break;
									case 3:
										ingredientFoodGroup.Add("Grain");
										break;
									case 4:
										ingredientFoodGroup.Add("Protein");
										break;
									case 5:
										ingredientFoodGroup.Add("Dairy");
										break;
									case 6:
										ingredientFoodGroup.Add("Fat");
										break;
									default:
										ingredientFoodGroup.Add("Other");
										break;
								}
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Invalid input. Please enter a valid ingredient food group.");
								Console.ResetColor();
							}
						}

						Console.Clear();
					}

					int numSteps = 0; // Variable to store the number of steps in the recipe
					bool isNumStepsValid = false; // Flag to validate the number of steps

					while (!isNumStepsValid)
					{
						Console.WriteLine("How many steps are there in this recipe?");
						isValidInput = Int32.TryParse(Console.ReadLine(), out numSteps); // Read the number of steps from the user

						if (isValidInput && numSteps >= 1) // Check if the input is a valid positive number
						{
							isNumStepsValid = true; // Set the flag to exit the loop

							for (int i = 0; i < numSteps; i++)
							{
								Console.WriteLine("Enter step " + (i + 1));
								steps.Add(Console.ReadLine()); // Read the step from the user and add it to the list
							}

							// Create a new Recipe object with the entered information and add it to the recipe list
							FullRecipe.Add(new Recipe(name, ingredientName, ingredientQuantity, ingredientUnit, DEFAULTSCALE, ingredientCalories, ingredientFoodGroup, steps));

							// Sort the recipe list alphabetically by recipe name
							FullRecipe.Sort((x, y) => string.Compare(x.Name, y.Name));

							Console.Clear();
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Invalid input. Please enter a valid number of steps.");
							Console.ResetColor();
						}
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Invalid input. Please enter a valid number of ingredients.");
					Console.ResetColor();
				}
			}
		}

		public static void DeleteRecipe()
		{
			try
			{
				string recipeName = RecipeSelect("delete"); // Prompt the user to select a recipe to delete

				Recipe recipeToDelete = FullRecipe.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase)); // Find the recipe to delete in the FullRecipe list
				if (recipeToDelete != null) // If the recipe is found
				{
					FullRecipe.Remove(recipeToDelete); // Remove the recipe from the FullRecipe list
					Console.WriteLine("Recipe deleted successfully."); // Display success message
				}
				else
				{
					Console.WriteLine("Recipe not found."); // Display message if the recipe is not found
				}

				Console.WriteLine("\n");
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid Input"); // Handle format exception if an invalid input is encountered
			}
		}


		public static void ScaleRecipe()
		{
			string recipeName = RecipeSelect("scale"); // Prompt the user to select a recipe to scale
			Recipe recipe = Methods.FullRecipe.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase)); // Find the selected recipe in the FullRecipe list
			if (recipe != null) // If the recipe is found
			{
				Console.WriteLine("Enter a number to select an option:"); // Prompt the user to enter a number to select an option
				Console.WriteLine("1. Scale recipe by 0.5 (Half)"); 
				Console.WriteLine("2. Scale recipe by 2 (Double)"); 
				Console.WriteLine("3. Scale recipe by 3 (Triple)"); 
				Console.WriteLine("4. Reset scale"); 
				int userInput = Convert.ToInt32(Console.ReadLine()); // Read user input and convert it to an integer

				double scale = 1.0; // Initialize the scale factor to 1.0 (no scaling)
				switch (userInput) // Check the user input
				{
					case 1:
						// scale recipe by 0.5
						scale = 0.5; 
						break;
					case 2:
						// scale recipe by 2
						scale = 2; 
						break;
					case 3:
						// scale recipe by 3
						scale = 3; 
						break;
					case 4:
						// reset scale
						scale = 1;
						break;
					default:
						Console.WriteLine("\nInvalid input\n"); // Display an error message for invalid input
						return; 
				}
				recipe.IngredientScale = scale; // Set the scale factor of the recipe to the selected scale
			}
		}


		public static void DisplayRecipe()
		{
			CalorieMessage calorieMessageDelegate = CalorieMessage; // Declare a delegate variable to store the CalorieMessage method
			Console.Clear(); 
			string recipeName = RecipeSelect("display"); // Prompt the user to select a recipe to display
			Recipe recipe = FullRecipe.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase)); // Find the selected recipe in the FullRecipe list
			if (recipe != null) // If the recipe is found
			{
				Console.Clear();
				Console.WriteLine("Recipe Details:\n"); 

				Console.ForegroundColor = ConsoleColor.Green; // Set console text color to green
				Console.WriteLine($"Name: {recipe.Name}"); // Display the recipe name
				Console.ResetColor(); 

				Console.ForegroundColor = ConsoleColor.Yellow; // Set console text color to yellow
				Console.WriteLine("\nIngredients:"); 
				Console.ResetColor(); 

				for (int i = 0; i < recipe.IngredientName.Count; i++) // Iterate through each ingredient of the recipe
				{
					Console.WriteLine($"- Name: {recipe.IngredientName[i]}"); // Display the ingredient name
					Console.WriteLine($"  Quantity: {recipe.IngredientQuantity[i] * recipe.IngredientScale} {recipe.IngredientUnit[i]}"); // Display the scaled quantity and unit of the ingredient
					Console.WriteLine($"  Food Group: {recipe.IngredientFoodGroup[i]}"); // Display the food group of the ingredient
				}

				double totalCalorie = CalculateCalorie(recipeName); // Calculate the total calorie of the recipe
				calorieMessageDelegate(totalCalorie); // Invoke the CalorieMessage delegate to display the calorie message

				Console.ForegroundColor = ConsoleColor.Magenta; // Set console text color to magenta
				Console.WriteLine("\nSteps:"); // Display "Steps" header
				Console.ResetColor(); 

				for (int i = 0; i < recipe.Steps.Count; i++) // Iterate through each step of the recipe
				{
					Console.WriteLine($"{(i + 1)}. {recipe.Steps[i]}"); // Display the step number and description
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red; // Set console text color to red
				Console.WriteLine("Recipe not found."); // Display "Recipe not found" message
				Console.ResetColor(); 
			}

			Console.WriteLine("\n"); 
		}

		public static string RecipeSelect(string operation)
		{
			if (FullRecipe.Count > 0)
			{
				Console.WriteLine($"Enter a number to select a recipe to {operation}:");



				// Display all saved recipes
				for (int i = 0; i < FullRecipe.Count; i++)
				{
					Console.WriteLine((i + 1) + ". " + FullRecipe[i].Name);
				}

				int userInput = Convert.ToInt32(Console.ReadLine());

				// Validate the user input
				if (userInput >= 1 && userInput <= FullRecipe.Count)
				{
					string selectedRecipeName = FullRecipe[userInput - 1].Name;
					return selectedRecipeName;
				}
				else
				{
					Console.WriteLine("Invalid input. Please select a valid recipe number.");
				}
			}
			else
			{
				Console.WriteLine("No recipes found. Please add some recipes.");
			}

			return null;
		}

		public static double CalculateCalorie(string recipeName)
		{
			Recipe recipe = FullRecipe.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase)); // Find the recipe in the FullRecipe list based on the given recipe name
			double totalCalories = 0; // Initialize the totalCalories variable to 0
			foreach (double ingredientCalorie in recipe.IngredientCalories) // Iterate through each ingredient calorie in the recipe
			{
				totalCalories += ingredientCalorie; // Add the ingredient calorie to the totalCalories
			}
			return totalCalories * recipe.IngredientScale; // Multiply the totalCalories by the ingredient scale and return the result
		}

		public static void CalorieMessage(double totalCalories)
		{
			if (totalCalories > 300) // If the totalCalories exceeds 300
			{
				Console.ForegroundColor = ConsoleColor.Red; // Set console text color to red
				Console.WriteLine($"  Total calories of {totalCalories} exceeds: 300"); // Display the total calories and the exceeded message
				Console.ResetColor(); // Reset console text color
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green; // Set console text color to green
				Console.WriteLine($"  The total calories are: {totalCalories}"); // Display the total calories
				Console.ResetColor(); // Reset console text color
			}
		}

	}
}