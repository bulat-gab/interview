import unittest
from bst import BST, Node
from heap import Heap

class BinarySearchTreeTests(unittest.TestCase):
    def test_get(self):
        bst = self._generate_tree()

        self.assertEqual(bst[1].value, '1')
        self.assertEqual(bst[8].value, '8')
        self.assertEqual(bst[50].value, '50')
        self.assertIsNone(bst[100])
    
    def test_put(self):
        bst = BST()
        # bst.put
        pass

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

class HeapTests(unittest.TestCase):
    def testAdd(self):
        expectedHeap = [58, 40, 50, 31, 3, 40] 
        maxHeap = Heap()

        for elem in expectedHeap:
            maxHeap.add(elem)
        
        for index in range(len(expectedHeap)):
            self.assertEqual(self.arr[i], expectedHeap[i])

if __name__ == "__main__":
    unittest.main()
    