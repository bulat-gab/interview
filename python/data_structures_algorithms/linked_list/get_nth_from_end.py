from LinkedList import Node, LinkedList

def get_nth_from_end(head,n):
    #code here
    
    size = 0
    current = head
    while current is not None:
        current = current.next
        size += 1
        
    if size < n:
        return -1
    
    current = head
    i = 0
    while i < size - n:
        current = current.next
        i += 1
    
    return current.data

if __name__ == "__main__":
    ll = LinkedList()
    for i in range(1, 7):
        ll.add_to_tail(i)


    print(getNthfromEnd(ll.head, 2))
    print(ll)
    