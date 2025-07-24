using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode
{
    public class Count_Nodes_Equal_to_Average_of_Subtree
    {
        public int AverageOfSubtree(TreeNode root)
        {

            return 0;
        }





        public TreeNode GetSample()
        {
            var leaf_0 = new TreeNode(0);
            var leaf_1 = new TreeNode(1);
            var leaf_6 = new TreeNode(6);

            var middle_node_8 = new TreeNode(8, leaf_0, leaf_1);
            var middle_node_5 = new TreeNode(5, null, leaf_6);
            var rootNode = new TreeNode(4, middle_node_8, middle_node_5);


            return rootNode;
        }

        public void PrintTree(TreeNode rootNode)
        {
            if (rootNode.left == null && rootNode.right == null)
            {
                Console.WriteLine(rootNode.val);
            }

            var currentNode = rootNode.right;
            while(currentNode?.right != null)
            {
                currentNode = currentNode.right;
            }

            Console.WriteLine(currentNode?.val);
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
