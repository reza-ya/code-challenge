using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode._347_Top_K_Frequent_Elements;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var solution = new Solution();




            //var result = solution.TopKFrequent([1, 1, 1, 2, 2, 3], 2);
            var result = solution.TopKFrequent([4, 1, -1, 2, -1, 2, 3], 2);

            Console.WriteLine($"result: {result}");
        }
    }
}
