"""
printLevelorder(tree)
1) Create an empty queue q
2) temp_node = root /*start from root*/
3) Loop while temp_node is not NULL
    a) print temp_node->data.
    b) Enqueue temp_node’s children (first left then right children) to q
    c) Dequeue a node from q and assign it’s value to temp_node
"""
from bst import Node
from collections import deque

class BFS:
    def traverse(self, root: Node):
        if root is None:
            return
        
        queue = deque([root])
        while queue:
            tempNode = queue.popleft()
            print(f"{tempNode.key} : {tempNode.value}")
            if tempNode.left is not None:
                queue.append(tempNode.left)
            if tempNode.right is not None:
                queue.append(tempNode.right)
        

bfs = BFS()
n1 = Node(1, '1')
n2 = Node(8, '8')
n3 = Node(5, '5', n1, n2)

n4 = Node(50, '50')
n5 = Node(40, '40', None, n4)

root = Node(10, '10', n3, n5)
bfs.traverse(root)