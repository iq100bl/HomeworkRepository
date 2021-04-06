using System;

namespace Candelader //первая версия простого приложения
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write day of the week");
            String day = Console.ReadLine();
            switch (day.ToLower())          //ToLower() для приведения в нижний регистр всего введённого текста
            {
                case "mon" or "monday":
                    Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Monday");
                    Console.ResetColor();
                    break;
                case "tue" or "tuesday":
                    Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Tuesday");
                    Console.ResetColor();
                    break;
                case "wed" or "wednesday":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Wednesday");
                    Console.ResetColor();
                    break;
                case "thu" or "thursday":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Thursday");
                    Console.ResetColor();
                    break;
                case "fri" or "friday":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Friday");
                    Console.ResetColor();
                    break;
                case "sat" or "saturday":
                    Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Saturday");
                    Console.ResetColor();
                    break;
                case "sun" or "sunday":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Sunday");
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine("This is not the day of the week");
                    break;

            }
        }
    }
}
