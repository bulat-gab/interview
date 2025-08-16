from typing import List
from collections import defaultdict

def topKFrequent(nums: List[int], k: int) -> List[int]:
    dict = defaultdict(int)
    for num in nums:
        dict[num] += 1
    
    sorted_x = sorted(dict.items(), key=lambda kv: kv[1], reverse=True)
    
    return [k for (k,v) in sorted_x[:k]]

a = [1,1,1,2,2,3]
k = 2

topKFrequent(a, k)
