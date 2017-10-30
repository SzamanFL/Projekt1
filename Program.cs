using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace Projekt
{
    public class Program
    {
        public static List<string> lista = new List<string>();
        public static List<string> listaS;
        public static Timer timer;
        public static string path = @"D:\Dokumenty\programowanie\C#\Projekt\Zapis\odp.txt";

        static void Main(string[] args)
        {
            TworzPlik();
            Czas();
            Zegar.StartZegara();
            string komenda = "";
            int liczba = 0;
            int staraliczba = 0;
            while (liczba != -10)
            {
                Console.WriteLine("Wpisz numer zadania.");
                liczba = Convert.ToInt32(Console.ReadLine());
                if (liczba > staraliczba)
                {
                    for (int i = 0; i <= liczba; i++)
                    {
                        lista.Add("");
                    }
                    staraliczba = liczba;
                }
                
                if (liczba != -10)
                {
                    Console.WriteLine("Wpisz swoją komendę.");
                    komenda = Console.ReadLine();
                    if (Odczyt(komenda) == true)
                    {
                        if (lista.ElementAtOrDefault(liczba) != "")
                            lista.RemoveAt(liczba);
                        else if (lista.ElementAtOrDefault(liczba) != komenda)
                            lista.RemoveAt(liczba);
                        lista.Insert(liczba, komenda);
                    }
                    else
                        Console.WriteLine("Zla komenda");
                }
            }
            Console.ReadKey();
        }

        public static void TworzPlik()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter ws = File.CreateText(path))
                {
                    ws.WriteLine(" ");
                    ws.Close();
                }
            }
            else
            {
                using (StreamWriter ws = File.CreateText(path))
                {
                    ws.WriteLine(" ");
                    ws.Close();
                }
            }
        }

        public static void Czas()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 30000;
            timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            listaS = new List<string>(lista);
            for (int i = 0; i < listaS.Count; i++)
            {
                listaS.RemoveAll(intem => intem == "");
            }
            File.WriteAllLines(path, listaS);
        }

        public static bool Odczyt(string zapytanie)
        {
            if (zapytanie.Contains("SELECT") && zapytanie.Contains("FROM"))
            {
                if (zapytanie.Contains("WHERE") || zapytanie.Contains("ORDER BY"))
                {
                    string tymczasowe = zapytanie;
                    for (dynamic i = 0, nowe = new string[,] { { "SELECT", "1" }, { "FROM", "2" }, { "WHERE", "3" }, { "ORDER BY", "4" } }; i < nowe.Length / 2; i++)
                        tymczasowe = tymczasowe.Replace(nowe[i, 0], nowe[i, 1]);
                    string justNumbers = new String(tymczasowe.Where(Char.IsDigit).ToArray());
                    bool wyr = false;
                    if (tymczasowe.IndexOf("1") == 0) wyr = true;
                    bool czyDobrze = Enumerable.SequenceEqual(justNumbers.OrderBy(x => x), justNumbers);
                    if (czyDobrze == true && wyr==true)
                        return true;
                    else
                        return false;
                }
                else
                {
                    string tymczasowe = zapytanie;
                    for (dynamic i = 0, repl = new string[,] { { "SELECT", "1" }, { "FROM", "2" }, { "WHERE", "3" }, { "ORDER BY", "4" } }; i < repl.Length / 2; i++)
                    {
                        tymczasowe = tymczasowe.Replace(repl[i, 0], repl[i, 1]);
                    }
                    string justNumbers = new String(tymczasowe.Where(Char.IsDigit).ToArray());
                    bool wyr = false;
                    bool sorted1 = Enumerable.SequenceEqual(justNumbers.OrderBy(x => x), justNumbers);
                    if (tymczasowe.IndexOf("1") == 0) wyr = true;
                    if (sorted1 == true && wyr == true)
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }
    }

}
/*class Program
{
    public static List<string> lista = new List<string>();
    public static List<string> listaS;
    public static Timer timer;
    public static string path = @"D:\Dokumenty\programowanie\C#\Projekt\Zapis\odp.txt";
    static void Main(string[] args)
    {
        TworzPlik();
        Zegar.StartZegara();
        Czas();
        string komenda = "";
        int liczba = 0;
        int staraliczba = 0;
        while (liczba != -10)
        {
            Console.WriteLine("Wpisz numer zadania.");
            liczba = Convert.ToInt32(Console.ReadLine());
            if (liczba > staraliczba)
            {
                for (int i = 0; i <= liczba; i++)
                {
                    lista.Add("");
                }
                staraliczba = liczba;
            }

            if (liczba != -10)
            {
                Console.WriteLine("Wpisz swoją komendę.");
                komenda = Console.ReadLine();
                if (Odczyt(komenda) == true)
                {
                    if (lista.ElementAtOrDefault(liczba) != "")
                        lista.RemoveAt(liczba);
                    else if (lista.ElementAtOrDefault(liczba) != komenda)
                        lista.RemoveAt(liczba);
                    lista.Insert(liczba, komenda);
                }
                else
                    Console.WriteLine("Zla komenda");
            }

        }/*
        for (int i= 0;i< lista.Capacity;i++)
        {
            lista.RemoveAll(intem => intem=="");
        }
        File.WriteAllLines(path, lista);
        Console.ReadKey();
    }

    public static void Zapis(List<string> listaS)
    {
            File.WriteAllLines(path, listaS);
    }

    public static void TworzPlik()
    {
        if (!File.Exists(path))
        {
            using (StreamWriter ws = File.CreateText(path))
            {
                ws.WriteLine(" ");
                ws.Close();
            }
        }
        else
        {
            using (StreamWriter ws = File.CreateText(path))
            {
                ws.WriteLine(" ");
                ws.Close();
            }
        }
    }

    public static void Czas()
    {
        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(timer_Tick);
        timer.Interval = 30000;
        timer.Start();
    }

    private static void timer_Tick(object sender, EventArgs e)
    {
        listaS = new List<string>(lista);
        for (int i = 0; i < listaS.Count; i++)
        {
            listaS.RemoveAll(intem => intem == "");
        }
        File.WriteAllLines(path, listaS);
    }

    static bool Odczyt(string zapytanie)
    {
        if (zapytanie.Contains("SELECT") && zapytanie.Contains("FROM"))
        {
            if (zapytanie.Contains("WHERE") || zapytanie.Contains("ORDER BY"))
            {
                string tymczasowe = zapytanie;
                for (dynamic i = 0, nowe = new string[,] { { "SELECT", "1" }, { "FROM", "2" }, { "WHERE", "3" }, { "ORDER BY", "4" } }; i < nowe.Length / 2; i++)
                    tymczasowe = tymczasowe.Replace(nowe[i, 0], nowe[i, 1]);
                string justNumbers = new String(tymczasowe.Where(Char.IsDigit).ToArray());
                bool czyDobrze = Enumerable.SequenceEqual(justNumbers.OrderBy(x => x), justNumbers);
                if (czyDobrze == true)
                    return true;
                else
                    return false;
            }
            else
            {
                string tymczasowe = zapytanie;
                for (dynamic i = 0, repl = new string[,] { { "SELECT", "1" }, { "FROM", "2" }, { "WHERE", "3" }, { "ORDER BY", "4" } }; i < repl.Length / 2; i++)
                {
                    tymczasowe = tymczasowe.Replace(repl[i, 0], repl[i, 1]);
                }
                string justNumbers = new String(tymczasowe.Where(Char.IsDigit).ToArray());
                bool sorted1 = Enumerable.SequenceEqual(justNumbers.OrderBy(x => x), justNumbers);
                if (sorted1 == true)
                    return true;
                else
                    return false;
            }
        }
        else
            return false;
    }
}*/




