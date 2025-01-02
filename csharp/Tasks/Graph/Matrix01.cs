using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Graph;

/*
 * 
 * Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
 * The distance between two adjacent cells is 1.
 * 
 * */

public class Matrix01
{
    private static Complex Up = Complex.ImaginaryOne;
    private static Complex Down = -Complex.ImaginaryOne;
    private static Complex Right = Complex.One;
    private static Complex Left = -Complex.One;

    private static Complex[] Directions = [Up, Down, Right, Left];


    public int[][] UpdateMatrix(int[][] mat)
    {
        var result = new int[mat.Length][];

        for (int i = 0; i < mat.Length; i++)
        {
            result[i] = new int[mat[i].Length];

            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    result[i][j] = 0;
                    continue;
                }

                var distance = FindDistance(mat, new Complex(i, j));
                result[i][j] = distance;
            }
        }


        return result;
    }

    private int FindDistance(int[][] mat, Complex currentCoord)
    {
        //int minDistance = int.MaxValue;
        var visited = new HashSet<Complex>();

        var q = new Queue<(Complex, int)>();
        q.Enqueue((currentCoord, 0));
        while (q.Count > 0)
        {
            var (coord, distance) = q.Dequeue();

            foreach (var dir in Directions)
            {
                var nextCoord = coord + dir;
                if (!IsValidCoord(mat, nextCoord))
                {
                    continue;
                }

                int i = (int) nextCoord.Real;
                int j = (int) nextCoord.Imaginary;

                if (mat[i][j] == 0)
                {
                    return distance + 1;
                }


                if (!visited.Contains(nextCoord))
                {
                    q.Enqueue((nextCoord, distance + 1));
                }
                visited.Add(nextCoord);
            }
        }

        throw new NotImplementedException("Not found.");
    }

    private static bool IsValidCoord(int[][] mat, Complex coord)
    {
        int N = mat.Length;
        int M = mat[0].Length;

        return coord.Real >= 0 && coord.Real < N 
            && coord.Imaginary >= 0 && coord.Imaginary < M;
    }
}


public class Matrix01SolutionTwo
{
    private static List<(int, int)> directions =
    [
        (-1,0), // Up
        (1, 0), // Down
        (0, -1), // Left
        (0, 1) // Right
    ];

    // Run 2 loops and do the following:
    // a) Initialize result array
    // b) For each cell find distance
    public int[][] UpdateMatrix(int[][] mat)
    {
        int ROWS = mat.Length;
        int COLS = mat[0].Length;

        var queue = new Queue<(int,int)>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                 if (mat[i][j] == 0)
                    queue.Enqueue((i, j));
                 else
                    mat[i][j] = -1;
            }
        }
        

        while (queue.Count > 0)
        {
            var (r,c) = queue.Dequeue();

            foreach(var (dr, dc) in directions)
            {
                var newR = r + dr;
                var newC = c + dc;

                if (newR < 0 || newR >= ROWS || newC < 0 || newC >= COLS || mat[newR][newC] != -1)
                {
                    continue;
                }

                mat[newR][newC] = mat[r][c] + 1;
                queue.Enqueue((newR, newC));
            }

        }

        return mat;
    }
}