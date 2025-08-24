
using Code_Challenge.LeetCode.Mediums.Shopping_Offers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_Test.LeetCode.Shopping_Offers
{
    public class ShoppingOffersTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new List<int> { 2, 5 },
                new List<IList<int>>
                {
                    new List<int> { 3, 0, 5 },
                    new List<int> { 1, 2, 10 }
                },
                new List<int> { 3, 2 },
                14 // expected result
            };

            yield return new object[]
            {
                new List<int> { 2, 3, 4 },
                new List<IList<int>>
                {
                    new List<int> { 1, 1, 0, 4 },
                    new List<int> { 2, 2, 1, 9 }
                },
                new List<int> { 1, 2, 1 },
                11 // expected result
            };

 
        }


        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ShoppingOffers_ShouldReturnExpectedResult(
            IList<int> price,
            IList<IList<int>> special,
            IList<int> needs,
            int expected)
        {
            // Arrange
            var solution = new Solution();

            // Act
            var result = solution.ShoppingOffers(price, special, needs);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}