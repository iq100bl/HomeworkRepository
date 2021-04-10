using System;

namespace Candelader_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write day of the week");
            int now = (int)DateTime.Now.DayOfWeek;
            String day = Console.ReadLine();
            var colorDay = ConsoleColor.Red;
            switch (day.ToLower())
            {
                case "mon" or "monday":
                    colorDay = ConsoleColor.Red;
                    EnteredDay(DayOfWeek.Monday, colorDay);
                    break;
                case "tue" or "tuesday":
                    colorDay = ConsoleColor.Green;
                    EnteredDay(DayOfWeek.Tuesday, colorDay);
                    break;
                case "wed" or "wednesday":
                    colorDay = ConsoleColor.Yellow;
                    EnteredDay(DayOfWeek.Wednesday, colorDay); ;
                    break;
                case "thu" or "thursday":
                    colorDay = ConsoleColor.Magenta;
                    EnteredDay(DayOfWeek.Thursday, colorDay); ;
                    break;
                case "fri" or "friday":
                    colorDay = ConsoleColor.DarkCyan;
                    EnteredDay(DayOfWeek.Friday, colorDay);
                    break;
                case "sat" or "saturday":
                    colorDay = ConsoleColor.Blue;
                    EnteredDay(DayOfWeek.Saturday, colorDay);
                    break;
                case "sun" or "sunday":
                    colorDay = ConsoleColor.DarkYellow;
                    EnteredDay(DayOfWeek.Sunday, colorDay);
                    break;
                default:
                    Console.WriteLine("This is not the day of the week");
                    break;

            }

            static void EnteredDay(DayOfWeek days, ConsoleColor colorDay)
            {
                var now = DateTime.Now.DayOfWeek;
                int weekend = DayOfWeek.Saturday - days;
                Console.ForegroundColor = colorDay;
                if (weekend == 6 || weekend == 0)
                {

                    if (now == days)
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, it's weekend", days, (int)days);
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, today is the day of your choice and weekend", days, (int)days);
                    }

                }
                else
                {

                    if (now == days)
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s),today is the day of your choice", days, (int)days, weekend);
                    }
                    else
                    {
                        Console.WriteLine("your choice: {0}, weekday number: {1}, untill weekend: {2} day(s)", days, (int)days, weekend);
                    }

                }

                Console.ResetColor();
            }
        }
    }
}