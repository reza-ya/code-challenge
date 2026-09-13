using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Mediums._3870_Count_Commas_in_Range
{
    public class Solution
    {
        public int CountCommas(int n)
        {
            var lenght = n.ToString().Length;
            if (lenght <= 3)
            {
                return 0;
            }
            var powOfTen = (int)Math.Pow(10, lenght - 1);
            var remanent = n - powOfTen + 1;
            var remanentCount = lenght % 3 == 0 ? ((lenght / 3) - 1) * remanent : (lenght / 3) * remanent;

            var result = CountCommasOfTenghtPow(n - remanent, lenght - 1, 0);
            

            return result + remanentCount;
        }

        public int CountCommasOfTenghtPow(int n, int len, int acc)
        {
            if (len <= 3) return 0 + acc;

            var powOfTen = (int)Math.Pow(10, len - 1);
            var countLenNumber = n - (powOfTen - 1);
            var remanentCount = len % 3 == 0 ? ((len / 3) - 1) * countLenNumber : (len / 3) * countLenNumber;
            var remain = n - remanentCount;

            var result = CountCommasOfTenghtPow(remain, len - 1, remanentCount);


            return result + acc;
        }
    }

}
