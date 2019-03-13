using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeSolver4.Classes
{
	public class Maze
	{
		public Coordinates StartLocation { get; set; }
		public Coordinates EndLocation { get; set; }

		//[,] dynamic 2 dimensional array
		public string [,] MazeGrid { get; set; }
		public int MazeWidth { get; set; }
		public int MazeHeight { get; set; }
	}
}
