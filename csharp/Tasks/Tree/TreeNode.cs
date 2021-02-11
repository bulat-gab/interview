namespace Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }

        public TreeNode(T value, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            Value = value;
            this.left = left;
            this.right = right;
        }
    }
    
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            val = val;
            this.left = left;
            this.right = right;
        }
    }
}