using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver4.Classes
{
	public static class MazeHelper
	{

		public  static Maze InitialiseMaze(string fileName)
		{

			try
			{

				Maze maze = new Maze();
				//var Maze = ReadFrom(@"C:\Users\Shyhiem Gilbert\Source\Repos\ShyhiemGilbert\MazeSolver4\MazeSolver4\Mazes\input.txt");
				var file = ReadFrom(fileName);
				//Turn into an array
				var gridParameters = file.ToArray();
				//Array splits once there is an space
				var gridSize = gridParameters[0].Split(' ');
				//Grid size coord
				maze.MazeWidth = Int32.Parse(gridSize[0]);
				maze.MazeHeight = Int32.Parse(gridSize[1]);

				var gridStart = gridParameters[1].Split(' ');
				//Grid Start (x,y) coord
				maze.StartLocation.x = Int32.Parse(gridStart[0]);
				maze.StartLocation.y = Int32.Parse(gridStart[1]);

				var gridEnd = gridParameters[2].Split(' ');
				//Grid End (x,y) coord
				maze.EndLocation.x = Int32.Parse(gridEnd[0]);
				maze.EndLocation.y = Int32.Parse(gridEnd[1]);

				//Created an array which is size of maze grid
				maze.MazeGrid = new string[maze.MazeWidth,maze.MazeHeight];

				//Populate grid

				for (int y = 0; y < maze.MazeHeight; y++)
				{
					for (int x = 0; x < maze.MazeWidth; x++)
					{
						var gridLine = gridParameters[3+y].Split(' ');
						var gridCode = gridLine[x];
						if (gridCode == "1")
						{
							maze.MazeGrid[x, y] = "#";
						}
						else
						{
							maze.MazeGrid[x, y] = " ";
						}

					}
				}



				//Populate Start Location
				maze.MazeGrid[maze.StartLocation.x, maze.StartLocation.y] = "S";

				//Populate End Location
				maze.MazeGrid[maze.EndLocation.x, maze.EndLocation.y] = "E";

				//Population Ending--------------------------------------------------------------------------------------------



			}
			catch (IOException e)
			{
				Console.WriteLine("This file could not be read");
				Console.WriteLine(e.Message);
				System.Console.ReadKey();
			}

			return new Maze();

		}




		static IEnumerable<string> ReadFrom(string file)
		{
			string line;
			using (var reader = File.OpenText(file))
			{
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}


	}
}
