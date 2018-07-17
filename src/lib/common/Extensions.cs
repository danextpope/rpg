namespace FourZoas.RPG.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Given two orthogonally adjacent points, returns the direction to travel to get from the first to the second.
        /// </summary>
        /// <param name="first">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <returns>The direction to travel.</returns>
        public static Direction OrthogonalDirection(this (int x, int y) first, (int x, int y) b)
        {
            var dx = first.x - b.x;
            var dy = first.y - b.y;
            if (dx >= dy) return Direction.East;
            if (dy >= dx) return Direction.North;
            if (dx <= dy) return Direction.West;
            return Direction.South;
        }
    }
}