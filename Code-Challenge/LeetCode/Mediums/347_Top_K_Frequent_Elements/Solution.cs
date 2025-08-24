using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode._347_Top_K_Frequent_Elements
{
    /*
     Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

 

        Example 1:

        Input: nums = [1,1,1,2,2,3], k = 2
        Output: [1,2]
        Example 2:

        Input: nums = [1], k = 1
        Output: [1]
 

        Constraints:

        1 <= nums.length <= 105
        -104 <= nums[i] <= 104
        k is in the range [1, the number of unique elements in the array].
        It is guaranteed that the answer is unique.
 

        Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size. 
     */
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {

            int[] ints = new int[10_000 * 2 + 1];

            for(int i = 0; i < nums.Length; i++)
            {
                ints[nums[i] + 10_000] += 1;
            }


            int[] result = new int[k];
            for(int i = 0; i < k; i++)
            {
                int max = int.MinValue;
                int maxIndex = 0;
                for(int j = 0; j < ints.Length; j++)
                {
                    if (ints[j] > max)
                    {
                        maxIndex = j;
                        max = ints[j];
                    }
                }
                ints[maxIndex] = int.MinValue;
                result[i] = maxIndex - 10_000;
            }

            
            return result;
        }
    }
}
