using System;

namespace Program
{
    class Program
    {
        static double DecrPay(int term, double sum, double payment, double annuity_payment, double i, 
            int selectedMounth, DateTime now, double rate)
        {
            int day_m;
            int k = 0;
            double per;
            double overpay = 0;

            while (term != 0)
            {
                if (sum <= 0)
                {
                    sum = 0;
                    break;
                }
                if (k == selectedMounth)
                {
                    sum -= payment;
                    annuity_payment = (sum * i * (Math.Pow((1 + i), term))) / (Math.Pow((1 + i), term) - 1);
                }
                day_m = (now.AddMonths(k + 1) - now.AddMonths(k)).Duration().Days;
                per = (sum * rate * day_m) / (100 * 365);
                sum = sum - annuity_payment + per;
                term--;
                overpay += per;
                k++;
            }
            return overpay;
        }
		static double RedTerm(int term, double sum, double payment, double annuity_payment, double i, 
            int selectedMounth, DateTime now, double rate)
		{
			int day_m;
            int k = 0;
            double per;
            double overpay = 0;

			while (term != 0)
            {
                if (sum <= 0)
                {
                    sum = 0;
                    break;
                }
                day_m = (now.AddMonths(k + 1) - now.AddMonths(k)).Duration().Days;
                per = (sum * rate * day_m) / (100 * 365);
                overpay += per;
                sum = sum - annuity_payment + per;
                if (k == selectedMounth - 1)
                {
                    term = (int) Math.Log((annuity_payment / (annuity_payment - i * sum)), (1 + i));
                    sum -= payment;
                }
                term--;
                k++;
            }
			return overpay;
		}
        
        static void Main(string[] args)
        {
            double sum;
            double rate;//процент годовой
            int term;//месяц
            int selectedMounth;//номер месяца досрочного платежа
            double payment;//сумма досрочного платежв
            double annuity_payment;
            double i;//процентная ставка по займу в месяц
            double overpayR;
			double overpayD;
            DateTime now = DateTime.Now;

            if (args.Length != 5)
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                return;
            }

            double.TryParse(args[0], out sum);
            double.TryParse(args[1], out rate);
            Int32.TryParse(args[2], out term);
            Int32.TryParse(args[3], out selectedMounth);
            double.TryParse(args[4], out payment);

            i = rate / 12 / 100;
            annuity_payment = (sum * i * (Math.Pow((1 + i), term))) / (Math.Pow((1 + i), term) - 1);
            overpayD = Math.Round(DecrPay(term, sum, payment, annuity_payment, i, selectedMounth, now,rate), 2);
			overpayR = Math.Round(RedTerm(term, sum, payment, annuity_payment, i, selectedMounth, now,rate), 2);
            Console.WriteLine("Переплата при уменьшении платежа: " + overpayD.ToString("0.00") + "p.");
            Console.WriteLine("Переплата при уменьшении срока: " + overpayR.ToString("0.00") + "p.");

			if (overpayD > overpayR)
				Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на " + (overpayD - overpayR).ToString("0.00") + "p.");
			else if (overpayD < overpayR)
				Console.WriteLine("Уменьшение платежа выгоднее уменьшения срока на " + (overpayD - overpayR).ToString("0.00") + "p.");
			else
				Console.WriteLine("Переплата одинакова в обоих вариантах.");
        }
    }
}