using System;

namespace Candelader_v2
{
    class Program
    {

        static void Daily(DayOfWeek y)
        {
            var now = DateTime.Now.DayOfWeek;
            int weekend = DayOfWeek.Saturday - y;

            if (weekend == 6 || weekend ==0)
            {
                
                if (now == y)
                {
                    Console.WriteLine("your choice: {0}, weekday number: {1}, today is the day of your choice and weekend", y, (int)y);
                }
                else
                {
                    Console.WriteLine("your choice: {0}, weekday number: {1}, it's weekend", y, (int)y);
                }

            }
            else
            {
                
                if (now == y)
                {
                    Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day of your choice", y, (int)y, weekend);
                }
                else
                {
                    Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, (int)y, weekend);
                }

            }

            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Write day of the week");
            var y = DayOfWeek.Monday;
            int now = (int)DateTime.Now.DayOfWeek;
            String day = Console.ReadLine();
            switch (day.ToLower())          //ToLower() для приведения в нижний регистр всего введённого текста
            {
                case "mon" or "monday":
                    Console.ForegroundColor = ConsoleColor.Red;
                    y = DayOfWeek.Monday;
                    Daily(y);
                    break;
                case "tue" or "tuesday":
                    Console.ForegroundColor = ConsoleColor.Green;
                    y = DayOfWeek.Tuesday;
                    Daily(y);
                    break;
                case "wed" or "wednesday":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    y = DayOfWeek.Wednesday;
                    Daily(y);
                    break;
                case "thu" or "thursday":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    y = DayOfWeek.Thursday;
                    Daily(y);
                    break;
                case "fri" or "friday":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    y = DayOfWeek.Friday;
                    Daily(y);
                    break;
                case "sat" or "saturday":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    y = DayOfWeek.Saturday;
                    Daily(y);
                    break;
                case "sun" or "sunday":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    y = DayOfWeek.Sunday;
                    Daily(y);
                    break;
                default:
                    Console.WriteLine("This is not the day of the week");
                    break;

            }
        }
    }
}