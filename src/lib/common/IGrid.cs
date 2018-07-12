namespace FourZoas.RPG.Common
{
    using System.Collections.Generic;

    public interface IGrid<T>
    {
        int Height { get; }

        int Width { get; }

        T this[int x, int y] { get; set; }

        IEnumerable<T> Neighbors(int x, int y);
    }
}