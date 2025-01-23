using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Microsoft
{
    /// <summary>
    ///    Help the mouse to find cheese in a maze. You are given an interface IMaze with 2 methods:
    ///     - TryMoveMouse that moves the mouse to a given direction, if possible. 
    ///     - FoundCheese - returns true if the mouse and the cheese are at the same cell
    ///    The mouse is generated in a random location in the maze.
    /// </summary>
    public interface IMaze
    {
        bool TryMoveMouse(Direction direction);
        bool FoundCheese();
    }

    public enum Direction
    {
        Left,
        Right,
        Down,
        Up
    }

    public class Solution
    {
        private readonly Dictionary<Direction, (int dx, int dy)> _directions = new Dictionary<Direction, (int dx, int dy)>
        {
            { Direction.Up, (0, 1) },
            { Direction.Down, (0, -1) },
            { Direction.Left, (-1, 0) },
            { Direction.Right, (1, 0) }
        };

        public void FindCheese(IMaze maze)
        {
            var visited = new HashSet<(int x, int y)>();
            var listOfMoves = new List<Direction>();

            var stack = new Stack<(int x, int y)>();
            // Initial mouse coordinates (X,Y): (0,0)
            stack.Push((0, 0));

            while (stack.Count != 0)
            {
                var currentCoord = stack.Pop();

                visited.Add(currentCoord);
                if (maze.FoundCheese())
                {
                    Console.WriteLine("Success!");
                    return;
                }

                // If no move is possible from this coordinate then mouse should go back to the previous position
                var isMoved = false;
                foreach (var (direction, (dx, dy)) in _directions)
                {
                    var nextX = currentCoord.x + dx;
                    var nextY = currentCoord.y + dy;

                    if (!visited.Contains((nextX, nextY)) && maze.TryMoveMouse(direction))
                    {
                        stack.Push((nextX, nextY));
                        listOfMoves.Add(direction);
                        isMoved = true;
                        visited.Add((nextX, nextY));
                    }
                }

                if (!isMoved && !TryUndoLastMove(maze, listOfMoves))
                {
                    return;
                }
            }
        }

        private static bool TryUndoLastMove(IMaze maze, List<Direction> listOfMoves)
        {
            // Undo the last move, so the mouse goes back
            Direction? lastMove = null;
            if (listOfMoves.Count > 0)
            {
                lastMove = listOfMoves.Last();
            }

            var oppositeDirection = GetOppositeDirectionOrNull(lastMove);
            if (oppositeDirection.HasValue)
            {
                maze.TryMoveMouse(oppositeDirection.Value);
            }
            else
            {
                // If there are no moves available from the starting position
                return false;
            }

            return true;
        }

        private static Direction? GetOppositeDirectionOrNull(Direction? direction)
        {
            return direction switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => null
            };
        }
    }
}