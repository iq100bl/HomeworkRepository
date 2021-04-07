using System;

namespace Candelader_v2
{
    class Program
    {
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
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day you entered", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    Console.ResetColor();
                    break;
                case "tue" or "tuesday":
                    Console.ForegroundColor = ConsoleColor.Green;
                    y = DayOfWeek.Tuesday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day you entered", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    Console.ResetColor();
                    break;
                case "wed" or "wednesday":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    y = DayOfWeek.Wednesday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day you entered", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    Console.ResetColor();
                    break;
                case "thu" or "thursday":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    y = DayOfWeek.Thursday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day you entered", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    Console.ResetColor();
                    break;
                case "fri" or "friday":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    y = DayOfWeek.Friday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day you entered", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", y, Convert.ToByte(y), 6 - Convert.ToByte(y));
                    }
                    Console.ResetColor();
                    break;
                case "sat" or "saturday":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    y = DayOfWeek.Saturday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2}, today is the day you entered ", y, Convert.ToByte(y), "Weekend");
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} ", y, Convert.ToByte(y), "Weekend");
                    }
                    Console.ResetColor();
                    break;
                case "sun" or "sunday":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    y = DayOfWeek.Sunday;
                    y = DayOfWeek.Saturday;
                    if (now == Convert.ToInt32(y))
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2}, today is the day you entered ", y, Convert.ToByte(y), "Weekend");
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} ", y, Convert.ToByte(y), "Weekend");
                    }
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine("This is not the day of the week");
                    break;

            }
        }
    }
}