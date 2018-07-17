namespace FourZoas.RPG.Common
{
    public static class Extensions
    {
        public static Direction Direction(this (int x, int y) a, (int x, int y) b)
        {
            var dx = a.x - b.x;
            var dy = a.y - b.y;
            if (dx >= dy) return Common.Direction.East;
            if (dy >= dx) return Common.Direction.North;
            if (dx <= dy) return Common.Direction.West;
            return Common.Direction.South;
        }
    }
}
