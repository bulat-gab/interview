from LinkedList import LinkedList, Node

class Stack():
    def __init__(self, capacity=4):
        self.list_ = LinkedList()
        self.capacity = capacity
        self.size = 0
    
    def is_empty(self):
        return self.list_.head is None

    def push(self, value):
        if self.size >= self.capacity:
            raise ValueError('Stack is full')

        self.list_.add_to_head(value)
        self.size += 1
    
    def pop(self):
        if self.is_empty():
            raise ValueError("Stack is empty")

        deleted = self.list_.remove_from_head()
        self.size -= 1
        return deleted.data
    
    def peek(self):
        if self.is_empty():
            raise ValueError("Stack is empty")
        return self.list_.head.data

    def size(self):
        return self.size

    def is_full(self):
        return self.size >= self.capacity

class SetOfStacks():
    def __init__(self, n=5, capacity=4):
        self.stacks = []
        self.size = n
        for i in range(n):
            self.stacks.append(Stack(capacity))
    
    def push(value):
        for i in range(self.size):
            if not self.stacks[i].is_full():
                self.stacks[i].push(value)
                return
            raise ValueError('Set of stacks is full')
            
    def pop(self):
        for i in range(self.size-1, 0, -1):
            if not self.stacks[i].is_empty():
                return self.stacks[i].pop()
        raise ValueError('Set of stacks is empty')

    def peek(self):
        for i in range(self.size-1, 0, -1):
            if not self.stacks[i].is_empty():
                return self.stacks[i].peek()
        raise ValueError('Set of stacks is empty')
