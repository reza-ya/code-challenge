using Code_Challenge.LeetCode;
using Code_Challenge.LeetCode.Mediums._36_Valid_Sudoku;

using System.Collections;
using System.Runtime.CompilerServices;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new object();


            var hashTable = new Hashtable(9);
            

            var solution = new Solution();
            //var sudou = new char[9][] {
            //    new [] {'8','3','.','.','7','.','.','.','.'},
            //    new [] {'6','.','.','1','9','5','.','.','.'},
            //    new [] {'.','9','8','.','.','.','.','6','.'},
            //    new [] {'8','.','.','.','6','.','.','.','3'},
            //    new [] {'4','.','.','8','.','3','.','.','1'},
            //    new [] {'7','.','.','.','2','.','.','.','6'},
            //    new [] {'.','6','.','.','.','.','2','8','.'},
            //    new [] {'.','.','.','4','1','9','.','.','5'},
            //    new [] {'.','.','.','.','8','.','.','7','9'}
            //    };
                var sudou = new char[9][] {
                ['.', '.', '.', '.', '5', '.', '.', '1', '.'],
                ['.', '4', '.', '3', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '3', '.', '.', '1'],
                ['8', '.', '.', '.', '.', '.', '.', '2', '.'],
                ['.', '.', '2', '.', '7', '.', '.', '.', '.'],
                ['.', '1', '5', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '2', '.', '.', '.'],
                ['.', '2', '.', '9', '.', '.', '.', '.', '.'],
                ['.', '.', '4', '.', '.', '.', '.', '.', '.']
                };



            var result = solution.IsValidSudoku(sudou);

            Console.WriteLine($"result: {result}");
        }
    }

    public class HashProvider : IEqualityComparer
    {
        public new bool Equals(object? x, object? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
