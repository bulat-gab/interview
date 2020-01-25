import heapq

def mergeKArrays(a,n):
    '''
    :param a: given array
    :param n: size of row and column
    :return: merged sorted list
    '''
    heap = []
    result = []
    for row in range(n):
        heapq.heappush(heap, (a[row][0], row, 0))
    
    while heap:
        current = heapq.heappop(heap)
        result.append(current[0])
        row = current[1]
        col = current[2] + 1
        
        if col < n:
            heapq.heappush(heap, (a[row][col], row, col))
            
    
    return result