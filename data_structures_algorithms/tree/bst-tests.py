import unittest
from bst import BST, Node

class BinarySearchTreeTests(unittest.TestCase):
    def test_get(self):
        bst = self._generate_tree()
        actual = bst.get(1)
        self.assertEqual(actual.value, '1')
    
    def _generate_tree(self):
        n1 = Node(1, '1')
        n2 = Node(2, '2')
        n3 = Node(5, '5', n1, n2)
        
        n4 = Node(50, '50')
        n5 = Node(40, '40', None, n4)
        
        root = Node(10, '10', n3, n5)

        return BST(root)

if __name__ == "__main__":
    unittest.main()