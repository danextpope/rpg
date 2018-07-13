namespace CommonTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FourZoas.RPG.Common;

    using Xunit;

    public class GridTests
    {
        public static IEnumerable<object[]> HexNeighbors { get; } = GenerateNeighbors(GenerateHexNeighborsInstance);

        public static IEnumerable<object[]> OutOfRangeValues { get; } = Enumerable.Range(-1, 3).SelectMany(x => Enumerable.Range(-1, 3).Select(y => new object[] { x, y })).Where(o => ((int)o[0]) != 0 || ((int)o[1]) != 0);

        public static IEnumerable<object[]> SizeFails { get; } = GetSizeTests().Where(a => !((bool)a[2])).Select(x => new[] { x[0], x[1], x[3] });

        public static IEnumerable<object[]> SizeTotal { get; } = GetSizeTests().Where(a => ((bool)a[2])).Select(x => new[] { x[0], x[1], x[4] });

        public static IEnumerable<object[]> SquareNeighbors { get; } = GenerateNeighbors(GenerateSquareNeighborsInstance);

        [Theory]
        [MemberData(nameof(HexNeighbors))]
        public void HexNeighborsWork(int x, int y, (int x, int y)[] expected)
        {
            var grid = new HexGrid<int>(4, 4);
            Assert.Equal(expected.OrderBy(a => a.x).ThenBy(a => a.y), grid.NeighboringCells(x, y).OrderBy(a => a.x).ThenBy(a => a.y));
        }

        [Theory]
        [MemberData(nameof(SizeTotal))]
        public void HexSizeMatches(int x, int y, int total) => Assert.Equal(total, new HexGrid<int>(x, y).Count());

        [Theory]
        [MemberData(nameof(OutOfRangeValues))]
        public void InvalidCoordinatesFailsGet(int x, int y)
        {
            var grid = new SquareGrid<int>(1, 1);
            Assert.Throws<IndexOutOfRangeException>(() => grid[x, y]);
        }

        [Theory]
        [MemberData(nameof(OutOfRangeValues))]
        public void InvalidCoordinatesFailsSet(int x, int y)
        {
            var grid = new SquareGrid<int>(1, 1);
            Assert.Throws<IndexOutOfRangeException>(() => grid[x, y] = 1);
        }

        [Theory]
        [MemberData(nameof(SizeFails))]
        public void NegativeSizeHexFails(int x, int y, string member) => Assert.Throws<ArgumentOutOfRangeException>(member, () => new HexGrid<int>(x, y));

        [Theory]
        [MemberData(nameof(SizeFails))]
        public void NegativeSizeSquareFails(int x, int y, string member) => Assert.Throws<ArgumentOutOfRangeException>(member, () => new SquareGrid<int>(x, y));

        [Theory]
        [MemberData(nameof(SquareNeighbors))]
        public void SquareNeighborsWork(int x, int y, (int x, int y)[] expected)
        {
            var grid = new SquareGrid<int>(4, 4);
            Assert.Equal(expected.OrderBy(a => a.x).ThenBy(a => a.y), grid.NeighboringCells(x, y).OrderBy(a => a.x).ThenBy(a => a.y));
        }

        [Theory]
        [MemberData(nameof(SizeTotal))]
        public void SquareSizeMatches(int x, int y, int total) => Assert.Equal(total, new SquareGrid<int>(x, y).Count());

        [Fact]
        public void ZeroSizeHexWorks()
        {
            var grid = new HexGrid<int>(0, 0);
            Assert.Empty(grid);
        }

        [Fact]
        public void ZeroSizeSquareWorks()
        {
            var grid = new SquareGrid<int>(0, 0);
            Assert.Empty(grid);
        }

        private static object[] GenerateHexNeighborsInstance(int x, int y)
        {
            var locs = new List<(int x, int y)>();
            if (x > 0)
            {
                locs.Add((x - 1, y));
                if (y < 3) locs.Add((x - 1, y + 1));
            }
            if (y > 0)
            {
                locs.Add((x, y - 1));
                if (x < 3) locs.Add((x + 1, y - 1));
            }
            if (x < 3) locs.Add((x + 1, y));
            if (y < 3) locs.Add((x, y + 1));
            return new object[] { x, y, locs.ToArray() };
        }

        private static IEnumerable<object[]> GenerateNeighbors(Func<int, int, object[]> func)
        {
            for (var x = 0; x <= 3; x++)
                for (var y = 0; y <= 3; y++)
                    yield return func(x, y);
        }

        private static object[] GenerateSquareNeighborsInstance(int x, int y)
        {
            var locs = new List<(int x, int y)>();
            if (x > 0) locs.Add((x - 1, y));
            if (y > 0) locs.Add((x, y - 1));
            if (x < 3) locs.Add((x + 1, y));
            if (y < 3) locs.Add((x, y + 1));
            return new object[] { x, y, locs.ToArray() };
        }

        private static IEnumerable<object[]> GetSizeTests()
        {
            var rnd = new Random(1);
            for (var i = 0; i < 20; i++)
            {
                var x = rnd.Next(21) - 10;
                var y = rnd.Next(21) - 10;
                yield return new object[] { x, y, x >= 0 && y >= 0, x < 0 ? "width" : y < 0 ? "height" : null, x * y };
            }
        }
    }
}