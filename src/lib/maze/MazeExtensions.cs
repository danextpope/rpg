namespace FourZoas.RPG.Maze
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FourZoas.RPG.Common;

    public static class MazeExtensions
    {
        public static string StringRepresentation<T>(this IGrid<T> maze) where T : IMazeCell<T>
        {
            var sb = new StringBuilder();
            for (var y = 0; y < maze.Height; y++)
            {
                var yp = maze.Top - y - 1;
                for (var x = 0; x < maze.Width; x++)
                {
                    var xp = maze.Left + x;
                    sb.Append('+');
                    if (maze[xp, yp].Exits.HasFlag(Directions.North)) sb.Append(' ');
                    else sb.Append('-');
                }
                sb.AppendLine("+");

                for (var x = 0; x < maze.Width; x++)
                {
                    var xp = maze.Left + x;
                    if (maze[xp, yp].Exits.HasFlag(Directions.West)) sb.Append(' ');
                    else sb.Append('|');
                    sb.Append(' ');
                }
                if (maze[maze.Right - 1, yp].Exits.HasFlag(Directions.East)) sb.AppendLine(" ");
                else sb.AppendLine("|");
            }

            for (var x = 0; x < maze.Width; x++)
            {
                var xp = maze.Left + x;
                sb.Append('+');
                if (maze[xp, maze.Bottom].Exits.HasFlag(Directions.South)) sb.Append(' ');
                else sb.Append('-');
            }
            sb.Append('+');

            return sb.ToString();
        }
    }
}
