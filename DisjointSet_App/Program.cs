using System;

namespace DisjointSet_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // .. {2} {1} {0} هنا كونا النود كل وحده تشير لنفسها 
            var disjointSet = new DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

            disjointSet.Union(5, 6);  // 5 <- 6      {5,6}
            disjointSet.Union(1, 2);  // 1 <- 2      {1,2}
            disjointSet.Union(0, 2);  // 1 <- 0 , 2  {1,2,0}  Ranka gore

            for (int i = 0; i < 7; i++)
            {
                // find ترجع لنا الممثل او الجذر للعنصر
                Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
            }

            Console.ReadKey();
        }
    }

}
