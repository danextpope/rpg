namespace CommonTests
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FourZoas.RPG.Common;

    using Xunit;

    public class DirectionTests : BaseTests
    {
        public static IEnumerable<object[]> DirectionValues => Enumerable.Range(0, (int)Direction.Last).Select(n => new object[] { (Direction)n, (Directions)(1 << n) });

        public static IEnumerable<object[]> OppositeDirection { get; } = GetDirection();

        public static IEnumerable<object[]> OppositeDirections { get; } = GetDirections();

        [Theory]
        [MemberData(nameof(DirectionValues))]
        public void MappingWorks(object left, object right)
        {
            Assert.Equal((Direction)left, Mapper.Map<Direction>((Directions)right));
            Assert.Equal((Directions)right, Mapper.Map<Directions>((Direction)left));
        }

        [Theory]
        [MemberData(nameof(OppositeDirection))]
        public void OppositeWorks1(Direction expected, Direction real) => Assert.Equal(expected, real.Opposite());

        [Theory]
        [MemberData(nameof(OppositeDirections))]
        public void OppositeWorks2(Directions expected, Directions real) => Assert.Equal(expected, real.Opposite());

        private static IEnumerable<object[]> GetDirection()
        {
            yield return new object[] { Direction.East, Direction.West };
            yield return new object[] { Direction.West, Direction.East };
            yield return new object[] { Direction.North, Direction.South };
            yield return new object[] { Direction.South, Direction.North };
            yield return new object[] { Direction.Up, Direction.Down };
            yield return new object[] { Direction.Down, Direction.Up };
            yield return new object[] { Direction.NorthEast, Direction.SouthWest };
            yield return new object[] { Direction.SouthWest, Direction.NorthEast };
            yield return new object[] { Direction.NorthWest, Direction.SouthEast };
            yield return new object[] { Direction.SouthEast, Direction.NorthWest };
        }

        private static IEnumerable<object[]> GetDirections()
        {
            var values = new[] { false, true };
            foreach (var n in values)
                foreach (var e in values)
                    foreach (var s in values)
                        foreach (var w in values)
                            foreach (var u in values)
                                foreach (var d in values)
                                    foreach (var sw in values)
                                        foreach (var se in values)
                                            foreach (var nw in values)
                                                foreach (var ne in values)
                                                {
                                                    var expected = Directions.None;
                                                    var input = expected;
                                                    if (n)
                                                    {
                                                        expected |= Directions.North;
                                                        input |= Directions.South;
                                                    }
                                                    if (s)
                                                    {
                                                        expected |= Directions.South;
                                                        input |= Directions.North;
                                                    }
                                                    if (e)
                                                    {
                                                        expected |= Directions.East;
                                                        input |= Directions.West;
                                                    }
                                                    if (w)
                                                    {
                                                        expected |= Directions.West;
                                                        input |= Directions.East;
                                                    }
                                                    if (u)
                                                    {
                                                        expected |= Directions.Up;
                                                        input |= Directions.Down;
                                                    }
                                                    if (d)
                                                    {
                                                        expected |= Directions.Down;
                                                        input |= Directions.Up;
                                                    }
                                                    if (ne)
                                                    {
                                                        expected |= Directions.NorthEast;
                                                        input |= Directions.SouthWest;
                                                    }
                                                    if (nw)
                                                    {
                                                        expected |= Directions.NorthWest;
                                                        input |= Directions.SouthEast;
                                                    }
                                                    if (se)
                                                    {
                                                        expected |= Directions.SouthEast;
                                                        input |= Directions.NorthWest;
                                                    }
                                                    if (sw)
                                                    {
                                                        expected |= Directions.SouthWest;
                                                        input |= Directions.NorthEast;
                                                    }

                                                    yield return new object[] { expected, input };
                                                }
        }
    }
}