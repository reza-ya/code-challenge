using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Mediums._227_Basic_Calculator_II;

using System.Collections;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var solution = new Solution();

            var str = "3+2*2";
            var result = solution.Calculate(str);

            Console.WriteLine($"result: {result}");
        }
    }
}
