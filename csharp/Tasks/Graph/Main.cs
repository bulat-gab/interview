using System.Collections.Generic;
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
                    (IList<int>)new List<int> { coordinate.x, coordinate.y })
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

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return new List<int>();

            var N = matrix.Length;
            var M = matrix[0].Length;
            var expectedSize = N * M;

            var result = new List<int>();

            var startMargin = 0;
            var endMargin = 0;

            while (startMargin < N || startMargin < M)
            {
                for (int i = startMargin; i < M - endMargin; i++)
                    result.Add(matrix[startMargin][i]);
                if (result.Count == expectedSize)
                    return result;

                for (int i = 1 + startMargin; i < N - endMargin; i++)
                    result.Add(matrix[i][M - 1 - endMargin]);
                if (result.Count == expectedSize)
                    return result;

                for (int i = M - 2 - endMargin; i >= startMargin; i--)
                    result.Add(matrix[N - 1 - endMargin][i]);
                if (result.Count == expectedSize)
                    return result;

                for (int i = N - 2 - endMargin; i > startMargin; i--)
                    result.Add(matrix[i][startMargin]);
                if (result.Count == expectedSize)
                    return result;

                startMargin++;
                endMargin++;
            }

            return result;



        }

    }
}