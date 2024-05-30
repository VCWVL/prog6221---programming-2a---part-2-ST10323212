using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using prog6221___programming_2a;
using System.Linq;

namespace RecipeUnitTest
{
    [TestClass]
    public class CalorieTest
    {
        [TestMethod]
        public void CalculateCalorie_ShouldReturnCorrectTotalCalories()
        {
            // Arrange
            var recipe = new Recipe(
                "Test Recipe",
                new List<string> { "Ingredient1", "Ingredient2" },
                new List<double> { 1.0, 2.0 },
                new List<string> { "Unit1", "Unit2" },
                1, // Default scale
                new List<int> { 100, 200 },
                new List<string> { "Group1", "Group2" },
                new List<string> { "Step1", "Step2" }
            );

            Methods.FullRecipe.Add(recipe);
            double expected = 300; // 100 + 200

            // Act
            double actual = Methods.CalculateCalorie("Test Recipe");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
