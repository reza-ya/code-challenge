using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode
{
    public class Count_Nodes_Equal_to_Average_of_Subtree
    {
        private int result = 0;
        public int AverageOfSubtree(TreeNode root)
        {
            var rootState = CalculateState(root);
            return this.result;
        }

        public NodeState CalculateState(TreeNode rootNode)
        {
            var currentNode = rootNode;
            if (currentNode.left == null && currentNode.right == null)
            {
                this.result++;
               return new NodeState(1, currentNode.val);
            }
            else if (currentNode.left != null && currentNode.right == null)
            {
                var leftNodeState = CalculateState(currentNode.left);
                var sum = (double)(leftNodeState.sum + currentNode.val);
                var count = leftNodeState.count + 1;
                var average = (int)Math.Floor(sum / count);
                if (currentNode.val == average)
                {
                    this.result++;
                }
                return new NodeState(leftNodeState.count + 1, leftNodeState.sum + currentNode.val);
            }
            else if (currentNode.left == null && currentNode.right != null)
            {
                var rightNodeState = CalculateState(currentNode.right);
                var sum = (double)rightNodeState.sum + currentNode.val;
                var count = rightNodeState.count + 1;
                var average = (int)Math.Floor(sum / count);
                if (currentNode.val == average)
                {
                    this.result++;
                }
                return new NodeState(rightNodeState.count + 1, rightNodeState.sum + currentNode.val);
            }
            else 
            {
                var leftNodeState = CalculateState(currentNode.left);
                var rightNodeState = CalculateState(currentNode.right);
                var sum = (double)(leftNodeState.sum + rightNodeState.sum + currentNode.val);
                var count = leftNodeState.count + rightNodeState.count + 1;
                var average = (int)Math.Floor(sum / count);
                if (currentNode.val == average)
                {
                    this.result++;
                }
                return new NodeState(rightNodeState.count + leftNodeState.count + 1 , rightNodeState.sum + leftNodeState.sum + currentNode.val);
            }
        }


        public TreeNode GetSample()
        {
            var leaf_0 = new TreeNode(0);

            var level_2_0 = new TreeNode(0, leaf_0);
            var level_3_0 = new TreeNode(0, null, level_2_0);
            var rootNode = new TreeNode(0, level_3_0, null);

            return rootNode;
        }

        public class NodeState
        {
            public int count;
            public int sum;
            public NodeState(int count, int sum)
            {
                this.count = count;
                this.sum = sum;
            }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
