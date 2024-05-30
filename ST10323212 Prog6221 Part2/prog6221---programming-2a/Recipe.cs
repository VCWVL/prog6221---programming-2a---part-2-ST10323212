using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221___programming_2a
{
	public class Recipe
	{
		public string Name { get; set; }
		public List<string> IngredientName { get; set; }
		public List<double> IngredientQuantity { get; set; }
		public List<string> IngredientUnit { get; set; }
		public double IngredientScale { get; set; }
		public List<int> IngredientCalories { get; set; }
		public List<string> IngredientFoodGroup { get; set; }
		public List<string> Steps { get; set; }

		public Recipe(string name, List<string> ingredientName, List<double> ingredientQuantity, List<string> ingredientUnit, double ingredientScale, List<int> ingredientCalories, List<string> ingredientFoodGroup, List<string> steps)
		{
			Name = name;
			IngredientName = ingredientName;
			IngredientQuantity = ingredientQuantity;
			IngredientUnit = ingredientUnit;
			IngredientScale = ingredientScale;
			IngredientCalories = ingredientCalories;
			IngredientFoodGroup = ingredientFoodGroup;
			Steps = steps;
		}
	}
}

