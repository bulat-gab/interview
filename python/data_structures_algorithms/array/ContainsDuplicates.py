from typing import List

def containsDuplicate(nums: List[int]) -> bool:
    dict = {}
        
    for i in nums:
        if dict[i]:
            return True
        else:
            dict[i] = 0
            
    return False


if __name__ == "__main__":
    arr = [1, 2, 3, 1]

    print(containsDuplicate(arr))