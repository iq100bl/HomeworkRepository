using System;

namespace string5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entered text");
            var text = Console.ReadLine();
            var number = 0;
            string[] words = text.Split(new char[] { ' ' });

            foreach (string s in words)
            {
                number++;
            }
            Console.WriteLine("Total number of words in the string is: " + number);
        }
    }
}
