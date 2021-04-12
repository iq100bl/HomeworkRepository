using System;

namespace array2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] mass = { 2, 5, 7 };
            Console.WriteLine("The values store into the array are: ");
            InOrder(mass);
            Console.WriteLine("\r\n" + "The values store into the array in reverse are : ");
            Revers(mass);
        }

        public static void InOrder(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write(mass[i] + " ");
            }
        }

        private static void Revers(int[] mass)
        {
            for (int i = mass.Length - 1; i > -1; i--)
            {
                Console.Write(mass[i] + " ");
            }
        }
    }
}
