using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Mediums.Insert_Into_A_Binary_Search_Tree
{
    /*
     Difficulty: Medium
             
     You are given the root node of a binary search tree (BST) and a value to insert into the tree.
     Return the root node of the BST after the insertion. 
     It is guaranteed that the new value does not exist in the original BST.

     Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

     Constraints:
     The number of nodes in the tree will be in the range [0, 104].
     -108 <= Node.val <= 108
     All the values Node.val are unique.
     -108 <= val <= 108
     It's guaranteed that val does not exist in the original BST.

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
