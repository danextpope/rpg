namespace FourZoas.RPG.Maze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FourZoas.RPG.Common;

    public static class MazeExtensions
    {
        public static string StringRepresentation<T>(this IGrid<T> maze) where T : IMazeCell<T>
        {
            var sb = new StringBuilder();
            for (var yp = maze.Top - 1; yp >= maze.Bottom; yp--)
            {
                sb.Append(GetFirstLine(maze, yp));
                sb.Append(GetSecondLine(maze, yp));
            }
            sb.Append(GetLastLine(maze));
            return sb.ToString();
        }

        private static string GetFirstLine<T>(IGrid<T> maze, int yp) where T : IMazeCell<T>
        {
            var top = yp == maze.Top - 1;
            var sb = new StringBuilder();
            if (top)
            {
                for (var xp = maze.Left; xp < maze.Right; xp++)
                {
                    if (xp == maze.Left) sb.Append("┌──");
                    else if (maze[xp, yp].Exits.HasFlag(Directions.West)) sb.Append("───");
                    else sb.Append("┬──");
                }
                sb.AppendLine("┐");
            }
            else
            {
                for (var xp = maze.Left; xp < maze.Right; xp++)
                {
                    if (xp == maze.Left)
                    {
                        if (maze[xp, yp].Exits.HasFlag(Directions.North)) sb.Append("│  ");
                        else sb.Append("├──");
                    }
                    else
                    {
                        if (maze[xp, yp].Exits.HasFlag(Directions.West))
                        {
                            if (maze[xp, yp].Exits.HasFlag(Directions.North))
                            {
                                if (maze[xp, yp+1].Exits.HasFlag(Directions.West))
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("   ");
                                    else sb.Append("╴  ");
                                }
                                else
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("╵  ");
                                    else sb.Append("┘  ");
                                }
                            }
                            else
                            {
                                if (maze[xp, yp+1].Exits.HasFlag(Directions.West))
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("╶──");
                                    else sb.Append("───");
                                }
                                else
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("└──");
                                    else sb.Append("┴──");
                                }
                            }
                        }
                        else
                        {
                            if (maze[xp, yp].Exits.HasFlag(Directions.North))
                            {
                                if (maze[xp, yp+1].Exits.HasFlag(Directions.West))
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("╷  ");
                                    else sb.Append("┐  ");
                                }
                                else
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("│  ");
                                    else sb.Append("┤  ");
                                }
                            }
                            else
                            {
                                if (maze[xp, yp+1].Exits.HasFlag(Directions.West))
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("┌──");
                                    else sb.Append("┬──");
                                }
                                else
                                {
                                    if (maze[xp - 1, yp].Exits.HasFlag(Directions.North)) sb.Append("├──");
                                    else sb.Append("┼──");
                                }
                            }
                        }
                    }
                }
                if (maze[maze.Right - 1, yp].Exits.HasFlag(Directions.North)) sb.AppendLine("│");
                else sb.AppendLine("┤");
            }
            return sb.ToString();
        }
        private static string GetSecondLine<T>(IGrid<T> maze, int yp) where T : IMazeCell<T> => Enumerable.Range(maze.Left, maze.Width).Select(xp => maze[xp, yp].Exits.HasFlag(Directions.West) ? "   " : "│  ").Concat(new[] { "│","\n" }).Aggregate((a, x) => a + x);
        private static string GetLastLine<T>(IGrid<T> maze) where T : IMazeCell<T>
        {
            var lc = "└──";
            var cw = "┴──";
            var cc = "───";
            var rc = "┘";
            var sb = new StringBuilder();
            for (var xp = maze.Left; xp < maze.Right; xp++)
            {
                if (xp == maze.Left) sb.Append(lc);
                else if (maze[xp, maze.Bottom].Exits.HasFlag(Directions.West)) sb.Append(cc);
                else sb.Append(cw);
            }
            sb.Append(rc);

            return sb.ToString();
        }
    }
}
