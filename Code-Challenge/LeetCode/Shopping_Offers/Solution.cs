using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Shopping_Offers
{
    public class Solution
    {
        int _globalPrice = int.MaxValue;

        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {

            if (price.All(price => price == 0)) 
            {
                return 0;
            }

            if (needs.All(n => n == 0))
            {
                return 0;
            }

            int n = price.Count - 1;
            int offerPrice = n + 1;
            int offerColumnCount = special[0].Count;

            int[][] offers = new int[special.Count + price.Count][];
            for(int i =  0; i < special.Count + price.Count; i ++)
            {
                offers[i] = new int[offerColumnCount];
            }
            
            // add special-offers to the offers 
            for(int i = 0; i < special.Count; i++)
            {
                // add each row to the offers
                for (int j = 0; j < special[i].Count - 1; j++)
                {
                    offers[i][j] = special[i][j];

                }
                offers[i][offerPrice] = special[i][offerPrice];
            }

            // add normal price to the offers to make it general
            for(int i = 0; i < price.Count; i++)
            {
                for(int j = 0; j < price.Count; j++)
                {
                    if (i == j)
                    {
                        offers[special.Count + i][j] = 1;
                    }
                    else
                    {
                        offers[special.Count + i][j] = 0;
                    }
                }

                offers[special.Count + i][offerPrice] = price[i];
            }


            List<int[]> listOffers = offers.ToList();
            var offersForFirstNode = _calcNewOffersBaseOnNeed(needs, listOffers);

            var stack = new Stack<Node>();
            stack.Push(new Node(needs, offersForFirstNode, 0));

            var visited = new HashSet<string>();
            visited.Add($"{string.Join(',', needs)}:{0}");


            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();
                //Console.WriteLine($"stack.Count: {stack.Count()}");
                //Console.WriteLine($"currentNode.Needs: {currentNode.NeedsKey}");
                //Console.WriteLine($"currentNode.Price: {currentNode.Price}");
                //for(int i = 0; i < currentNode.Offers.Count; i++)
                //{
                //    Console.WriteLine($"currentNode.Offers:");
                //    Console.WriteLine($"offers[{i}]: {string.Join(',', currentNode.Offers[i])}");
                //}
                //Console.WriteLine();
                //Console.WriteLine();
                for (int i = 0; i < currentNode.Offers.Count; i++)
                {
                    var newNode = _purchase(currentNode.Needs, currentNode.Offers, i, currentNode.Price);
                    if(newNode.Needs.All(n => n == 0))
                    {
                        if (newNode.Price < _globalPrice)
                        {
                            _globalPrice = newNode.Price;
                        }
                        continue;
                    }

                    if (!visited.Add($"{newNode.NeedsKey}:{newNode.Price}"))
                    {
                        continue;
                    }

                    stack.Push(newNode);
                }
            }


            return _globalPrice;
        }

        private Node _purchase(IList<int> needs, List<int[]> offers, int purchaseIndex, int currentPurchasePrice)
        {
            var newNeed = new int[needs.Count];

            for (int i = 0; i < needs.Count; i++)
            {
                newNeed[i] = needs[i] - offers[purchaseIndex][i];
            }

            var newOffers = _calcNewOffersBaseOnNeed(newNeed, offers);

            return new Node(newNeed, newOffers, currentPurchasePrice + offers[purchaseIndex][newNeed.Length]);
        }

        private List<int[]> _calcNewOffersBaseOnNeed(IList<int> needs, List<int[]> offers)
        {
            List<int[]> newOffers = new List<int[]>();

            for (int i = 0; i < offers.Count; i++)
            {
                bool canPurchase = true;
                for (int j = 0; j < needs.Count; j++)
                {
                    if (offers[i][j] > needs[j])
                    {
                        canPurchase = false;
                        break;
                    }
                }
                if (canPurchase)
                {
                    int[] offer = new int[needs.Count + 1];
                    for (int j = 0; j < offers[i].Length; j++)
                    {
                        offer[j] = offers[i][j];
                    }
                    newOffers.Add(offer);
                }

            }
            return newOffers;
        }
    }

    public class Node
    {
        public IList<int> Needs { get; }
        public List<int[]> Offers { get; }
        public int Price { get; }
        public string NeedsKey;
        public Node(IList<int> needs, List<int[]> offers, int price) 
        {
            Needs = needs;
            NeedsKey = string.Join(',', needs);
            Offers = offers;
            Price = price;
        }

    }



    //public class Solution
    //{

    //    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    //    {

    //        if (price.All(price => price == 0))
    //        {
    //            return 0;
    //        }

    //        int overAllPurchasePrice = 0;
    //        int n = price.Count - 1;
    //        int offerPrice = n + 1;
    //        int profit = n + 2;
    //        int maxPurchase = n + 3;
    //        int offerColumnCount = special[0].Count + 2;
    //        int[][] offers = new int[special.Count + price.Count][];
    //        for (int i = 0; i < special.Count + price.Count; i++)
    //        {
    //            offers[i] = new int[offerColumnCount];
    //        }

    //        // add special-offers to the offers 
    //        for (int i = 0; i < special.Count; i++)
    //        {
    //            int normalPurchase = 0;
    //            // add each row to the offers
    //            for (int j = 0; j < special[i].Count - 1; j++)
    //            {
    //                normalPurchase += special[i][j] * price[j];
    //                offers[i][j] = special[i][j];

    //            }
    //            offers[i][offerPrice] = special[i][offerPrice];
    //            offers[i][profit] = normalPurchase - special[i][offerPrice];
    //            offers[i][maxPurchase] = 0;
    //        }
    //        // add normal price to the offers to make it general
    //        for (int i = 0; i < price.Count; i++)
    //        {
    //            for (int j = 0; j < price.Count; j++)
    //            {
    //                if (i == j)
    //                {
    //                    offers[special.Count + i][j] = 1;
    //                }
    //                else
    //                {
    //                    offers[special.Count + i][j] = 0;
    //                }
    //            }

    //            offers[special.Count + i][offerPrice] = price[i];
    //            offers[special.Count + i][profit] = 0;
    //            offers[special.Count + i][maxPurchase] = 0;
    //        }

    //        bool needsRemain = true;
    //        while (needsRemain)
    //        {
    //            int maxPurchaseProfit = int.MinValue;
    //            int purchaseIndexOffer = -1;
    //            // calculate max purchase per row
    //            for (int i = 0; i < offers.Length; i++)
    //            {
    //                offers[i][maxPurchase] = _calMaxPurchase(offers[i], needs);
    //                int offerMaxProfit = offers[i][maxPurchase] * offers[i][profit];
    //                if (offerMaxProfit > maxPurchaseProfit && offerMaxProfit > 0)
    //                {
    //                    purchaseIndexOffer = i;
    //                    maxPurchaseProfit = offerMaxProfit;
    //                }
    //            }

    //            if (purchaseIndexOffer == -1)
    //            {
    //                for (int i = 0; i < offers.Length; i++)
    //                {
    //                    if (offers[i][maxPurchase] != 0)
    //                    {
    //                        purchaseIndexOffer = i;
    //                        break;
    //                    }
    //                }
    //            }

    //            if (purchaseIndexOffer == -1)
    //            {
    //                break;
    //            }
    //            overAllPurchasePrice += _purchase(offers[purchaseIndexOffer], needs);


    //            needsRemain = needs.Any(x => x != 0);
    //        }
    //        return overAllPurchasePrice;
    //    }



    //    private int _calMaxPurchase(int[] offer, IList<int> needs)
    //    {

    //        int[] accumulateOffer = new int[offer.Length];
    //        for (int i = 0; i < offer.Length; i++)
    //        {
    //            accumulateOffer[i] = offer[i];
    //        }


    //        bool canPurchaseMore = true;
    //        int purchaseCount = 0;

    //        while (canPurchaseMore)
    //        {
    //            for (int i = 0; i < needs.Count; i++)
    //            {
    //                if (accumulateOffer[i] > needs[i])
    //                {
    //                    canPurchaseMore = false;
    //                    break;
    //                }
    //            }
    //            if (canPurchaseMore == false) break;
    //            purchaseCount++;

    //            for (int i = 0; i < needs.Count; i++)
    //            {
    //                accumulateOffer[i] += offer[i];
    //            }
    //        }

    //        return purchaseCount;
    //    }

    //    private int _purchase(int[] offer, IList<int> needs)
    //    {
    //        for (int i = 0; i < needs.Count; i++)
    //        {
    //            needs[i] = needs[i] - offer[i];
    //        }
    //        return offer[needs.Count];
    //    }
    //}
}
