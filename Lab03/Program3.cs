using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            double exchng;
            Console.WriteLine("Введите значение для конвертации валют:");
            
            exchng = double.Parse(Console.ReadLine());
            Currency.Exchange = exchng;

            CurrencyUSD usd = new CurrencyUSD(100);
            CurrencyEUR eur = (CurrencyEUR)usd;
            CurrencyRUB rub = (CurrencyRUB)usd;

            Console.WriteLine($"USD: {usd.Value}");
            Console.WriteLine("EUR:" + eur.Value);
            Console.WriteLine("Rub:" + rub.Value);
        }
    }

    public class Currency
    {
        public double Value { get; set; }
        public static double Exchange { get; set; }

        public Currency(double value) 
        {
            this.Value = value;
        }
    }

    public class CurrencyUSD : Currency
    {
        public CurrencyUSD(double value) : base(value) { }

        public static explicit operator CurrencyEUR(CurrencyUSD usd)
        {
            double eur = usd.Value/Currency.Exchange;
            return new CurrencyEUR(eur);
        }

        public static explicit operator CurrencyRUB(CurrencyUSD usd)
        {
            double rub = usd.Value * Currency.Exchange;
            return new CurrencyRUB(rub);
        }
    }

    public class CurrencyEUR : Currency
    {
        public CurrencyEUR(double value) : base(value) { }

        public static explicit operator CurrencyRUB(CurrencyEUR eur)
        {
            double rub = eur.Value * Currency.Exchange;
            return new CurrencyRUB(rub);
        }

        public static explicit operator CurrencyUSD(CurrencyEUR eur) 
        {
            double usd = eur.Value * Currency.Exchange;
            return new CurrencyUSD(usd);
        }

    }

    public class CurrencyRUB : Currency
    {
        public CurrencyRUB (double value) : base(value) { }

        public static explicit operator CurrencyUSD(CurrencyRUB rub)
        {
            double usd = rub.Value * Currency.Exchange;
            return new CurrencyUSD (usd);
        }

        public static explicit operator CurrencyEUR(CurrencyRUB rub)
        {
            double eur = rub.Value * Currency.Exchange;
            return new CurrencyEUR(eur);
        }
    }
}
