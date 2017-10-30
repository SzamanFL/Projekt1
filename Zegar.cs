using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Zegar
    {
        private static Timer timer;
        public static void StartZegara()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(SprawdzqczCzasu);
            timer.Interval = 60000; // in miliseconds
            timer.Start();
        }
        private static void SprawdzqczCzasu(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            DayOfWeek day = DateTime.Now.DayOfWeek;
            if ((day != DayOfWeek.Saturday) || (day != DayOfWeek.Sunday))
            {
                do
                {
                    startTime = DateTime.Now;
                } while (startTime.Second != 0);
                DateTime endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 9, 45, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 10, 0, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 11, 30, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 11, 45, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 13, 15, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 13, 45, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 15, 15, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 15, 30, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 17, 0, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 17, 15, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 18, 45, 0);
                if (startTime <= endTime)
                {
                    TimeSpan span = endTime.Subtract(startTime);
                    Console.WriteLine("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                Console.WriteLine("Nie ma juz zajec");
            }
            else
            {
                Console.WriteLine("Jest weekend co Ty robisz?");
            }
        }
    }
}