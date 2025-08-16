from LinkedList import LinkedList, Node

class Stack():
    def __init__(self):
        self.list_ = LinkedList()
    
    def is_empty(self):
        return True if self.list_.head is None else False 

    def push(self, value):
        self.list_.add_to_head(value)
    
    def pop(self):
        if self.is_empty():
            raise ValueError("Stack is empty")

        deleted = self.list_.remove_from_head()
        return deleted.data
    
    def peek(self):
        if self.is_empty():
            raise ValueError("Stack is empty")
        return self.list_.head.data

if __name__ == "__main__":
    s = Stack()
    s.push(1)
    s.push(2)
    s.push(3)
    assert s.peek() == 3
    assert s.pop() == 3
    assert s.pop() == 2
    assert s.peek() == 1

    assert s.pop() == 1
    s.push(5)
    assert s.peek() == 5 
    