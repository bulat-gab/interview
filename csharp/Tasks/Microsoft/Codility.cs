using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Microsoft
{
    public class Codility
    {
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

        readonly HashSet<(int i, int j)> _visited = new HashSet<(int, int)>();
        
        public void FindCheese(IMaze maze)
        {
            var stack = new Stack<(int, int)>();
            // Initial mouse coordinates (X,Y): (0,0)
            stack.Push((0, 0));

            var listOfMoves = new List<Direction>();
            
            while (stack.Count != 0)
            {
                var coord = stack.Pop();

                _visited.Add(coord);
                if (maze.FoundCheese())
                {
                    Console.WriteLine("Success!");
                    return;
                }

                var x = coord.Item1;
                var y = coord.Item2;
                if (!_visited.Contains((x, y + 1)) && maze.TryMoveMouse(Direction.Up))
                {
                    stack.Push((x, y + 1));
                    listOfMoves.Add(Direction.Up);
                }
                else if (!_visited.Contains((x, y - 1)) && maze.TryMoveMouse(Direction.Down))
                {
                    stack.Push((x, y - 1));
                    listOfMoves.Add(Direction.Down);
                }
                else if (!_visited.Contains((x - 1, y)) && maze.TryMoveMouse(Direction.Left))
                {
                    stack.Push((x - 1, y));
                    listOfMoves.Add(Direction.Left);
                }
                else if (!_visited.Contains((x + 1, y)) && maze.TryMoveMouse(Direction.Right))
                {
                    stack.Push((x + 1, y));
                    listOfMoves.Add(Direction.Right);
                }
                else
                {
                    // Undo the last move, so the mouse goes back
                    Direction? lastMove = null;
                    if (listOfMoves.Count > 0)
                    {
                        lastMove = listOfMoves.Last();
                    }

                    switch (lastMove)
                    {
                        case Direction.Up:
                            maze.TryMoveMouse(Direction.Down);
                            break;
                        case Direction.Down:
                            maze.TryMoveMouse(Direction.Up);
                            break;
                        case Direction.Left:
                            maze.TryMoveMouse(Direction.Right);
                            break;
                        case Direction.Right:
                            maze.TryMoveMouse(Direction.Left);
                            break;
                        default:
                            // If there are no moves available from the starting position
                            return;
                    }
                }
            }
        }
    }
}