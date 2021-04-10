using System;

namespace array
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] task1 = new int[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Elements in array are:");
            
            foreach (int i in task1)
            {
                Console.Write(i+" ");
            }
        }
    }
}
