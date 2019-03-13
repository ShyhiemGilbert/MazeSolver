using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MazeSolver4.Classes;

namespace MazeSolver4
{
	static class Program
	{
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
		static void Main(string[] args)
		{
			var Maze = ReadFrom(@"C:\Users\Shyhiem Gilbert\Source\Repos\ShyhiemGilbert\MazeSolver4\MazeSolver4\Mazes\input.txt");
			foreach (var line in Maze)
			{
				Console.WriteLine((line));
				var lineParts = line.Split(' ');

			}
			Console.ReadKey();

		}
	}



}
