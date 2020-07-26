using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2016
{
	static class Day1
	{
		public static void Problem1()
		{
			string inputtext;

			Console.WriteLine("Input file:");
			string fileName = Console.ReadLine();
			while (!File.Exists(fileName))
			{
				Console.WriteLine("file not found - try again:");
				fileName = Console.ReadLine();
			}

			using (StreamReader sr = new StreamReader(fileName))
			{
				inputtext = sr.ReadLine();
			}


			var instructions = inputtext.Replace(" ", "").Split(',');

			int stepsEast = 0;
			int stepsNorth = 0;

			int direction = 0;

			foreach(var instruction in instructions)
			{
				//turn
				if(instruction[0] == 'R')
				{
					direction = (direction + 90) % 360;
				}
				else
				{
					direction = (direction + 270) % 360;
				}

				//take steps
				int steps = Convert.ToInt32(instruction.Substring(1));

				switch (direction)
				{
					case 0:
						stepsNorth += steps;
						break;
					case 90:
						stepsEast += steps;
						break;
					case 180:
						stepsNorth -= steps;
						break;
					case 270:
						stepsEast -= steps;
						break;
				}
			}

			var totalSteps = Math.Abs(stepsEast) + Math.Abs(stepsNorth);

			Console.WriteLine(totalSteps);
			


		}

		public static void Problem2()
		{
			string inputtext;

			Console.WriteLine("Input file:");
			string fileName = Console.ReadLine();
			while (!File.Exists(fileName))
			{
				Console.WriteLine("file not found - try again:");
				fileName = Console.ReadLine();
			}

			using (StreamReader sr = new StreamReader(fileName))
			{
				inputtext = sr.ReadLine();
			}

			//inputtext = "R8, R4, R4, R8";  //example values from the problem description for testing

			var instructions = inputtext.Replace(" ", "").Split(',');

			int stepsEast = 0;
			int stepsNorth = 0;

			int direction = 0;

			var visited = new Dictionary<int, HashSet<int>>();
			visited.Add(0, new HashSet<int>() { 0 });

			var notFound = true;
			for(int j = 0; j < instructions.Length && notFound; j++ )
			{
				var instruction = instructions[j];
				//turn
				if (instruction[0] == 'R')
				{
					direction = (direction + 90) % 360;
				}
				else
				{
					direction = (direction + 270) % 360;
				}

				//take steps
				int steps = Convert.ToInt32(instruction.Substring(1));

				for (int i = 0; i < steps && notFound; i++)
				{
					switch (direction)
					{
						case 0:
							stepsNorth++; 
							break;
						case 90:
							stepsEast++;
							break;
						case 180:
							stepsNorth--;
							break;
						case 270:
							stepsEast--;
							break;
					}

					if (visited.ContainsKey(stepsEast) && visited[stepsEast].Contains(stepsNorth))
					{
						//found our goal
						var totalSteps = Math.Abs(stepsEast) + Math.Abs(stepsNorth);
						Console.WriteLine(totalSteps);
						notFound = false;
					}
					else
					{
						if (!visited.ContainsKey(stepsEast))
						{
							visited[stepsEast] = new HashSet<int>() { stepsNorth };
						}
						else
						{
							visited[stepsEast].Add(stepsNorth);
						}
					}
				}
			}

			





		}

	}
}
