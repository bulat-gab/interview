using NUnit.Framework;

namespace Tree.Tests
{
    [TestFixture]
    public class IsValidBSTTest
    {
        [Test]
        public void IsValidBST1()
        {
            var isValidBST = new IsValidBST();
            var root = new TreeNode<int>(2);
            root.Left = new TreeNode<int>(1);
            root.Right = new TreeNode<int>(3);
            
            var result = isValidBST.CheckIsValidBST(root);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsValidBST2()
        {
            var isValidBST = new IsValidBST();
            var root = new TreeNode<int>(5);
            root.Left = new TreeNode<int>(1);
            root.Right = new TreeNode<int>(4);
            root.Right.Left = new TreeNode<int>(3);
            root.Right.Right = new TreeNode<int>(6);
            
            var result = isValidBST.CheckIsValidBST(root);
            Assert.IsFalse(result);
        }
    }
}