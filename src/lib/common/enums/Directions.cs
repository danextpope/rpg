namespace FourZoas.RPG.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum Direction : byte
    {
        North,
        /// <summary>
        /// Northeast, used in hax grids.
        /// </summary>
        NorthEast, East,
        /// <summary>
        /// Southeast, used in hex grids.
        /// </summary>
        SouthEast, Up,
        South,
        /// <summary>
        /// Southwest, used in hex grids.
        /// </summary>
        SouthWest, West,
        /// <summary>
        /// NorthWest, used in hex grids
        /// </summary>
        NorthWest, Down,
        Last
    }

    [Flags]
    public enum Directions : ushort
    {
        None = 0,
        North = 1 << ((int)Direction.North),
        NorthEast = 1 << ((int)Direction.NorthEast),
        East = 1 << ((int)Direction.East),
        SouthEast = 1 << ((int)Direction.SouthEast),
        Up = 1 << ((int)Direction.Up),
        South = 1 << ((int)Direction.South),
        SouthWest = 1 << ((int)Direction.SouthWest),
        West = 1 << ((int)Direction.West),
        NorthWest = 1 << ((int)Direction.NorthWest),
        Down = 1 << ((int)Direction.Down),
        All = North | East | South | West | Up | Down | NorthEast | NorthWest | SouthEast | SouthWest
    }

    public static class DirectionExtensions
    {
        public static Directions Opposite(this Directions directions) => (Directions)((((ushort)directions) << 5) & (ushort)Directions.All) | (Directions)(((ushort)(directions & (Directions.South | Directions.West | Directions.Down | Directions.SouthWest | Directions.NorthWest))) >> 5);
        public static Direction Opposite(this Direction direction) => (Direction)(((byte)direction + ((byte)Direction.Last) / 2) % (byte)Direction.Last);
    }
}
