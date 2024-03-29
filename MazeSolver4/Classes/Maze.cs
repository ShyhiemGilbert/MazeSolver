﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeSolver4.Classes
{
	public class Maze
	{

		public Maze()
		{
			StartLocation = new Coordinates();
			EndLocation = new Coordinates();
            SearchedLocations = new List<Coordinates>();
		}

		public Coordinates StartLocation { get; set; }
		public Coordinates EndLocation { get; set; }

		//[,] dynamic 2 dimensional array
		public string [,] MazeGrid { get; set; }
		public int MazeWidth { get; set; }
		public int MazeHeight { get; set; }

        public List<Coordinates> SearchedLocations { get; set; }


        public bool HasLocationBeenSearched(Coordinates coordinate)
        {
            foreach (var searchedLocation in SearchedLocations)
            {
                if (searchedLocation.x == coordinate.x && searchedLocation.y == coordinate.y)
                    return true;
            }
            return false;
        }

    }
}
