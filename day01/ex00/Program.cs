using System;
using System.IO;

namespace ex00
{
	struct ExchengerRate
	{
		public double RUBtoEUR;
		public double RUBtoUSD;
		public double EURtoRUB;
		public double EURtoUSD;
		public double USDtoEUR;
		public double USDtoRUB;
	}
	struct ExchengerSum
    {
    	public double EUR;
		public double RUB;
		public double USD;
    }
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

			double.TryParse(splited_values[0], out value.EUR);
			double.TryParse(splited_values[0], out value.RUB);
			double.TryParse(splited_values[0], out value.USD);

			if (splited_values[1] == "RUB")
			{
				path = path + "/RUB.txt";
				course = File.ReadAllLines(path);
				course[0] = course[0].Replace("USD:", "").Replace(",", ".");
				course[1] = course[1].Replace("EUR:", "").Replace(",", ".");

				double.TryParse(course[0], out rates.RUBtoUSD);
				double.TryParse(course[1], out rates.RUBtoEUR);

				Console.WriteLine("Сумма в исходной валюте: " + value.RUB.ToString("0.00") + " " + splited_values[1]);
				Console.WriteLine("Сумма в USD: " + (value.RUB * rates.RUBtoUSD).ToString("0.00") + " USD");
				Console.WriteLine("Сумма в EUR: " + (value.RUB * rates.RUBtoEUR).ToString("0.00") + " EUR");
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

				Console.WriteLine("Сумма в исходной валюте: " + value.EUR.ToString("0.00") + " " + splited_values[1]);
				Console.WriteLine("Сумма в USD: " + (value.EUR * rates.EURtoUSD).ToString("0.00") + " USD");
				Console.WriteLine("Сумма в RUB: " + (value.EUR * rates.EURtoRUB).ToString("0.00") + " RUB");
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

				Console.WriteLine("Сумма в исходной валюте: " + value.USD.ToString("0.00") + " " + splited_values[1]);
				Console.WriteLine("Сумма в RUB: " + (value.USD * rates.USDtoRUB).ToString("0.00") + " RUB");
				Console.WriteLine("Сумма в EUR: " + (value.USD * rates.USDtoEUR).ToString("0.00") + " EUR");
				return ;
			}
        }
    }
}
