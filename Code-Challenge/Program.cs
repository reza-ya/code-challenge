using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Mediums._198_House_Robber;

using System.Collections;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var solution = new Solution();

            //var houses = new int[] { 1, 2, 3, 1 };
            var houses = new int[] { 0, 0, 0, 1 };

            var result = solution.Rob(houses);

            Console.WriteLine($"result: {result}");
        }
    }
}
