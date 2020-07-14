using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Bank
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            while (true)
            {
                
                Userview();
                Account account = new Account();
                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Wybierz co chcesz zrobić i zatwierdź naciskając ENTER : ");
                    int licz = int.Parse(Console.ReadLine());

                    if (licz == 1)
                    {
                        Back();
                        Console.WriteLine();
                        Console.WriteLine("Witamy w aplikacji bankowej twoj obecny stan konta wynosi:" + account.Balance + "zł");
                    }
                    else if (licz == 2)
                    {
                        Back();
                        Console.Write("Podaj kwotę wpałaty: ");
                        account.Payment = int.Parse(Console.ReadLine());
                        account.Balance += account.Payment;
                        Console.WriteLine("Saldo po dokanoaniu wpłaty " + account.Balance + "zł");
                    }
                    else if (licz == 3)
                    {
                        Back();
                        Console.Write("Jaką kwotę chcesz wypłacić: ");
                        account.Payoff = int.Parse(Console.ReadLine());
                        account.Balance -= account.Payoff;
                        Console.WriteLine("Saldo po dokonaniu wypłaty" + account.Balance + "zł");
                    }
                    else if (licz == 4)
                    {

                    }
                    else if (licz == 5)
                    {
                        Back();
                    }
                    else if (licz == 6)
                    {
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Nie można wykonać tej operacji!");
                    }
                }
            }

        }
        public static void Userview()
        {
            Console.Write("\t MENU");

            Console.WriteLine();
            Console.WriteLine("1. Wejdź na konto bankowe");
            Console.WriteLine("2. Wpłać pieniądze");
            Console.WriteLine("3. Wypłać pieniądze");
            Console.WriteLine("4. Zarządzać stopą procentową");
            Console.WriteLine("5. Cofnij");
            Console.WriteLine("6. Zamknij program");

        }
        public static void Back()
        {
            Console.Clear();
            Userview();
        }
    }
    public class Account
    {
        public int Balance { get; set; }
        public int Payment { get; set; }
        public int Payoff { get; set; }
        public int Interest_rate { get; set; }
    }
    public class DisplayClock
    {
        public static async void ShowTime()
        {
            for (; ; )
            {
                await Task.Run(ShowTime);

                var showtime = DateTime.Now.ToString();

                Console.Write(showtime);

                Thread.Sleep(1000);

                ClearCurrentConsoleLine();
            }
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0 , Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0 , currentLineCursor);
        }
    }
}

