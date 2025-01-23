namespace Tree
{
    public class IsValidBST
    {
        public bool CheckIsValidBST(TreeNode<int> root)
        {
            return this.Impl(root);
        }

        private bool Impl(TreeNode<int> node, int lower = int.MinValue, int upper = int.MaxValue)
        {
            if (node is null)
            {
                return true;
            }

            int value = node.Value;

            if (value <= lower || value >= upper)
            {
                return false;
            }

            var left = this.Impl(node.left, lower, value);
            var right = this.Impl(node.right, value, upper);

            return left && right;
        }
    }
}