using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221___programming_2a
{
	public class Program
	{
		static void Main(string[] args)
		{
			// set a flag to control the main loop
			bool exitFlag = false;

			// set console text color to yellow and print welcome message
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Welcome to RecipeMate!");

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("======================\n");

			// main loop
			while (exitFlag == false)
			{
				// print menu options
				Console.WriteLine("Enter a number to select an option:");
				Console.WriteLine("1. Enter Recipe");
				Console.WriteLine("2. Display Recipe");
				Console.WriteLine("3. Scale Recipe");
				Console.WriteLine("4. Delete Recipe");
				Console.WriteLine("5. Exit Program");

				// read user input
				int userInput = Convert.ToInt32(Console.ReadLine());

				// clear console screen
				Console.Clear();

				// execute different methods based on user input
				switch (userInput)
				{
					case 1:
						// enter recipe

						Methods.EnterRecipe();
						break;

					case 2:
						// print recipe
						if (Methods.FullRecipe.Count == 0)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("\nCannot Display recipe as no recipe has been entered.\n");
							Console.ForegroundColor = ConsoleColor.White;
							break;
						}
						Methods.DisplayRecipe();
						break;
					case 3:
						// scale recipe
						if (Methods.FullRecipe.Count == 0)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("\nCannot SCALE recipe as no recipe has been entered.\n");
							Console.ForegroundColor = ConsoleColor.White;
							break;
						}
						Methods.ScaleRecipe();
						break;
					case 4:
						// delete recipe
						if (Methods.FullRecipe.Count == 0)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("\nCannot Delete recipe as no recipe has been entered.\n");
							Console.ForegroundColor = ConsoleColor.White;
							break;
						}
						Methods.DeleteRecipe();
						break;
					case 5:
						// exit program
						Console.WriteLine("Are you sure you want to exit?");
						Console.WriteLine("1. Yes");
						Console.WriteLine("2. No");

						// read user input as an integer
						int exitInput = Convert.ToInt32(Console.ReadLine());

						// if user selects "Yes", set exit flag to true to exit the main loop
						if (exitInput == 1)
						{
							exitFlag = true;
							break;
						}
						break;
					default:
						// print error message for invalid input
						Console.WriteLine("Invalid input");
						break;
				}
			}

			// print goodbye message and wait for user to close the program
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Thank you for using RecipeMate!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Enter any key to close ...");
			Console.ReadKey();
		}
	}
}
