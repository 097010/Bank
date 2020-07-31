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
using System.Text.RegularExpressions;
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
                List<Register> Registered_Users = new List<Register>();
                Register register = new Register();
                Login login = new Login();
                jump2:
                Console.Write("Naciśnij 1 by się zarejestrować lub 2 by zalogować: ");
                int a = int.Parse(Console.ReadLine());

                if (a == 1)
                {
                    Console.Write("Podaj nazwę urzytkownika: ");
                    register.UserName = Console.ReadLine();
                    jump:
                    Console.Write("Podaj hasło: ");
                    register.Password = string.Empty;
                    ConsoleKey key;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;

                        if (key == ConsoleKey.Backspace && register.Password.Length > 0)
                        {
                            Console.Write("\b \b");
                            register.Password = register.Password[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            register.Password += keyInfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);
                    Console.WriteLine();
                    Console.Write("Powtórz hasło: ");
                    register.Repeat_Password = string.Empty;
                    ConsoleKey key1;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key1 = keyInfo.Key;

                        if (key1 == ConsoleKey.Backspace && register.Repeat_Password.Length > 0)
                        {
                            Console.Write("\b \b");
                            register.Repeat_Password = register.Repeat_Password[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            register.Repeat_Password += keyInfo.KeyChar;
                        }
                    } while (key1 != ConsoleKey.Enter);

                    if (register.Password == register.Repeat_Password)
                    {
                        Registered_Users.Add(new Register
                        {
                            UserName = register.UserName,
                            Password = register.Password
                        });
                        Console.Clear();
                        Console.WriteLine("Zarejestrowano pomyślnie");
                    }
                    else if (register.Password != register.Repeat_Password)
                    {
                        Console.Clear();
                        Console.WriteLine("Hasła nie są takie same!");
                        goto jump;
                    }
                    goto jump2;
                }
                else if (a == 2)
                {
                    Console.Write("Wprowadź Login: ");
                    login.UserName = Console.ReadLine();
                    Console.Write("Podaj hasło: ");
                    login.Password = string.Empty;
                    ConsoleKey key2;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key2 = keyInfo.Key;

                        if (key2 == ConsoleKey.Backspace && login.Password.Length > 0)
                        {
                            Console.Write("\b \b");
                            login.Password  = login.Password[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            login.Password += keyInfo.KeyChar;
                        }
                    } while (key2 != ConsoleKey.Enter);
                    WaitingScreen();
                    Console.Clear();
                    if (login.Password == register.Password && login.UserName == register.UserName)
                    {
                        Console.WriteLine("Witaj " + register.UserName);
                        Userview();
                        while (true)
                        {
                            Account account = new Account();
                            Console.WriteLine();
                            Console.Write("Wybierz co chcesz zrobić i zatwierdź naciskając ENTER : ");
                            int licz = int.Parse(Console.ReadLine());

                            if (licz == 1)
                            {
                                Back();
                                Console.WriteLine();
                                Console.WriteLine("Witamy w aplikacji bankowej twoj obecny stan konta wynosi: " + account.Balance + "zł");
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
                                DisplayClock.ShowTime();
                                Back();
                            }
                            else if (licz == 8)
                            {
                                //Wylogowanie
                            }
                            else
                            {
                                Console.WriteLine("Nie można wykonać tej operacji!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login lub hasło jest nieprawidłowe");
                    }
                }
                else
                {
                    Console.WriteLine("Błąd operacji");
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
            Console.WriteLine("1. Zobacz stan konta");
            Console.WriteLine("2. Wpłać pieniądze");
            Console.WriteLine("3. Wypłać pieniądze");
            Console.WriteLine("4. Zarządzać stopą procentową");
            Console.WriteLine("5. Cofnij");
            Console.WriteLine("6. Zamknij program");
            Console.WriteLine("7. Wyświetl aktualną godzinę");
            Console.WriteLine("8. Wyloguj");
        }
        public static void WaitingScreen()
        {
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
        public static void ShowTime()
        {
            for (int i = 0; i < 5; i++)
            {
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
        public Register Register { get; set; }
    }
}

