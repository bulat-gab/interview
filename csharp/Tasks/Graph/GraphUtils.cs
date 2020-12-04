namespace Tasks.Graph
{
    public static class GraphUtils
    {
        public static readonly (int i, int j)[] Directions = { (0, 1), (0, -1), (1, 0), (-1, 0) };
        
        public static bool CheckMatrixBoundaries(int[][] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.Length && y >= 0 && y < matrix[0].Length;
        }
        
        public static bool CheckMatrixBoundaries(char[][] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.Length && y >= 0 && y < matrix[0].Length;
        }
    }
}