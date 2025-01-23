using System;
using System.Collections.Generic;
using Tree;

namespace Tasks.Tree
{
    public class Main
    {
        public int MaxDepth(TreeNode<int> root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        public int MaxDepthIteratively(TreeNode<int> root)
        {
            if (root == null)
                return 0;

            var depth = 0;
            var q = new Queue<TreeNode<int>>();
            q.Enqueue(root);
            while (true)
            {
                var nodeCount = q.Count;
                if (nodeCount == 0)
                    return depth;

                depth++;

                while (nodeCount > 0)
                {
                    var cur = q.Dequeue();

                    if (cur.left != null)
                        q.Enqueue(cur.left);

                    if (cur.right != null)
                        q.Enqueue(cur.right);
                    nodeCount--;
                }
            }
        }

        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null || k <= 0)
                return -1;

            var list = new List<int>();
            InorderTraversal(root);

            if (k > list.Count)
                return -1;

            return list[k - 1];


            void InorderTraversal(TreeNode node)
            {
                if (node.left != null)
                    InorderTraversal(node.left);

                list.Add(node.val);

                if (node.right != null)
                    InorderTraversal(node.right);
            }
        }
    }
}