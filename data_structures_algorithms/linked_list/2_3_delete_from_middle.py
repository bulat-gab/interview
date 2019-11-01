from LinkedList import LinkedList, Node

def delete_from_middle(node):
    '''node - Linked List Node'''
    node.data = node.next.data
    node.next = node.next.next

l = LinkedList()

l.head = Node(1)
l.head.next = Node(2)
l.head.next.next = Node(3)
l.head.next.next.next = Node(4)
l.head.next.next.next.next = Node(5)
l.tail = l.head.next.next.next.next

print(l)

delete_from_middle(l.head.next.next)

print(l)