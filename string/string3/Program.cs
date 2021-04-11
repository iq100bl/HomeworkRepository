using System;

namespace string3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entered text");
            var text = Console.ReadLine();
            Console.Write("The characters of the string are : ");
            var i = 0;
            do
            {
                Console.Write(text[i] + " ");
                i++;
            }
            while (i < text.Length);
        }
    }
}
