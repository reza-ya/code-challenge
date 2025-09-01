using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Mediums._3348_Smallest_Divisible_Digit_Product_II;

using System.Collections;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var solution = new Solution();

            
            var result = solution.SmallestNumber("1234", 256);

            Console.WriteLine($"result: {result}");
        }
    }
}
