def bin_search(arr, x):
    n = len(arr)
    
    left = 0
    right = n - 1

    while left <= right:
        mid = (left + right) // 2
        if arr[mid] == x:
            return mid
        elif arr[mid] > x:
            right = mid - 1
        else:
            left = mid
        
    return None

if __name__ == "__main__":
    assert 5 == bin_search([1,2,3,4,5,6,7], 6)
    assert 3 == bin_search([1,2,3,4,5,6,7], 4)
    assert 4 == bin_search([1,2,3,4,5,6,7], 5)
    assert 0 == bin_search([1], 1)
    assert None is bin_search([], 1)