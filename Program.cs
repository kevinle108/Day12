using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Sums(10);
        }

        static void Sums(int n)
        {
            Sums(n, new List<int>());
        }

        static void Sums(int n, List<int> result)
        {
            if (n == 0)
            {
                PrintSums(result);
                return;
            }
            int max = n; 
            if (result.Count > 0 && n > result.Last()) max = result.Last();
            for (int i = max; i > 0; i--)
            {
                result.Add(i);
                Sums(n - i, result);
                result.RemoveAt(result.Count - 1);
            }
        }

        static void PrintSums(List<int> result)
        {
            Console.WriteLine(String.Join('+', result)); ;         
        }
    }
}
