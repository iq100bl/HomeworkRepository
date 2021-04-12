using System;

namespace array4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 15, 10, 12 };
            int[] copy = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                copy[i] = mass[i];
            }
            Console.WriteLine("The elements stored in the first array are : ");
            foreach (int i in mass)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\r\n"+ "The elements copied into the second array are : ");
            foreach (int i in copy)
            {
                Console.Write(i + " ");
            }
        }
    }
}
