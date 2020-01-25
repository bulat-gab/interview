import unittest
from bst import BST, Node
from LevelOrderTraversal import BFS

class BinarySearchTreeTests(unittest.TestCase):
    def test_get(self):
        bst = self._generate_tree()

        self.assertEqual(bst[1].value, '1')
        self.assertEqual(bst[8].value, '8')
        self.assertEqual(bst[50].value, '50')
        self.assertIsNone(bst[100])
    
    def test_put(self):
        bst = BST()
        bst.put(10, '10')
        bst.put(5, '5')
        bst.put(40, '40')
        bst.put(1, '1')
        bst.put(8, '8')
        bst.put(50, '50')
        
        inorder = [k for (k,v) in bst.inorder()]
        self.assertEqual(inorder, [1, 5, 8, 10, 40, 50])

    def test_inorder(self):
        bst = self._generate_tree()
        inorder = [k for (k,v) in bst.inorder()]
        self.assertEqual(inorder, [1, 5, 8, 10, 40, 50])

    def _generate_tree(self):
        """
                    10
                   /  \
                  5    40
                 / \     \
                1   8     50
        """

        n1 = Node(1, '1')
        n2 = Node(8, '8')
        n3 = Node(5, '5', n1, n2)
        
        n4 = Node(50, '50')
        n5 = Node(40, '40', None, n4)
        
        root = Node(10, '10', n3, n5)

        return BST(root)
    
    def levelOrderTraversalTests(self):
        bst = self._generate_tree()
        bfs = BFS()
        # expected = [10, 5, 40, 1, 8, 50]
        bfs.traverse(bst.root)



if __name__ == "__main__":
    unittest.main()
    