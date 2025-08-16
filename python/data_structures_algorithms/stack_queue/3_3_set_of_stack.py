from LinkedList import LinkedList, Node
from tabulate import tabulate

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
    
    def push(self, value):
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

    def pop_at(self, index):
        if index >= self.size or index < 0:
            raise ValueError('Index out of range')
        
        return self.stacks[index].pop()

    def __str__(self):
        temp = {}
        for i in range(self.size):
            if not self.stacks[i].is_empty():
                temp[i] = list(self.stacks[i].list_)[::-1]

        return str(temp)

if __name__ == "__main__":
    ss = SetOfStacks()
    for i in range(20):
        ss.push(i)

    print(ss)

    ss.pop()
    ss.pop()
    ss.pop()
    ss.pop_at(0)
    ss.pop_at(1)
    ss.pop_at(1)
    ss.push(999)
    print(ss)