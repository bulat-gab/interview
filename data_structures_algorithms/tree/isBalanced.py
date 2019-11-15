from bst import Node

class Solution:
    def isBalanced(self, root: Node) -> bool:
        # O(N^2)
        if root is None:
            return True
        
        lh = self.height(root.left)
        rh = self.height(root.right)
        
        if abs(lh - rh) > 1:
            return False
        elif self.isBalanced(root.left) and self.isBalanced(root.right):
            return True
        else:
            return False
            
    def height(self, root):
        if root is None:
            return 0
        return max(self.height(root.left), self.height(root.right)) + 1

    def isBalancedOptimized(self, root: TreeNode) -> bool:
        # Time: O(n), Space: O(height)
        return False if self.checkHeight(root) == -1 else True
    
    def checkHeight(self, root):
        if root is None:
            return 0
        
        lh = self.checkHeight(root.left)
        if lh == -1:
            return -1 # Not balanced
        
        rh = self.checkHeight(root.right)
        if rh == -1:
            return -1 # Not balanced
        
        heightDiff = lh - rh
        if abs(heightDiff) > 1:
            return -1
        else:
            return max(lh, rh) + 1