using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Mediums._198_House_Robber
{
    public class Solution
    {
        public int[]? houseMaxRob;
        public int Rob(int[] nums)
        {
            houseMaxRob = new int[nums.Length];
            for (int i = 0; i < houseMaxRob.Length; i++)
            {
                houseMaxRob[i] = -1;
            }
            if (nums.Length == 1) return nums[0];
            int robStartAtOne = DFSRob(ref nums, 0, nums[0]);
            int robStartAtTwo = DFSRob(ref nums, 1, nums[1]);


            return Math.Max(robStartAtOne, robStartAtTwo);
        }


        public int DFSRob(ref int[] houses, int currentIndex, int RobAmmount)
        {
            if (houseMaxRob[currentIndex] >= RobAmmount)
            {
                return RobAmmount;
            }
            else
            {
                houseMaxRob[currentIndex] = RobAmmount;
            }
            int robStartAtOne = RobAmmount;
            int robStartAtTwo = RobAmmount;
            if (currentIndex + 2 <= houses.Length - 1)
            {
                robStartAtOne = DFSRob(ref houses, currentIndex + 2, houses[currentIndex + 2] + RobAmmount);
            }
            if (currentIndex + 3 <= houses.Length - 1)
            {
                robStartAtTwo = DFSRob(ref houses, currentIndex + 3, houses[currentIndex + 3] + RobAmmount);
            }
            
            return Math.Max(robStartAtOne, robStartAtTwo);
        }
    }

}
