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
    def __init__(self, root=None):
        self.root: Node = root
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

    def __setitem__(self,k,v):
        self.put(k,v)

    def get(self, k):
        if self.root is None:
            return None
        
        return self._get(k, self.root)
    
    def _get(self, k, node):
        if not node :
            return None

        if node.key == k:
            return node
        elif k < node.key:
            return self._get(k, node.left)
        else:
            return self._get(k, node.right)

    def __getitem__(self,key):
        return self.get(key)
    
    def inorder(self):
        if self.root is None:
            return []
        return self._inorder(self.root)
    
    def _inorder(self, currentNode: Node):
        return (self._inorder(currentNode.left) +
         [(currentNode.key, currentNode.value)] + 
         self._inorder(currentNode.right)) \
         if currentNode is not None else []

    def delete(self, k):
        if self.root is None:
            return
        
        currentNode = self.root
        parentNode = None
        while currentNode is not None:
            if currentNode.key < k:
                parentNode = currentNode
                currentNode = currentNode.right
            elif currentNode.key > k:
                parentNode = currentNode
                currentNode = currentNode.left
            else:
                break
        
        if currentNode is None:
            return
        
        # case 1: no children
        if currentNode.left is None and currentNode.right is None:
            if parentNode.left.key == currentNode.key:
                parentNode.left = None
                return currentNode
            else:
                parentNode.right = None
                return currentNode
        
        # case 2: one child
        # when left subtree exists
        if currentNode.left is not None and currentNode.right is None:
            pa



if __name__ == "__main__":
    n = Node("key", 5)
    bst = BST()
    bst.put(3, "three")
    bst.put(1, "one")
    bst.put(2, "two")
    bst.put(4, "four")
    bst.put(5, "five")

    bst.inorder()