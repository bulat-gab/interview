import unittest
from bst import BST, Node

class BinarySearchTreeTests(unittest.TestCase):
    def test_get(self):
        bst = self._generate_tree()

        self.assertEqual(bst.get(1).value, '1')
        self.assertEqual(bst.get(8).value, '8')
        self.assertEqual(bst.get(50).value, '50')
        self.assertIsNone(bst.get(100))
    
    def _generate_tree(self):
        n1 = Node(1, '1')
        n2 = Node(8, '8')
        n3 = Node(5, '5', n1, n2)
        
        n4 = Node(50, '50')
        n5 = Node(40, '40', None, n4)
        
        root = Node(10, '10', n3, n5)

        return BST(root)

if __name__ == "__main__":
    unittest.main()