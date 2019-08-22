class Node:
    def __init__(self, key):
        self.left = None
        self.right = None
        self.val = key
    
    def __str__(self):
        return str(self.val)

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

    def str_inorder(self):
        self.sorted = []
        self.get_inorder(self.root)
        return str(self.sorted)

    def get_inorder(self, node):
        if node:
            self.get_inorder(node.left)
            self.sorted.append(str(node))
            self.get_inorder(node.right)
    
    def str_preorder(self):
        self.sorted = []
        self.get_preorder(self.root)
        return str(self.sorted)

    def get_preorder(self, node):
        if node:
            self.sorted.append(str(node))
            self.get_preorder(node.left)
            self.get_preorder(node.right)

    def str_postorder(self):
        self.sorted = []
        self.get_postorder(self.root)
        return str(self.sorted)

    def get_postorder(self, node):
        if node:
            self.get_postorder(node.left)
            self.get_postorder(node.right)
            self.sorted.append(str(node))


if __name__ == "__main__":
    # bst = BST()
    # bst.add(3)
    # bst.add(4)
    # bst.add(2)
    # bst.add(5)
    # bst.add(1)
    # print(bst.str_inorder())
    # print(bst.str_postorder())
    # print(bst.str_preorder())

    from random import randint

    bst = BST()

    for i in range(10):
        bst.add(randint(1, 1000))
    print(bst.str_inorder())
