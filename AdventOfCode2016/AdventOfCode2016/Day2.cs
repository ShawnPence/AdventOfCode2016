using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2016
{
	static class Day2
	{
		public static void Problem1()
		{
			List<string> inputtext = new List<string>();

			Console.WriteLine("Input file:");
			string fileName = Console.ReadLine();
			while (!File.Exists(fileName))
			{
				Console.WriteLine("file not found - try again:");
				fileName = Console.ReadLine();
			}

			using (StreamReader sr = new StreamReader(fileName))
			{
				while (sr.Peek() != -1)
				{
					inputtext.Add(sr.ReadLine());
				}
			
			}

			int result = 0;

			foreach (var line in inputtext)
			{
				/*
				 * 123
				 * 456
				 * 789
				 */
				int currentNumber = 5;
				foreach(var c in line)
				{
					switch(c)
					{
						case 'U':
							if (currentNumber > 3) currentNumber -= 3;
							break;
						case 'D':
							if (currentNumber < 7) currentNumber += 3;
							break;
						case 'L':
							if ((currentNumber % 3) != 1) currentNumber--;
							break;
						case 'R':
							if ((currentNumber % 3) != 0) currentNumber++;
							break;

					}

				}
				result *= 10;
				result += currentNumber;
   
			}

			Console.WriteLine(result);

		}
		public static void Problem2()
		{
			List<string> inputtext = new List<string>();

			Console.WriteLine("Input file:");
			string fileName = Console.ReadLine();
			while (!File.Exists(fileName))
			{
				Console.WriteLine("file not found - try again:");
				fileName = Console.ReadLine();
			}

			using (StreamReader sr = new StreamReader(fileName))
			{
				while (sr.Peek() != -1)
				{
					inputtext.Add(sr.ReadLine());
				}

			}

			string result = "";

			foreach (var line in inputtext)
			{
				/*
				 * pattern for part 2
						1
					  2 3 4
					5 6 7 8 9
					  A B C
						D
				 */
				int currentPosition = 5;
				foreach (var c in line)
				{
					switch (c)
					{
						case 'U':
							if (currentPosition == 3)
							{
								currentPosition = 1;
							}
							else if (currentPosition >= 6 && currentPosition <= 8)
							{
								currentPosition -= 4;
							}
							else if (currentPosition > 9 && currentPosition < 13)
							{
								currentPosition -= 4;
							}
							else if (currentPosition == 13)
							{
								currentPosition = 11;
							}
							break;
						case 'D':
							if (currentPosition == 1)
							{
								currentPosition = 3;
							}
							else if (currentPosition >= 2 && currentPosition <= 4)
							{
								currentPosition += 4;
							}
							else if (currentPosition >= 6 && currentPosition <= 8)
							{
								currentPosition += 4;
							}
							else if (currentPosition == 11)
							{
								currentPosition = 13;
							}
							break;
						case 'L':
							if (
									(currentPosition >= 3 && currentPosition <= 4) ||
									(currentPosition >= 6 && currentPosition <= 9) ||
									(currentPosition >= 11 && currentPosition <= 12)
								)
							{
								currentPosition--;
							}
							
							break;
						case 'R':
							if (
									(currentPosition >= 2 && currentPosition <= 3) ||
									(currentPosition >= 5 && currentPosition <= 8) ||
									(currentPosition >= 10 && currentPosition <= 11)
								)
							{
								currentPosition++;
							}
							break;
							/*
							 * pattern for part 2
									1
								  2 3 4
								5 6 7 8 9
								  A B C
									D
							 */
					}

				}
				result += currentPosition < 10 ? currentPosition.ToString() : ((char)('A' + currentPosition - 10)).ToString();

			}

			Console.WriteLine(result);

		}
	}
}
