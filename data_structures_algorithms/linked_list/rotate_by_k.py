from LinkedList import Node, LinkedList

def rotate(head, k):
    current = head
    count = 1
    while count < k and current is not None:
        count += 1
        current = current.next
    
    if current is None:
        return head
    
    kth_node = current
    
    while current.next is not None:
        current = current.next
    
    current.next = head
    head = kth_node.next
    kth_node.next = None
    
    return head


if __name__ == "__main__":
    ll1 = LinkedList()
    ll1.add_to_tail(1)
    ll1.add_to_tail(2)
    ll1.add_to_tail(3)
    ll1.add_to_tail(4)

    print(ll1)
    rotate(ll1.head, 2)
    print(ll1)