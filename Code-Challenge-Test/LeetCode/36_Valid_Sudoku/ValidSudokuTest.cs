using Code_Challenge.LeetCode.Mediums._36_Valid_Sudoku;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_Test.LeetCode._36_Valid_Sudoku
{
    public class ValidSudokuTest
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new char[9][] {
                new [] {'8','3','.','.','7','.','.','.','.'},
                new [] {'6','.','.','1','9','5','.','.','.'},
                new [] {'.','9','8','.','.','.','.','6','.'},
                new [] {'8','.','.','.','6','.','.','.','3'},
                new [] {'4','.','.','8','.','3','.','.','1'},
                new [] {'7','.','.','.','2','.','.','.','6'},
                new [] {'.','6','.','.','.','.','2','8','.'},
                new [] {'.','.','.','4','1','9','.','.','5'},
                new [] {'.','.','.','.','8','.','.','7','9'}
                },
                false // expected result
            };


        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ShoppingOffers_ShouldReturnExpectedResult(char[][] sudoku, bool expected)
        {
            // Arrange
            var solution = new Solution();

            // Act
            var result = solution.IsValidSudoku(sudoku);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
