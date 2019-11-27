# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

from collections import deque

class Solution:
    def isSameTree(self, p: TreeNode, q: TreeNode) -> bool:
        queue = deque([(p, q)])
        
        while queue:
            p, q = queue.popleft()
            if not self.check(p, q):
                return False
            
            if p is not None:
                queue.extend([(p.left, q.left), (p.right, q.right)])
            
        return True
    
    
    def check(self, p, q):
        if p is None and q is None:
            return True
        
        if p is None or q is None:
            return False
        
        if p.val == q.val:
            return True