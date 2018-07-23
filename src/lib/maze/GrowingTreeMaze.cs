namespace FourZoas.RPG.Maze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FourZoas.RPG.Common;

    /// <summary>Basic class to hold some basic decider methods for <see cref="GrowingTreeMaze{T}"/>.</summary>
    public static class GrowingTreeMazeConstants
    {
        /// <summary>Pick the next cell from the five most recent.</summary>
        public static readonly Func<IList<(int x, int y)>, int> Newer = l => LastN(l, 5);

        /// <summary>Always pick the most recently added cell.</summary>
        public static readonly Func<IList<(int x, int y)>, int> Newest = l => l.Count - 1;

        /// <summary>Pick the next cell from the five oldest cells.</summary>
        public static readonly Func<IList<(int x, int y)>, int> Older = l => FirstN(l, 5);

        /// <summary>Always pick the oldest cell.</summary>
        public static readonly Func<IList<(int x, int y)>, int> Oldest = l => 0;

        private static readonly Random rnd = new Random();

        private static int FirstN(IList<(int x, int y)> list, int n)
        {
            if (n > list.Count) n = list.Count;
            if (list.Count == 0) return -1;
            return rnd.Next(n);
        }

        private static int LastN(IList<(int x, int y)> list, int n)
        {
            if (n > list.Count) n = list.Count;
            if (list.Count == 0) return -1;
            return list.Count - 1 - rnd.Next(n);
        }
    }

    public class GrowingTreeMaze<T> : IMaze<T> where T : IMazeCell<T>, new()
    {
        private readonly Func<IList<(int x, int y)>, int> decider;

        public GrowingTreeMaze(Func<IList<(int x, int y)>, int> decider) => this.decider = decider;

        /// <summary>Creates the maze using the specified random number generator.</summary>
        /// <param name="random">The random number generator.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="decider">The function used to pick a next start cell.</param>
        /// <returns>The maze, stored in a <see cref="T:FourZoas.RPG.Common.IGrid`1"/>.</returns>
        /// <remarks>
        /// This is a general algorithm, capable of creating Mazes of different textures. It requires
        /// storage up to the size of the Maze. Each time you carve a cell, add that cell to a list.
        /// Proceed by picking a cell from the list, and carving into an unmade cell next to it. If
        /// there are no unmade cells next to the current cell, remove the current cell from the
        /// list. The Maze is done when the list becomes empty. The interesting part that allows many
        /// possible textures is how you pick a cell from the list. For example, if you always pick
        /// the most recent cell added to it, this algorithm turns into the recursive backtracker. If
        /// you always pick cells at random, this will behave similarly but not exactly to Prim's
        /// algorithm. If you always pick the oldest cells added to the list, this will create Mazes
        /// with about as low a "river" factor as possible, even lower than Prim's algorithm. If you
        /// usually pick the most recent cell, but occasionally pick a random cell, the Maze will
        /// have a high "river" factor but a short direct solution. If you randomly pick among the
        /// most recent cells, the Maze will have a low "river" factor but a long windy solution.
        /// </remarks>
        public IGrid<T> Create(IRandom random, int width, int height) => Create(random, width, height, new SquareGrid<Directions>(width, height));
        public IGrid<T> Create(IRandom random, int width, int height, IGrid<Directions> map)
        {
            if (map.Width != width) throw new ArgumentOutOfRangeException(nameof(width), "Passed in IGrid is a different size than requested.");
            if (map.Height!=height)throw new ArgumentOutOfRangeException(nameof(height), "Passed in IGrid is a different size than requested.");

            random.Reset();

            var completed = new SquareGrid<T>(width, height);
            var list = new List<(int x, int y)>();
            int x, y;

            do
            {
                x = random.Get(width);
                y = random.Get(height);
            } while (map[x, y] != Directions.None);
            var current = (x, y);
            list.Add(current);
            while (list.Count > 0)
            {
                var n = decider(list);
                current = list[n];
                var neighbors = map.NeighboringCells(current.x, current.y).Where(c => map[c] == Directions.None);
                if (!neighbors.Any())
                {
                    list.Remove(current);
                    continue;
                }
                var next = random.RandomItem(neighbors);
                map[current] |= Mapper.Map<Directions>(current.OrthogonalDirection(next));
                map[next] |= Mapper.Map<Directions>(next.OrthogonalDirection(current));
                list.Add(next);
            }

            for (x = 0; x < width; x++)
                for (y = 0; y < height; y++)
                    completed[x, y] = new T { Exits = map[x, y] };

            return completed;
        }
    }
}