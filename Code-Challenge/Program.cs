using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Mediums._3870_Count_Commas_in_Range;

using System.Collections;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var solution = new Solution();

            var result = solution.CountCommas(100000);

            Console.WriteLine($"result: {result}");
        }
    }
}
