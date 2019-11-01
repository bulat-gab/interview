from LinkedList import Node, LinkedList

def reverse(l: LinkedList) -> LinkedList:
    current = l.head
    l.tail = l.head

    previous = None
    next_ = None

    while current is not None:
        next_ = current.next
        current.next = previous
        previous = current
        current = next_

    l.head = previous
    

    return l


l = LinkedList.get_sample(5)
print(l)
l = reverse(l)
print(l)
assert [4, 3, 2, 1, 0] == list(l)
