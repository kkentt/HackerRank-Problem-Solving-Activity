using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    class IceCreamParlor
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int money = Convert.ToInt32(Console.ReadLine());

                int n = Convert.ToInt32(Console.ReadLine());

                int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp))
                ;
                whatFlavors(cost, money);
            }
        }

        private static void whatFlavors(int[] cost, int money)
        {
            int[] sortedCost = (int[])cost.Clone();
            Array.Sort(sortedCost);

            for (int i = 0; i < sortedCost.Length; i++)
            {
                int complement = money - sortedCost[i];
                if (i < sortedCost.Length-1)
                {
                    int complementIndex = Array.BinarySearch(sortedCost, i + 1, sortedCost.Length - i-1  , complement);
                    if (complementIndex >= 0 && complementIndex < sortedCost.Length)
                    {
                        int[] resultIndex = new int[2];
                        resultIndex = GetIndexes(cost, firstValue: sortedCost[i], secondValue: complement);
                        Array.Sort(resultIndex);
                        Console.WriteLine( (resultIndex[0]+1) + " " +  (resultIndex[1]+1));
                        Console.ReadKey();
                    }
                }
            }
        }

        private static int[] GetIndexes(int[] cost, int firstValue, int secondValue)
        {
            int[] result = new int[2];
            var firstIndex = Array.IndexOf(cost, firstValue);
            var secondIndex = Array.IndexOf(cost, secondValue);
            if (firstIndex == secondIndex)
            {
                secondIndex = Array.LastIndexOf(cost, secondValue);
            }
            result[0] = firstIndex;
            result[1] = secondIndex;

            return result;
        }
    }
}
