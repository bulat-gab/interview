using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Tasks.Graph
{
    public class Main
    {
        public IList<IList<int>> PacificAtlanticRun(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new List<IList<int>>();
            }

            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Length;

            var pacific = new HashSet<(int x, int y)>();
            var atlantic = new HashSet<(int x, int y)>();

            // iterate for rows
            for (int i = 0; i < numberOfRows; i++)
            {
                DFS(pacific, i, 0);
                DFS(atlantic, i, numberOfColumns - 1);
            }

            // iterate for columns
            for (int i = 0; i < numberOfColumns; i++)
            {
                DFS(pacific, 0, i);
                DFS(atlantic, numberOfRows - 1, i);
            }

            return pacific
                .Intersect(atlantic)
                .Select(coordinate => 
                    (IList<int>) new List<int> {coordinate.x, coordinate.y})
                .ToList();

            void DFS(ISet<(int x, int y)> visited, int x, int y)
            {
                visited.Add((x, y));
                foreach (var (dx, dy) in GraphUtils.Directions)
                {
                    var nextX = x + dx;
                    var nextY = y + dy;

                    if (GraphUtils.CheckMatrixBoundaries(matrix, nextX, nextY)
                                   && !visited.Contains((nextX, nextY))
                                   && matrix[x][y] <= matrix[nextX][nextY])
                    {
                        DFS(visited, nextX, nextY);
                    }
                }
            }
        }

        public bool FindWordOnTheGrid(char[][] grid, string word)
        {
            if (grid.Length == 0 || grid[0].Length == 0 || string.IsNullOrEmpty(word))
                return false;
        
            var N = grid.Length;
            var M = grid[0].Length;
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                     if (grid[i][j] == word[0] 
                        && DFS(word.Substring(1), i, j, new HashSet<(int x, int y)>()))
                        return true;

                }
            }
            
            return false;
            
            bool DFS(string word, int x, int y, HashSet<(int x, int y)> visited)
            {
                var N = grid.Length;
                var M = grid[0].Length;
        
                foreach (var (dx, dy) in GraphUtils.Directions)
                {
                    var nextX = x + dx;
                    var nextY = y + dy;

                    if (GraphUtils.CheckMatrixBoundaries(grid, nextX, nextY)
                        && !visited.Contains((nextX, nextY))
                        && grid[nextX][nextY] == word[0])
                    {
                        return word.Length <= 1 
                               || DFS(word.Substring(1), nextX, nextY, visited);
                    }
                }
                return false;
            }
        }

        
    }
}