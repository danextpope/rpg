namespace FourZoas.RPG.Maze
{
    using FourZoas.RPG.Common;

    /// <summary>
    /// An interface for cells within a maze that includes the exit directions.
    /// </summary>
    /// <typeparam name="T">The type of data stored in this cell.</typeparam>
    public interface IMazeCell<T>
    {
        /// <summary>
        /// Gets or sets the exits fron this cell.
        /// </summary>
        /// <value>
        /// The exits.
        /// </value>
        Directions Exits { get; set; }
    }
}