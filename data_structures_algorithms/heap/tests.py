import unittest
from heap import Heap

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