from LinkedList import LinkedList

def remove_dups_with_buffer(l):
    """l - Linked List"""
    d = {}
    for node in l:
        if node in d:
            d[node] = d[node] + 1
            l.remove(node)
        else: 
            d[node] = 1

def remove_dups(l):
    current = l.head

    if current is None:
       return
    
    while current is not None:
        runner = current
        
        while runner.next is not None:
            if runner.next.data == current.data:
                runner.next = runner.next.next
            else:
                runner = runner.next

        current = current.next
    

l = LinkedList.get_sample()
l.add(3)
l.add(3)
l.add(2)

print(l)

remove_dups(l)
print(l)