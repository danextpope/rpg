namespace FourZoas.RPG.Maze
{
    using System;
    using System.Collections.Generic;
    using FourZoas.RPG.Common;

    /// <summary>A generic maze interface.</summary>
    /// <typeparam name="T">The type of data stored in the maze.</typeparam>
    public interface IMaze<T> where T : IMazeCell<T>
    {
        /// <summary>
        /// Creates the maze using the specified random number generator.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="decider">The function used to pick a next start cell.</param>
        /// <returns>
        /// The maze, stored in a <see cref="IGrid{T}" />.
        /// </returns>
        IGrid<T> Create(IRandom random, int width, int height);
    }
}