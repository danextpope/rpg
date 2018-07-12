namespace FourZoas.RPG.Common
{
    using System.Collections.Generic;

    /// <summary>An offset hex grid forming a parallelogram.</summary>
    /// <typeparam name="T"></typeparam>
    public class HexGrid<T> : SquareGrid<T>, IGrid<T>, IEnumerable<T>
    {
        private static readonly (int, int)[] defaultOffsets = new[] { (0, 1), (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1) };

        /// <summary>Initializes a new instance of the <see cref="SquareGrid"/> class.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public HexGrid(int width, int height) : this(0, 0, width, height)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SquareGrid"/> class.</summary>
        /// <param name="left">The left.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public HexGrid(int left, int bottom, int width, int height) : base(left, bottom, width, height, defaultOffsets) { }
    }
}