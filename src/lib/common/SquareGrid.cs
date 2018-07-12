namespace FourZoas.RPG.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>A Cartesian, square grid</summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Common.IGrid{T}"/>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
    public class SquareGrid<T> : IGrid<T>, IEnumerable<T>
    {
        private static readonly (int x, int y)[] offsets = new[] { (-1, 0), (0, -1), (1, 0), (0, 1) };
        private readonly T[] data;

        /// <summary>Initializes a new instance of the <see cref="SquareGrid"/> class.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public SquareGrid(int width, int height) : this(0, 0, width, height)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SquareGrid"/> class.</summary>
        /// <param name="left">The left.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public SquareGrid(int left, int bottom, int width, int height)
        {
            Width = width;
            Height = height;
            Left = left;
            Bottom = bottom;
            data = new T[width * height];
        }

        /// <summary>Gets the minimum value allow for the <c>y</c> coordinate.</summary>
        /// <value>The minimum value allow for the <c>y</c> coordinate.</value>
        public int Bottom { get; }

        /// <summary>Gets the height of the grid.</summary>
        /// <value>The height of the grid.</value>
        public int Height { get; }

        /// <summary>Gets the minimum value allow for the <c>x</c> coordinate.</summary>
        /// <value>The minimum value allow for the <c>x</c> coordinate.</value>
        public int Left { get; }

        /// <summary>Gets the maximum value allow for the <c>x</c> coordinate.</summary>
        /// <value>The maximum value allow for the <c>x</c> coordinate.</value>
        public int Right => Left + Width;

        /// <summary>Gets the maximum value allow for the <c>y</c> coordinate.</summary>
        /// <value>The maximum value allow for the <c>y</c> coordinate.</value>
        public int Top => Bottom + Height;

        /// <summary>Gets the width of the grid.</summary>
        /// <value>The width of the grid.</value>
        public int Width { get; }

        /// <summary>Gets or sets the <see cref="T"/> at the specified coordinates</summary>
        /// <value>The <see cref="T"/>.</value>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The value at the specified coordinate</returns>
        public T this[int x, int y]
        {
            get => data[(x - Left) + Width * (y - Bottom)];
            set => data[(x - Left) + Width * (y - Bottom)] = value;
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator() => data.OfType<T>().GetEnumerator();

        /// <summary>Gets the coordinate list of all adjacent cells.</summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The adjacent coordinates.</returns>
        public IEnumerable<(int x, int y)> NeighboringCells(int x, int y)
        {
            foreach (var offset in offsets)
            {
                if (x + offset.x >= Left && x + offset.x < Right && y + offset.y >= Bottom && y + offset.y < Top) yield return (x + offset.x, y + offset.y);
            }
        }

        /// <summary>Gets all values that are adjacent to the specified cell.</summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>All neighboring values.</returns>
        public IEnumerable<T> Neighbors(int x, int y) => NeighboringCells(x, y).Select(p => this[p.x, p.y]);

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate
        /// through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
    }
}