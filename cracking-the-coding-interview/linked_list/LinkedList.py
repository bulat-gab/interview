from __future__ import print_function 

class Node:
    def __init__(self, data=None):
        self.data = data
        self.next = None
    
    def __str__(self):
        return self.data

class LinkedList:
    def __init__(self):
        self.head = None
        self.tail = None

    def add_to_head(self, value):
        newest = Node(value)
        newest.next = self.head
        self.head = newest

    def add_to_tail(self, value):
        new_node = Node(value)

        if self.tail is None:
            self.tail = new_node
            self.head = self.tail
        else:
            self.tail.next = new_node
            self.tail = new_node
            self.tail.next = None
    
    def remove_from_head(self):
        if self.head is None:
            return
        if self.head.next is None:
            self.head = None
            self.tail = None
            return
        
        deleted_node = self.head
        self.head = self.head.next

        return deleted_node
    
    def remove(self, value):
        current = self.head
        previous = None
        found = False
        while current and found is False:
            if current.data == value:
                found = True
            else:
                previous = current
                current = current.next
        if current is None:
            raise ValueError("Value not in list")
        if previous is None:
            self.head = current.next
        else:
            previous.next = current.next

    def __iter__(self):
        current = self.head
        while current is not None:
            yield current.data
            current = current.next

    def __str__(self):
        return str(list(self))

    def size(self):
        return len(list(self))

    @classmethod
    def get_sample(cls, size=5):
        l = LinkedList()
        for i in range(size):
            l.add_to_tail(i)
        return l

# l = LinkedList()
# n1 = Node('1')
# n2 = Node('2')
# n3 = Node('3')
# n4 = Node('4')
# n5 = Node('5')

# l.add(n1)
# l.add(n2)
# l.add(n3)
# l.add(n4)
# l.add(n5)
# l.print_list()
# l.remove()
# l.remove()
# l.remove()
# l.remove()
# l.print_list()