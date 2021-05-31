using System;
using System.IO;
using Models;

namespace ex00
{
    class Program
    {
        static void Main(string[] args)
        {
			ExchengerSum value = new ExchengerSum();
			ExchengerRate rates = new ExchengerRate();
			string[] splited_values;
			string[] course;
			string path;
		
			splited_values = args[0].Split(' ');
			path = args[1];

			double.TryParse(splited_values[0], out value.SUM);

			Console.WriteLine("Сумма в исходной валюте: " + value.SUM.ToString("0.00") + " " + splited_values[1]);
			
			if (splited_values[1] == "RUB")
			{
				path = path + "/RUB.txt";
				course = File.ReadAllLines(path);
				course[0] = course[0].Replace("USD:", "").Replace(",", ".");
				course[1] = course[1].Replace("EUR:", "").Replace(",", ".");

				double.TryParse(course[0], out rates.RUBtoUSD);
				double.TryParse(course[1], out rates.RUBtoEUR);

				Console.WriteLine("Сумма в USD: " + (value.SUM * rates.RUBtoUSD).ToString("0.00") + " USD");
				Console.WriteLine("Сумма в EUR: " + (value.SUM * rates.RUBtoEUR).ToString("0.00") + " EUR");
				return ;
			}
			else if (splited_values[1] == "EUR")
			{
				path = path + "/EUR.txt";
				course = File.ReadAllLines(path);
				course[0] = course[0].Replace("USD:", "").Replace(",", ".");
				course[1] = course[1].Replace("RUB:", "").Replace(",", ".");

				double.TryParse(course[0], out rates.EURtoUSD);
				double.TryParse(course[1], out rates.EURtoRUB);

				Console.WriteLine("Сумма в USD: " + (value.SUM * rates.EURtoUSD).ToString("0.00") + " USD");
				Console.WriteLine("Сумма в RUB: " + (value.SUM * rates.EURtoRUB).ToString("0.00") + " RUB");
				return ;
			}
			else if (splited_values[1] == "USD")
			{
				path = path + "/USD.txt";
				course = File.ReadAllLines(path);
				course[0] = course[0].Replace("RUB:", "").Replace(",", ".");
				course[1] = course[1].Replace("EUR:", "").Replace(",", ".");

				double.TryParse(course[0], out rates.USDtoRUB);
				double.TryParse(course[1], out rates.USDtoEUR);

				Console.WriteLine("Сумма в RUB: " + (value.SUM * rates.USDtoRUB).ToString("0.00") + " RUB");
				Console.WriteLine("Сумма в EUR: " + (value.SUM * rates.USDtoEUR).ToString("0.00") + " EUR");
				return ;
			}
        }
    }
}
