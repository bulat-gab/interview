class Node:
    def __init__(self, key):
        self.left = None
        self.right = None
        self.val = key

class BinaryTree:
    def __init__(self):
        self.root = None

    def add(self, key: int):
        if self.root is None:
            self.root = Node(key)
            return

        if self.root.val >= key:
            _add(self.root.left, key)
        else:
            _add(self.root.right, key)
            

    def _add(self, node: Node, key: int):
        if node.val >= key:
            _add(node.left, key)
        else:
            _add(node.right, key)

    def to_string(self):
        if self.root is None:
            return ''
        
        _inorder(self.root.left)
        print(self.root.val, end=' ')
        _inorder(self.root.right, end=' ')
    
    def _inorder(self, node: Node):
        if node is not None:
            return

        _inorder(node.left)
        print(node.val, end=' ')
        _inorder(node.right, end=' ')
        

if __name__ == "__main__":
    bt = BinaryTree()
    bt.add(4)
    bt.add(3)
    bt.add(2)
    bt.add(5)
    bt.add(1)