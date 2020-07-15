using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
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

                Register register = new Register();
                Login login = new Login();
                Console.WriteLine("REJSTRACJA - 1");
                Console.WriteLine("LOGOWANIE - 2");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {

                    Console.WriteLine("Podaj nazwę użytkownika: ");
                    register.UserName = Console.ReadLine();
                    jump:
                    Console.WriteLine("Podaj hasło: ");
                    register.Password = Console.ReadLine();
                    Console.WriteLine("Powtórz hasło: ");
                    register.Repeat_Password = Console.ReadLine();
                    if (register.Password == register.Repeat_Password)
                    {
                        Console.WriteLine("Rejstracja przebiegła pomyślnie");
                        Console.Clear();
                        Console.WriteLine(".");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("...");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Podane hasła się nie zgadzają spróbuj jeszcze raz");
                        register.Password = string.Empty;
                        register.Repeat_Password = string.Empty;
                        goto jump;
                    }
                }
                if (x == 2)
                {

                    Console.WriteLine("Wprowadź Login: ");
                    login.UserName = Console.ReadLine();
                    if (login.UserName == register.UserName)
                    {
                        Console.WriteLine("Wrpwadź Hasło: ");
                        login.Password = Console.ReadLine();
                        if (login.Password == register.Password)
                        {
                            Console.WriteLine("Zalogowano pomyślnie");
                            Console.Clear();

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nie udało się zalogować ; (");
                }
                if (login.Password == register.Password && login.UserName == register.UserName)
                {
                    Console.WriteLine("WitaJ");
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
                            Console.WriteLine("Saldo po dokonaniu wypłaty: " + account.Balance + "zł");
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
                        else if (licz == 7)
                        {
                            //Wylogowanie
                        }
                        else
                        {
                            Console.WriteLine("Nie można wykonać tej operacji!");
                        }
                    }
                }
            }
        }
        public static void Interface_of_Choice()
        {

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
            Console.WriteLine("7. Wyloguj");

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
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Repeat_Password { get; set; }
        public Login Login { get; set; }
    }
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}

