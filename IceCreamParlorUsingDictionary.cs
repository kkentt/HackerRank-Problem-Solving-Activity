using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProblemSolving
{
    class IceCreamParlorUsingDictionary
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int money = Convert.ToInt32(Console.ReadLine());

                int n = Convert.ToInt32(Console.ReadLine());

                int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp));

                var resultIndex = WhatFlavors(cost, money);
                Console.WriteLine((resultIndex[0] + 1) + " " + (resultIndex[1] + 1));
                Console.ReadKey();
            }
        }

        private static int[] WhatFlavors(int[] cost, int money)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < cost.Length; i++)
            {
                int complement = money - cost[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map.FirstOrDefault(x => x.Key == complement).Value, i };
                }
                map.Add(cost[i], i);
            }

            return null;
        }
    }
}

//Dictionary<int, int> map = new Dictionary<int, int>();
//for (int i = 0; i < cost.Length; i++)
//{
//    map.Add(i, cost[i]);
//}
//for (int i = 0; i < cost.Length; i++)
//{
//    int complement = money - cost[i];
//    var key =  map.FirstOrDefault(x => x.Value == complement).Key;
//    if (map.ContainsValue(complement) && key != i)
//    {
//        if( key > i)
//        {
//            return new int[] { i, key };
//        }
//        else
//        {
//            return new int[] { key, i };
//        }
//    }
//}
//return null;