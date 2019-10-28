class LL:
    def reverseList(self):
    # Code here
    if self.head is None:
        return None
        
    previous = None
    current = self.head
    next = None
    
    while current is not None:
        next = current.next
        current.next = previous
        previous = current
        current = next

    def __init__(self):
        self.head = None


class Node:
    def __init__(self, val):
        self.val = val
        self.next = None

