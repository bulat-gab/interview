class Heap:
    def __init__(self, isMaxHeap=True, capacity=16):
        self.capacity = capacity
        self.arr = [None] * capacity
        self.isMaxHeap = isMaxHeap
        self.count = 0
    
    def _ensureHeapIsNotEmpty(self):
        if self.count <= 0:
            raise ValueError('Heap is empty')

    def add(self, value: int):
        """ 
        1. Add element to the bottom level
        2. Compare the added element with its parent;
            if they are in correct order, stop
        3. If not, swap the element with its parent and return to previous step
        """

        self.arr[self.count] = value
        self._upHeap(self.count)
        self.count += 1
    
    def remove(self):
        self._ensureHeapIsNotEmpty()
        
        toDelete = self.arr[0]
        self.arr[0] = self.arr[count-1]
        self.arr[count-1] = None
        self.count -= 1
        self._heapifyDown()
        
        return toDelete
    
    def peek(self):
        self._ensureHeapIsNotEmpty()
        return self.arr[0]

    def _upHeap(self, index: int):
        

        if self.isMaxHeap:
            while self.arr[index] > self.arr[parentIndex]:
                parentIndex = (index-1) // 2

                temp = self.arr[index]
                self.arr[index] = self.arr[parentIndex]
                self.arr[parentIndex] = temp

                index = parentIndex
        else:
            while self.arr[index] < self.arr[parentIndex]:
                parentIndex = (index-1) // 2

                temp = self.arr[index]
                self.arr[index] = self.arr[parentIndex]
                self.arr[parentIndex] = temp

                index = parentIndex
        return