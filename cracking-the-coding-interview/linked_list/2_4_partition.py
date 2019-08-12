from LinkedList import LinkedList, Node

def get_partition(l, x):
    left_ll = LinkedList()
    right_ll = LinkedList()

    current = l.head
    while current is not None:

        if (current.data < x):
            left_ll.add_to_tail(current.data)
        else:
            right_ll.add_to_tail(current.data)

        current = current.next
    
    if left_ll.size() == 0:
        return right_ll
    else:
        left_ll.tail.next = right_ll.head
        left_ll.tail = right_ll.tail

    return left_ll

l = LinkedList()
l.add(10)
l.add(9)
l.add(8)
l.add(3)
l.add(11)

print(l)

l = get_partition(l, 8)

print(l)