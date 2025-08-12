using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Shopping_Offers;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shopingOffer = new Solution();
            int[] price = [2, 5];
            int[][] specials = [[3, 0, 5], [1, 2, 10]];
            int[] needs = [3, 2];
            var result = shopingOffer.ShoppingOffers(price, specials, needs);

            Console.WriteLine($"result: {result}");
        }
    }
}
