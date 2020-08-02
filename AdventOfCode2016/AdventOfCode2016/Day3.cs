using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2016
{
	class Day3
	{
		public static void Problem1()
		{
			var inputText = FileReader.ReadLines("");

			int triangleCount = 0;
			foreach(string line in inputText)
			{
				
				var a = Convert.ToInt32(line.Substring(0,5).Trim());
				var b = Convert.ToInt32(line.Substring(5,5).Trim());
				var c = Convert.ToInt32(line.Substring(10,5).Trim());

				if (Math.Max(a, Math.Max(b,c)) < ((a + b + c +1) / 2)) triangleCount++;

			}

			Console.WriteLine(triangleCount);

		}

		public static void Problem2()
		{
			var inputText = FileReader.ReadLines("");

			int triangleCount = 0;

			for(int i = 0; i < inputText.Count; i += 3)
			{
				

				var a0 = Convert.ToInt32(inputText[i].Substring(0, 5).Trim());
				var b0 = Convert.ToInt32(inputText[i].Substring(5, 5).Trim());
				var c0 = Convert.ToInt32(inputText[i].Substring(10, 5).Trim());
				var a1 = Convert.ToInt32(inputText[i+1].Substring(0, 5).Trim());
				var b1 = Convert.ToInt32(inputText[i+1].Substring(5, 5).Trim());
				var c1 = Convert.ToInt32(inputText[i+1].Substring(10, 5).Trim());
				var a2 = Convert.ToInt32(inputText[i+2].Substring(0, 5).Trim());
				var b2 = Convert.ToInt32(inputText[i+2].Substring(5, 5).Trim());
				var c2 = Convert.ToInt32(inputText[i+2].Substring(10, 5).Trim());
				if (Math.Max(a0, Math.Max(a1, a2)) < ((a0 + a1 + a2 + 1) / 2)) triangleCount++;
				if (Math.Max(b0, Math.Max(b1, b2)) < ((b0 + b1 + b2 + 1) / 2)) triangleCount++;
				if (Math.Max(c0, Math.Max(c1, c2)) < ((c0 + c1 + c2 + 1) / 2)) triangleCount++;

			}

			Console.WriteLine(triangleCount);
		}

	}
}
