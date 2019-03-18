using System;
using MazeSolver4.Classes;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MazeSolver4
{
	static class Program
	{
		[STAThread]
		 static void Main(string[] args)
		{

			Maze maze;

			//Check if a parameter has been specified,
			if (args.Length == 1)
			{
				//initialise maze using the specified file
				maze = MazeHelper.InitialiseMaze(args[0]);
			}
			else if (args.Length > 1)
			{
				Console.WriteLine("Please select one file as only one parameter can be passed through");
			}
			else
			{
				//Display DialogBox to allow a file to be selected
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					var FilePath = File.ReadAllText(openFileDialog.FileName);
				}
				//initialise maze using the selected file
				maze = MazeHelper.InitialiseMaze(openFileDialog.FileName);
			}

			//solve maze, searches the maze for a path to the end location.
			var result = MazeHelper.SolveMaze(maze, maze.StartLocation);

			//Solve maze will return E if it has found the end location in the maze.
			if (result == "E")
				Console.WriteLine("This maze can be solved: ");
			//Otherwise the maze cannot be solved
			else
				Console.WriteLine("There is no solution for this maze: ");

			Console.WriteLine();

			MazeHelper.DisplayMaze(maze);

			Console.ReadKey();


		}



	}



}
