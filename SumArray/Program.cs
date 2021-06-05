using System;
using System.Collections.Generic;

namespace SumArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> r1 = new List<int>(){11, 2, 4};
            List<int> r2 = new List<int>(){4, 5, 6};
            List<int> r3 = new List<int>(){10, 8, -12 };
            
            List<List<int>> arr = new List<List<int>>(){r1, r2, r3};

            int dLeft = 0;
            int dRight = 0;
        
            System.Console.WriteLine($"dLeft: {dLeft}\ndRight: {dRight}");
            for(int i = 0; i < arr.Count; i++)
            {
                
                for(int j = 0; j < arr[i].Count; j++)
                {
                    if (i == j)
                        dLeft += arr[i][j];

                    Console.Write(arr[i][j] + " ");

                }
                dRight += arr[i][arr.Count - i - 1];
                Console.WriteLine();
            }

            Console.WriteLine($"dLeft = {dLeft}");
            Console.WriteLine($"dRight = {dRight}");

            int dif = Math.Abs(dLeft - dRight);
            Console.WriteLine("Difference: " + dif);


        }
    }
}
