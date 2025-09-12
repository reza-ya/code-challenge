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

            //var str = "2+5 * 20/2 -6";
            var str = "0-2147483647";
            //var str = "1-1-1";
            //var str = "1+2*5/3+6/4*2";
            var result = solution.Calculate(str);

            Console.WriteLine($"result: {result}");
        }
    }
}
