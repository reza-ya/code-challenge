﻿using Code_Challenge.LeetCode;

namespace Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var challenge = new Count_Nodes_Equal_to_Average_of_Subtree();
            var binaryTreeSample = challenge.GetSample();

            var result = challenge.AverageOfSubtree(binaryTreeSample);



            Console.WriteLine($"result: {result}");
        }
    }
}
