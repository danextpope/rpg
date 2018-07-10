namespace FourZoas.RPG.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum Direction : byte
    {
        North, East, Up,
        South, West, Down,
        Last
    }

    [Flags]
    public enum Directions : ushort
    {
        North = 1 << ((int)Direction.North),
        East = 1 << ((int)Direction.East),
        Up = 1 << ((int)Direction.Up),
        South = 1 << ((int)Direction.South),
        West = 1 << ((int)Direction.West),
        Down = 1 << ((int)Direction.Down),
        All = North | East | South | West | Up | Down
    }

    public static class DirectionExtensions
    {
        public static Directions Opposite(this Directions directions) => (Directions)((((ushort)directions) << 3) & (ushort)Directions.All) | (Directions)(((ushort)(directions & (Directions.South | Directions.West | Directions.Down))) >> 3);
        public static Direction Opposite(this Direction direction) => (Direction)(((byte)direction + ((byte)Direction.Last) / 2) % (byte)Direction.Last);
    }
}
