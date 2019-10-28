from collections import defaultdict

# T = int(input())

def find(N, arr):
    d = defaultdict(int)

    for i in arr:
        d[i] += 1

    max = 0
    max_key = None
    for k, v in d:
        if v > max:
            max = v
            max_key = k
    
    if max > (N / 2):
        return max_key
    else:
        return -1


for i in T:
    N = int(input())
    arr = [int(c) for c in input().split(' ')]

    res = find(N, arr)
    print(res)


arr = [3, 1, 3, 3, 2]
k = find(len(arr), arr)
print(k)