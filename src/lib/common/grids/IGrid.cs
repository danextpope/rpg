namespace FourZoas.RPG.Common
{
    using System.Collections.Generic;

    /// <summary>Interface for a generic grid.</summary>
    /// <typeparam name="T">The type of data stored in the grid</typeparam>
    public interface IGrid<T>
    {
        /// <summary>Gets the minimum value allow for the <c>y</c> coordinate.</summary>
        /// <value>The minimum value allow for the <c>y</c> coordinate.</value>
        int Bottom { get; }

        /// <summary>Gets the height of the grid.</summary>
        /// <value>The height of the grid.</value>
        int Height { get; }

        /// <summary>Gets the minimum value allow for the <c>x</c> coordinate.</summary>
        /// <value>The minimum value allow for the <c>x</c> coordinate.</value>
        int Left { get; }

        /// <summary>Gets the maximum value allow for the <c>x</c> coordinate.</summary>
        /// <value>The maximum value allow for the <c>x</c> coordinate.</value>
        int Right { get; }

        /// <summary>Gets the maximum value allow for the <c>y</c> coordinate.</summary>
        /// <value>The maximum value allow for the <c>y</c> coordinate.</value>
        int Top { get; }

        /// <summary>Gets the width of the grid.</summary>
        /// <value>The width of the grid.</value>
        int Width { get; }

        /// <summary>Gets or sets the <see cref="T"/> with the specified coordinates.</summary>
        /// <value>The <see cref="T"/>.</value>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The value at the specified coordinates.</returns>
        T this[int x, int y] { get; set; }
        T this[(int x, int y) cell] { get; set; }

        /// <summary>
        /// Gets all values that are adjacent to the specified cell.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>All neighboring values.</returns>
        IEnumerable<T> Neighbors(int x, int y);
        /// <summary>
        /// Gets the coordinate list of all adjacent cells.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The adjacent coordinates.</returns>
        IEnumerable<(int x, int y)> NeighboringCells(int x, int y);
    }
}