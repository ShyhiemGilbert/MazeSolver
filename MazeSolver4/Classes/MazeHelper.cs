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

        //Initialise Maze using selected file
		public static Maze InitialiseMaze(string fileName)
		{

			try
			{
				//initialize an empty maze
				Maze maze = new Maze();

				//file is read as a list of strings
				var file = ReadFrom(fileName);

				//Turn list into an array
				var gridParameters = file.ToArray();

				//extract size parameters from array
				var gridSize = gridParameters[0].Split(' ');
				maze.MazeWidth = Int32.Parse(gridSize[0]);
				maze.MazeHeight = Int32.Parse(gridSize[1]);

				//extract start position from array
				var gridStart = gridParameters[1].Split(' ');
				maze.StartLocation.x = Int32.Parse(gridStart[0]);
				maze.StartLocation.y = Int32.Parse(gridStart[1]);

				//extract end position from array
				var gridEnd = gridParameters[2].Split(' ');
				maze.EndLocation.x = Int32.Parse(gridEnd[0]);
				maze.EndLocation.y = Int32.Parse(gridEnd[1]);

				//Create 2 dimensional array which is the size of maze specified in file
				maze.MazeGrid = new string[maze.MazeWidth,maze.MazeHeight];

				//Populate maze with # for walls, or space for path
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

				//Population Ending

				return maze;

			}
			catch (IOException e)
			{
				Console.WriteLine("This file could not be read");
				Console.WriteLine(e.Message);
				System.Console.ReadKey();
				return null;
			}
		}

		//This method reads the contents of a file into a list of strings
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

		//Recursive search of maze 
		public static string SolveMaze(Maze maze, Coordinates currentCoordinates)
		{
			//Before moving need to check if user will hit a wall.
			if (maze.MazeGrid[currentCoordinates.x, currentCoordinates.y] == "#")
				return "#";

            //Check if end Location has already been found
			if (maze.MazeGrid[currentCoordinates.x, currentCoordinates.y] == "E")
				return "E";

            //Record a searched location
            maze.SearchedLocations.Add(currentCoordinates);

            List<string> directions = new List<string>{ "E","S","W","N" };
      
            //Search East, South, West, North 
            foreach (var direction in directions)
            {
                var coordinates = move(currentCoordinates, direction, maze.MazeWidth, maze.MazeHeight);
                if (!maze.HasLocationBeenSearched(coordinates))
                {
                    //Check if End Location has been found
                    if (SolveMaze(maze, coordinates) == "E")
                    {
                        if (currentCoordinates != maze.StartLocation)
                        {
                            //Mark path (X) in grid as successive recursive function calls return after a successful search
                            maze.MazeGrid[currentCoordinates.x, currentCoordinates.y] = "X";
                        }
                        return "E";
                    }
                }
            }

            return "";
		}

        //Move in one direction in maze
		public static Coordinates move(Coordinates coordinates, string direction, int gridWidth, int gridHeight)
		{
           
            //Get coordinates for placement on the grid x and y axis
            Coordinates newCoordinates = new Coordinates()
				{
					x = coordinates.x,
					y = coordinates.y
				};
			//If going north and already at the top of the maze, the next coor with vertically wrap
				if (direction == "N")
				{
					if (newCoordinates.y == 0)
					{
						newCoordinates.y = gridHeight - 1;
					}
					else
					{
						newCoordinates.y = newCoordinates.y - 1;
					}
				}

				//If going east and already at the right hand edge of the maze, the next coor with horizontally wrap
			if (direction == "E")
				{
					if (newCoordinates.x == (gridWidth - 1))
					{
						newCoordinates.x = 0;
					}
					else
					{
						newCoordinates.x = newCoordinates.x + 1;
					}

				}

			//If going east and already at the left hand edge of the maze, the next coor with horizontally wrap
			if (direction == "W")
				{
					if (newCoordinates.x == 0)
					{
						newCoordinates.x = (gridWidth - 1);
					}
					else
					{
						newCoordinates.x = newCoordinates.x - 1;
					}

				}
			//If going south and already at the bottom of the maze, the next coor with vertically wrap
			if (direction == "S")
				{
					if (newCoordinates.y == (gridHeight - 1))
					{
						newCoordinates.y = 0;
					}
					else
					{
						newCoordinates.y = newCoordinates.y + 1;
					}

				}

			return newCoordinates;

		}

		//Maze borders are built
		public static void DisplayMaze (Maze maze)
		{

			for (int y = 0; y < maze.MazeHeight; y++)
			{
				for (int x = 0; x < maze.MazeWidth; x++)
				{
					Console.Write(maze.MazeGrid[x, y]);
				}
				Console.WriteLine();
			}

		}




	}
}
