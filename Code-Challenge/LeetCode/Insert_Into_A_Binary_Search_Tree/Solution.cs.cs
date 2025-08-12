using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Code_Challenge.LeetCode.Count_Nodes_Equal_to_Average_of_Subtree;

namespace Code_Challenge.LeetCode.Insert_Into_A_Binary_Search_Tree
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }
            TreeNode currentNode = root;
            while (currentNode != null)
            {
                if(val > currentNode.val)
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new TreeNode(val);
                        break;
                    }
                    currentNode = currentNode.right;
                }
                else
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new TreeNode(val);
                        break;
                    }
                    currentNode = currentNode.left;
                }
            }
            return root;
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
