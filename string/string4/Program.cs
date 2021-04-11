using System;

namespace string4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entered text");
            var text = Console.ReadLine();
            Console.Write("The characters of the string in reverse are : ");
            var i = text.Length-1;
            do
            {
                Console.Write(text[i] + " ");
                i--;
            }
            while (i >= 0);
        }
    }
}
