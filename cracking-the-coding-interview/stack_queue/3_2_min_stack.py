class NodeWithMin:
    def __init__(self, value = None):
        self.data = value
        self.next = None
        self.min = value

class StackWithMin():
    def __init__(self):
        self.top = None

    def push(self, value):
        new_top = NodeWithMin(value)

        if self.top is None:
            self.top = new_top
            return

        new_top.next = self.top
        if value < self.top.min:
            new_top.min = value
        else:
            new_top.min= self.top.min

        self.top = new_top
    
    def pop(self):
        if self.top is None:
            raise ValueError('Stack is empty')

        deleted_value = self.top.data
        self.top = self.top.next
        
        return deleted_value

    def peek(self):
        if self.top is None:
            raise ValueError('Stack is empty')

        return self.top.data

    def min(self):
        if self.top is None:
            raise ValueError('Stack is empty')

        return self.top.min

if __name__ == "__main__":
    s = StackWithMin()
    s.push(6)
    s.push(2)
    s.push(100)
    s.push(11)
    s.push(23)
    assert s.pop() == 23
    assert s.peek() == 11
    assert s.min() == 2
    