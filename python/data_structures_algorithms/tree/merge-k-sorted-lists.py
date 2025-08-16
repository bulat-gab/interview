# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None
import heapq 

class Solution:
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        if not lists:
            return None
        
        k = len(lists)
        if k == 1:
            return lists[0]
        
        # create a heap from first entries of each of K lists
        heap = []
        for ll in lists:
            heapq.heappush(heap, (ll.val, ll.next))
        
        headNode = ListNode(heap[0].val)
        currentNode = headNode
        while len(heap) > 0:
            # pick the smallest element from the heap and append it to resulting list
            smallest = heapq.heappop(heap)
            current.next = smallest

            # add the smallest element's next to the heap
            if smallest.next is not None:
                heapq.heappush(heap, (smallest.next.val, smallest.next.next))
    
        return headNode