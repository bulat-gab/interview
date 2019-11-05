class Node:
    def __init__(self, k, v, left=None, right=None):
        self.key = k
        self.value = v
        self.left = left
        self.right = right
    
    def hasLeft(self):
        return self.left != None
    
    def hasRight(self):
        return self.right != None

class BST:
    def __init__(self):
        self.root: Node = None
        self.size: int = 0
    
    def length(self):
        return self.size
    
    def __len__(self):
        return self.size
    
    def __iter__(self):
        return self.root.__iter__()
    
    def put(self, k, v):
        if self.root:
            self._put(k, v, self.root)
        else:
            self.root = Node(k, v)
        self.size += 1
    
    def _put(self, k, v, currentNode):
        if k < currentNode.key:
            if currentNode.hasLeft():
                self._put(k, v, currentNode.left)
            else:
                currentNode.left = Node(k, v)
        elif k > currentNode.key:
            if currentNode.hasRight():
                self._put(k, v, currentNode.right)
            else:
                currentNode.right = Node(k, v)
        else:
            # Trying to add existing key will result in replacing that key's value
            currentNode.value = v

    def inorder(self):
        if not self.root:
            return
        
        self._inorder(self.root)
    
    def _inorder(self, currentNode):
        if not currentNode:
            return

        self._inorder(currentNode.left)
        print(f"{currentNode.key} : {currentNode.value}") 
        self._inorder(currentNode.right) 



if __name__ == "__main__":
    n = Node("key", 5)
    bst = BST()
    bst.put(3, "three")
    bst.put(1, "one")
    bst.put(2, "two")
    bst.put(4, "four")
    bst.put(5, "five")

    bst.inorder()