import unittest
from LinkedList import LinkedList

class TestLinkedListMethods(unittest.TestCase):
    def test_remove_from_head(self):
        l = LinkedList.get_sample()

        l.remove(0)
        self.assertListEqual([1, 2, 3, 4], list(l))

    def test_remove_from_tail(self):
        l = LinkedList.get_sample()

        l.remove(4)
        self.assertListEqual([0, 1, 2, 3], list(l))

    def test_size(self):
        l = LinkedList.get_sample(10)
        self.assertEqual(10, l.size())

if __name__ == "__main__":
    unittest.main()