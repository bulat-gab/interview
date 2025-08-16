from collections import deque
from typing import List

class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        islands_count = 0

        rows = len(grid)
        cols = len(grid[0])

        q = deque()
        # Fill up the queue of islands. Time O(N*M)
        for i in range(rows):
            for j in range(cols):
                if grid[i][j] == 1:
                    q.append((i,j))
        
        directions = [(-1,0), (1,0), (0, -1), (0,1)]
        print("Q: ", q)
        while q:
            i, j = q.popleft()
            print(f"Q: ({i},{j})")
            if grid[i][j] == 2:
                continue
            
            stack = []
            stack.append((i,j))
            while stack:
                i2, j2 = stack.pop()
                grid[i2][j2] = 2

                for di, dj in directions:
                    new_i = di + i2
                    new_j = dj + j2

                    # invalid coordinates
                    if new_i < 0 or new_i >= rows or new_j < 0 or new_j >= cols:
                        continue
                    
                    if grid[new_i][new_j] == 1:
                        stack.append((new_i, new_j))
            
            islands_count += 1


        return islands_count
    

grid = [["1","1","0","0","0"],["1","1","0","0","0"],["0","0","1","0","0"],["0","0","0","1","1"]]
result = Solution().numIslands(grid)
assert result == 3