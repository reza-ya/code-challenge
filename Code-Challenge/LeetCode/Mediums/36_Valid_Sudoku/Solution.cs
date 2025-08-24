
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Mediums._36_Valid_Sudoku
{
    /*
        Determine if a 9 x 9 Sudoku board is valid. 
        Only the filled cells need to be validated according to the following rules:

        1.Each row must contain the digits 1-9 without repetition.
        2.Each column must contain the digits 1-9 without repetition.
        3.Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        
        Note:
        A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        Only the filled cells need to be validated according to the mentioned rules.

        Constraints:
        board.length == 9
        board[i].length == 9
        board[i][j] is a digit 1-9 or '.'.
    */
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {


            var hashTable = new Hashtable();
            bool[] validator = new bool[9] { false, false, false, false, false, false, false, false, false };
            // for each row
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var item = board[i][j];
                    if (item == '.') continue;
                    if (validator[item - 49])
                    {
                        return false;
                    }
                    else
                    {
                        validator[item - 49] = true;
                    }
                }
                ResetValidator(ref validator);
            }

            ResetValidator(ref validator);
            
            // for each column
            for (int j = 0; j < 9; j++)
            {
                // write for each column items
                for (int i = 0; i < 9; i++)
                {
                    var item = board[i][j];
                    if (item == '.') continue;
                    if (validator[item - 49])
                    {
                        return false;
                    }
                    else
                    {
                        validator[item - 49] = true;
                    }

                }

                ResetValidator(ref validator);
            }


            ResetValidator(ref validator);
            // for each 3*3 block
            for (int block_i = 0; block_i < 3; block_i++)
            {
                for (int block_j = 0; block_j < 3; block_j++)
                {
                    var list = new List<char>();
                    for (int i = 0 + block_i * 3; i < (block_i * 3) + 3; i++)
                    {
                        for (int j = 0 + block_j * 3; j < (block_j * 3) + 3; j++)
                        {
                            var item = board[i][j];
                            if (item == '.') continue;
                            if (validator[item - 49])
                            {
                                return false;
                            }
                            else
                            {
                                validator[item - 49] = true;
                            }
                        }
                    }
                    ResetValidator(ref validator);
                }
            }

            return true;
        }

        public void ResetValidator(ref bool[] validator)
        {
            for(int i = 0; i <validator.Length; i++)
            {
                validator[i] = false;
            }
        }
    }

}

