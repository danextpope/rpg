namespace FourZoas.RPG.Maze
{
    using FourZoas.RPG.Common;

    /// <summary>A maze cell implementation that stores no additional date beyond exits.</summary>
    /// <seealso cref="FourZoas.RPG.Maze.IMazeCell{EmptyCell}"/>
    public class EmptyCell : IMazeCell<EmptyCell>
    {
        /// <summary>Gets or sets the exits fron this cell.</summary>
        /// <value>The exits.</value>
        public Directions Exits { get; set; }
    }
}