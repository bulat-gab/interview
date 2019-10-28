class Node:
    def __init__(self, key):
        self.left = None
        self.right = None
        self.val = key
    
    def __str__(self):
        return str(self.val)

class TreeUtil:
    @classmethod
    def height(cls, node):
        if node is None:
            return 0

        return max(TreeUtil.height(node.left), TreeUtil.height(node.right)) + 1

class BST:
    def __init__(self):
        self.root = None

    def add(self, key):
        if not self.root:
            self.root = Node(key)
        else:
            self._add(self.root, key)
    
    def _add(self, node: Node, key):
        if key <= node.val:
            if node.left:
                self._add(node.left, key)
            else:
                node.left = Node(key)
        else:
            if node.right:
                self._add(node.right, key)
            else:
                node.right = Node(key)


class TreeTraversals():
    def str_inorder(self, node):
        if not node:
            return ""

        self.sorted = []
        self.get_inorder(node)
        return str(self.sorted)

    def get_inorder(self, node):
        if node:
            self.get_inorder(node.left)
            self.sorted.append(str(node))
            self.get_inorder(node.right)
    
    def str_preorder(self, node):
        self.sorted = []
        self.get_preorder(node)
        return str(self.sorted)

    def get_preorder(self, node):
        if node:
            self.sorted.append(str(node))
            self.get_preorder(node.left)
            self.get_preorder(node.right)

    def str_postorder(self, node):
        self.sorted = []
        self.get_postorder(node)
        return str(self.sorted)

    def get_postorder(self, node):
        if node:
            self.get_postorder(node.left)
            self.get_postorder(node.right)
            self.sorted.append(str(node))

    def str_levelorder(self, node):
        self.sorted = []
        h = TreeUtil.height(node)

        for i in range(1, h+1):
            self.get_levelorder(node, i)

        return str(self.sorted)

    def get_levelorder(self, node, level):
        if node is None:
            return
        if level == 1:
            self.sorted.append(str(node))
        if level > 1:
            self.get_levelorder(node.left, level-1)
            self.get_levelorder(node.right, level-1)
        
    


if __name__ == "__main__":
    root = Node(1)
    root.left = Node(2)
    root.right = Node(3)
    root.left.left = Node(4)
    root.left.right = Node(5)

    t = TreeTraversals()
    print(t.str_inorder(root))
    print(t.str_postorder(root))
    print(t.str_preorder(root))
    print(t.str_levelorder(root))