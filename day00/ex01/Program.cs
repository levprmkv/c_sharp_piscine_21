using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {
			static int LevenshteinDistance(string string1, string string2)
		{
			if (string1 == null) throw new ArgumentNullException("string1");
			if (string2 == null) throw new ArgumentNullException("string2");
			int diff;
			int[,] m = new int[string1.Length + 1, string2.Length + 1];

			for (int i = 0; i <= string1.Length; i++) 
				m[i, 0] = i;
			for (int j = 0; j <= string2.Length; j++)
				m[0, j] = j;
			for (int i = 1; i <= string1.Length; i++)
			{
				for (int j = 1; j <= string2.Length; j++)
				{
					if (string1[i - 1] == string2[j - 1])
						diff = 0;
					else
						diff = 1;
					m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
				}
			}
			return m[string1.Length, string2.Length];
		}
        static void Main()
        {
			int diff;
			int i;
			string ans;
			int l_dist;
			string name;
			string[] line = File.ReadAllLines("us.txt");
			Console.WriteLine("Enter name: ");
			name = Console.ReadLine();
			Console.WriteLine(name);
			string patterns = "^[a-zA-Z]";
			if (!Regex.IsMatch(name, patterns))
			{
				Console.WriteLine("Your name was not found.");
				return ;
			}

			for (diff = 0; diff < 3; diff++)
			{
				for (i = 0; i < line.Length; i++)
				{
					l_dist = LevenshteinDistance(name, line[i]);
					if (l_dist == diff)
					{
						if (l_dist == 0)
						{
							Console.WriteLine("Hello, " + name + "!");
							return ;
						}
						Console.WriteLine("Did you mean \"" + line[i] + "\"? Y/N");
						ans = Console.ReadLine();
						while (ans != "Y" && ans != "N")
						{
							Console.WriteLine("Did you mean \"" + line[i] + "\"? Y/N");
							ans = Console.ReadLine();
						}
						if (ans == "Y")
						{
							Console.WriteLine("Hello, " + line[i] + "!");
							return ;
						}
					}
				}
			}
			Console.WriteLine("Your name was not found.");
			return ;
        }
    }
}
